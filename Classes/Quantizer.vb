Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public MustInherit Class Quantizer

    ''' <summary>
    ''' Construct the quantizer
    ''' </summary>
    ''' <param name="singlePass">If true, the quantization only needs to loop through the source pixels once</param>
    ''' <remarks>
    ''' If you construct this class with a true value for singlePass, then the code will, when quantizing your image,
    ''' only call the 'QuantizeImage' function. If two passes are required, the code will call 'InitialQuantizeImage'
    ''' and then 'QuantizeImage'.
    ''' </remarks>
    Public Sub New(ByVal singlePass As Boolean)
        _singlePass = singlePass
        _pixelSize = Marshal.SizeOf(GetType(Color32))
    End Sub

    ''' <summary>
    ''' Quantize an image and return the resulting output bitmap
    ''' </summary>
    ''' <param name="source">The image to quantize</param>
    ''' <returns>A quantized version of the image</returns>
    Public Function Quantize(ByVal source As System.Drawing.Image) As Bitmap
        ' Get the size of the source image
        Dim height As Integer = source.Height
        Dim width As Integer = source.Width
        ' And construct a rectangle from these dimensions
        Dim bounds As New Rectangle(0, 0, width, height)
        ' First off take a 32bpp copy of the image
        Dim copy As New Bitmap(width, height, PixelFormat.Format32bppArgb)
        ' And construct an 8bpp version
        Dim output As New Bitmap(width, height, PixelFormat.Format8bppIndexed)
        ' Now lock the bitmap into memory
        Using g As Graphics = Graphics.FromImage(copy)
            g.PageUnit = GraphicsUnit.Pixel
            ' Draw the source image onto the copy bitmap,
            ' which will effect a widening as appropriate.
            g.DrawImage(source, bounds)
        End Using
        ' Define a pointer to the bitmap data
        Dim sourceData As BitmapData = Nothing
        Try
            ' Get the source image bits and lock into memory
            sourceData = copy.LockBits(bounds, ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)
            ' Call the FirstPass function if not a single pass algorithm.
            ' For something like an octree quantizer, this will run through
            ' all image pixels, build a data structure, and create a palette.
            If Not _singlePass Then
                FirstPass(sourceData, width, height)
            End If
            ' Then set the color palette on the output bitmap. I'm passing in the current palette
            ' as there's no way to construct a new, empty palette.
            output.Palette = GetPalette(output.Palette)
            ' Then call the second pass which actually does the conversion
            SecondPass(sourceData, output, width, height, bounds)
        Finally
            ' Ensure that the bits are unlocked
            copy.UnlockBits(sourceData)
        End Try
        ' Last but not least, return the output bitmap
        Return output
    End Function

    ''' <summary>
    ''' Execute the first pass through the pixels in the image
    ''' </summary>
    ''' <param name="sourceData">The source data</param>
    ''' <param name="width">The width in pixels of the image</param>
    ''' <param name="height">The height in pixels of the image</param>
    Protected Overridable Sub FirstPass(ByVal sourceData As BitmapData, ByVal width As Integer, ByVal height As Integer)

        ' Define the source data pointers. The source row is a byte to

        ' keep addition of the stride value easier (as this is in bytes)

        Dim pSourceRow As IntPtr = sourceData.Scan0

        For row As Integer = 0 To height - 1

            ' Loop through each row

            ' Set the source pixel to the first pixel in this row

            Dim pSourcePixel As IntPtr = pSourceRow

            For col As Integer = 0 To width - 1

                ' And loop through each column

                InitialQuantizePixel(New Color32(pSourcePixel))

                pSourcePixel = CType((CType(pSourcePixel, Int32) + _pixelSize), IntPtr)

            Next

            ' Now I have the pixel, call the FirstPassQuantize function...

            ' Add the stride to the source row

            pSourceRow = CType((CLng(pSourceRow) + sourceData.Stride), IntPtr)

        Next

    End Sub

    ''' <summary>
    ''' Execute a second pass through the bitmap
    ''' </summary>
    ''' <param name="sourceData">The source bitmap, locked into memory</param>
    ''' <param name="output">The output bitmap</param>
    ''' <param name="width">The width in pixels of the image</param>
    ''' <param name="height">The height in pixels of the image</param>
    ''' <param name="bounds">The bounding rectangle</param>
    Protected Overridable Sub SecondPass(ByVal sourceData As BitmapData, ByVal output As Bitmap, ByVal width As Integer, ByVal height As Integer, ByVal bounds As Rectangle)

        Dim outputData As BitmapData = Nothing

        Try

            ' Lock the output bitmap into memory

            outputData = output.LockBits(bounds, ImageLockMode.[WriteOnly], PixelFormat.Format8bppIndexed)

            ' Define the source data pointers. The source row is a byte to

            ' keep addition of the stride value easier (as this is in bytes)

            Dim pSourceRow As IntPtr = sourceData.Scan0

            Dim pSourcePixel As IntPtr = pSourceRow

            Dim pPreviousPixel As IntPtr = pSourcePixel

            ' Now define the destination data pointers

            Dim pDestinationRow As IntPtr = outputData.Scan0

            Dim pDestinationPixel As IntPtr = pDestinationRow

            ' And convert the first pixel, so that I have values going into the loop

            Dim pixelValue As Byte = QuantizePixel(New Color32(pSourcePixel))

            ' Assign the value of the first pixel

            Marshal.WriteByte(pDestinationPixel, pixelValue)

            For row As Integer = 0 To height - 1

                ' Loop through each row

                ' Set the source pixel to the first pixel in this row

                pSourcePixel = pSourceRow

                ' And set the destination pixel pointer to the first pixel in the row

                pDestinationPixel = pDestinationRow

                For col As Integer = 0 To width - 1

                    ' Loop through each pixel on this scan line

                    ' Check if this is the same as the last pixel. If so use that value

                    ' rather than calculating it again. This is an inexpensive optimisation.

                    If Marshal.ReadByte(pPreviousPixel) <> Marshal.ReadByte(pSourcePixel) Then

                        ' Quantize the pixel

                        pixelValue = QuantizePixel(New Color32(pSourcePixel))

                        ' And setup the previous pointer

                        pPreviousPixel = pSourcePixel

                    End If

                    ' And set the pixel in the output

                    Marshal.WriteByte(pDestinationPixel, pixelValue)

                    pSourcePixel = CType((CLng(pSourcePixel) + _pixelSize), IntPtr)

                    pDestinationPixel = CType((CLng(pDestinationPixel) + 1), IntPtr)

                Next

                ' Add the stride to the source row

                pSourceRow = CType((CLng(pSourceRow) + sourceData.Stride), IntPtr)

                ' And to the destination row

                pDestinationRow = CType((CLng(pDestinationRow) + outputData.Stride), IntPtr)

            Next

        Finally

            ' Ensure that I unlock the output bits

            output.UnlockBits(outputData)

        End Try

    End Sub

    ''' <summary>
    ''' Override this to process the pixel in the first pass of the algorithm
    ''' </summary>
    ''' <param name="pixel">The pixel to quantize</param>
    ''' <remarks>
    ''' This function need only be overridden if your quantize algorithm needs two passes,
    ''' such as an Octree quantizer.
    ''' </remarks>
    Protected Overridable Sub InitialQuantizePixel(ByVal pixel As Color32)

    End Sub

    ''' <summary>
    ''' Override this to process the pixel in the second pass of the algorithm
    ''' </summary>
    ''' <param name="pixel">The pixel to quantize</param>
    ''' <returns>The quantized value</returns>
    Protected MustOverride Function QuantizePixel(ByVal pixel As Color32) As Byte

    ''' <summary>
    ''' Retrieve the palette for the quantized image
    ''' </summary>
    ''' <param name="original">Any old palette, this is overrwritten</param>
    ''' <returns>The new color palette</returns>
    Protected MustOverride Function GetPalette(ByVal original As ColorPalette) As ColorPalette

    ''' <summary>
    ''' Flag used to indicate whether a single pass or two passes are needed for quantization.
    ''' </summary>
    Private _singlePass As Boolean

    Private _pixelSize As Integer

    ''' <summary>
    ''' Struct that defines a 32 bpp colour
    ''' </summary>
    ''' <remarks>
    ''' This struct is used to read data from a 32 bits per pixel image
    ''' in memory, and is ordered in this manner as this is the way that
    ''' the data is layed out in memory
    ''' </remarks>
    <StructLayout(LayoutKind.Explicit)> _
    Public Structure Color32
        Public Sub New(ByVal pSourcePixel As IntPtr)
            Dim C As Color32 = Marshal.PtrToStructure(pSourcePixel, GetType(Color32))
            Me.Blue = C.Blue
            Me.Green = C.Green
            Me.Red = C.Red
            Me.Alpha = C.Alpha
            Me.ARGB = C.ARGB
        End Sub
        ''' <summary>
        ''' Holds the blue component of the colour
        ''' </summary>
        <FieldOffset(0)> _
        Public Blue As Byte
        ''' <summary>
        ''' Holds the green component of the colour
        ''' </summary>
        <FieldOffset(1)> _
        Public Green As Byte
        ''' <summary>
        ''' Holds the red component of the colour
        ''' </summary>
        <FieldOffset(2)> _
        Public Red As Byte
        ''' <summary>
        ''' Holds the alpha component of the colour
        ''' </summary>
        <FieldOffset(3)> _
        Public Alpha As Byte
        ''' <summary>
        ''' Permits the color32 to be treated as an int32
        ''' </summary>
        <FieldOffset(0)> _
        Public ARGB As Integer
        ''' <summary>
        ''' Return the color for this Color32 object
        ''' </summary>
        Public ReadOnly Property Color() As Color
            Get
                Return Color.FromArgb(Alpha, Red, Green, Blue)
            End Get
        End Property
    End Structure
End Class

Public Class OctreeQuantizer
    Inherits Quantizer
    ''' <summary>
    ''' Construct the octree quantizer
    ''' </summary>
    ''' <remarks>
    ''' The Octree quantizer is a two pass algorithm. The initial pass sets up the octree,
    ''' the second pass quantizes a color based on the nodes in the tree
    ''' </remarks>
    ''' <param name="maxColors">The maximum number of colors to return</param>
    ''' <param name="maxColorBits">The number of significant bits</param>
    Public Sub New(ByVal maxColors As Integer, ByVal maxColorBits As Integer)
        MyBase.New(False)
        If maxColors > 255 Then
            Throw New ArgumentOutOfRangeException("maxColors", maxColors, "The number of colors should be less than 256")
        End If
        If (maxColorBits < 1) Or (maxColorBits > 8) Then
            Throw New ArgumentOutOfRangeException("maxColorBits", maxColorBits, "This should be between 1 and 8")
        End If
        ' Construct the octree
        _octree = New Octree(maxColorBits)
        _maxColors = maxColors
    End Sub
    ''' <summary>
    ''' Process the pixel in the first pass of the algorithm
    ''' </summary>
    ''' <param name="pixel">The pixel to quantize</param>
    ''' <remarks>
    ''' This function need only be overridden if your quantize algorithm needs two passes,
    ''' such as an Octree quantizer.
    ''' </remarks>
    Protected Overloads Overrides Sub InitialQuantizePixel(ByVal pixel As Color32)
        ' Add the color to the octree
        _octree.AddColor(pixel)
    End Sub
    ''' <summary>
    ''' Override this to process the pixel in the second pass of the algorithm
    ''' </summary>
    ''' <param name="pixel">The pixel to quantize</param>
    ''' <returns>The quantized value</returns>
    Protected Overloads Overrides Function QuantizePixel(ByVal pixel As Color32) As Byte
        Dim paletteIndex As Byte = CByte(_maxColors)
        ' The color at [_maxColors] is set to transparent
        ' Get the palette index if this non-transparent
        If pixel.Alpha > 0 Then
            paletteIndex = CByte(_octree.GetPaletteIndex(pixel))
        End If
        Return paletteIndex
    End Function
    ''' <summary>
    ''' Retrieve the palette for the quantized image
    ''' </summary>
    ''' <param name="original">Any old palette, this is overrwritten</param>
    ''' <returns>The new color palette</returns>
    Protected Overloads Overrides Function GetPalette(ByVal original As ColorPalette) As ColorPalette
        ' First off convert the octree to _maxColors colors
        Dim palette As ArrayList = _octree.Palletize(_maxColors - 1)
        For index As Integer = 0 To palette.Count - 1
            original.Entries(index) = CType(palette(index), Color)
        Next
        ' Then convert the palette based on those colors
        ' Add the transparent color
        original.Entries(_maxColors) = Color.FromArgb(0, 0, 0, 0)
        Return original
    End Function
    ''' <summary>
    ''' Stores the tree
    ''' </summary>
    Private _octree As Octree
    ''' <summary>
    ''' Maximum allowed color depth
    ''' </summary>
    Private _maxColors As Integer
    ''' <summary>
    ''' Class which does the actual quantization
    ''' </summary>
    Private Class Octree
        ''' <summary>
        ''' Construct the octree
        ''' </summary>
        ''' <param name="maxColorBits">The maximum number of significant bits in the image</param>
        Public Sub New(ByVal maxColorBits As Integer)
            _maxColorBits = maxColorBits
            _leafCount = 0
            _reducibleNodes = New OctreeNode(8) {}
            _root = New OctreeNode(0, _maxColorBits, Me)
            _previousColor = 0
            _previousNode = Nothing
        End Sub
        ''' <summary>
        ''' Add a given color value to the octree
        ''' </summary>
        ''' <param name="pixel"></param>
        Public Sub AddColor(ByVal pixel As Color32)
            ' Check if this request is for the same color as the last
            If _previousColor = pixel.ARGB Then
                ' If so, check if I have a previous node setup. This will only ocurr if the first color in the image
                ' happens to be black, with an alpha component of zero.
                If _previousNode Is Nothing Then
                    _previousColor = pixel.ARGB
                    _root.AddColor(pixel, _maxColorBits, 0, Me)
                Else
                    _previousNode.Increment(pixel)
                    ' Just update the previous node
                End If
            Else
                _previousColor = pixel.ARGB
                _root.AddColor(pixel, _maxColorBits, 0, Me)
            End If
        End Sub
        ''' <summary>
        ''' Reduce the depth of the tree
        ''' </summary>
        Public Sub Reduce()
            Dim index As Integer
            ' Find the deepest level containing at least one reducible node
            index = _maxColorBits - 1
            While (index > 0) AndAlso (_reducibleNodes(index) Is Nothing)
                index -= 1
            End While
            ' Reduce the node most recently added to the list at level 'index'
            Dim node As OctreeNode = _reducibleNodes(index)
            _reducibleNodes(index) = node.NextReducible
            ' Decrement the leaf count after reducing the node
            _leafCount -= node.Reduce()
            ' And just in case I've reduced the last color to be added, and the next color to
            ' be added is the same, invalidate the previousNode...
            _previousNode = Nothing
        End Sub
        ''' <summary>
        ''' Get/Set the number of leaves in the tree
        ''' </summary>
        Public Property Leaves() As Integer
            Get
                Return _leafCount
            End Get
            Set(ByVal value As Integer)
                _leafCount = value
            End Set
        End Property
        ''' <summary>
        ''' Return the array of reducible nodes
        ''' </summary>
        Protected ReadOnly Property ReducibleNodes() As OctreeNode()
            Get
                Return _reducibleNodes
            End Get
        End Property
        ''' <summary>
        ''' Keep track of the previous node that was quantized
        ''' </summary>
        ''' <param name="node">The node last quantized</param>
        Protected Sub TrackPrevious(ByVal node As OctreeNode)
            _previousNode = node
        End Sub
        ''' <summary>
        ''' Convert the nodes in the octree to a palette with a maximum of colorCount colors
        ''' </summary>
        ''' <param name="colorCount">The maximum number of colors</param>
        ''' <returns>An arraylist with the palettized colors</returns>
        Public Function Palletize(ByVal colorCount As Integer) As ArrayList
            While Leaves > colorCount
                Reduce()
            End While
            ' Now palettize the nodes
            Dim palette As New ArrayList(Leaves)
            Dim paletteIndex As Integer = 0
            _root.ConstructPalette(palette, paletteIndex)
            ' And return the palette
            Return palette
        End Function
        ''' <summary>
        ''' Get the palette index for the passed color
        ''' </summary>
        ''' <param name="pixel"></param>
        ''' <returns></returns>
        Public Function GetPaletteIndex(ByVal pixel As Color32) As Integer
            Return _root.GetPaletteIndex(pixel, 0)
        End Function
        ''' <summary>
        ''' Mask used when getting the appropriate pixels for a given node
        ''' </summary>
        Private Shared mask As Integer() = New Integer(7) {128, 64, 32, 16, 8, 4, 2, 1}
        ''' <summary>
        ''' The root of the octree
        ''' </summary>
        Private _root As OctreeNode
        ''' <summary>
        ''' Number of leaves in the tree
        ''' </summary>
        Private _leafCount As Integer
        ''' <summary>
        ''' Array of reducible nodes
        ''' </summary>
        Private _reducibleNodes As OctreeNode()
        ''' <summary>
        ''' Maximum number of significant bits in the image
        ''' </summary>
        Private _maxColorBits As Integer
        ''' <summary>
        ''' Store the last node quantized
        ''' </summary>
        Private _previousNode As OctreeNode
        ''' <summary>
        ''' Cache the previous color quantized
        ''' </summary>
        Private _previousColor As Integer
        ''' <summary>
        ''' Class which encapsulates each node in the tree
        ''' </summary>
        Protected Class OctreeNode
            ''' <summary>
            ''' Construct the node
            ''' </summary>
            ''' <param name="level">The level in the tree = 0 - 7</param>
            ''' <param name="colorBits">The number of significant color bits in the image</param>
            ''' <param name="octree">The tree to which this node belongs</param>
            Public Sub New(ByVal level As Integer, ByVal colorBits As Integer, ByVal octree As Octree)
                ' Construct the new node
                _leaf = (level = colorBits)
                _red = _green = _blue = 0
                _pixelCount = 0
                ' If a leaf, increment the leaf count
                If _leaf Then
                    octree.Leaves += 1
                    _nextReducible = Nothing
                    _children = Nothing
                Else
                    ' Otherwise add this to the reducible nodes
                    _nextReducible = octree.ReducibleNodes(level)
                    octree.ReducibleNodes(level) = Me
                    _children = New OctreeNode(7) {}
                End If
            End Sub
            ''' <summary>
            ''' Add a color into the tree
            ''' </summary>
            ''' <param name="pixel">The color</param>
            ''' <param name="colorBits">The number of significant color bits</param>
            ''' <param name="level">The level in the tree</param>
            ''' <param name="octree">The tree to which this node belongs</param>
            Public Sub AddColor(ByVal pixel As Color32, ByVal colorBits As Integer, ByVal level As Integer, ByVal octree As Octree)
                ' Update the color information if this is a leaf
                If _leaf Then
                    Increment(pixel)
                    ' Setup the previous node
                    octree.TrackPrevious(Me)
                Else
                    ' Go to the next level down in the tree
                    Dim shift As Integer = 7 - level
                    Dim index As Integer = ((pixel.Red And mask(level)) >> (shift - 2)) Or ((pixel.Green And mask(level)) >> (shift - 1)) Or ((pixel.Blue And mask(level)) >> (shift))
                    Dim child As OctreeNode = _children(index)
                    If child Is Nothing Then
                        ' Create a new child node & store in the array
                        child = New OctreeNode(level + 1, colorBits, octree)
                        _children(index) = child
                    End If
                    ' Add the color to the child node
                    child.AddColor(pixel, colorBits, level + 1, octree)
                End If
            End Sub
            ''' <summary>
            ''' Get/Set the next reducible node
            ''' </summary>
            Public Property NextReducible() As OctreeNode
                Get
                    Return _nextReducible
                End Get
                Set(ByVal value As OctreeNode)
                    _nextReducible = value
                End Set
            End Property
            ''' <summary>
            ''' Return the child nodes
            ''' </summary>
            Public ReadOnly Property Children() As OctreeNode()
                Get
                    Return _children
                End Get
            End Property
            ''' <summary>
            ''' Reduce this node by removing all of its children
            ''' </summary>
            ''' <returns>The number of leaves removed</returns>
            Public Function Reduce() As Integer
                _red = _green = _blue = 0
                Dim children As Integer = 0
                For index As Integer = 0 To 7
                    ' Loop through all children and add their information to this node
                    If _children(index) IsNot Nothing Then
                        _red += _children(index)._red
                        _green += _children(index)._green
                        _blue += _children(index)._blue
                        _pixelCount += _children(index)._pixelCount
                        children += 1
                        _children(index) = Nothing
                    End If
                Next
                ' Now change this to a leaf node
                _leaf = True
                ' Return the number of nodes to decrement the leaf count by
                Return (children - 1)
            End Function
            ''' <summary>
            ''' Traverse the tree, building up the color palette
            ''' </summary>
            ''' <param name="palette">The palette</param>
            ''' <param name="paletteIndex">The current palette index</param>
            Public Sub ConstructPalette(ByVal palette As ArrayList, ByRef paletteIndex As Integer)
                If _leaf Then
                    ' Consume the next palette index
                    _paletteIndex = System.Math.Max(System.Threading.Interlocked.Increment(paletteIndex), paletteIndex - 1)
                    ' And set the color of the palette entry
                    palette.Add(Color.FromArgb(_red / _pixelCount, _green / _pixelCount, _blue / _pixelCount))
                Else
                    For index As Integer = 0 To 7
                        ' Loop through children looking for leaves
                        If _children(index) IsNot Nothing Then
                            _children(index).ConstructPalette(palette, paletteIndex)
                        End If
                    Next
                End If
            End Sub
            ''' <summary>
            ''' Return the palette index for the passed color
            ''' </summary>
            Public Function GetPaletteIndex(ByVal pixel As Color32, ByVal level As Integer) As Integer
                Dim paletteIndex As Integer = _paletteIndex
                If Not _leaf Then
                    Dim shift As Integer = 7 - level
                    Dim index As Integer = ((pixel.Red And mask(level)) >> (shift - 2)) Or ((pixel.Green And mask(level)) >> (shift - 1)) Or ((pixel.Blue And mask(level)) >> (shift))
                    If _children(index) IsNot Nothing Then
                        paletteIndex = _children(index).GetPaletteIndex(pixel, level + 1)
                    Else
                        Throw New Exception("Didn't expect this!")
                    End If
                End If
                Return paletteIndex
            End Function
            ''' <summary>
            ''' Increment the pixel count and add to the color information
            ''' </summary>
            Public Sub Increment(ByVal pixel As Color32)
                _pixelCount += 1
                _red += pixel.Red
                _green += pixel.Green
                _blue += pixel.Blue
            End Sub
            ''' <summary>
            ''' Flag indicating that this is a leaf node
            ''' </summary>
            Private _leaf As Boolean
            ''' <summary>
            ''' Number of pixels in this node
            ''' </summary>
            Private _pixelCount As Integer
            ''' <summary>
            ''' Red component
            ''' </summary>
            Private _red As Integer
            ''' <summary>
            ''' Green Component
            ''' </summary>
            Private _green As Integer
            ''' <summary>
            ''' Blue component
            ''' </summary>
            Private _blue As Integer
            ''' <summary>
            ''' Pointers to any child nodes
            ''' </summary>
            Private _children As OctreeNode()
            ''' <summary>
            ''' Pointer to next reducible node
            ''' </summary>
            Private _nextReducible As OctreeNode
            ''' <summary>
            ''' The index of this node in the palette
            ''' </summary>
            Private _paletteIndex As Integer
        End Class
    End Class
End Class