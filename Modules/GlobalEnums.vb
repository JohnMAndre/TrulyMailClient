Module GlobalEnums
    Friend Enum PackageOpeningStatus
        ReadingPackage
        ReadPackage
        ConnectingToServer
        ConnectedToServer
        GettingKey
        GotKey
        DecryptingPackage
        DecryptedPackage
        OpeningPackage
        Complete
    End Enum
    Friend Enum AutoUpdateSetting
        InstallAutomatically
        DownloadAndNotify
        NotifyBeforeDownload
        IgnoreExceptRequired
    End Enum
    Friend Enum ReplyPostModeEnum
        ReplyAboveQuote
        ReplyBelowQuote
    End Enum
    Friend Enum SendReceiveTriggerEnum
        None '-- only when not sending/receiving
        Automatic
        Manual
    End Enum
    Friend Enum MarkMessageType
        Reply
        Forward
    End Enum
    Friend Enum ModifyOnSend
        None
        Delete
        MarkForward
        MarkReply
    End Enum
    Friend Enum RecipientType
        Send_To
        Send_CC
        Send_BCC
    End Enum
    Friend Enum MessageResponseType
        Reply
        ReplyToAll
        Forward
        Resend
        FollowUp
        ReplyNoBody
        ReplyToAllNoBody
        ForwardNoAttachments
    End Enum
    Friend Enum UpdateType
        Unknown
        NoUpdate
        RecommendedUpdate
        RequiredUpdate
    End Enum
    Friend Enum ContextError
        None
        Timeout
        LoginError
        UserCancel
        VersionTooOld
        TooManyFailedByIP
        TooManyFailedByUsername
        LoginSuspended
        UsernamePasswordInvalid
    End Enum
    Friend Enum MessageTransportType
        TrulyMail
        Email
        Mixed
        RSS
        WebPageMonitor
        EncryptedWebMessage
        TM2TM
        InternalOnly
    End Enum
    Friend Enum EmailAttachmentType
        Ignore
        Attachment
        Embedded
    End Enum
    Friend Enum EncryptionStatus
        NotEncrypted
        Encrypted
        PartiallyEncrypted '-- not to email but encrypted to TM recipients
    End Enum
    Friend Enum EmailBodyFormatEnum
        HTML
        PlainText
        MixedPainTextAndHTML
    End Enum
    Friend Enum ImageResizePromptFrequencyEnum
        EveryImage
        EveryMessage
        NeverAgain
    End Enum
    Friend Enum ImageResizeSizeEnum
        None '-- do not resize
        x640 '640x480
        x800 '800x600
        x1024 '1024x768
        x1600 '1600x1200
    End Enum
    Friend Enum EncryptedEmailType
        ClearText
        EncrypedTM2TMEmail
    End Enum
    Public Enum EmailCheckingEnum
        ForceAll
        AtStartup
        DueToCheck
    End Enum
    Public Enum LocalFileEncryptionStatus
        Decrypted '-- all files are in clear text
        Decrypting '-- in the process of decrypting
        Encrypting '-- in the process of encrypting
        Encrypted '-- all files are encrypted
    End Enum
    Public Enum EncryptionLevelEnum
        Unknown '-- Something for a default value
        Version3 '-- from TM version 3 and before
        Version4 '-- from TM version 4
        Version5Strong '-- Introduced in TM version 5.1 to be strong (for settings encryption which happens rarely and sensitive to speed)
        Version5Fast '-- Introduced in TM version 5.1 to be fast (for message encryption which happens A LOT)
    End Enum
End Module
