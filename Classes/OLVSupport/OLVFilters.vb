Public Class AttachmentFilterEmbeddedImages
    Implements BrightIdeasSoftware.IModelFilter


    ''' <summary>
    ''' This filter will remove embedded images which are attachments
    ''' </summary>
    ''' <param name="modelObject "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Filter(modelObject As Object) As Boolean Implements BrightIdeasSoftware.IModelFilter.Filter
        Dim item As AttachmentItem = CType(modelObject, AttachmentItem)
        Return Not item.Embedded
    End Function
End Class
