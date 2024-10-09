Public Class RenameFile
    Inherits System.Web.UI.UserControl

    Dim FIDQSTR As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FIDQSTR = Request.QueryString("FileID")
        If FIDQSTR = "" Then Response.Redirect("/") : Exit Sub
        oldname.Value = IO.Path.GetFileName(Base64DeCode(FIDQSTR))
    End Sub

    Protected Sub editbtn_Click(sender As Object, e As ImageClickEventArgs) Handles editbtn.Click
        Try
            My.Computer.FileSystem.RenameFile(Base64DeCode(FIDQSTR), newname.Value)
            Response.Redirect("/")
        Catch ex As Exception
            renameerror.InnerHtml = "<ul><li>" & "بروز خطای زیر در هنگام تغییر نام فایل :" & "</li></ul>" & ex.Message
        End Try
    End Sub
End Class