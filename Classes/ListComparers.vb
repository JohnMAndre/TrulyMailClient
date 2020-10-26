Friend Class AddressBookEntryComparerByTags
    Implements IComparer(Of AddressBookEntry)

    Public Function Compare(x As AddressBookEntry, y As AddressBookEntry) As Integer Implements IComparer(Of AddressBookEntry).Compare
        Return x.Tags.CompareTo(y.Tags)
    End Function
End Class
Friend Class AddressBookEntryComparerByImportance
    Implements IComparer(Of AddressBookEntry)

    Public Function Compare(x As AddressBookEntry, y As AddressBookEntry) As Integer Implements IComparer(Of AddressBookEntry).Compare
        Return x.Tags.CompareTo(y.ImportanceRating)
    End Function
End Class

Friend Class AddressBookEntryComparerByImportanceAndLastSent
    Implements IComparer(Of AddressBookEntry)

    Public Function Compare(x As AddressBookEntry, y As AddressBookEntry) As Integer Implements IComparer(Of AddressBookEntry).Compare
        Dim strCompoundDataX As String = x.ImportanceRating.ToString("00")
        If x.LastMessageSent.HasValue Then
            strCompoundDataX &= x.LastMessageSent.Value.ToString(DATEFORMAT_FILENAME)
        Else
            strCompoundDataX &= "0" '-- come up last in sort
        End If

        Dim strCompoundDataY As String = y.ImportanceRating.ToString("00")
        If y.LastMessageSent.HasValue Then
            strCompoundDataY &= y.LastMessageSent.Value.ToString(DATEFORMAT_FILENAME)
        Else
            strCompoundDataY &= "0" '-- come up last in sort
        End If


        Return strCompoundDataY.CompareTo(strCompoundDataX)  '-- reverse sort
    End Function
End Class
