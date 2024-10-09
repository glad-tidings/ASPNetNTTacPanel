Public Class ADefault
    Inherits System.Web.UI.Page

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("Page")
        Dim QSTRUI As String = Base64DeCode(Request.QueryString("UserID"))
        Select Case QSTR
            Case "Login"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") = "True" Then
                        Response.Redirect("/Admin/") : Exit Sub
                    End If
                End If
                ttl.InnerText = "Pars TC - Admin Login"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='/Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='/News/'>اخبار</a></li>" + _
                    IIf(Session.Item("ALogin") = "True", "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>", "<li><a href='//User/?Page=Login'>پنل کاربری</a></li>") + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>دانلود کانکشن ها ، برنامه ها و آموزش ها</h3></li>" + _
                    "<a href='/?Page=Download-Connection'><image src='/images/conn.png'  alt='دانلود کانکشن' title='دانلود کانکشن'></image></a>"
            Case "Logout"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") = "True" Then
                        Session.Remove("ALogin")
                        Session.Remove("AUser")
                        Response.Redirect("?Page=Login")
                    End If
                Else
                    Response.Redirect("?Page=Login") : Exit Sub
                End If
                ttl.InnerText = "Pars TC - Admin Login"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='//Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='//News/'>اخبار</a></li>" + _
                    IIf(Session.Item("ALogin") = "True", "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>", "<li><a href='//User/?Page=Login'>پنل کاربری</a></li>") + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>دانلود کانکشن ها ، برنامه ها و آموزش ها</h3></li>" + _
                    "<a href='/?Page=Download-Connection'><image src='/images/conn.png'  alt='دانلود کانکشن' title='دانلود کانکشن'></image></a>"
            Case "KillUser"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") = "True" Then
                        If (InStr(QSTRUI, "'") = 0) And (InStr(QSTRUI, ";") = 0) And (InStr(QSTRUI, "-") = 0) Then
                            Shell("C:\NTTacPlus2\External\remotedcplusclient.exe " & QSTRUI, AppWinStyle.Hide)
                        End If
                    End If
                End If
                Response.Redirect("?Page=OnlineUser") : Exit Sub
            Case "OnlineUser"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") <> "True" Then Response.Redirect("?Page=Login") : Exit Sub
                Else
                    Response.Redirect("?Page=Login") : Exit Sub
                End If
                ttl.InnerText = "Pars TC - Admin Panel - Online User"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='//Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='//News/'>اخبار</a></li>" + _
                    "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>" + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>منوی مدیریت</h3></li><table>" + _
                    "<tr><td><image src='/images/admin-pn.png'></image></td><td><a href='/Admin/'>پنل مدیریت</a></td></tr>" + _
                    "<tr><td><image src='/images/user-on.png'></image></td><td><a href='?Page=OnlineUser'>کاربران آنلاین</a></td></tr>" + _
                    "<tr><td><image src='/images/user-all.png'></image></td><td><a href='?Page=AllUser'>تمامی کاربران</a></td></tr>" + _
                    "<tr><td><image src='/images/user-add.png'></image></td><td><a href='?Page=AddUser'>افزودن کاربر</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case "AllUser"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") <> "True" Then Response.Redirect("?Page=Login") : Exit Sub
                Else
                    Response.Redirect("?Page=Login") : Exit Sub
                End If
                ttl.InnerText = "Pars TC - Admin Panel - View All Users"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='//Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='//News/'>اخبار</a></li>" + _
                    "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>" + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>منوی مدیریت</h3></li><table>" + _
                    "<tr><td><image src='/images/admin-pn.png'></image></td><td><a href='/Admin/'>پنل مدیریت</a></td></tr>" + _
                    "<tr><td><image src='/images/user-on.png'></image></td><td><a href='?Page=OnlineUser'>کاربران آنلاین</a></td></tr>" + _
                    "<tr><td><image src='/images/user-all.png'></image></td><td><a href='?Page=AllUser'>تمامی کاربران</a></td></tr>" + _
                    "<tr><td><image src='/images/user-add.png'></image></td><td><a href='?Page=AddUser'>افزودن کاربر</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case "EditUser"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") <> "True" Then Response.Redirect("?Page=Login") : Exit Sub
                Else
                    Response.Redirect("?Page=Login") : Exit Sub
                End If
                ttl.InnerText = "Pars TC - Admin Panel - User Edit"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='//Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='//News/'>اخبار</a></li>" + _
                    "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>" + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>منوی مدیریت</h3></li><table>" + _
                    "<tr><td><image src='/images/admin-pn.png'></image></td><td><a href='/Admin/'>پنل مدیریت</a></td></tr>" + _
                    "<tr><td><image src='/images/user-on.png'></image></td><td><a href='?Page=OnlineUser'>کاربران آنلاین</a></td></tr>" + _
                    "<tr><td><image src='/images/user-all.png'></image></td><td><a href='?Page=AllUser'>تمامی کاربران</a></td></tr>" + _
                    "<tr><td><image src='/images/user-add.png'></image></td><td><a href='?Page=AddUser'>افزودن کاربر</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case "DeleteUser"
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") <> "True" Then Response.Redirect("?Page=Login") : Exit Sub
                Else
                    Response.Redirect("?Page=Login") : Exit Sub
                End If
                ttl.InnerText = "Pars TC - Admin Panel - User Delete"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='//Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='//News/'>اخبار</a></li>" + _
                    "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>" + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>منوی مدیریت</h3></li><table>" + _
                    "<tr><td><image src='/images/admin-pn.png'></image></td><td><a href='/Admin/'>پنل مدیریت</a></td></tr>" + _
                    "<tr><td><image src='/images/user-on.png'></image></td><td><a href='?Page=OnlineUser'>کاربران آنلاین</a></td></tr>" + _
                    "<tr><td><image src='/images/user-all.png'></image></td><td><a href='?Page=AllUser'>تمامی کاربران</a></td></tr>" + _
                    "<tr><td><image src='/images/user-add.png'></image></td><td><a href='?Page=AddUser'>افزودن کاربر</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case Else
                If Session.Count <> 0 Then
                    If Session.Item("ALogin") <> "True" Then Response.Redirect("?Page=Login") : Exit Sub
                Else
                    Response.Redirect("?Page=Login") : Exit Sub
                End If
                ttl.InnerText = "Pars TC - Admin Panel"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='//Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='//News/'>اخبار</a></li>" + _
                    "<li class='current'><a href='/Admin/'>پنل مدیریت</a></li>" + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                'ManList.InnerHtml = ""
                SBList.InnerHtml = "<li><h3>منوی مدیریت</h3></li><table>" + _
                    "<tr><td><image src='/images/admin-pn.png'></image></td><td><a href='/Admin/'>پنل مدیریت</a></td></tr>" + _
                    "<tr><td><image src='/images/user-on.png'></image></td><td><a href='?Page=OnlineUser'>کاربران آنلاین</a></td></tr>" + _
                    "<tr><td><image src='/images/user-all.png'></image></td><td><a href='?Page=AllUser'>تمامی کاربران</a></td></tr>" + _
                    "<tr><td><image src='/images/user-add.png'></image></td><td><a href='?Page=AddUser'>افزودن کاربر</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
        End Select
    End Sub

End Class