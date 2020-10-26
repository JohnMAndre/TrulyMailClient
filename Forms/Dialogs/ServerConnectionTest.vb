Public Class ServerConnectionTest

    Private Class ConnectionTestItem
        Public Address As String
        Public Duration As Double
        Public Result As String = "Testing"
    End Class
    Private currentTest As ConnectionTestItem
    Private Delegate Function AddTestCallback(ByVal address As String) As ConnectionTestItem
    Private Function AddTest(ByVal address As String) As ConnectionTestItem
        If InvokeRequired Then
            Dim deleg As New AddTestCallback(AddressOf AddTest)
            Return Invoke(deleg, address)
        Else
            Dim o As New ConnectionTestItem()
            o.Address = address
            ObjectListView1.AddObject(o)
            Return o
        End If
    End Function
    Private Function PassedTest(ByVal address As String, ByVal displayName As String) As Boolean
        Try

            Dim strURL As String
            Dim sw As Stopwatch
            Dim strContents As String
            Dim intMaxTime, intTime As Integer
            Dim intMinTime As Integer = 10000 '-- default to 10 seconds

            strURL = address
            currentTest = AddTest(displayName)
            sw = Stopwatch.StartNew()
            Try
                Using wc As New System.Net.WebClient()
                    Dim strm As System.IO.Stream = wc.OpenRead(strURL)
                    strm.ReadTimeout = 30000 '30 seconds
                    Using sr As New System.IO.StreamReader(strm)

                        strContents = sr.ReadToEnd()
                        intTime = sw.ElapsedMilliseconds
                        If strContents.Length > 0 Then
                            If intTime > intMaxTime Then
                                intMaxTime = intTime
                            ElseIf intTime < intMinTime Then
                                intMinTime = intTime
                            End If
                            currentTest.Duration = Convert.ToDouble(intTime) / Convert.ToDouble(1000)
                            currentTest.Result = "Passed"
                        Else
                            currentTest.Result = "Failed"
                        End If
                        sr.Dispose()
                        strm.Dispose()
                    End Using
                End Using
            Catch ex As Exception
                Log(ex)
                Log("Url: " & strURL)
                currentTest.Result = "Failed"
            End Try

            ObjectListView1.RefreshObject(currentTest)
        Catch ex As Exception
            Log(ex)
        End Try

    End Function
    Private Sub bgwCheckConnections_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwCheckConnections.DoWork
        Dim intTestWebSiteConnectionSuccesses As Integer
        Dim intTestWebSiteConnectionFailures As Integer

        Try
            If PassedTest("http://Google.com", "Google.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Microsoft.com", "Microsoft.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://www.TrulyMail.com", "TrulyMail.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Apple.com", "Apple.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Yahoo.com", "Yahoo.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Facebook.com", "Facebook.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://YouTube.com", "YouTube.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Live.com", "Live.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Baidu.com", "Baidu.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Wikipedia.org", "Wikipedia.org") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Blogger.com", "Blogger.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://MSN.com", "MSN.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://www.QQ.com", "www.QQ.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://Twitter.com", "Twitter.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
            If PassedTest("http://WordPress.com", "WordPress.com") Then
                intTestWebSiteConnectionSuccesses += 1
            Else
                intTestWebSiteConnectionFailures += 1
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error running the connection test. Please contact TrulyMail Support.")
        End Try
    End Sub

    Private Sub ObjectListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjectListView1.SelectedIndexChanged

    End Sub

    Private Sub ServerConnectionTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not bgwCheckConnections.IsBusy Then
            bgwCheckConnections.RunWorkerAsync()
        Else
            ShowMessageBoxError("Please wait until the current process completes.")
        End If

        Me.Text = "Server Connection Test - " & Application.ProductVersion
    End Sub
End Class