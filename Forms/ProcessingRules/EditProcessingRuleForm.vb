Friend Class EditProcessingRuleForm

    Private m_newProcessingRule As ProcessingRule
    Private m_oldProcessingRule As ProcessingRule

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        '-- this tells us later (ok_click) to simply add this rule, not modify an existing rule
        m_oldProcessingRule = Nothing

        '-- load up new rule with defaults
        m_newProcessingRule = New ProcessingRule()
        m_newProcessingRule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd
        m_newProcessingRule.Name = String.Empty
        m_newProcessingRule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage

        m_newProcessingRule.MatchDatas.Add(CreateNewMatchData())

        Dim action As New ProcessingRuleActionData
        action.ActionType = ProcessingRuleActionTypeEnum.MoveMessageTo
        action.ActionValue = InBoxRootPath
        m_newProcessingRule.Actions.Add(action)

    End Sub
    Public Sub New(ByVal rule As ProcessingRule)

        ' This call is required by the designer.
        InitializeComponent()

        '-- this tells us later (ok_click) to modify this existing rule
        m_oldProcessingRule = rule

        '-- duplicate existing rule (to allow cancel to not modify existing rule)
        m_newProcessingRule = New ProcessingRule()
        CopyRuleProperties(m_oldProcessingRule, m_newProcessingRule)

    End Sub
    Private Sub CopyRuleProperties(ByVal sourceRule As ProcessingRule, ByVal destinationRule As ProcessingRule)
        destinationRule.MatchType = sourceRule.MatchType
        destinationRule.Name = sourceRule.Name
        destinationRule.TriggerType = sourceRule.TriggerType

        '-- clear existing matchdatas
        destinationRule.MatchDatas.Clear()

        Dim matchdata As ProcessingRuleMatchData
        For Each match As ProcessingRuleMatchData In sourceRule.MatchDatas
            matchdata = New ProcessingRuleMatchData()
            matchdata.MatchField = match.MatchField
            matchdata.CompareType = match.CompareType
            matchdata.CompareValue = match.CompareValue

            destinationRule.MatchDatas.Add(matchdata)
        Next

        destinationRule.Actions.Clear()
        Dim actiondata As ProcessingRuleActionData
        For Each action As ProcessingRuleActionData In sourceRule.Actions
            actiondata = New ProcessingRuleActionData()
            actiondata.ActionType = action.ActionType
            actiondata.ActionValue = action.ActionValue

            destinationRule.Actions.Add(actiondata)
        Next
    End Sub
    Private Function CreateNewActionData() As ProcessingRuleActionData
        Dim action As New ProcessingRuleActionData
        action.ActionType = ProcessingRuleActionTypeEnum.MoveMessageTo
        action.ActionValue = InBoxRootPath

        Return action
    End Function
    Private Function CreateNewMatchData() As ProcessingRuleMatchData
        Dim matchdata As New ProcessingRuleMatchData
        matchdata.MatchField = ProcessingRuleMatchFieldEnum.FieldSubject
        matchdata.CompareType = ProcessingRuleMatchDataCompareTypeEnum.Contains
        matchdata.CompareValue = String.Empty

        Return matchdata
    End Function

    Private Sub EditProcessingRuleForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddMatchColumn.AspectGetter = New BrightIdeasSoftware.AspectGetterDelegate(AddressOf AddDeleteAspectGetter)
        AddMatchColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf AddImageGetter)
        AddMatchColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf AddDeleteAspectToStringConverter)
        DeleteMatchColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf AddDeleteAspectToStringConverter)
        DeleteMatchColumn.AspectGetter = New BrightIdeasSoftware.AspectGetterDelegate(AddressOf AddDeleteAspectGetter)
        DeleteMatchColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf RemoveImageGetter)
        CompareValueColumn.Renderer = New ProcessingRuleCompareValueRenderer()

        AddActionColumn.AspectGetter = New BrightIdeasSoftware.AspectGetterDelegate(AddressOf AddDeleteAspectGetter)
        AddActionColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf AddImageGetter)
        AddActionColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf AddDeleteAspectToStringConverter)
        DeleteActionColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf AddDeleteAspectToStringConverter)
        DeleteActionColumn.AspectGetter = New BrightIdeasSoftware.AspectGetterDelegate(AddressOf AddDeleteAspectGetter)
        DeleteActionColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf RemoveImageGetter)
        ActionValueColumn.Renderer = New FolderPathRenderer()

        '-- populate form with rule
        txtRuleName.Text = m_newProcessingRule.Name
        Select Case m_newProcessingRule.MatchType
            Case ProcessingRuleMatchTypeEnum.MatchAnd
                rbtnMatchAnd.Checked = True
            Case ProcessingRuleMatchTypeEnum.MatchOr
                rbtnMatchOr.Checked = True
            Case ProcessingRuleMatchTypeEnum.MatchAll
                rbtnMatchAll.Checked = True
        End Select

        olvMatching.SetObjects(m_newProcessingRule.MatchDatas)

        olvActions.SetObjects(m_newProcessingRule.Actions)

        cboProcessRuleRunTime.SelectedIndex = ConvertToInt32(m_newProcessingRule.TriggerType, 0)

    End Sub

    Private Sub olvMatching_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvMatching.CellEditFinishing
        Dim rowobj As ProcessingRuleMatchData = CType(e.RowObject, ProcessingRuleMatchData)
        Select Case e.Column.AspectName
            Case MatchFieldColumn.AspectName
                rowobj.MatchFieldText = e.Control.Text
                rowobj.CompareType = GetValidProcessingRuleMatchDataCompareTypesForField(rowobj.MatchField)(0)
                rowobj.CompareValue = String.Empty
            Case CompareTypeColumn.AspectName
                rowobj.CompareTypeText = e.Control.Text
                rowobj.CompareValue = String.Empty
            Case CompareValueColumn.AspectName
                Select Case rowobj.EditorType
                    Case ProcessingRuleEditorTypeEnum.None
                        e.Cancel = True
                    Case ProcessingRuleEditorTypeEnum.TextBox
                        rowobj.CompareValue = e.Control.Text
                    Case ProcessingRuleEditorTypeEnum.TrulyMailContactSelector
                        Dim cbo As ComboBox = CType(e.Control, ComboBox)
                        Dim contact As AddressBookEntry = CType(cbo.SelectedItem, AddressBookEntry)
                        rowobj.CompareValue = contact.ID
                    Case ProcessingRuleEditorTypeEnum.EmailContactSelector
                        Dim cbo As ComboBox = CType(e.Control, ComboBox)
                        Dim contact As AddressBookEntry = CType(cbo.SelectedItem, AddressBookEntry)
                        rowobj.CompareValue = contact.Address
                    Case ProcessingRuleEditorTypeEnum.SMTPAccountSelector
                        Dim cbo As ComboBox = CType(e.Control, ComboBox)
                        Dim smtp As SMTPProfile = CType(cbo.SelectedItem, SMTPProfile)
                        rowobj.CompareValue = smtp.ID
                End Select
        End Select
    End Sub

    Private Sub olvMatching_CellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvMatching.CellEditStarting
        Dim rowobj As ProcessingRuleMatchData = CType(e.RowObject, ProcessingRuleMatchData)
        Select Case e.Column.AspectName
            Case MatchFieldColumn.AspectName
                Dim intIndex As Integer
                Dim cbo As New ComboBox()
                For Each item As Integer In [Enum].GetValues(GetType(ProcessingRuleMatchFieldEnum))
                    Dim s As String = GetProcessingRuleMatchFieldText(item)
                    If s = rowobj.MatchFieldText Then
                        intIndex = cbo.Items.Count()
                    End If
                    cbo.Items.Add(s)
                Next
                cbo.DropDownStyle = ComboBoxStyle.DropDownList
                cbo.SelectedIndex = intIndex
                cbo.Bounds = e.CellBounds
                e.Control = cbo
            Case CompareTypeColumn.AspectName
                Dim intIndex As Integer
                Dim cbo As New ComboBox()
                Dim lst As List(Of ProcessingRuleMatchDataCompareTypeEnum) = GetValidProcessingRuleMatchDataCompareTypesForField(rowobj.MatchField)
                For Each item As ProcessingRuleMatchDataCompareTypeEnum In lst
                    Dim s As String = GetProcessingRuleMatchDataCompareTypeText(item)
                    If s = e.Value Then
                        intIndex = cbo.Items.Count()
                    End If
                    cbo.Items.Add(s)
                Next
                cbo.DropDownStyle = ComboBoxStyle.DropDownList
                cbo.SelectedIndex = intIndex
                cbo.Bounds = e.CellBounds
                e.Control = cbo
            Case CompareValueColumn.AspectName
                Select Case rowobj.EditorType
                    Case ProcessingRuleEditorTypeEnum.None
                        e.Cancel = True
                    Case ProcessingRuleEditorTypeEnum.TextBox
                        '-- do nothing
                        'Case ProcessingRuleEditorTypeEnum.TrulyMailContactSelector
                        '    Dim intIndex As Integer
                        '    Dim cbo As New ComboBox()
                        '    Dim lst As List(Of AddressBookEntry) = ABook.GetAllContacts
                        '    lst.Sort()
                        '    For Each item As AddressBookEntry In lst
                        '        If item.ContactType = AddressBookEntryType.TrulyMail Then
                        '            Dim s As String = item.ID '-- store contact ID
                        '            If s = rowobj.CompareValue Then
                        '                intIndex = cbo.Items.Count()
                        '            End If
                        '            cbo.Items.Add(item)
                        '        End If
                        '    Next
                        '    cbo.DropDownStyle = ComboBoxStyle.DropDownList
                        '    cbo.SelectedIndex = intIndex
                        '    cbo.Bounds = e.CellBounds
                        '    e.Control = cbo
                    Case ProcessingRuleEditorTypeEnum.EmailContactSelector
                        Dim intIndex As Integer
                        Dim cbo As New ComboBox()
                        Dim lst As List(Of AddressBookEntry) = ABook.GetAllContacts
                        lst.Sort()
                        For Each item As AddressBookEntry In lst
                            If item.ContactType = AddressBookEntryType.Email Then
                                Dim s As String = item.Address '-- store email address
                                If s = rowobj.CompareValue Then
                                    intIndex = cbo.Items.Count()
                                End If
                                cbo.Items.Add(item)
                            End If
                        Next
                        cbo.DropDownStyle = ComboBoxStyle.DropDownList
                        cbo.SelectedIndex = intIndex
                        cbo.Bounds = e.CellBounds
                        e.Control = cbo
                    Case ProcessingRuleEditorTypeEnum.SMTPAccountSelector
                        Dim intIndex As Integer
                        Dim cbo As New ComboBox()
                        Dim lst As List(Of SMTPProfile) = AppSettings.SMTPProfiles
                        For Each item As SMTPProfile In lst
                            Dim s As String = item.ID '-- store contact ID
                            If s = rowobj.CompareValue Then
                                intIndex = cbo.Items.Count()
                            End If
                            cbo.Items.Add(item)
                        Next
                        cbo.DropDownStyle = ComboBoxStyle.DropDownList
                        cbo.SelectedIndex = intIndex
                        cbo.Bounds = e.CellBounds
                        e.Control = cbo
                End Select
        End Select
    End Sub

    Private Sub olvMatching_CellClick(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellClickEventArgs) Handles olvMatching.CellClick
        Select Case e.ColumnIndex
            Case 4
                '-- Add new row
                Dim matchData As ProcessingRuleMatchData = CreateNewMatchData()
                m_newProcessingRule.MatchDatas.Add(matchData)
                olvMatching.AddObject(matchData)
            Case 5
                '-- Remove this row
                If m_newProcessingRule.MatchDatas.Count = 1 Then
                    ShowMessageBox("A processing rule must have at least one match condition.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    m_newProcessingRule.MatchDatas.Remove(e.Item.RowObject)
                    olvMatching.RemoveObject(e.Item.RowObject)
                End If
            Case Else
                '-- do nothing
        End Select
    End Sub

    Private Sub rbtnMatchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMatchAll.CheckedChanged
        olvMatching.Visible = Not rbtnMatchAll.Checked

        '-- make sure we have at least one rule if we make it and/or
        If Not rbtnMatchAll.Checked AndAlso m_newProcessingRule.MatchDatas.Count = 0 Then
            m_newProcessingRule.MatchDatas.Add(CreateNewMatchData())
        End If
    End Sub

    Private Function AddImageGetter(ByVal rowObject As Object) As Object
        Return "add-icon_48.png"
    End Function
    Private Function RemoveImageGetter(ByVal rowObject As Object) As Object
        Return "remove-icon_48.png"
    End Function
    Private Function AddDeleteAspectGetter(ByVal rowObject As Object) As Object
        Return String.Empty
    End Function
    Private Function AddDeleteAspectToStringConverter(ByVal value As Object) As String
        Return String.Empty
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '-- check if everything is valid
        If Not rbtnMatchAll.Checked Then
            For Each match As ProcessingRuleMatchData In m_newProcessingRule.MatchDatas
                If Not match.IsValid Then
                    ShowMessageBox("A match rule (" & match.MatchFieldText & ") is not valid. Please correct before continuing.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next
        End If

        For Each action As ProcessingRuleActionData In m_newProcessingRule.Actions
            If Not action.IsValid Then
                ShowMessageBox("An action (" & action.ActionTypeText & ") is not valid. Please correct before continuing.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Next

        If txtRuleName.Text.Trim.Length = 0 Then
            If rbtnMatchAll.Checked Then
                m_newProcessingRule.Name = m_newProcessingRule.Actions(0).ActionTypeText & " " & m_newProcessingRule.Actions(0).ActionValue
            Else
                If m_newProcessingRule.MatchDatas(0).CompareType = ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact OrElse _
                     m_newProcessingRule.MatchDatas(0).CompareType = ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact Then

                    Dim contact As AddressBookEntry = ABook.GetContactByID(m_newProcessingRule.MatchDatas(0).CompareValue)
                    If contact IsNot Nothing Then
                        m_newProcessingRule.Name = m_newProcessingRule.MatchDatas(0).MatchFieldText & " " & m_newProcessingRule.MatchDatas(0).CompareTypeText & " " & contact.ToString()
                    Else
                        m_newProcessingRule.Name = m_newProcessingRule.MatchDatas(0).MatchFieldText & " " & m_newProcessingRule.MatchDatas(0).CompareTypeText
                    End If
                Else
                    m_newProcessingRule.Name = m_newProcessingRule.MatchDatas(0).MatchFieldText & " " & m_newProcessingRule.MatchDatas(0).CompareTypeText & " " & m_newProcessingRule.MatchDatas(0).CompareValue
                End If
            End If
        Else
            m_newProcessingRule.Name = txtRuleName.Text
        End If
        m_newProcessingRule.TriggerType = CType(Me.cboProcessRuleRunTime.SelectedIndex, ProcessingRuleTriggerTypeEnum)

        If rbtnMatchAll.Checked Then
            m_newProcessingRule.MatchType = ProcessingRuleMatchTypeEnum.MatchAll
        ElseIf rbtnMatchAnd.Checked Then
            m_newProcessingRule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd
        ElseIf rbtnMatchOr.Checked Then
            m_newProcessingRule.MatchType = ProcessingRuleMatchTypeEnum.MatchOr
        End If

        If m_oldProcessingRule Is Nothing Then
            '-- just add this rule
            AppSettings.ProcessingRules.Add(m_newProcessingRule)
        Else
            '-- Update existing rule with new values
            CopyRuleProperties(m_newProcessingRule, m_oldProcessingRule)
        End If
        AppSettings.Save()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_newProcessingRule = Nothing
        Hide()
    End Sub
    Public ReadOnly Property NewRule As ProcessingRule
        Get
            Return m_newProcessingRule
        End Get
    End Property

    Private Sub olvActions_CellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvActions.CellEditStarting
        Try
            Dim rowobj As ProcessingRuleActionData = CType(e.RowObject, ProcessingRuleActionData)
            Select Case e.Column.AspectName
                Case ActionTypeColumn.AspectName
                    Dim intIndex As Integer
                    Dim cbo As New ComboBox()
                    For Each item As Integer In [Enum].GetValues(GetType(ProcessingRuleActionTypeEnum))
                        Dim s As String = GetProcessingRuleActionTypeText(item)
                        If s = CType(e.RowObject, ProcessingRuleActionData).ActionTypeText Then
                            intIndex = cbo.Items.Count()
                        End If
                        cbo.Items.Add(s)
                    Next
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList
                    cbo.SelectedIndex = intIndex
                    cbo.Bounds = e.CellBounds
                    e.Control = cbo
                Case ActionValueColumn.AspectName
                    Select Case CType(e.RowObject, ProcessingRuleActionData).EditorType
                        Case ProcessingRuleEditorTypeEnum.None
                            rowobj.ActionValue = String.Empty
                            olvActions.RefreshObject(rowobj)
                            e.Cancel = True
                        Case ProcessingRuleEditorTypeEnum.TextBox
                            rowobj.ActionValue = String.Empty
                            e.Control.Text = String.Empty
                            olvActions.RefreshObject(rowobj)
                        Case ProcessingRuleEditorTypeEnum.NumericUpDown
                            rowobj.ActionValue = String.Empty
                            olvActions.RefreshObject(rowobj)
                            Dim nud As New Windows.Forms.NumericUpDown()
                            nud.Maximum = 1000000 ' million
                            nud.Minimum = -1000000 ' -million
                            nud.Bounds = e.CellBounds
                            nud.Value = 0
                            e.Control = nud
                        Case ProcessingRuleEditorTypeEnum.FolderSelector
                            Try
                                Dim fbd As New FolderBrowserDialogTM()
                                fbd.ShowAllFolders = False
                                fbd.SelectedPath = CType(e.RowObject, ProcessingRuleActionData).ActionValue
                                fbd.ShowNewFolderButton = False
                                fbd.Description = "Select destination folder"
                                If fbd.ShowDialog(Me) = DialogResult.OK Then
                                    If QualifyPath(fbd.SelectedPath) = QualifyPath(MessageStoreRootPath) Then
                                        ShowMessageBox("You cannot store messages in this location. Please try another folder.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                    Else
                                        '--OK
                                        Dim tb As New TextBox
                                        tb.ReadOnly = True
                                        tb.Bounds = e.CellBounds
                                        tb.Text = fbd.SelectedPath
                                        e.Control = tb
                                    End If
                                End If
                            Catch ex As Exception
                                Log(ex)
                                ShowMessageBoxError("There was an error changing the folder for export. " & CONTACT_TRULYMAIL_MESSAGE)
                            End Try
                        Case ProcessingRuleEditorTypeEnum.SoundBrowser
                            Dim cbo As New ComboBox
                            cbo.DropDownStyle = ComboBoxStyle.DropDownList
                            Dim files() As String = System.IO.Directory.GetFiles(MySoundsPath, "*" & NOTIFY_SOUND_VALID_EXTENSION)
                            For Each strFilename As String In files
                                cbo.Items.Add(System.IO.Path.GetFileName(strFilename))
                            Next
                            If cbo.Items.Count > 0 Then
                                cbo.SelectedIndex = 0
                            End If
                            cbo.Bounds = e.CellBounds
                            e.Control = cbo
                    End Select
            End Select
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error editing this information. Please contact TrulyMail Support for assistance.")
        End Try
    End Sub

    Private Sub olvActions_CellEditFinishing(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvActions.CellEditFinishing
        Dim rowobj As ProcessingRuleActionData = CType(e.RowObject, ProcessingRuleActionData)
        Select Case e.Column.AspectName
            Case ActionTypeColumn.AspectName
                rowobj.ActionTypeText = e.Control.Text
                rowobj.ActionValue = String.Empty
            Case ActionValueColumn.AspectName
                Select Case CType(e.RowObject, ProcessingRuleActionData).EditorType
                    Case ProcessingRuleEditorTypeEnum.None
                        '-- nothing to do
                    Case ProcessingRuleEditorTypeEnum.TextBox
                        rowobj.ActionValue = e.Control.Text
                        olvActions.RefreshObject(rowobj)
                    Case ProcessingRuleEditorTypeEnum.TextArea
                    Case ProcessingRuleEditorTypeEnum.AddressBookEntryOrEmail '-- can enter free text also
                    Case ProcessingRuleEditorTypeEnum.NumericUpDown
                        rowobj.ActionValue = CType(e.Control, Windows.Forms.NumericUpDown).Value.ToString()
                        olvActions.RefreshObject(rowobj)
                        e.Cancel = True
                    Case ProcessingRuleEditorTypeEnum.FolderSelector
                        rowobj.ActionValue = e.Control.Text
                        olvActions.RefreshObject(rowobj)
                        e.Cancel = True
                    Case ProcessingRuleEditorTypeEnum.SoundBrowser
                        Dim cbo As ComboBox = CType(e.Control, ComboBox)
                        If cbo.SelectedIndex > -1 Then
                            rowobj.ActionValue = cbo.Items(cbo.SelectedIndex).ToString()
                            olvActions.RefreshObject(rowobj)
                            e.Cancel = True
                        Else
                            '-- do nothing
                        End If
                End Select
        End Select
    End Sub

    Private Sub olvActions_CellClick(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellClickEventArgs) Handles olvActions.CellClick
        Select Case e.ColumnIndex
            Case 3
                '-- Add new row
                Dim actionData As ProcessingRuleActionData = CreateNewActionData()
                m_newProcessingRule.Actions.Add(actionData)
                olvActions.AddObject(actionData)
            Case 4
                '-- Remove this row
                If m_newProcessingRule.Actions.Count = 1 Then
                    ShowMessageBox("A processing rule must have at least one action to perform.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    m_newProcessingRule.Actions.Remove(e.Item.RowObject)
                    olvActions.RemoveObject(e.Item.RowObject)
                End If
            Case Else
                '-- do nothing
        End Select
    End Sub
End Class