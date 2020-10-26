Imports System.Threading.Tasks
Imports System.Threading

Public Class LocationFileEncryptionProcess


    Private Const UPDATE_INTERVAL As Integer = 50


    Private WithEvents m_bgwrkEncryptDecrypt As New System.ComponentModel.BackgroundWorker()
    Private m_intProgressBarMax As Integer = 100
    Private m_intProgressBarCurrent As Integer = 0
    Private m_strStatus As String = String.Empty
    Private m_strProcessName As String
    Private m_intStatusSnipPoint As Integer
    Private m_boolComplete As Boolean
    Private m_stopwatch As New Stopwatch()
    Private m_intMillisecondsPerMessage As Integer
    Private m_dtProcessStarted As Date = Date.Now
    Private m_boolRollingback As Boolean '-- cannot cancel during rollback
    Private m_cancelToken As CancellationTokenSource

    Public ReadOnly Property ProcessComplete As Boolean
        Get
            Return m_boolComplete
        End Get
    End Property
    Private m_strNewPassword As String
    Private m_ht As Hashtable
    Public Sub NotifyUserOnComplete(newMasterPassword As String, ht As Hashtable)
        m_strNewPassword = newMasterPassword
        m_ht = ht
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Select Case AppSettings.EncryptLocalFiles
            Case LocalFileEncryptionStatus.Decrypting
                If ShowMessageBox("Are you sure you want to stop the decryption process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                End If
            Case LocalFileEncryptionStatus.Encrypting
                If ShowMessageBox("Are you sure you want to stop the encryption process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                End If
            Case Else
                '-- done, so close
                Close()
        End Select
    End Sub

    Private Delegate Sub UpdateDisplayControlsDelegate(includeTimeEstimates As Boolean)
    Private Sub UpdateDisplayControls(includeTimeEstimates As Boolean)
        If InvokeRequired Then
            Dim deleg As New UpdateDisplayControlsDelegate(AddressOf UpdateDisplayControls)
            Me.Invoke(deleg, includeTimeEstimates)
        Else
            txtStatus.Text = m_strStatus
            Me.ProgressBar1.Maximum = m_intProgressBarMax
            If m_intProgressBarMax < 1000 Then
                Me.ProgressBar1.HighTextDecimalPlaces = 0
                Me.ProgressBar1.LowTextDecimalPlaces = 0
            ElseIf m_intProgressBarMax < 10000 Then
                Me.ProgressBar1.HighTextDecimalPlaces = 1
                Me.ProgressBar1.LowTextDecimalPlaces = 1
            ElseIf m_intProgressBarMax < 100000 Then
                Me.ProgressBar1.HighTextDecimalPlaces = 2
                Me.ProgressBar1.LowTextDecimalPlaces = 2
            Else
                '-- more than 100,000 files
                Me.ProgressBar1.HighTextDecimalPlaces = 3
                Me.ProgressBar1.LowTextDecimalPlaces = 3
            End If
            Me.ProgressBar1.Value = m_intProgressBarCurrent

            If includeTimeEstimates Then
                '-- update the time estimates
                Dim intSecondsRemaining As Integer = (m_intMillisecondsPerMessage * (m_intProgressBarMax - m_intProgressBarCurrent)) / 1000
                Dim ts As New TimeSpan(0, 0, intSecondsRemaining)
                lblRemainingTime.Text = FormatTimeSpan2Compact(ts)

                ts = Date.Now - m_dtProcessStarted
                lblElapsedTime.Text = FormatTimeSpan2Compact(ts)
            End If

            Application.DoEvents()
        End If
    End Sub
    Private Sub AddStatus(status As String, removePreviousLine As Boolean, supportRemoving As Boolean)
        If removePreviousLine Then
            m_strStatus = m_strStatus.Substring(0, m_intStatusSnipPoint)
        End If
        If supportRemoving Then
            m_intStatusSnipPoint = m_strStatus.Length
        End If
        m_strStatus &= Date.Now.ToString("dd-MMM-yyyy HH:mm:ss") & ": " & status & Environment.NewLine
        If Not supportRemoving Then
            m_intStatusSnipPoint = m_strStatus.Length
        End If

        UpdateDisplayControls(False)
    End Sub

    Private Sub m_bgwrkEncryptDecrypt_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles m_bgwrkEncryptDecrypt.DoWork
        m_boolComplete = False

        Log("Starting " & m_strProcessName & " process.")

        AddStatus("Please do not close this form or TrulyMail until this process is complete.", False, False)

        AddStatus("Searching for messages to " & m_strProcessName & ".", False, False)

        '-- Find all the messages
        Dim files() As String = System.IO.Directory.GetFiles(MessageStoreRootPath, "*.tmm", IO.SearchOption.AllDirectories)

        AddStatus("Found " & files.Length.ToString("#,##0") & " messages to process.", False, False)

        '-- walk through the msgs and encrypt/decrypt each message
        m_intProgressBarCurrent = 0
        m_intProgressBarMax = files.Length


        Try
            ProcessLocalFiles(files)

        Catch ex As OperationCanceledException
            m_boolRollingback = True '-- cannot cancel rollback
            Log("Rolling back " & m_strProcessName & " process.")
        Catch ex As Exception
            Log(ex)
            Application.DoEvents()
        End Try

        If m_boolRollingback Then
            '-- user cancelled so now we need to rollback the encryption
            Dim intMessagesToRollback = m_intProgressBarCurrent + (2 * UPDATE_INTERVAL)
            ReDim Preserve files(intMessagesToRollback - 1) '-- this should truncate the array quite quickly

            AddStatus("Processed " & intMessagesToRollback.ToString("#,##0") & " of " & m_intProgressBarMax.ToString("#,##0") & " messages.", True, False)

            AddStatus("Beginning rollback. You may not cancel this process.", False, False)

            '-- Take the original list, we are going to just process the first n plus a buffer of (2 * UPDATE_INTERVAL )

            m_intProgressBarCurrent = 0
            m_intProgressBarMax = files.Length

            '-- flip from encrypting / decrypting for rollback
            If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting Then
                AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypting
            ElseIf AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypting Then
                AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting
            End If

            Try
                ProcessLocalFiles(files)

                UpdateDisplayControls(True)

            Catch ex As Exception
                Log("Error during rollback.")
                Log(ex)
            End Try
            Application.DoEvents()
            AddStatus("Rolled back all " & m_intProgressBarCurrent.ToString("#,##0") & " of " & m_intProgressBarMax.ToString("#,##0") & " messages.", True, False)
            AddStatus("Finished rollback.", False, False)
        Else
            AddStatus("Processed all " & m_intProgressBarCurrent.ToString("#,##0") & " of " & m_intProgressBarMax.ToString("#,##0") & " messages.", True, False)
        End If

        Log("Finished " & m_strProcessName & " process.")


    End Sub

    Private Sub ProcessLocalFiles(files() As String)

        Dim lockProgress As New Object()
        Dim lockTimePerMessage As New Object()

        '-- Setup to support cancelation
        Dim options As New ParallelOptions()
        m_cancelToken = New CancellationTokenSource
        options.CancellationToken = m_cancelToken.Token

        '-- This next line slows it down for debugging by limiting to 1 thread max:  
        'options.MaxDegreeOfParallelism = 1

        System.Threading.Tasks.Parallel.ForEach(files, options, Sub(filename As String)
                                                                    '- Simple load and save the file to encrypt or decrypt it
                                                                    TrulyMailMessage.QuickConvert(filename) '-- This call knows if we are encrypting or decrypting, we don't need to know here
                                                                    SyncLock lockProgress
                                                                        m_intProgressBarCurrent += 1
                                                                    End SyncLock

                                                                    If (m_intProgressBarCurrent Mod UPDATE_INTERVAL) = 0 Then
                                                                        SyncLock lockTimePerMessage
                                                                            m_intMillisecondsPerMessage = m_stopwatch.ElapsedMilliseconds / UPDATE_INTERVAL
                                                                        End SyncLock

                                                                        AddStatus("Processed " & m_intProgressBarCurrent.ToString("#,##0") & " of " & m_intProgressBarMax.ToString("#,##0") & " messages.", True, True)
                                                                        m_stopwatch.Reset()
                                                                        m_stopwatch.Start()

                                                                        UpdateDisplayControls(True)
                                                                    Else
                                                                        UpdateDisplayControls(False)
                                                                    End If

                                                                    options.CancellationToken.ThrowIfCancellationRequested()
                                                                End Sub)


    End Sub
    Private Sub m_bgwrkEncryptDecrypt_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles m_bgwrkEncryptDecrypt.RunWorkerCompleted
        m_boolComplete = True
        AddStatus("Process complete.", True, False)
        Select Case AppSettings.EncryptLocalFiles
            Case LocalFileEncryptionStatus.Encrypting
                AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted
            Case LocalFileEncryptionStatus.Decrypting
                AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted
        End Select

        If m_ht IsNot Nothing Then '-- If m_ht is nothing then we just drop out, otherwise we must call the finalize method in Globals
            'If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted Then
            '    ShowMessageBox("Your Startup Password has been set and local files have been encrypted.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            'ElseIf AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted Then
            '    If AppSettings.EncryptSettingsFile Then
            '        '-- must have started encrypting then cancelled/rollback
            '        ShowMessageBox("Your Startup Password has been set but local files were not encrypted because the process was cancelled.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '    Else
            '        ShowMessageBox("Your Startup Password has been removed and local files have been decrypted.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '    End If
            'End If
            Globals.ApplyMasterPasswordFinalize(m_strNewPassword, m_ht)
        End If

        Close()
    End Sub

    Private Sub LocationFileEncryptionProcess_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not m_boolComplete Then
            If m_boolRollingback Then
                '-- cannot cancel during rollback
                ShowMessageBoxError("You must wait until the process is 100% complete.")
            Else
                If ShowMessageBox("Do you want to cancel the process? If you choose yes, you must allow TrulyMail time to rollback the changes.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.Yes Then
                    m_cancelToken.Cancel()
                End If
            End If

            e.Cancel = True
        End If
    End Sub

    Private Sub LocationFileEncryptionProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case AppSettings.EncryptLocalFiles
            Case LocalFileEncryptionStatus.Decrypting
                Text = "Local file decryption process"
                m_strProcessName = "decrypt"
            Case LocalFileEncryptionStatus.Encrypting
                Text = "Local file encryption process"
                m_strProcessName = "encrypt"
        End Select
    End Sub

    Private Sub LocationFileEncryptionProcess_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        m_bgwrkEncryptDecrypt.RunWorkerAsync()
    End Sub


End Class