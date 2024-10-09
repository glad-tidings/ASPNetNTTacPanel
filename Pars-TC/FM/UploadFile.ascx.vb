Public Class UploadFile
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub FileUploader_FileUploaded(sender As Object, args As CuteWebUI.UploaderEventArgs) Handles FileUploader.FileUploaded
        Dim TMP As String
        If args.FileSize < 1024 Then
            TMP = args.FileSize & " بایت"
        ElseIf args.FileSize < 1048576 Then
            TMP = Math.Round((args.FileSize / 1024), 1) & " کیلوبایت"
        Else
            TMP = Math.Round((args.FileSize / 1048576), 1) & " مگابایت"
        End If
        args.CopyTo("Files\" & args.FileName)
        args.Delete()
        uploadstat.InnerHtml &= "<ul><li>فایل '" & args.FileName & "' با سایز " & TMP & " آپلود شد.</li></ul>"
    End Sub
End Class