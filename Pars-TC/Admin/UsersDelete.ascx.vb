Public Class UsersDelete
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools
    Dim User As String
    Dim Result As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        User = Request.QueryString("UserName")
        If (User = "") Or (InStr(User, "'") <> 0) Or (InStr(User, ";") <> 0) Or (InStr(User, "-") <> 0) Then Response.Redirect("?Page=AllUser") : Exit Sub
        Result = Request.QueryString("Result")
        If Result = "OK" Then
            Toolz = New Tools
            Toolz.Delete_User(User)
            Response.Redirect("?Page=AllUser")
        Else
            AUD.InnerHtml = "<h2>پنل مدیریت</h2><div class='featured'><h3>حذف کاربران</h3><table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>" + _
                "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>آیا می خواهید نام کاربری " & User & " را حذف کنید؟</td></tr></table><br><br>" + _
                "<table width=150 border=0 cellspacing=0 cellpadding=0><tr>" + _
                "<td align=center><a class='blue' style='color:white' href='?Page=DeleteUser&UserName=" & User & "&Result=OK'>بله</a></td>" + _
                "<td align=center><a class='blue' style='color:white' href='?Page=AllUser'>خیر</a></td>" + _
                "</tr></table></td></tr></table><br></div><br>"
        End If
    End Sub

End Class