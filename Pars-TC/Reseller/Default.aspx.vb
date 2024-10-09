Public Class RDefault
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("Page")
        Dim QSTR2 As String = Request.QueryString("UserName")
        Dim QSTRUI As String = Base64DeCode(Request.QueryString("UserID"))
        Select Case QSTR
            Case "Login"
                If Session.Count <> 0 Then
                    If Session.Item("RLogin") = "True" Then
                        Response.Redirect("/Reseller/") : Exit Sub
                    End If
                End If
            Case "Logout"
                If Session.Count <> 0 Then
                    If Session.Item("RLogin") = "True" Then
                        Session.Remove("RLogin")
                        Session.Remove("RUser")
                        Response.Redirect("/") : Exit Sub
                    End If
                Else
                    Response.Redirect("/Reseller/?Page=Login") : Exit Sub
                End If
            Case "KillUser"
                If Session.Count <> 0 Then
                    If Session.Item("RLogin") = "True" Then
                        If (InStr(QSTRUI, "'") = 0) And (InStr(QSTRUI, ";") = 0) And (InStr(QSTRUI, "-") = 0) Then
                            Shell("C:\NTTacPlus2\External\remotedcplusclient.exe " & QSTRUI, AppWinStyle.Hide)
                        End If
                    End If
                End If
                Response.Redirect("/Reseller/?Page=OnlineUser") : Exit Sub
            Case Else
                If Session.Count <> 0 Then
                    If Session.Item("RLogin") <> "True" Then Response.Redirect("/Reseller/?Page=Login") : Exit Sub
                Else
                    Response.Redirect("/Reseller/?Page=Login") : Exit Sub
                End If
        End Select
        Select Case QSTR
            Case "Login"
                ttl.InnerText = "Pars TC - Reseller - Login"
            Case "Logout"
                ttl.InnerText = "Pars TC - Reseller - Logout"
            Case "ServerInfo"
                ttl.InnerText = "Pars TC - Reseller - Server Informations"
            Case "AllUser"
                ttl.InnerText = "Pars TC - Reseller - View All Users"
            Case "KillUser"
                ttl.InnerText = "Pars TC - Reseller - Kill User"
            Case "OnlineUser"
                ttl.InnerText = "Pars TC - Reseller - View Online Users"
            Case "ChangePass"
                ttl.InnerText = "Pars TC - Reseller - Change Reseller's Password"
            Case "ChangeUserPass"
                ttl.InnerText = "Pars TC - Reseller - Change User's Password"
            Case "ResellerTickets"
                ttl.InnerText = "Pars TC - Reseller - View User Tickets"
            Case Else
                ttl.InnerText = "Pars TC - Reseller"
        End Select
        MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
            "<li><a href='/Support/'>پشتیبانی</a></li>" + _
            "<li><a href='/News/'>اخبار</a></li>"
        If Session.Item("ALogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Admin/'>پنل مدیریت</a></li>"
        ElseIf Session.Item("RLogin") = "True" Then
            MNUList.InnerHtml &= "<li class='current'><a href='/Reseller/'>پنل فروشنده</a></li>"
        Else
            MNUList.InnerHtml &= "<li><a href='/User/'>پنل کاربری</a></li>"
        End If
        MNUList.InnerHtml &= "<li><a href='/'>صفحه اصلی</a></li>"
        SBList.InnerHtml = "<li><h3>منوی فروشندگان</h3></li><table>" + _
            "<tr><td><image src='/images/admin-pn.png'></image></td><td><a href='/Reseller/'>پنل فروشنده</a></td></tr>" + _
            "<tr><td><image src='/images/server.png'></image></td><td><a href='/Reseller/?Page=ServerInfo'>مشخصات سرورها</a></td></tr>" + _
            "<tr><td><image src='/images/user-on.png'></image></td><td><a href='/Reseller/?Page=OnlineUser'>کاربران آنلاین</a></td></tr>" + _
            "<tr><td><image src='/images/user-all.png'></image></td><td><a href='/Reseller/?Page=AllUser'>تمامی کاربران</a></td></tr>" + _
            "<tr><td><image src='/images/user-tickets.png'></image></td><td><a href='/Reseller/?Page=ResellerTickets'>مشاهده درخواستهای پشتیبانی</a></td></tr>" + _
            "<tr><td><image src='/images/user-add.png'></image></td><td><a href='/Reseller/?Page=AddUser'>افزودن کاربر</a></td></tr>" + _
            "<tr><td><image src='/images/change-pass.png'></image></td><td><a href='/Reseller/?Page=ChangePass'>تغییر کلمه عبور</a></td></tr>" + _
            "<tr><td><image src='/images/logout.png'></image></td><td><a href='/Reseller/?Page=Logout'>خروج از پنل</a></td></tr>" + _
            "</table>"
        Select Case QSTR
            Case "Login"
                ManList.Controls.Add(LoadControl("ResellersLogin.ascx"))
                SBList.InnerHtml = ""
                SBList.Controls.Add(LoadControl("/Counter/CounterInfo.ascx"))
            Case "Logout"
                ManList.InnerHtml = "<h2>کنترل پنل فروشندگان</h2>" + _
                    "<div class='featured'><h3>خروج از پنل فروشندگان</h3>" + _
                    "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>فروشنده گرامی شما با موفقیت از پنل خارج شدید.</td></tr>" + _
                    "<tr><td align=center>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='/'>اینجا را کلیک کنید</a></td></tr></table>" + _
                    "<br></div><br><script>window.setTimeout(function() {location.href = '/'}, 4000);</script>"
                SBList.InnerHtml = ""
                SBList.Controls.Add(LoadControl("/Counter/CounterInfo.ascx"))
            Case "ServerInfo"
                ManList.Controls.Add(LoadControl("ResellerServerInfo.ascx"))
            Case "AllUser"
                ManList.Controls.Add(LoadControl("ResellerAllUsers.ascx"))
            Case "KillUser"
                ManList.InnerHtml = "<h2>کنترل پنل فروشندگان</h2>" + _
                    "<div class='featured'><h3>قطع ارتباط کاربر</h3>" + _
                    "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>فروشنده گرامی ارتباط کاربر با موفقیت قطع گردید.</td></tr>" + _
                    "<tr><td align=center>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='/Reseller/?Page=OnlineUser'>اینجا را کلیک کنید</a></td></tr></table>" + _
                    "<br></div><br><script>window.setTimeout(function() {location.href = '/Reseller/?Page=OnlineUser'}, 4000);</script>"
            Case "OnlineUser"
                ManList.Controls.Add(LoadControl("ResellerOnlineUsers.ascx"))
            Case "ChangePass"
                ManList.Controls.Add(LoadControl("ResellerPassChange.ascx"))
            Case "ChangeUserPass"
                ManList.Controls.Add(LoadControl("ResellerUserPassChange.ascx"))
            Case "ResellerTickets"
                ManList.Controls.Add(LoadControl("ResellerTickets.ascx"))
            Case Else
                ManList.Controls.Add(LoadControl("ResellersPanel.ascx"))
        End Select
        ULList.Controls.Add(LoadControl("/UserLeft.ascx"))
        UMList.Controls.Add(LoadControl("/UserMiddle.ascx"))
        URList.Controls.Add(LoadControl("/UserRight.ascx"))
    End Sub

End Class