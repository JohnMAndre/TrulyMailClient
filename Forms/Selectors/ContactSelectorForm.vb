Friend Class ContactSelectorForm

    Private Sub ContactSelector1_CancelButtonClicked() Handles ContactSelector1.CancelButtonClicked
        '-- Do nothing
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ContactSelector1_OKButtonClicked() Handles ContactSelector1.OKButtonClicked
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Function GetSelectedContacts() As List(Of AddressBookEntry)
        Return ContactSelector1.GetSelectedContacts()
    End Function
End Class