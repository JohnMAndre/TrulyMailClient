Public Class CharacterSelectorForm

    Public Property SelectedText As String
        Get
            Return txtCharacters.Text
        End Get
        Set(value As String)
            txtCharacters.Text = value
        End Set
    End Property
    Public Property SelectionStart As Integer
        Get
            Return txtCharacters.SelectionStart
        End Get
        Set(value As Integer)
            Try
                txtCharacters.SelectionStart = value
            Catch ex As Exception
                Log(ex) '-- log and continue
            End Try
        End Set
    End Property
    Public Property SelectionLength As Integer
        Get
            Return txtCharacters.SelectionLength
        End Get
        Set(value As Integer)
            Try
                txtCharacters.SelectionLength = value
            Catch ex As Exception
                Log(ex) '-- log and continue
            End Try
        End Set
    End Property
    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton9.Click, KryptonButton8.Click, KryptonButton7.Click, KryptonButton6.Click, KryptonButton5.Click, KryptonButton4.Click, KryptonButton31.Click, KryptonButton30.Click, KryptonButton3.Click, KryptonButton29.Click, KryptonButton28.Click, KryptonButton27.Click, KryptonButton26.Click, KryptonButton25.Click, KryptonButton24.Click, KryptonButton23.Click, KryptonButton22.Click, KryptonButton21.Click, KryptonButton20.Click, KryptonButton2.Click, KryptonButton19.Click, KryptonButton18.Click, KryptonButton17.Click, KryptonButton16.Click, KryptonButton15.Click, KryptonButton14.Click, KryptonButton13.Click, KryptonButton12.Click, KryptonButton11.Click, KryptonButton10.Click, KryptonButton1.Click, KryptonButton38.Click, KryptonButton37.Click, KryptonButton36.Click, KryptonButton35.Click, KryptonButton34.Click, KryptonButton33.Click, KryptonButton32.Click, KryptonButton40.Click, KryptonButton39.Click, KryptonButton51.Click, KryptonButton50.Click, KryptonButton49.Click, KryptonButton48.Click, KryptonButton47.Click, KryptonButton46.Click, KryptonButton45.Click, KryptonButton44.Click, KryptonButton43.Click, KryptonButton42.Click, KryptonButton41.Click, KryptonButton52.Click, KryptonButton53.Click, KryptonButton54.Click, KryptonButton55.Click, KryptonButton60.Click, KryptonButton59.Click, KryptonButton58.Click, KryptonButton57.Click, KryptonButton56.Click
        txtCharacters.SelectedText = CType(sender, ComponentFactory.Krypton.Toolkit.KryptonButton).Text
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub


End Class
