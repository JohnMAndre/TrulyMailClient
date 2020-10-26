Module GlobalConstants
    Friend Const INBOX_NAME As String = "InBox"
    Friend Const OUTBOX_NAME As String = "Outbox"
    Friend Const UNSENT_NAME_PREVIOUS As String = "Unsent"
    Friend Const TRASH_NAME As String = "Trash"
    Friend Const ATTACHMENTS_FOLDER_NAME As String = "Attachments"
    Friend Const DRAFTS_FOLDER_NAME As String = "Drafts"
    Friend Const PICTURES_FOLDER_NAME As String = "Pictures"
    Friend Const SOUNDS_FOLDER_NAME As String = "Sounds"
    Friend Const ENCRYPTION_KEYS_FOLDER_NAME As String = "Keys"
    Friend Const KEY_FILENAME_EXTENSION As String = ".key"
    Friend Const SENTITEMS_NAME As String = "Sent Items"
    Friend Const MESSAGE_FILENAME_EXTENSION As String = ".tmm"
    Friend Const CONTACT_PICTURE_FILENAME_EXTENSION As String = ".png"
    Friend Const ENCRYPTED_EMAIL_PACKAGE_FILE_EXTENSION As String = ".TrulyPrivate"
    Friend Const REGEX_MESSAGE_FILENAME As String = ".\.tmm"
    Friend Const REGEX_ALL_FILES As String = "."
    Friend Const ATTRIBUTE_NAME_RECEIVED_DATE As String = "Received"
    Friend Const ATTRIBUTE_NAME_READ_DATE As String = "Read"
    Friend Const ATTACHMENTS_FOLDER_REPLACEMENT_CODE As String = "{[ATTACHMENTSFOLDER]}"
    Friend Const MESSAGEID_REPLACEMENT_CODE As String = "{[MESSAGEID]}"
    Friend Const IMAGES_EMBEDDED_FOLDER As String = "Images\"
    Friend Const IMAGES_EMBEDDED_FOLDER_IN_ZIP As String = "Images/" '-- different directory separator
    Friend Const PASSWORD_ENCRYPTION_KEY As String = "8748ADD1-9501-4cc0-A9E8-8B547E84595D"
    Friend Const DICTIONARY_FOLDER_NAME As String = "dictionaries"
    Friend Const ENCRYPTED_TITLEBAR_TEXT As String = "[Encrypted]"
    Friend Const UNENCRYPTED_TITLEBAR_TEXT As String = "[Not Encrypted]"
    Friend Const PARTIALLYENCRYPTED_TITLEBAR_TEXT As String = "[Encrypted to TrulyMail Recipients Only]"
    Friend Const EMAIL_CONTENTID_CODE As String = "cid:"
    Friend Const BLOCKED_IMAGE_SCR_PREFIX As String = "---"

    '-- Constants from Server.Login
    Friend Const ENCRYPTION_ENABLED As String = "EncryptionEnabled"
    Friend Const LASTEST_VERSION As String = "LatestVersion"
    Friend Const MESSAGEID_VARIABLE_NAME As String = "MessageID"

    Friend Const MESSAGETYPE_COMMUNICATION As String = "dcc232ee-4b59-4742-9b72-c667cc235702"
    Friend Const MESSAGETYPE_DRAFT_COMMUNICATION As String = "b2525f9d-c869-468c-954b-4b4d0285b400" '-- not on server, just for local use
    Friend Const MESSAGETYPE_NOTE_TO_SELF As String = "24de5ca6-e6fa-4ce0-a261-729f17dda3d1"
    Friend Const MESSAGETYPE_RSSARTICLE As String = "624fc688-f06a-4310-b0b5-63989d0bf78c"

    Friend Const ROLEID_TO As String = "e9688fad-d3ff-405e-aa11-1761de0834e6"
    Friend Const ROLEID_CC As String = "2ced15c3-a21d-49ff-98f9-d7cea34b182c"
    Friend Const ROLEID_BCC As String = "bb5d663a-ec1e-443b-9ae4-64d32ed81346"
    Friend Const ROLEID_FROM As String = "f3a6eca1-b07d-4167-86e6-6092733fdacb"

    Friend Const DATEFORMAT_XML As String = "yyyy'-'MM'-'ddTHH':'mm':'ss'.'fff" '-- used to be "yyyy-MM-ddTHH:mm:ss.fff" but diff cultures were throwing things into chaos
    Friend Const DATEFORMAT_XML_DATEONLY As String = "yyyy'-'MM'-'dd" '-- changed for same reason as above, just in case. was: "yyyy-MM-dd"
    Friend Const DATEFORMAT_FILENAME As String = "yyyyMMddHHmmssfff"

    Friend Const RECEIPTTYPEID_RECEIVE As String = "3e738193-127d-4282-866c-10f275b4caf5"
    Friend Const RECEIPTTYPEID_READ As String = "45b356fa-b64a-4721-a5da-ebbb68eb012f"

    Friend Const ADDRESS_BOOK_FILENAME As String = "addressbook.xml"
    Friend Const UNKNOWN_USER As String = "Unknown User"

    Friend Const ADDRESS_TO As String = "To"
    Friend Const ADDRESS_CC As String = "CC"
    Friend Const ADDRESS_BCC As String = "BCC"

    Friend Const BODYFORMAT_HTML As String = "HTML"
    Friend Const BODYFORMAT_PLAINTEXTANDHTML As String = "MixedPlainTextAndHTML"
    Friend Const BODYFORMAT_PLAINTEXT As String = "PlainText"

    '-- Version 1 encryption introduced in TM 3.0
    Friend Const ENCRYPTION_1_SUBJECT As String = "$$##%%%^^~~$$" '-- this in the subject line triggers 3.0 encryption/decryption routines
    Friend Const ENCRYPTION_1_DELIMITER As String = "&&&@@&&&%%$$#" '-- this delimits between key, subject, and message body
    Friend Const ENCRYPTION_1_SYMMETRIC_IDENTIFIER As String = "!" '-- this will be the first character in encrypted text if version 1 encryption was used

    '-- Version 5 (jumped from 2) encryption in TM5.1
    Friend Const ENCRYPTION_5FAST_SYMMETRIC_IDENTIFIER As String = "&" '-- this will be the first character in encrypted text if version 5Fast encryption was used
    Friend Const ENCRYPTION_5STRONG_SYMMETRIC_IDENTIFIER As String = "%" '-- this will be the first character in encrypted text if version 5Strong encryption was used

    '-- Version 2 encryption introduced in TM 4.0
    Friend Const ENCRYPTION_2_SUBJECT As String = "@@##%%%^^~~$$" '-- this in the subject line triggers 4.0 encryption/decryption routines
    Friend Const ENCRYPTION_2_DELIMITER As String = "**&@@&&&%%$$#" '-- this delimits between key, subject, and message body
    Friend Const ENCRYPTION_2_SYMMETRIC_IDENTIFIER As String = "*" '-- this will be the first character in encrypted text if version 2 encryption was used

    Friend Const MESSAGE_ATTRIBUTE_NAME_ADDRESS As String = "Address"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ADDRESSES As String = "Addresses"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ACCEPTDATE As String = "AcceptDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ATTACHMENTCYPHERIV As String = "Support"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ATTACHMENTCYPHERKEY As String = "Reference"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS As String = "Attachments"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ATTACHMENT As String = "Attachment"
    Friend Const MESSAGE_ATTRIBUTE_NAME_BODY As String = "Body"
    Friend Const MESSAGE_ATTRIBUTE_NAME_CONTACT_RECEIVEONLY As String = "ContactReceiveOnly"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ENCRYPTED As String = "Encrypted"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE As String = "EncryptedEmail"
    'Friend Const MESSAGE_ATTRIBUTE_NAME_ENCRYPTED_EMAIL As String = "EncryptedToEmailAddresses"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME As String = "EncryptedFilename"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDPACKAGEKEY As String = "EncryptionKey" '-- for .TrulyPrivate files
    Friend Const MESSAGE_ATTRIBUTE_NAME_EMAILREPLYTO As String = "ReplyTo"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FILESIZE As String = "FileSize"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FILEID As String = "FileID"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FILENAME As String = "Name"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FILEHASH As String = "Hash"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FORMAT As String = "Format"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FORWARDED As String = "Forwarded"
    Friend Const MESSAGE_ATTRIBUTE_NAME_FULLNAME As String = "FullName"
    Friend Const MESSAGE_ATTRIBUTE_NAME_HEADER As String = "Header"
    Friend Const MESSAGE_ATTRIBUTE_NAME_HEADERS As String = "Headers"
    Friend Const MESSAGE_ATTRIBUTE_NAME_IMPORTANCE As String = "Importance"
    Friend Const MESSAGE_ATTRIBUTE_NAME_KEEPCOPYAFTERSEND As String = "KeepCopyAfterSend"
    Friend Const MESSAGE_ATTRIBUTE_NAME_LASTSAVEDATE As String = "LastSaveDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE As String = "MessageSize"
    Friend Const MESSAGE_ATTRIBUTE_NAME_MESSAGE As String = "Message"
    Friend Const MESSAGE_ATTRIBUTE_NAME_MESSAGEID As String = "MessageID"
    Friend Const MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID As String = "MessageTypeID"
    Friend Const MESSAGE_ATTRIBUTE_NAME_NAME As String = "Name"
    Friend Const MESSAGE_ATTRIBUTE_NAME_NEWSLETTERMODE As String = "NewsletterMode"
    Friend Const MESSAGE_ATTRIBUTE_NAME_NOTES As String = "Notes"
    Friend Const MESSAGE_ATTRIBUTE_NAME_NOTESSPLITTER As String = "Splitter"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ORIGINALMESSAGEID As String = "OriginalMessageID"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ORIGINALMESSAGEFILENAME As String = "OriginalMessageFilename"
    Friend Const MESSAGE_ATTRIBUTE_NAME_POPACCOUNT As String = "POPAccount"
    Friend Const MESSAGE_ATTRIBUTE_NAME_QUESTION As String = "Question" '-- for web message replies
    Friend Const MESSAGE_ATTRIBUTE_NAME_READ As String = "Read"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RECIPIENTID As String = "RecipientID" '-- used in local messages as userid
    Friend Const MESSAGE_ATTRIBUTE_NAME_RECIPIENTUSERID As String = "RecipientUserID" '-- used in resend as userid only
    Friend Const MESSAGE_ATTRIBUTE_NAME_RECIPIENT As String = "Recipient"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RECIPIENTS As String = "Recipients"
    Friend Const MESSAGE_ATTRIBUTE_NAME_REJECTDATE As String = "RejectDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RECEIVED As String = "Received"
    Friend Const MESSAGE_ATTRIBUTE_NAME_REPLIED As String = "Replied"
    Friend Const MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT As String = "RequestReturnReceipt"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RESENTDATE As String = "ResentDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RESPONSETYPE As String = "ResponseType"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ROLE As String = "Role"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ROLEID As String = "RoleID"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RSSITEM As String = "RSSItem"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RSSLINK As String = "Link"
    Friend Const MESSAGE_ATTRIBUTE_NAME_RSSPUBDATE As String = "PubDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE As String = "SendAfter"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SENTDATE As String = "SentDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SENDERADDRESS As String = "SenderAddress"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME As String = "SenderFullName"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SENDERUSERID As String = "SenderUserID"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SHOWREMOTEIMAGES As String = "ShowRemoteImages"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT As String = "SMTPAccount"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SPAM As String = "Spam"
    Friend Const MESSAGE_ATTRIBUTE_NAME_SUBJECT As String = "Subject"
    Friend Const MESSAGE_ATTRIBUTE_NAME_TAGS As String = "Tags"
    Friend Const MESSAGE_ATTRIBUTE_NAME_TRULYMAILVERSION As String = "TrulyMailVersion"
    Friend Const MESSAGE_ATTRIBUTE_NAME_UNSENTDATE As String = "UnsentDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEQUESTION As String = "WebMessageQuestion"
    Friend Const MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEPASSWORD As String = "WebMessagePassword"
    Friend Const MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEEXPIRATIONDATE As String = "ExpirationDate"
    Friend Const MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEEXPIRATIONDAYSAFTERREAD As String = "ExpirationDaysAfterRead"
    Friend Const MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEATTACHMENTPASSWORD As String = "WebMessageAttachmentPassword"
    Friend Const MESSAGE_ATTRIBUTE_NAME_TM2TMPASSWORD As String = "TM2TMPassword"
    Friend Const MESSAGE_ATTRIBUTE_NAME_ZIPATTACHMENTS As String = "ZipAttachments"
    Friend Const MESSAGE_ATTRIBUTE_NAME_READRECEIPTSENT As String = "ReadReceiptSent"

    Friend Const RETURN_RECEIPT_SUBJECT = "Return Receipt (displayed) - "


    Friend Const STANDARD_SERVER_TIMEOUT As Integer = 15000 '-- 10 sec
    Friend Const STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY As Integer = 30 '-- 30 seconds to auto-close an auto-close messagebox

    Friend Const STATUS_READY As String = "Ready"
    Friend Const STATUS_CONNECTING As String = "Securely connecting to TrulyMail server"
    Friend Const STATUS_GETTING_NEW_EXTERNAL_MESSAGES As String = "Getting new messages from server"
    Friend Const STATUS_GETTING_NEW_MESSAGES As String = "Getting new messages from server"
    Friend Const STATUS_GETTING_EXTERNAL_MESSAGE_NUMBER As String = "Getting web reply: "
    Friend Const STATUS_GETTING_MESSAGE_NUMBER As String = "Getting message: "
    Friend Const STATUS_GETTING_NEW_EXTERNAL_RECEIPTS As String = "Getting new web receipts from server"
    Friend Const STATUS_GETTING_NEW_RECEIPTS As String = "Getting new receipts from server"
    Friend Const STATUS_PROCESSING_RECEIPT_NUMBER As String = "Processing receipt: "
    Friend Const STATUS_GETTING_RECEIPT_NUMBER As String = "Getting receipt: "
    Friend Const STATUS_SENDING_UNSENT As String = "Sending unsent items"
    Friend Const STATUS_DOWNLOADING_ATTACHMENTS As String = "Downloading attachments "
    Friend Const STATUS_SENDING_UNSENT_NUMBER As String = "Sending message: "
    Friend Const STATUS_SENDING_MESSAGE As String = "Sending message"
    Friend Const STATUS_PREPARING_LOGFILE As String = "Preparing log file"
    Friend Const STATUS_SENDING_LOGFILE As String = "Sending log file"
    Friend Const STATUS_PREPARING_TO_SEND As String = "Preparing to send"
    Friend Const STATUS_PREPARING_TO_UNSEND As String = "Preparing to unsend"
    Friend Const STATUS_UNSENDING As String = "Unsending message"
    Friend Const STATUS_CHARACTERS_REMAINING As String = "Characters remaining: "
    Friend Const STATUS_GENERATING_NEW_KEYS As String = "Generating new encryption keys"
    Friend Const STATUS_UPDATING_SERVER As String = "Updating server"
    Friend Const STATUS_BACKINGUP_DATA As String = "Backing up to server"
    Friend Const STATUS_RESTORING_DATA As String = "Restoring from server"
    Friend Const STATUS_DONE As String = "Done"
    Friend Const STATUS_ERRORS As String = "Error Occurred"
    Friend Const STATUS_CHECK_FOR_NEW_KEYS As String = "Checking server for new encryption keys for contact"
    Friend Const STATUS_CHECK_CONNECTIONS As String = "Checking several websites for connectivity, please wait."
    Friend Const STATUS_CHECKING_WEBSITE As String = "Checking website: "

    Friend Const ARCHIVE_ATTACHMENT_FILENAME As String = "archive.tma"
    Friend Const MASTER_ARCHIVE_FILENAME As String = "tm.tmc"
    Friend Const NEW_MESSAGE_DETAILS_FILENAME As String = "details.xml" '-- name of xml file use when calling NewMessage in MessageTransmitter
    Friend Const EXE_FILE_EXTENSIONS As String = ".ade;.adp;.air;.bas;.bat;.btm;.chm;.cmd;.cod;.com;.cpl;.crt;.dll;.exe;.fmx;.hlp;.hta;.ipf;.jar;.js;.jse;.lnk;.mde;.msc;.msi;.msp;.pe;.pgm;.pif;.prc;.prg;.reg;.sav;.scr;.sct;.shs;.vb;.vbe;.vbs;.widget;.wsc;.wsf;.wsh;.xlink"

    Friend Const DICTIONARY_FILENAME_EXTENSION_PREVIOUS As String = ".dic"
    Friend Const DICTIONARY_FILENAME_EXTENSION As String = ".dct"
    Friend Const DICTIONARY_USER_DICT_FILENAME As String = "userWords.dct"
    Friend Const SOURCE_STRING As String = "src"

    Friend Const EMAIL_RETURN_RECEIPT_REQUEST_HEADER_NAME_1 As String = "Disposition-Notification-To"
    Friend Const EMAIL_RETURN_RECEIPT_REQUEST_HEADER_NAME_2 As String = "Return-Receipt-To"
    Friend Const EMAIL_MAILER_HEADER_NAME_1 As String = "X-Mailer"
    Friend Const EMAIL_MAILER_HEADER_NAME_2 As String = "User-Agent"

    Friend Const ATTACHMENT_ENCRYPTION_KEY_LENGTH_PREVIOUS As Integer = 512
    Friend Const ATTACHMENT_ENCRYPTION_KEY_LENGTH As Integer = 36

    Friend Const NOTIFY_SOUND_VALID_EXTENSION As String = ".wav"
    Friend Const NOTIFY_SOUND_DEFAULT As String = "Default"
    Friend Const NOTIFY_SOUND_APPSOUNDS As String = "AppSounds"
    Friend Const NOTIFY_SOUND_USERSOUNDS As String = "UserSounds"

    Friend Const TOOLBAR_16_HEIGHT As Integer = 25
    Friend Const TOOLBAR_32_HEIGHT As Integer = 39
    Friend Const TOOLSTRIPCONTAINER_TEXT_EXTRA_HEIGHT As Integer = 15

    Friend Const SUBJECT_PREFIX_REPLY As String = "Re: "
    Friend Const SUBJECT_PREFIX_REPLY_ALT As String = "Re : " '-- iphone email seems to do this
    Friend Const SUBJECT_PREFIX_FORWARD As String = "Fwd: "
    Friend Const SUBJECT_PREFIX_RESEND As String = "Resend: "
    Friend Const SUBJECT_PREFIX_FOLLOWUP As String = "Follow Up: "

    Friend Const SERVER_PUBLIC_KEY As String = "<RSAKeyValue><Modulus>jgnJZ/GUNcbl1BeBb521D3uNQabfC3rTTGoTp4KqVtICqdgST26nXprmxwxrFPAe+SjcbmirbsAmlX/VLoICp7M42kcGD0qYe8l1gETBdR3dLiLnMzaJnoJEPhmM4Tu/udboqk84JYWbonsgThKi1rlNG7wFFqfwgBgRWCt/e3sLRq9bPZBY27pGy9OqFaa64HpA3YnOK/7ZVHF488jDSa6LoBdLAFfMuS87MpGVWAUmMhvnSwXMAmJP+xgtChHh7UOVhG5w3bdnoWjXvvqro2jtaQBMPLh6y+d8MBEDSoRwJOJ9oGvPnH5FKTXctL0g4xkU6eKM+89gIq/xXe6BNNqF/ySFYTamkFKA01K9ogSVb6WI/7m4wofxW8MsgEC+9n0UnWu0nWY3gsSYob8TOhY9m7DfdDbTk2oNf1XuSb0P96N5KWuxi1DrERss/J/yf6ExmzfO++J1JnNXp6mpX3F6etWZrIDrAWphR2McvuBuz7vqa4vV2U0PKFZCCVtLlpu9YKnwxJnud/e9Px+sFM/myJDEJEgrH5l/l0vu4qofOpS5IPl+dbh44QYqFA1eQf/6mIfgFiJd73msQ1fZw1CGCiUQNC4HixuLE9VAvS4oG5rNXWkqe8CB6VLYJX1LWQfC7H5E7nN2Z3OFY+DrgzidgQMrBNUvqY2lF0eYpys=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"

    Friend Const PREMIUM_FEATURE_ENABLED_VARIABLE_NAME As String = "PremiumFeatureEnabled"


    Friend Const NEWSLETTER_REPLACEMENTCODE_ADDRESS As String = "[@@@REPLACEMENT_ADDRESS@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_NAME As String = "[@@@REPLACEMENT_NAME@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_TAGS As String = "[@@@REPLACEMENT_TAGS@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_CUSTOM1 As String = "[@@@REPLACEMENT_CUSTOM1@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_CUSTOM2 As String = "[@@@REPLACEMENT_CUSTOM2@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_CUSTOM3 As String = "[@@@REPLACEMENT_CUSTOM3@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_CUSTOM4 As String = "[@@@REPLACEMENT_CUSTOM4@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_DATELASTRECEIVED As String = "[@@@REPLACEMENT_DATELASTRECEIVED@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_DATELASTSENT As String = "[@@@REPLACEMENT_DATELASTSENT@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_HOME As String = "[@@@REPLACEMENT_HOME@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_WORK As String = "[@@@REPLACEMENT_WORK@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_MOBILE As String = "[@@@REPLACEMENT_MOBILE@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_WEB As String = "[@@@REPLACEMENT_WEB@@@]"
    Friend Const NEWSLETTER_REPLACEMENTCODE_DATEADDED As String = "[@@@REPLACEMENT_DATEADDED@@@]"


    '-- not really a constant, but we'll treat it as one
    Friend CONTACT_TRULYMAIL_MESSAGE As String = Environment.NewLine & Environment.NewLine & "Please contact TrulyMail Support at Support@TrulyMail.com."
    Friend CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE As String = Environment.NewLine & Environment.NewLine & "If problems persist, please contact TrulyMail Support at Support@TrulyMail.com."

    Friend DATE_NEVER As Date = New Date(2008, 1, 1)

#Region " Exception Constants "
    Friend Const EXCEPTIONTEXT_UNEXPECTED_ERROR As String = "Unexpected error"
    Friend Const EXCEPTIONTEXT_INVALID_ADDRESS As String = "Invalid recipient address"
    Friend Const EXCEPTIONTEXT_USERS_ALREADY_RELATED As String = "Users already related"
    Friend Const EXCEPTIONTEXT_SERVER_CALL_TIMEOUT As String = "Server call timeout"
    Friend Const EXCEPTIONTEXT_INVALID_CONTEXTID As String = "Context is invalid or expired."
    Friend Const EXCEPTIONTEXT_CLOSED_ACCOUNTS_CANNOT_SEND_MESSAGES As String = "Closed accounts cannot send messages"
    Friend Const EXCEPTIONTEXT_USER_HAS_NO_REMAINING_SIZE_ALLOWANCE As String = "User has no remaining size allowance"
    Friend Const EXCEPTIONTEXT_CANNOT_CREATE_MESSAGE As String = "Cannot create message"
    Friend Const EXCEPTIONTEXT_UNABLE_TO_CONNECT_TO_SERVER As String = "Unable to connect to the remote server"
    Friend Const EXCEPTIONTEXT_ATTEMPT_TO_ADD_INVALID_USER_TO_MESSAGE As String = "Attempted to add invalid user to message."
    Friend Const EXCEPTIONTEXT_RECIPIENT_ACCOUNT_CLOSED As String = "Specified recipient's account has been closed."
    Friend Const EXCEPTIONTEXT_RECIPIENT_AND_SENDER_ARE_BLOCKED As String = "Recipient and sender are blocked from communicating with each other."
    Friend Const EXCEPTIONTEXT_RECIPIENT_AND_SENDER_NOT_CONNECTED As String = "Recipient and sender are not connected."
    Friend Const EXCEPTIONTEXT_HASH_VALUES_DO_NOT_MATCH As String = "Hash values do not match."
    Friend Const EXCEPTIONTEXT_FILE_DOES_NOT_EXIST As String = "File does not exist."
    Friend Const EXCEPTIONTEXT_ERROR_ADDING_ATTACHMENT As String = "Error adding attachment."
    Friend Const EXCEPTIONTEXT_ERROR_BACKING_UP_ADDRESS_BOOK As String = "Error backing up address book."
    Friend Const EXCEPTIONTEXT_ENCRYPTED_ADDRESS_BOOK_USER_HAS_NO_ENCRYPTION As String = "Encrypted addressbook received for account without encryption."
    Friend Const EXCEPTIONTEXT_DATA_WAS_CORRUPTED As String = "Data was corrupted."
    Friend Const EXCEPTIONTEXT_NO_BACKUP_FOUND_FOR_USER As String = "No backup found for user."
    Friend Const EXCEPTIONTEXT_ERROR_GETTING_BACKUP As String = "Error getting backup."
    Friend Const EXCEPTIONTEXT_IS_NOT_A_VALID_ZIP_FILE As String = "is not a valid zip file"
    Friend Const EXCEPTIONTEXT_INVOCATION_TARGET_EXCEPTION As String = "Exception has been thrown by the target of an invocation."
    Friend Const EXCEPTIONTEXT_ALL_RECIPIENTS_SENDONLY As String = "All recipients unable to receive message."
    Friend Const EXCEPTIONTEXT_SERVER_IS_OFFLINE As String = "Server is offline."
    Friend Const EXCEPTIONTEXT_CANNOT_LOGIN As String = "Cannot login."
    Friend Const EXCEPTIONTEXT_CANNOT_CONNECT_TO_SERVER As String = "Cannot login. Cannot connect to server."
    Friend Const EXCEPTIONTEXT_VERSION_TOO_OLD As String = "Version too old"
    Friend Const EXCEPTIONTEXT_TOO_MANY_FAILURES_FROM_IP As String = "Too many failed login attempts from IP address."
    Friend Const EXCEPTIONTEXT_TOO_MANY_FAILURES_FOR_USERNAME As String = "Too many failed login attempts for username."
    Friend Const EXCEPTIONTEXT_LOGIN_SUSPENDED As String = "Login suspended."
    Friend Const EXCEPTIONTEXT_USERNAME_PASSWORD_INVALID As String = "Username and password invalid"
    Friend Const EXCEPTIONTEXT_EMAIL_TOO_LARGE As String = "Email too large"
    Friend Const EXCEPTIONTEXT_EMAIL_UNKNOWN_ERROR As String = "Unknown email error"
    Friend Const EXCEPTIONTEXT_GOOGLE_NOT_ALLOW_ENCRYPTED_ZIPS As String = "Google mail does not allow encrypted zip or other attachments they think might be dangerous."

    Friend Const EXCEPTIONTEXT_USERNAME_INVALID As String = "Username is not valid."
    Friend Const EXCEPTIONTEXT_CANNOT_SEND_PASSWORD_RESET_TOKEN As String = "Cannot send password reset token."
    Friend Const EXCEPTIONTEXT_INVALID_PASSWORD_RESET_TOKEN As String = "Password reset token is not valid."
    Friend Const EXCEPTIONTEXT_CANNOT_RESET_PASSWORD As String = "Cannot reset password."

    Friend Const EXCEPTIONTEXT_APPSETTINGS_ENCRYPTED_WRONG_PASSWORD As String = "TrulyMail settings are encrypted. Proper decryption password is required."
    Friend Const EXCEPTIONTEXT_APPSETTINGS_CANNOT_LOAD As String = "Settings file could not be loaded"

#End Region
End Module
