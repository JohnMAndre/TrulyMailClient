Module ProcessingRuleSupport
    '-- Processing Rules
    Public Enum ProcessingRuleMatchDataCompareTypeEnum
        IsEqualTo
        IsNotEqualTo
        StartsWith
        NotStartsWith
        EndsWith
        NotEndsWith
        Contains
        NotContains
        IsBefore
        IsAfter
        IsEmpty
        NotIsEmpty
        InAddressBook
        NotInAddressBook
        IsGreaterThan
        IsLessThan
        SpecificTrulyMailContact '-- Disabling all TM stuff in version 6.0 but cannot remove from here or loading settings will be off
        NotSpecificTrulyMailContact '-- Disabling all TM stuff in version 6.0 but cannot remove from here or loading settings will be off
        SpecificEmailContact
        NotSpecificEmailContact
        EmailAddressContains
        EmailAddressNotContains
        IsSMTPAccount
        IsNotSMTPAccount
        IsTrulyMailAccount '-- Disabling all TM stuff in version 6.0 but cannot remove from here or loading settings will be off
        IsNotTrulyMailAccount '-- Disabling all TM stuff in version 6.0 but cannot remove from here or loading settings will be off
    End Enum
    Public Enum ProcessingRuleMatchTypeEnum
        MatchAnd
        MatchOr
        MatchAll '-- no match criteria, apply rule to all messages
    End Enum
    Public Enum ProcessingRuleEditorTypeEnum
        None
        TextBox
        TextArea
        AddressBookEntryOrEmail '-- can enter free text also
        NumericUpDown
        FolderSelector
        SoundBrowser
        TrulyMailContactSelector
        EmailContactSelector
        SMTPAccountSelector
        'TagSelector '-- can enter free text also
    End Enum
    Public Enum ProcessingRuleActionTypeEnum
        DeleteMessageToTrash
        DeleteMessagePermanently
        MarkAsRead
        DisplayMsgBox
        AddTag
        MoveMessageTo
        SetMessageImportance
        AddToMessageImportance
        PlaySound
        'ForwardMessageTo '-- guid or email address
        'ReplyWithText
        'DisplaySysTrayPopup
    End Enum
    Public Enum ProcessingRuleMatchFieldEnum
        FieldSubject
        FieldBody
        FieldTags
        FieldFrom '-- guid or email address
        FieldTo '-- guid or email address
        FieldCC '-- guid or email address
        FieldBCC '-- guid or email address
        FieldToOrCC '-- guid or email address
        FieldFromToCCOrBCC '-- guid or email address
        FieldSendingAccount '-- guid (empty guid=tm account
        'FieldReceiveAccount 
        'FieldSentDate
        'FieldSizeInKB
        'FieldReceiveAccount
    End Enum
    Public Enum ProcessingRuleTriggerTypeEnum
        ReceiveMessage
        SendMessage
    End Enum
    Public Class ProcessingRule
        Public Property Name As String
        Public Property Enabled As Boolean = True
        Public Property TriggerType As ProcessingRuleTriggerTypeEnum
        Public Property MatchDatas As New List(Of ProcessingRuleMatchData)
        Public Property MatchType As ProcessingRuleMatchTypeEnum
        Public Property Actions As New List(Of ProcessingRuleActionData)
    End Class
    Public Class ProcessingRuleMatchData
        Public Property MatchField As ProcessingRuleMatchFieldEnum
        Public Property MatchFieldText As String
            Get
                Return GetProcessingRuleMatchFieldText(Me.MatchField)
            End Get
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    Me.MatchField = GetProcessingRuleMatchFieldEnumFromText(value)
                End If
            End Set
        End Property
        Public Property CompareType As ProcessingRuleMatchDataCompareTypeEnum
        Public Property CompareTypeText As String
            Get
                Return GetProcessingRuleMatchDataCompareTypeText(Me.CompareType)
            End Get
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    Me.CompareType = GetProcessingRuleMatchDataCompareTypeEnum(value)
                End If
            End Set
        End Property

        Private m_compareValue As String
        Public Property CompareValue As String '-- everything can be represented as a string
            Get
                Return m_compareValue
            End Get
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    m_compareValue = value
                End If
            End Set
        End Property
        Public ReadOnly Property EditorType As ProcessingRuleEditorTypeEnum
            Get
                Select Case CompareType
                    Case ProcessingRuleMatchDataCompareTypeEnum.Contains,
                        ProcessingRuleMatchDataCompareTypeEnum.NotContains, _
                        ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains, _
                        ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains, _
                        ProcessingRuleMatchDataCompareTypeEnum.EndsWith, _
                        ProcessingRuleMatchDataCompareTypeEnum.NotEndsWith, _
                        ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo, _
                        ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo, _
                        ProcessingRuleMatchDataCompareTypeEnum.StartsWith, _
                        ProcessingRuleMatchDataCompareTypeEnum.NotStartsWith

                        Return ProcessingRuleEditorTypeEnum.TextBox

                    Case ProcessingRuleMatchDataCompareTypeEnum.InAddressBook, _
                        ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook, _
                        ProcessingRuleMatchDataCompareTypeEnum.IsEmpty, _
                        ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty

                        Return ProcessingRuleEditorTypeEnum.None

                    Case ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact, _
                        ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact

                        Return ProcessingRuleEditorTypeEnum.EmailContactSelector

                        'Case ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact, _
                        '    ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact

                        '    Return ProcessingRuleEditorTypeEnum.TrulyMailContactSelector

                    Case ProcessingRuleMatchDataCompareTypeEnum.IsSMTPAccount, _
                        ProcessingRuleMatchDataCompareTypeEnum.IsNotSMTPAccount

                        Return ProcessingRuleEditorTypeEnum.SMTPAccountSelector


                        'Case ProcessingRuleMatchDataCompareTypeEnum.IsAfter
                        'Case ProcessingRuleMatchDataCompareTypeEnum.IsBefore
                        'Case ProcessingRuleMatchDataCompareTypeEnum.IsGreaterThan
                        'Case ProcessingRuleMatchDataCompareTypeEnum.IsLessThan
                End Select
            End Get
        End Property
        Public ReadOnly Property IsValid As Boolean
            Get
                Select Case MatchField
                    Case ProcessingRuleMatchFieldEnum.FieldSubject, _
                        ProcessingRuleMatchFieldEnum.FieldBody, _
                        ProcessingRuleMatchFieldEnum.FieldTags

                        Return CompareValue.Length > 0
                    Case ProcessingRuleMatchFieldEnum.FieldFrom, _
                        ProcessingRuleMatchFieldEnum.FieldTo, _
                        ProcessingRuleMatchFieldEnum.FieldCC, _
                        ProcessingRuleMatchFieldEnum.FieldBCC, _
                        ProcessingRuleMatchFieldEnum.FieldToOrCC, _
                        ProcessingRuleMatchFieldEnum.FieldFromToCCOrBCC

                        Select Case CompareType
                            'Case ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact, _
                            '    ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact

                            '    Return CompareValue.Length = Guid.Empty.ToString.Length '-- assume guid if length matches

                            Case ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact, _
                                ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact

                                Return IsValidEmailAddress(CompareValue)

                            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains, _
                                ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains

                                Return CompareValue.Length > 0
                            Case ProcessingRuleMatchDataCompareTypeEnum.InAddressBook, _
                                ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook

                                Return True
                            Case Else
                                Log("Invalid CompareType. MatchField: " & MatchField & " ... CompareType: " & CompareType)
                                Return False
                        End Select
                    Case ProcessingRuleMatchFieldEnum.FieldSendingAccount
                        Select Case CompareType
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsSMTPAccount, _
                                ProcessingRuleMatchDataCompareTypeEnum.IsNotSMTPAccount

                                Return SMTPProfile.GetByID(CompareValue) IsNot Nothing

                            Case ProcessingRuleMatchDataCompareTypeEnum.IsTrulyMailAccount, _
                                ProcessingRuleMatchDataCompareTypeEnum.IsNotTrulyMailAccount

                                Return True
                        End Select

                    Case Else
                        Log("Invalid MatchField. MatchField: " & MatchField & " ... CompareType: " & CompareType)
                        Return False
                End Select
            End Get
        End Property
    End Class
    Public Class ProcessingRuleActionData
        Public Property ActionType As ProcessingRuleActionTypeEnum
        Public Property ActionTypeText As String
            Get
                Return GetProcessingRuleActionTypeText(Me.ActionType)
            End Get
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    ActionType = GetProcessingRuleActionTypeEnum(value)
                End If
            End Set
        End Property
        Public Property ActionValue As String '-- everything can be represented as a string
        Public ReadOnly Property EditorType As ProcessingRuleEditorTypeEnum
            Get
                Select Case ActionType
                    Case ProcessingRuleActionTypeEnum.AddTag
                        Return ProcessingRuleEditorTypeEnum.TextBox
                    Case ProcessingRuleActionTypeEnum.AddToMessageImportance
                        Return ProcessingRuleEditorTypeEnum.NumericUpDown
                    Case ProcessingRuleActionTypeEnum.DeleteMessagePermanently
                        Return ProcessingRuleEditorTypeEnum.None
                    Case ProcessingRuleActionTypeEnum.DeleteMessageToTrash
                        Return ProcessingRuleEditorTypeEnum.None
                    Case ProcessingRuleActionTypeEnum.DisplayMsgBox
                        Return ProcessingRuleEditorTypeEnum.TextBox
                    Case ProcessingRuleActionTypeEnum.MarkAsRead
                        Return ProcessingRuleEditorTypeEnum.None
                    Case ProcessingRuleActionTypeEnum.MoveMessageTo
                        Return ProcessingRuleEditorTypeEnum.FolderSelector
                    Case ProcessingRuleActionTypeEnum.SetMessageImportance
                        Return ProcessingRuleEditorTypeEnum.NumericUpDown
                    Case ProcessingRuleActionTypeEnum.PlaySound
                        Return ProcessingRuleEditorTypeEnum.SoundBrowser
                        'Case ProcessingRuleActionTypeEnum.ForwardMessageTo
                        '    Return ProcessingRuleEditorTypeEnum.AddressBookEntryOrEmail
                        'Case ProcessingRuleActionTypeEnum.ReplyWithText
                        '    Return ProcessingRuleEditorTypeEnum.TextArea
                        'Case ProcessingRuleActionTypeEnum.DisplaySysTrayPopup
                        '    Return ProcessingRuleEditorTypeEnum.TextBox
                End Select
            End Get
        End Property
        Public ReadOnly Property IsValid As Boolean
            Get
                Select Case ActionType
                    Case ProcessingRuleActionTypeEnum.AddTag
                        Return ActionValue.Length > 0
                    Case ProcessingRuleActionTypeEnum.AddToMessageImportance
                        Return IsNumeric(ActionValue)
                    Case ProcessingRuleActionTypeEnum.SetMessageImportance
                        Return IsNumeric(ActionValue)
                    Case ProcessingRuleActionTypeEnum.DeleteMessagePermanently
                        Return True
                    Case ProcessingRuleActionTypeEnum.DeleteMessageToTrash
                        Return True
                    Case ProcessingRuleActionTypeEnum.DisplayMsgBox
                        Return ActionValue.Length > 0
                    Case ProcessingRuleActionTypeEnum.MarkAsRead
                        Return True
                    Case ProcessingRuleActionTypeEnum.MoveMessageTo
                        Return System.IO.Directory.Exists(ActionValue)
                    Case ProcessingRuleActionTypeEnum.PlaySound
                        If ActionValue Is Nothing Then
                            Return False
                        Else
                            Return System.IO.File.Exists(MySoundsPath & ActionValue)
                        End If
                End Select
            End Get
        End Property
    End Class
    Public Function GetProcessingRuleActionTypeEnum(ByVal actionTypeText As String) As ProcessingRuleActionTypeEnum
        Select Case actionTypeText
            Case "Add tag"
                Return ProcessingRuleActionTypeEnum.AddTag
            Case "Add to importance rating"
                Return ProcessingRuleActionTypeEnum.AddToMessageImportance
            Case "Set importance rating"
                Return ProcessingRuleActionTypeEnum.SetMessageImportance
            Case "Delete message (permanently)"
                Return ProcessingRuleActionTypeEnum.DeleteMessagePermanently
            Case "Move message to Trash"
                Return ProcessingRuleActionTypeEnum.DeleteMessageToTrash
            Case "Display dialog"
                Return ProcessingRuleActionTypeEnum.DisplayMsgBox
            Case "Mark message as read"
                Return ProcessingRuleActionTypeEnum.MarkAsRead
            Case "Move message to"
                Return ProcessingRuleActionTypeEnum.MoveMessageTo
            Case "Play a sound"
                Return ProcessingRuleActionTypeEnum.PlaySound
                'Case "Display system tray popup"
                '    Return ProcessingRuleActionTypeEnum.DisplaySysTrayPopup
                'Case "Forward message to"
                '    Return ProcessingRuleActionTypeEnum.ForwardMessageTo
                'Case "Reply to sender with text"
                '    Return ProcessingRuleActionTypeEnum.ReplyWithText
        End Select
    End Function
    Public Function GetProcessingRuleActionTypeText(ByVal actionType As ProcessingRuleActionTypeEnum) As String
        Select Case actionType
            Case ProcessingRuleActionTypeEnum.AddTag
                Return "Add tag"
            Case ProcessingRuleActionTypeEnum.AddToMessageImportance
                Return "Add to importance rating"
            Case ProcessingRuleActionTypeEnum.SetMessageImportance
                Return "Set importance rating"
            Case ProcessingRuleActionTypeEnum.DeleteMessagePermanently
                Return "Delete message (permanently)"
            Case ProcessingRuleActionTypeEnum.DeleteMessageToTrash
                Return "Move message to Trash"
            Case ProcessingRuleActionTypeEnum.DisplayMsgBox
                Return "Display dialog"
            Case ProcessingRuleActionTypeEnum.MarkAsRead
                Return "Mark message as read"
            Case ProcessingRuleActionTypeEnum.MoveMessageTo
                Return "Move message to"
            Case ProcessingRuleActionTypeEnum.PlaySound
                Return "Play a sound"
                'Case ProcessingRuleActionTypeEnum.DisplaySysTrayPopup
                '    Return "Display system tray popup"
                'Case ProcessingRuleActionTypeEnum.ForwardMessageTo
                '    Return "Forward message to"
                'Case ProcessingRuleActionTypeEnum.ReplyWithText
                '    Return "Reply to sender with text"
        End Select
    End Function

    ''' <summary>
    ''' Returns text to display for users in creating/modifying processing rules
    ''' </summary>
    ''' <param name="matchField"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProcessingRuleMatchFieldText(ByVal matchField As ProcessingRuleMatchFieldEnum) As String
        Select Case matchField
            Case ProcessingRuleMatchFieldEnum.FieldFrom
                Return "From"
            Case ProcessingRuleMatchFieldEnum.FieldTo
                Return "To"
            Case ProcessingRuleMatchFieldEnum.FieldCC
                Return "CC"
            Case ProcessingRuleMatchFieldEnum.FieldBCC
                Return "BCC"
            Case ProcessingRuleMatchFieldEnum.FieldToOrCC
                Return "To or CC"
            Case ProcessingRuleMatchFieldEnum.FieldFromToCCOrBCC
                Return "From, To, CC, or BCC"
            Case ProcessingRuleMatchFieldEnum.FieldSubject
                Return "Subject"
            Case ProcessingRuleMatchFieldEnum.FieldBody
                Return "Message body"
                'Case ProcessingRuleMatchFieldEnum.FieldSentDate
                '    Return "Sent date"
                'Case ProcessingRuleMatchFieldEnum.FieldSizeInKB
                '    Return "Size (in kb)"
            Case ProcessingRuleMatchFieldEnum.FieldTags
                Return "Tags"
                'Case ProcessingRuleMatchFieldEnum.FieldReceiveAccount
                '    Return "Receive Account"
            Case ProcessingRuleMatchFieldEnum.FieldSendingAccount
                Return "Sending account"
            Case Else
                Log("Invalid ProcessingRuleeMatchDataCompareTypeEnum found.")
                Return String.Empty
        End Select
    End Function
    ''' <summary>
    ''' Returns enum from the display name in creating/modifying processing rules
    ''' </summary>
    ''' <param name="matchFieldText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProcessingRuleMatchFieldEnumFromText(ByVal matchFieldText As String) As ProcessingRuleMatchFieldEnum
        Select Case matchFieldText
            Case "From"
                Return ProcessingRuleMatchFieldEnum.FieldFrom
            Case "To"
                Return ProcessingRuleMatchFieldEnum.FieldTo
            Case "CC"
                Return ProcessingRuleMatchFieldEnum.FieldCC
            Case "BCC"
                Return ProcessingRuleMatchFieldEnum.FieldBCC
            Case "To or CC"
                Return ProcessingRuleMatchFieldEnum.FieldToOrCC
            Case "From, To, CC, or BCC"
                Return ProcessingRuleMatchFieldEnum.FieldFromToCCOrBCC
            Case "Subject"
                Return ProcessingRuleMatchFieldEnum.FieldSubject
            Case "Message body"
                Return ProcessingRuleMatchFieldEnum.FieldBody
                'Case "Sent date"
                '    Return ProcessingRuleMatchFieldEnum.FieldSentDate
                'Case "Size (in kb)"
                '    Return ProcessingRuleMatchFieldEnum.FieldSizeInKB
            Case "Tags"
                Return ProcessingRuleMatchFieldEnum.FieldTags
                'Case "Receive Account"
                '    Return ProcessingRuleMatchFieldEnum.FieldReceiveAccount
            Case "Sending account"
                Return ProcessingRuleMatchFieldEnum.FieldSendingAccount
            Case Else
                Log("Invalid matchFieldText found.")
                Return ProcessingRuleMatchFieldEnum.FieldSubject
        End Select
    End Function
    ''' <summary>
    ''' Returns enum for given compare type text in creating/modifying processing rules
    ''' </summary>
    ''' <param name="compareTypeText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProcessingRuleMatchDataCompareTypeEnum(ByVal compareTypeText As String) As ProcessingRuleMatchDataCompareTypeEnum
        Select Case compareTypeText
            Case "is"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo
            Case "is not"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo
            Case "starts with"
                Return ProcessingRuleMatchDataCompareTypeEnum.StartsWith
            Case "does not start with"
                Return ProcessingRuleMatchDataCompareTypeEnum.NotStartsWith
            Case "ends with"
                Return ProcessingRuleMatchDataCompareTypeEnum.EndsWith
            Case "does not end with"
                Return ProcessingRuleMatchDataCompareTypeEnum.NotEndsWith
            Case "contains"
                Return ProcessingRuleMatchDataCompareTypeEnum.Contains
            Case "does not contain"
                Return ProcessingRuleMatchDataCompareTypeEnum.NotContains
            Case "is before"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsBefore
            Case "is after"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsAfter
            Case "is empty"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsEmpty
            Case "is not empty"
                Return ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty
            Case "is in my address book"
                Return ProcessingRuleMatchDataCompareTypeEnum.InAddressBook
            Case "is not in my address book"
                Return ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook
            Case "is larger than"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsGreaterThan
            Case "is smaller than"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsLessThan
                'Case "is specific TrulyMail contact"
                '    Return ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
                'Case "is not specific TrulyMail contact"
                '    Return ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact
            Case "is specific email address"
                Return ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact
            Case "is not specific email address"
                Return ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact
            Case "email address contains"
                Return ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
            Case "email address does not contain"
                Return ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains
            Case "is email sending account"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsSMTPAccount
            Case "is not email sending account"
                Return ProcessingRuleMatchDataCompareTypeEnum.IsNotSMTPAccount
                'Case "is TrulyMail sending account"
                '    Return ProcessingRuleMatchDataCompareTypeEnum.IsTrulyMailAccount
                'Case "is not TrulyMail sending account"
                '    Return ProcessingRuleMatchDataCompareTypeEnum.IsNotTrulyMailAccount
            Case Else
                Log("Invalid compareTypeText found.")
                Return ProcessingRuleMatchDataCompareTypeEnum.Contains
        End Select
    End Function
    ''' <summary>
    ''' Returns text to display for users in creating/modifying processing rules
    ''' </summary>
    ''' <param name="compareType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProcessingRuleMatchDataCompareTypeText(ByVal compareType As ProcessingRuleMatchDataCompareTypeEnum) As String
        Select Case compareType
            Case ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo
                Return "is"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo
                Return "is not"
            Case ProcessingRuleMatchDataCompareTypeEnum.StartsWith
                Return "starts with"
            Case ProcessingRuleMatchDataCompareTypeEnum.NotStartsWith
                Return "does not start with"
            Case ProcessingRuleMatchDataCompareTypeEnum.EndsWith
                Return "ends with"
            Case ProcessingRuleMatchDataCompareTypeEnum.NotEndsWith
                Return "does not end with"
            Case ProcessingRuleMatchDataCompareTypeEnum.Contains
                Return "contains"
            Case ProcessingRuleMatchDataCompareTypeEnum.NotContains
                Return "does not contain"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsBefore
                Return "is before"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsAfter
                Return "is after"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsEmpty
                Return "is empty"
            Case ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty
                Return "is not empty"
            Case ProcessingRuleMatchDataCompareTypeEnum.InAddressBook
                Return "is in my address book"
            Case ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook
                Return "is not in my address book"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsGreaterThan
                Return "is larger than"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsLessThan
                Return "is smaller than"
                'Case ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
                '    Return "is specific TrulyMail contact"
                'Case ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact
                '    Return "is not specific TrulyMail contact"
            Case ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact
                Return "is specific email address"
            Case ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact
                Return "is not specific email address"
            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
                Return "email address contains"
            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains
                Return "email address does not contain"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsSMTPAccount
                Return "is email sending account"
            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotSMTPAccount
                Return "is not email sending account"
                'Case ProcessingRuleMatchDataCompareTypeEnum.IsTrulyMailAccount
                '    Return "is TrulyMail sending account"
                'Case ProcessingRuleMatchDataCompareTypeEnum.IsNotTrulyMailAccount
                '    Return "is not TrulyMail sending account"
            Case Else
                Log("Invalid ProcessingRuleeMatchDataCompareTypeEnum found.")
                Return String.Empty
        End Select
    End Function
    'Public Function GetEditorForProcessingRuleActionType()

    'End Function
    'Public Function GetEditorForProcessingRuleActionType()

    'End Function
    ''' <summary>
    ''' Returns a list of compare types for a given field
    ''' </summary>
    ''' <param name="field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetValidProcessingRuleMatchDataCompareTypesForField(ByVal field As ProcessingRuleMatchFieldEnum) As List(Of ProcessingRuleMatchDataCompareTypeEnum)
        Dim lstReturn As New List(Of ProcessingRuleMatchDataCompareTypeEnum)

        Select Case field
            Case ProcessingRuleMatchFieldEnum.FieldFrom, ProcessingRuleMatchFieldEnum.FieldTo, ProcessingRuleMatchFieldEnum.FieldCC, _
                ProcessingRuleMatchFieldEnum.FieldBCC, ProcessingRuleMatchFieldEnum.FieldToOrCC, ProcessingRuleMatchFieldEnum.FieldFromToCCOrBCC
                'lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact)
                'lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.InAddressBook)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook)
            Case ProcessingRuleMatchFieldEnum.FieldSubject
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.Contains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotContains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEmpty)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.StartsWith)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotStartsWith)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.EndsWith)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotEndsWith)
            Case ProcessingRuleMatchFieldEnum.FieldBody
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.Contains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotContains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEmpty)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty)
                'Case ProcessingRuleMatchFieldEnum.FieldSentDate
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsAfter)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsBefore)
                'Case ProcessingRuleMatchFieldEnum.FieldSizeInKB
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsGreaterThan)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsLessThan)
            Case ProcessingRuleMatchFieldEnum.FieldTags
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.Contains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotContains)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEmpty)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty)
                'Case ProcessingRuleMatchFieldEnum.FieldReceiveAccount
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo)
                '    lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo)
            Case ProcessingRuleMatchFieldEnum.FieldSendingAccount
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsSMTPAccount)
                lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotSMTPAccount)
                'lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsTrulyMailAccount)
                'lstReturn.Add(ProcessingRuleMatchDataCompareTypeEnum.IsNotTrulyMailAccount)

            Case Else
                Log("Invalid ProcessingRuleMatchFieldEnum found.")
        End Select

        Return lstReturn
    End Function
    Private Function MessageHasRecipMatchingValue(ByVal msg As TrulyMailMessage, _
                                                  ByVal compareType As ProcessingRuleMatchDataCompareTypeEnum, _
                                                  ByVal recipType As RecipientType, _
                                                  ByVal compareValue As String) As Boolean

        Dim boolThisField As Boolean
        Dim boolRuleViolation As Boolean

        Select Case compareType
            'Case ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
            '    For Each recip As RecipientEntry In msg.Recipients
            '        If recip.RecipientType = recipType Then
            '            If recip.ContactType = AddressBookEntryType.TrulyMail AndAlso recip.ID = compareValue Then
            '                boolThisField = True
            '            End If
            '        End If
            '    Next
            'Case ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact
            '    '-- The test here is that the CompareValue does not exist within all of the TO recipients
            '    For Each recip As RecipientEntry In msg.Recipients
            '        If recip.RecipientType = recipType Then
            '            If recip.ContactType = AddressBookEntryType.TrulyMail AndAlso recip.ID = compareValue Then
            '                boolRuleViolation = True
            '            End If
            '        End If
            '    Next

            '    '-- as long as the rule was not violated, we can say this field is true
            '    boolThisField = Not boolRuleViolation
            Case ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact
                For Each recip As RecipientEntry In msg.Recipients
                    If recip.ContactType = AddressBookEntryType.Email AndAlso recip.RecipientType = recipType Then
                        If recip.Address.ToLower() = compareValue.ToLower() Then
                            boolThisField = True
                            Exit For
                        End If
                    End If
                Next
            Case ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact
                '-- The test here is that the CompareValue does not exist within all of the TO recipients
                For Each recip As RecipientEntry In msg.Recipients
                    If recip.ContactType = AddressBookEntryType.Email AndAlso recip.RecipientType = recipType Then
                        If recip.Address.ToLower() = compareValue.ToLower() Then
                            boolRuleViolation = True
                            Exit For
                        End If
                    End If
                Next

                '-- as long as the rule was not violated, we can say this field is true
                boolThisField = Not boolRuleViolation
            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
                For Each recip As RecipientEntry In msg.Recipients
                    If recip.ContactType = AddressBookEntryType.Email AndAlso recip.RecipientType = recipType Then
                        If recip.Address.ToLower().Contains(compareValue.ToLower()) Then
                            boolThisField = True
                            Exit For
                        End If
                    End If
                Next
            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains
                '-- The test here is that the CompareValue does not exist within all of the TO recipients
                For Each recip As RecipientEntry In msg.Recipients
                    If recip.ContactType = AddressBookEntryType.Email AndAlso recip.RecipientType = recipType Then
                        If recip.Address.ToLower().Contains(compareValue.ToLower()) Then
                            boolRuleViolation = True
                            Exit For
                        End If
                    End If
                Next

                '-- as long as the rule was not violated, we can say this field is true
                boolThisField = Not boolRuleViolation
            Case ProcessingRuleMatchDataCompareTypeEnum.InAddressBook
                For Each recip As RecipientEntry In msg.Recipients
                    If recip.RecipientType = recipType Then
                        'If msg.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                        '    '-- TrulyMail
                        '    Dim contact As AddressBookEntry = ABook.GetContactByID(recip.ID)
                        '    If contact IsNot Nothing Then
                        '        boolThisField = True
                        '        Exit For
                        '    End If
                        'Else
                        '-- Email
                        Dim contact As AddressBookEntry = ABook.GetContactByAddress(recip.Address)
                        If contact IsNot Nothing Then
                            boolThisField = True
                            Exit For
                        End If
                    End If
                    'End If
                Next
            Case ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook
                '-- The test here is that the CompareValue does not exist within all of the TO recipients
                For Each recip As RecipientEntry In msg.Recipients
                    If recip.RecipientType = recipType Then
                        'If msg.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                        '    '-- TrulyMail
                        '    Dim contact As AddressBookEntry = ABook.GetContactByID(recip.ID)
                        '    If contact IsNot Nothing Then
                        '        boolRuleViolation = True
                        '        Exit For
                        '    End If
                        'Else
                        '-- Email
                        Dim contact As AddressBookEntry = ABook.GetContactByAddress(recip.Address)
                        If contact IsNot Nothing Then
                            boolRuleViolation = True
                            Exit For
                        End If
                    End If
                    'End If
                Next

                '-- as long as the rule was not violated, we can say this field is true
                boolThisField = Not boolRuleViolation
        End Select

        Return boolThisField
    End Function
    Private Function MessageHasSenderMatchingValue(ByVal msg As TrulyMailMessage, _
                                                   ByVal compareType As ProcessingRuleMatchDataCompareTypeEnum, _
                                                   ByVal compareValue As String) As Boolean

        Dim boolThisField As Boolean

        Select Case compareType
            'Case ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
            '    boolThisField = msg.Sender.ContactType = AddressBookEntryType.TrulyMail AndAlso msg.Sender.ID = compareValue
            'Case ProcessingRuleMatchDataCompareTypeEnum.NotSpecificTrulyMailContact
            '    boolThisField = Not (msg.Sender.ID = compareValue)
            Case ProcessingRuleMatchDataCompareTypeEnum.SpecificEmailContact
                boolThisField = msg.Sender.Address.ToLower() = compareValue.ToLower()
            Case ProcessingRuleMatchDataCompareTypeEnum.NotSpecificEmailContact
                boolThisField = Not (msg.Sender.Address.ToLower() = compareValue.ToLower())
            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
                If msg.Sent Then
                    If msg.SMTPProfile IsNot Nothing Then
                        boolThisField = msg.SMTPProfile.DisplayEmail.ToLower.Contains(compareValue.ToLower())
                    Else
                        '-- must be sent via TrulyMail
                        boolThisField = False
                    End If
                Else
                    boolThisField = msg.Sender.Address.ToLower().Contains(compareValue.ToLower())
                End If
            Case ProcessingRuleMatchDataCompareTypeEnum.EmailAddressNotContains
                boolThisField = Not msg.Sender.Address.ToLower().Contains(compareValue.ToLower())
            Case ProcessingRuleMatchDataCompareTypeEnum.InAddressBook
                'If msg.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                '    '-- TrulyMail
                '    Dim contact As AddressBookEntry = ABook.GetContactByID(msg.Sender.ID)
                '    boolThisField = contact IsNot Nothing
                'Else
                '-- Email
                Dim contact As AddressBookEntry = ABook.GetContactByAddress(msg.Sender.Address)
                boolThisField = contact IsNot Nothing
                'End If
            Case ProcessingRuleMatchDataCompareTypeEnum.NotInAddressBook
                'If msg.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                '    '-- TrulyMail
                '    Dim contact As AddressBookEntry = ABook.GetContactByID(msg.Sender.ID)
                '    boolThisField = contact Is Nothing
                'Else
                '-- Email
                Dim contact As AddressBookEntry = ABook.GetContactByAddress(msg.Sender.Address)
                boolThisField = contact Is Nothing
                'End If
        End Select

        Return boolThisField
    End Function

    Friend Function MessageMatchesMatchRule(ByVal msg As TrulyMailMessage, ByVal rule As ProcessingRule) As Boolean
        If rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAll Then
            '-- ignore any match data (there should not be any) and just return true (always run actions from this rule)
            Return True
        Else
            Dim boolThisField As Boolean
            For Each match As ProcessingRuleMatchData In rule.MatchDatas
                boolThisField = False '-- reset
                Select Case match.MatchField
                    Case ProcessingRuleMatchFieldEnum.FieldTo
                        boolThisField = MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_To, match.CompareValue)
                    Case ProcessingRuleMatchFieldEnum.FieldCC
                        boolThisField = MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_CC, match.CompareValue)
                    Case ProcessingRuleMatchFieldEnum.FieldBCC
                        boolThisField = MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_BCC, match.CompareValue)
                    Case ProcessingRuleMatchFieldEnum.FieldToOrCC
                        boolThisField = MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_To, match.CompareValue) OrElse _
                                        MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_CC, match.CompareValue)
                    Case ProcessingRuleMatchFieldEnum.FieldFrom
                        boolThisField = MessageHasSenderMatchingValue(msg, match.CompareType, match.CompareValue)
                    Case ProcessingRuleMatchFieldEnum.FieldFromToCCOrBCC
                        boolThisField = MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_To, match.CompareValue) OrElse _
                                        MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_CC, match.CompareValue) OrElse _
                                        MessageHasRecipMatchingValue(msg, match.CompareType, RecipientType.Send_BCC, match.CompareValue) OrElse _
                                        MessageHasSenderMatchingValue(msg, match.CompareType, match.CompareValue)
                    Case ProcessingRuleMatchFieldEnum.FieldBody
                        Dim strBody As String = StripHTML(msg.Body, True).ToLower()
                        Dim strCompare As String = match.CompareValue.ToLower()
                        Select Case match.CompareType
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo
                                boolThisField = (strBody = strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo
                                boolThisField = Not (strBody = strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsEmpty
                                boolThisField = strBody.Trim().Length = 0
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty
                                boolThisField = strBody.Trim().Length > 0
                            Case ProcessingRuleMatchDataCompareTypeEnum.Contains
                                boolThisField = strBody.Contains(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotContains
                                boolThisField = Not strBody.Contains(strCompare)
                        End Select
                    Case ProcessingRuleMatchFieldEnum.FieldSubject
                        Dim strSubject As String = msg.Subject.ToLower
                        Dim strCompare As String = match.CompareValue.ToLower
                        Select Case match.CompareType
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo
                                boolThisField = (strSubject = strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo
                                boolThisField = Not (strSubject = strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.StartsWith
                                boolThisField = strSubject.StartsWith(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotStartsWith
                                boolThisField = Not strSubject.StartsWith(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.EndsWith
                                boolThisField = strSubject.EndsWith(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotEndsWith
                                boolThisField = Not strSubject.EndsWith(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.Contains
                                boolThisField = strSubject.Contains(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotContains
                                boolThisField = Not strSubject.Contains(strCompare)
                        End Select
                    Case ProcessingRuleMatchFieldEnum.FieldTags
                        Dim strTags As String = msg.Tags.ToLower()
                        Dim strCompare As String = match.CompareValue.ToLower()
                        Select Case match.CompareType
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsEqualTo
                                boolThisField = (strTags = strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotEqualTo
                                boolThisField = Not (strTags = strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsEmpty
                                boolThisField = strTags.Trim().Length = 0
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotIsEmpty
                                boolThisField = strTags.Trim().Length > 0
                            Case ProcessingRuleMatchDataCompareTypeEnum.Contains
                                boolThisField = strTags.Contains(strCompare)
                            Case ProcessingRuleMatchDataCompareTypeEnum.NotContains
                                boolThisField = Not strTags.Contains(strCompare)
                        End Select
                    Case ProcessingRuleMatchFieldEnum.FieldSendingAccount
                        Dim strCompare As String = match.CompareValue.ToLower()
                        Select Case match.CompareType
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsSMTPAccount
                                boolThisField = msg.Sent AndAlso msg.SMTPProfile IsNot Nothing AndAlso msg.SMTPProfile.ID.ToLower() = strCompare
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotSMTPAccount
                                boolThisField = (msg.Sent AndAlso msg.SMTPProfile Is Nothing) OrElse (msg.Sent AndAlso msg.SMTPProfile IsNot Nothing AndAlso Not (msg.SMTPProfile.ID.ToLower() = strCompare))
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsTrulyMailAccount
                                '-- do nothing 'boolThisField = msg.Sent AndAlso msg.SMTPProfile Is Nothing
                            Case ProcessingRuleMatchDataCompareTypeEnum.IsNotTrulyMailAccount
                                '-- do nothing 'boolThisField = msg.Sent AndAlso msg.SMTPProfile IsNot Nothing
                        End Select
                End Select

                If Not boolThisField AndAlso rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd Then
                    Return False '-- one failed, so return false
                ElseIf boolThisField AndAlso rule.MatchType = ProcessingRuleMatchTypeEnum.MatchOr Then
                    Return True '-- one matched, so return true
                End If
            Next

            '-- if we get here, then either 
            If rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd Then
                '-- we matchand and all were matched, so return true,
                Return True
            Else
                '-- or we matchor and all were false, so return false
                Return False
            End If
        End If
    End Function
    Friend Function PerformRuleActionOnMessage(ByVal msg As TrulyMailMessage, ByVal rule As ProcessingRule, logDetails As ReceiveFileDetails) As Boolean
        Dim boolReturn As Boolean = True '-- only return false if message was delete (perm) as no other actions can be performed

        For Each action As ProcessingRuleActionData In rule.Actions
            Select Case action.ActionType
                Case ProcessingRuleActionTypeEnum.AddToMessageImportance
                    If IsNumeric(action.ActionValue) Then
                        logDetails.AddDetail("Adding importance to message: " & action.ActionValue)
                        msg.Importance += ConvertToInt32(action.ActionValue, 0)
                        If AppSettings.AddNoteForProcessingRuleAction Then
                            msg.Notes &= "Processing rule (" & rule.Name & "): Adding importance to message: " & action.ActionValue & Environment.NewLine & Environment.NewLine
                        End If
                        msg.Save()
                    Else
                        Log("Non-numeric importance: " & action.ActionValue)
                    End If
                Case ProcessingRuleActionTypeEnum.SetMessageImportance
                    If IsNumeric(action.ActionValue) Then
                        logDetails.AddDetail("Setting message importance: " & action.ActionValue)
                        msg.Importance = ConvertToInt32(action.ActionValue, 0)
                        If AppSettings.AddNoteForProcessingRuleAction Then
                            msg.Notes &= "Processing rule (" & rule.Name & "): Setting message importance: " & action.ActionValue & Environment.NewLine & Environment.NewLine
                        End If
                        msg.Save()
                    Else
                        Log("Non-numeric importance: " & action.ActionValue)
                    End If
                Case ProcessingRuleActionTypeEnum.DisplayMsgBox
                    ShowMessageBox(action.ActionValue, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Case ProcessingRuleActionTypeEnum.AddTag
                    logDetails.AddDetail("Adding tag to message: " & action.ActionValue)
                    If msg.Tags.Length > 0 Then
                        msg.Tags &= " "
                    End If
                    msg.Tags &= action.ActionValue
                    If AppSettings.AddNoteForProcessingRuleAction Then
                        msg.Notes &= "Processing rule (" & rule.Name & "): Adding tag to message: " & action.ActionValue & Environment.NewLine & Environment.NewLine
                    End If
                    msg.Save()
                Case ProcessingRuleActionTypeEnum.DeleteMessagePermanently
                    logDetails.AddDetail("Deleting message permanently.")
                    DeleteLocalMessage(msg.Filename, True, True)
                    msg.Filename = String.Empty
                    boolReturn = False
                Case ProcessingRuleActionTypeEnum.DeleteMessageToTrash
                    logDetails.AddDetail("Moving message to trash.")
                    Dim strNewFolder As String = TrashRootPath
                    Dim strNewFilename As String = QualifyPath(strNewFolder) & System.IO.Path.GetFileName(msg.Filename)
                    DeleteLocalMessage(msg.Filename, False, True)
                    msg.Filename = strNewFilename
                    If AppSettings.AddNoteForProcessingRuleAction Then
                        msg.Notes &= "Processing rule (" & rule.Name & "): Moving message to trash." & Environment.NewLine & Environment.NewLine
                    End If
                    msg.Save()
                Case ProcessingRuleActionTypeEnum.MoveMessageTo
                    logDetails.AddDetail("Moving message to : " & action.ActionValue)
                    Dim strNewFolder As String = action.ActionValue
                    '-- Changed Sept 2012 to just create folder if it does not already exist
                    'If System.IO.Directory.Exists(strNewFolder) Then
                    Dim strNewFilename As String = QualifyPath(strNewFolder) & System.IO.Path.GetFileName(msg.Filename)
                    Try
                        Dim strDestinationFolder As String = System.IO.Path.GetDirectoryName(strNewFilename)
                        If Not System.IO.Directory.Exists(strDestinationFolder) Then
                            System.IO.Directory.CreateDirectory(strDestinationFolder)
                            MainFormReference.AddFolderToFolderTree(strDestinationFolder)
                        End If
                        System.IO.File.Move(msg.Filename, strNewFilename)
                        msg.Filename = strNewFilename
                        If AppSettings.AddNoteForProcessingRuleAction Then
                            msg.Notes &= "Processing rule (" & rule.Name & "): Moving message to : " & action.ActionValue & Environment.NewLine & Environment.NewLine
                        End If
                        msg.Save()
                    Catch ex As Exception
                        Log("[Rule: " & rule.Name & "] Error moving message to " & strNewFolder)
                        Log(ex)
                    End Try
                    'Else
                    'Log("[Rule: " & rule.Name & "] Cannot move message to " & strNewFolder & " because folder does not exist.")
                    'End If
                Case ProcessingRuleActionTypeEnum.MarkAsRead
                    logDetails.AddDetail("Marking message as read.")
                    MarkLocalMessageRead(msg.Filename, False)
                    msg.Read = True
                    If AppSettings.AddNoteForProcessingRuleAction Then
                        msg.Notes &= "Processing rule (" & rule.Name & "): Marking message as read." & Environment.NewLine & Environment.NewLine
                    End If
                    msg.Save()
                Case ProcessingRuleActionTypeEnum.PlaySound
                    logDetails.AddDetail("Playing sound: " & action.ActionValue)
                    Dim strSoundFile As String = MySoundsPath & action.ActionValue
                    If System.IO.File.Exists(strSoundFile) Then
                        My.Computer.Audio.Play(strSoundFile)
                        If AppSettings.AddNoteForProcessingRuleAction Then
                            msg.Notes &= "Processing rule: Playing sound: " & action.ActionValue & Environment.NewLine & Environment.NewLine
                        End If
                        msg.Save()
                    Else
                        Log("Cannot play sound file (" & rule.Name & "): " & strSoundFile)
                    End If

                    'Case ProcessingRuleActionTypeEnum.DisplaySysTrayPopup
                    'Case ProcessingRuleActionTypeEnum.ForwardMessageTo
                    'Case ProcessingRuleActionTypeEnum.ReplyWithText
            End Select
        Next

        Return boolReturn
    End Function
    Public Sub NewProcessingRuleFromSender(tm As TrulyMailMessage)
        Try
            Dim rule As New ProcessingRule()
            rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd
            Dim data As New ProcessingRuleMatchData

            Dim action As New ProcessingRuleActionData()
            action.ActionType = ProcessingRuleActionTypeEnum.AddTag

            If Not tm.Sent Then
                '-- received
                rule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage
                'If tm.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                '    rule.Name = "Msgs from " & tm.Sender.FullName
                '    action.ActionValue = "from " & tm.Sender.FullName
                '    data.CompareType = ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
                '    data.MatchField = ProcessingRuleMatchFieldEnum.FieldFrom
                '    data.CompareValue = tm.Sender.ID
                '    rule.MatchDatas.Add(data)
                'ElseIf tm.Sender.ContactType = AddressBookEntryType.Email Then
                If tm.Sender.ContactType = AddressBookEntryType.Email Then
                    rule.Name = "Msgs from " & tm.Sender.Address
                    action.ActionValue = "from " & tm.Sender.Address
                    data.CompareType = ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
                    data.MatchField = ProcessingRuleMatchFieldEnum.FieldFrom
                    data.CompareValue = tm.Sender.Address
                    rule.MatchDatas.Add(data)
                Else
                    '-- cannot be else (but maybe in the future)
                End If
            Else
                '-- sent (match all sent messages)
                rule.Name = "All sent messages"
                action.ActionValue = "sent msg"
                rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAll
                rule.TriggerType = ProcessingRuleTriggerTypeEnum.SendMessage
            End If

            rule.Actions.Add(action)

            Using frm As New EditProcessingRuleForm(rule)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    AppSettings.ProcessingRules.Add(rule)
                End If
            End Using
        Catch ex As Exception
            Log(ex)
            Throw (ex)
        End Try
    End Sub
    Public Sub NewProcessingRuleFromSubject(tm As TrulyMailMessage)
        Try
            Dim rule As New ProcessingRule()
            rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd
            Dim data As New ProcessingRuleMatchData

            Dim action As New ProcessingRuleActionData()
            action.ActionType = ProcessingRuleActionTypeEnum.AddTag

            If Not tm.Sent Then
                '-- received
                rule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage
            Else
                '-- sent
                rule.TriggerType = ProcessingRuleTriggerTypeEnum.SendMessage
            End If

            Dim strBaseSubject As String = GetBaseSubject(tm.Subject)

            rule.Name = "Subject contains " & strBaseSubject
            data.MatchField = ProcessingRuleMatchFieldEnum.FieldSubject
            data.CompareType = ProcessingRuleMatchDataCompareTypeEnum.Contains
            data.CompareValue = strBaseSubject
            action.ActionValue = "Subject contains " & strBaseSubject
            rule.MatchDatas.Add(data)

            rule.Actions.Add(action)

            Using frm As New EditProcessingRuleForm(rule)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    AppSettings.ProcessingRules.Add(rule)
                End If
            End Using
        Catch ex As Exception
            Log(ex)
            Throw (ex)
        End Try
    End Sub
End Module
