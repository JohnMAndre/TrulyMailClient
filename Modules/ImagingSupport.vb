Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Module ImagingSupport
    Public Function GetMaxSideForSize(ByVal imageResizeSize As ImageResizeSizeEnum) As Integer
        Select Case imageResizeSize
            Case ImageResizeSizeEnum.None
                Return 0
            Case ImageResizeSizeEnum.x640
                Return 640
            Case ImageResizeSizeEnum.x800
                Return 800
            Case ImageResizeSizeEnum.x1024
                Return 1024
            Case imageResizeSize.x1600
                Return 1600
        End Select
    End Function
    ''' <summary>
    ''' Returns true if filename is a supported image format
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsFileImage(ByVal filename As String) As Boolean
        Dim strExt As String = System.IO.Path.GetExtension(filename).ToLower()
        Const IMAGE_VALID_EXTENSIONS As String = ".jpg;.gif;.png;.bmp;.tiff"
        Return IMAGE_VALID_EXTENSIONS.Contains(strExt)
    End Function
    Public Function GetImageFormat(ByVal filename As String) As ImageFormat
        Try
            Using img As Image = Image.FromFile(filename)
                Return img.RawFormat
            End Using
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Public Sub ResizeImage(ByVal sourceImage As Image, ByVal destinationFilename As String, ByVal format As Imaging.ImageFormat, ByVal maxSide As Integer)
        Try
            Dim intHeight, intWidth As Integer
            Dim dblRatio As Double = GetRatio(sourceImage, maxSide)

            intWidth = Convert.ToInt32(sourceImage.Width * dblRatio)
            intHeight = Convert.ToInt32(sourceImage.Height * dblRatio)

            Dim imgThumb As Image = sourceImage.GetThumbnailImage(intWidth, intHeight, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback), IntPtr.Zero)

            Using graph As Graphics = Graphics.FromImage(imgThumb)
                graph.CompositingQuality = CompositingQuality.HighQuality
                graph.SmoothingMode = SmoothingMode.HighQuality
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic

                Dim rect As Rectangle = New Rectangle(0, 0, intWidth, intHeight)

                graph.DrawImage(sourceImage, rect)

                If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(destinationFilename)) Then
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(destinationFilename))
                End If

                If format Is ImageFormat.Jpeg Then
                    '// for jpeg, use the quality setting
                    Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

                    '// Create an Encoder object based on the GUID
                    '// for the Quality parameter category.
                    Dim myEncoder As Encoder = System.Drawing.Imaging.Encoder.Quality

                    '// Create an EncoderParameters object.
                    '// An EncoderParameters object has an array of EncoderParameter
                    '// objects. In this case, there is only one
                    '// EncoderParameter object in the array.
                    Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)

                    Const JPEG_QUALITY = 90 '-- 90%
                    Dim myEncoderParameter As EncoderParameter = New EncoderParameter(myEncoder, JPEG_QUALITY)
                    myEncoderParameters.Param(0) = myEncoderParameter

                    imgThumb.Save(destinationFilename, jgpEncoder, myEncoderParameters)
                ElseIf format Is ImageFormat.Gif Then
                    Using imgThumb
                        Dim quantizer As New OctreeQuantizer(255, 8)
                        Using quantized As Bitmap = quantizer.Quantize(imgThumb)
                            quantized.Save(destinationFilename, ImageFormat.Gif)
                        End Using
                    End Using
                Else
                    imgThumb.Save(destinationFilename, format)
                End If
            End Using
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Public Sub SaveImage(ByVal sourceImage As Image, ByVal destinationFilename As String, ByVal format As Imaging.ImageFormat)
        'Using bmNew As Bitmap = New Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb)
        '    Using g As Graphics = Graphics.FromImage(sourceImage)
        '        g.DrawImage(sourceImage, New Point(0, 0))
        '    End Using
        '    bmNew.Save(destinationFilename, ImageFormat.Png)
        'End Using
        sourceImage.Save(destinationFilename, format)
    End Sub
    Public Sub ResizeImage(ByVal sourceFilename As String, ByVal destinationFilename As String, ByVal format As Imaging.ImageFormat, ByVal maxSide As Integer)
        Try
            Dim img As Image = Image.FromFile(sourceFilename)
            ResizeImage(img, destinationFilename, format, maxSide)
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Function GetRatio(ByVal img As Image, ByVal maxSide As Integer) As Double
        If img.Width > img.Height Then
            If img.Width > maxSide Then
                Return maxSide / img.Width
            Else
                Return 1
            End If
        Else
            If img.Height > maxSide Then
                Return maxSide / img.Height
            Else
                Return 1
            End If
        End If
    End Function
    Private Function GetRatio(ByVal filename As String) As Double
        Return 0.5

    End Function
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs() As ImageCodecInfo = ImageCodecInfo.GetImageDecoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next

        '-- not installed
        Return Nothing
    End Function
    ''' <summary>
    ''' Required but not used
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ThumbnailCallback() As Boolean
        Return True
    End Function
End Module
