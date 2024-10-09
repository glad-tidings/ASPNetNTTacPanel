Public Class UDefault
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("Page")
        Select Case QSTR
            Case "Login"
                If Session.Count <> 0 Then
                    If Session.Item("VLogin") = "True" Then
                        Response.Redirect("/User/") : Exit Sub
                    End If
                End If
            Case "Logout"
                If Session.Count <> 0 Then
                    If Session.Item("VLogin") = "True" Then
                        Session.Remove("VLogin")
                        Session.Remove("VUser")
                        Response.Redirect("/") : Exit Sub
                    End If
                Else
                    Response.Redirect("/User/?Page=Login") : Exit Sub
                End If
            Case Else
                If Session.Count <> 0 Then
                    If Session.Item("VLogin") <> "True" Then Response.Redirect("/User/?Page=Login") : Exit Sub
                Else
                    Response.Redirect("/User/?Page=Login") : Exit Sub
                End If
        End Select
        Select Case QSTR
            Case "Login"
                ttl.InnerText = "Pars TC - User - Login"
            Case "Logout"
                ttl.InnerText = "Pars TC - User - Logout"
            Case "ServerInfo"
                ttl.InnerText = "Pars TC - User - Server Informations"
            Case "UserOnline"
                ttl.InnerText = "Pars TC - User - View Online"
            Case "UserReport"
                ttl.InnerText = "Pars TC - User - View Report"
            Case "UserTickets"
                ttl.InnerText = "Pars TC - User - View Tickets"
            Case "UserSendTicket"
                ttl.InnerText = "Pars TC - User - Send Ticket"
            Case "ChangePass"
                ttl.InnerText = "Pars TC - User - Change Password"
            Case Else
                ttl.InnerText = "Pars TC - User"
        End Select
        MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
            "<li><a href='/Support/'>پشتیبانی</a></li>" + _
            "<li><a href='/News/'>اخبار</a></li>"
        If Session.Item("ALogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Admin/'>پنل مدیریت</a></li>"
        ElseIf Session.Item("RLogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Reseller/'>پنل فروشنده</a></li>"
        Else
            MNUList.InnerHtml &= "<li class='current'><a href='/User/'>پنل کاربری</a></li>"
        End If
        MNUList.InnerHtml &= "<li><a href='/'>صفحه اصلی</a></li>"
        SBList.InnerHtml = "<li><h3>منوی کاربران</h3></li><table>" + _
            "<tr><td><image src='/images/user-pn.png'></image></td><td><a href='/User/'>پنل کاربر</a></td></tr>" + _
            "<tr><td><image src='/images/server.png'></image></td><td><a href='/User/?Page=ServerInfo'>مشخصات سرورها</a></td></tr>" + _
            "<tr><td><image src='/images/user-on.png'></image></td><td><a href='/User/?Page=UserOnline'>کاربران آنلاین</a></td></tr>" + _
            "<tr><td><image src='/images/user-report.png'></image></td><td><a href='/User/?Page=UserReport'>گزارش مصرف</a></td></tr>" + _
            "<tr><td><image src='/images/user-tickets.png'></image></td><td><a href='/User/?Page=UserTickets'>مشاهده درخواستهای پشتیبانی</a></td></tr>" + _
            "<tr><td><image src='/images/user-sendt.png'></image></td><td><a href='/User/?Page=UserSendTicket'>ارسال درخواست پشتیبانی</a></td></tr>" + _
            "<tr><td><image src='/images/change-pass.png'></image></td><td><a href='/User/?Page=ChangePass'>تغییر کلمه عبور</a></td></tr>" + _
            "<tr><td><image src='/images/logout.png'></image></td><td><a href='/User/?Page=Logout'>خروج از پنل</a></td></tr>" + _
            "</table>"
        Select Case QSTR
            Case "Login"
                ManList.Controls.Add(LoadControl("UsersLogin.ascx"))
                SBList.InnerHtml = ""
                SBList.Controls.Add(LoadControl("/Counter/CounterInfo.ascx"))
            Case "Logout"
                ManList.InnerHtml = "<h2>کنترل پنل کاربران</h2>" + _
                    "<div class='featured'><h3>خروج از پنل کاربران</h3>" + _
                    "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>کاربر گرامی شما با موفقیت از پنل خارج شدید.</td></tr>" + _
                    "<tr><td align=center>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='/'>اینجا را کلیک کنید</a></td></tr></table>" + _
                    "<br></div><br><script>window.setTimeout(function() {location.href = '/'}, 4000);</script>"
                SBList.InnerHtml = ""
                SBList.Controls.Add(LoadControl("/Counter/CounterInfo.ascx"))
            Case "ServerInfo"
                ManList.Controls.Add(LoadControl("UserServerInfo.ascx"))
            Case "UserOnline"
                ManList.Controls.Add(LoadControl("UserOnline.ascx"))
            Case "UserReport"
                ManList.Controls.Add(LoadControl("UserReport.ascx"))
            Case "UserTickets"
                ManList.Controls.Add(LoadControl("UserTickets.ascx"))
            Case "UserSendTicket"
                ManList.Controls.Add(LoadControl("UserSendTicket.ascx"))
            Case "ChangePass"
                ManList.Controls.Add(LoadControl("UserPassChange.ascx"))
            Case Else
                ManList.Controls.Add(LoadControl("UserPanel.ascx"))
        End Select
        ULList.Controls.Add(LoadControl("/UserLeft.ascx"))
        UMList.Controls.Add(LoadControl("/UserMiddle.ascx"))
        URList.Controls.Add(LoadControl("/UserRight.ascx"))
    End Sub

End Class