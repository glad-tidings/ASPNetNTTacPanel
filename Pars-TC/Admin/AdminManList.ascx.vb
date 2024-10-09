Public Class AdminManList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QSTR As String = Request.QueryString("Page")
        Select QSTR
            Case "Login"
                AML.Controls.Add(LoadControl("AdminsLogin.ascx"))
            Case "Logout"
                AML.InnerHtml = "<h2>پنل مدیریت</h2>" + _
                    "<div class='featured'><h3>خروج از پنل مدیریت</h3>" + _
                    "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>مدیر گرامی شما با موفقیت از پنل خارج شدید.</td></tr>" + _
                    "<tr><td align=center>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='?Page=Login'>اینجا را کلیک کنید</a></td></tr></table>" + _
                    "<br></div><br>"
            Case "OnlineUser"
                AML.Controls.Add(LoadControl("OnlineUsers.ascx"))
            Case "AllUser"
                AML.Controls.Add(LoadControl("AllUsers.ascx"))
            Case "EditUser"
                AML.Controls.Add(LoadControl("UsersEdit.ascx"))
            Case "DeleteUser"
                AML.Controls.Add(LoadControl("UsersDelete.ascx"))
            Case Else
                AML.Controls.Add(LoadControl("AdminsPanel.ascx"))
        End Select
    End Sub

End Class