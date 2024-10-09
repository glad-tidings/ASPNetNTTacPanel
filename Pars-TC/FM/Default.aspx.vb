Public Class _Default1
    Inherits System.Web.UI.Page

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QSTR As String = Request.QueryString("Page")
        Dim FIDQSTR As String = Request.QueryString("FileID")
        Dim FAQSTR As String = Request.QueryString("Action")
        Toolz = New Tools
        Dim passTemp As String = ""
        Select QSTR
            Case "Login"
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() = passTemp Then
                            Response.Redirect("/FM/") : Exit Sub
                        End If
                    Else
                        'Response.Redirect("/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager - Login"
                MNUList.InnerHtml = "<li class='current'><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li><a href='/FM/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("Login.ascx"))
                SBList.InnerHtml = ""
            Case "Logout"
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() = passTemp Then
                            Response.Cookies("PBLOGIN").Expires = DateTime.Now.AddDays(-30)
                            Response.Redirect("/FM/?Page=Login")
                            Exit Sub
                        End If
                    Else
                        'Response.Redirect("/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager - Logout"
                MNUList.InnerHtml = "<li class='current'><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li><a href='/FM/'>صفحه اصلی</a></li>"
                ManList.InnerHtml = "<h2>مدیریت فایل ها</h2>" + _
                    "<div class='featured'><h3>خروج از پنل</h3>" + _
                    "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>کاربر گرامی شما با موفقیت از پنل خارج شدید.</td></tr>" + _
                    "<tr><td align=center>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='/FM/?Page=Login'>اینجا را کلیک کنید</a></td></tr></table>" + _
                    "<br></div><br><script>window.setTimeout(function() {location.href = '/FM/?Page=Login'}, 4000);</script>"
                SBList.InnerHtml = ""
            Case "AddLink"
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() <> passTemp Then
                            Response.Redirect("/FM/?Page=Login") : Exit Sub
                        End If
                    Else
                        Response.Redirect("/FM/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager - Add Link"
                MNUList.InnerHtml = "<li><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li class='current'><a href='/FM/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("AddLink.ascx"))
                SBList.InnerHtml = "<li><h3>منوی مدیریت فایل ها</h3></li><table>" + _
                    "<tr><td><image src='/images/copy.png'></image></td><td><a href='/FM/'>لیست فایل ها</a></td></tr>" + _
                    "<tr><td><image src='/images/add_file.png'></image></td><td><a href='/FM/?Page=CreateFile'>ایجاد فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/upload.png'></image></td><td><a href='/FM/?Page=UploadFile'>آپلود فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/add_link.png'></image></td><td><a href='/FM/?Page=AddLink'>افزودن لینک</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='/FM/?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case "UploadFile"
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() <> passTemp Then
                            Response.Redirect("/FM/?Page=Login") : Exit Sub
                        End If
                    Else
                        Response.Redirect("/FM/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager - Upload File"
                MNUList.InnerHtml = "<li><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li class='current'><a href='/FM/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("UploadFile.ascx"))
                SBList.InnerHtml = "<li><h3>منوی مدیریت فایل ها</h3></li><table>" + _
                    "<tr><td><image src='/images/copy.png'></image></td><td><a href='/FM/'>لیست فایل ها</a></td></tr>" + _
                    "<tr><td><image src='/images/add_file.png'></image></td><td><a href='/FM/?Page=CreateFile'>ایجاد فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/upload.png'></image></td><td><a href='/FM/?Page=UploadFile'>آپلود فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/add_link.png'></image></td><td><a href='/FM/?Page=AddLink'>افزودن لینک</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='/FM/?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case "RenameFile"
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() <> passTemp Then
                            Response.Redirect("/FM/?Page=Login") : Exit Sub
                        End If
                    Else
                        Response.Redirect("/FM/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager - Rename File"
                MNUList.InnerHtml = "<li><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li class='current'><a href='/FM/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("RenameFile.ascx"))
                SBList.InnerHtml = "<li><h3>منوی مدیریت فایل ها</h3></li><table>" + _
                    "<tr><td><image src='/images/copy.png'></image></td><td><a href='/FM/'>لیست فایل ها</a></td></tr>" + _
                    "<tr><td><image src='/images/add_file.png'></image></td><td><a href='/FM/?Page=CreateFile'>ایجاد فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/upload.png'></image></td><td><a href='/FM/?Page=UploadFile'>آپلود فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/add_link.png'></image></td><td><a href='/FM/?Page=AddLink'>افزودن لینک</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='/FM/?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case "DeleteFile"
                If FIDQSTR = "" Then Response.Redirect("/FM/") : Exit Sub
                If System.IO.File.Exists(Base64DeCode(FIDQSTR)) = False Then Response.Redirect("/FM/") : Exit Sub
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() <> passTemp Then
                            Response.Redirect("/FM/?Page=Login") : Exit Sub
                        End If
                    Else
                        Response.Redirect("/FM/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager - Delete File"
                MNUList.InnerHtml = "<li><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li class='current'><a href='/FM/'>صفحه اصلی</a></li>"
                Select Case FAQSTR
                    Case "Delete"
                        Try
                            System.IO.File.Delete(Base64DeCode(FIDQSTR))
                            ManList.InnerHtml = "<h2>مدیریت فایل ها</h2>" + _
                                "<div class='featured'><h3>حذف فایل</h3>" + _
                                "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>فایل مورد نظر با موفقیت حذف گردید.</td></tr>" + _
                                "<tr><td align=center>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='/FM/'>اینجا را کلیک کنید</a></td></tr></table>" + _
                                "<br></div><br><script>window.setTimeout(function() {location.href = '/FM/'}, 4000);</script>"
                        Catch ex As Exception
                            ManList.InnerHtml = "<h2>مدیریت فایل ها</h2>" + _
                                "<div class='featured'><h3>حذف فایل</h3>" + _
                                "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>بروز خطای زیر در هنگام حذف فایل :</td></tr>" + _
                                "<tr><td align=center>" & ex.Message & "</td></tr></table>" + _
                                "<br></div><br>"
                        End Try
                    Case Else
                        ManList.InnerHtml = "<h2>مدیریت فایل ها</h2>" + _
                            "<div class='featured'><h3>حذف فایل</h3>" + _
                            "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>آیا می خواهید فایل " & System.IO.Path.GetFileName(Base64DeCode(FIDQSTR)) & " را حذف کنید؟</td></tr></table><br>" + _
                            "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td width=45% align=left><a href='/FM/?Page=DeleteFile&FileID=" & FIDQSTR & "&Action=Delete'>بله</a></td><td width=10%></td><td width=45% align=right><a href='/FM/'>خیر</a></td></tr></table>" + _
                            "<br></div><br>"
                End Select
                SBList.InnerHtml = "<li><h3>منوی مدیریت فایل ها</h3></li><table>" + _
                    "<tr><td><image src='/images/copy.png'></image></td><td><a href='/FM/'>لیست فایل ها</a></td></tr>" + _
                    "<tr><td><image src='/images/add_file.png'></image></td><td><a href='/FM/?Page=CreateFile'>ایجاد فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/upload.png'></image></td><td><a href='/FM/?Page=UploadFile'>آپلود فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/add_link.png'></image></td><td><a href='/FM/?Page=AddLink'>افزودن لینک</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='/FM/?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
            Case Else
                If Request.Browser.Cookies Then
                    If Request.Cookies("PBLOGIN") IsNot Nothing Then
                        passTemp = Toolz.Get_Admin_Info(Request.Cookies("PBLOGIN")("UNAME").ToString(), "AdminPass")
                        If Request.Cookies("PBLOGIN")("UPASS").ToString() <> passTemp Then
                            Response.Redirect("/FM/?Page=Login") : Exit Sub
                        End If
                    Else
                        Response.Redirect("/FM/?Page=Login") : Exit Sub
                    End If
                Else
                    GoTo Get_Cookie_Error
                    Exit Sub
                End If
                ttl.InnerText = "Pars TC - File Manager"
                MNUList.InnerHtml = "<li><a href='/FM/?Page=Login'>ورود</a></li>" + _
                    "<li class='current'><a href='/FM/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("List.ascx"))
                SBList.InnerHtml = "<li><h3>منوی مدیریت فایل ها</h3></li><table>" + _
                    "<tr><td><image src='/images/copy.png'></image></td><td><a href='/FM/'>لیست فایل ها</a></td></tr>" + _
                    "<tr><td><image src='/images/add_file.png'></image></td><td><a href='/FM/?Page=CreateFile'>ایجاد فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/upload.png'></image></td><td><a href='/FM/?Page=UploadFile'>آپلود فایل</a></td></tr>" + _
                    "<tr><td><image src='/images/add_link.png'></image></td><td><a href='/FM/?Page=AddLink'>افزودن لینک</a></td></tr>" + _
                    "<tr><td><image src='/images/logout.png'></image></td><td><a href='/FM/?Page=Logout'>خروج از پنل</a></td></tr>" + _
                    "</table>"
        End Select
        Exit Sub
Get_Cookie_Error:
        ttl.InnerText = "Pars TC - File Manager"
        MNUList.InnerHtml = "<li><a href='/FM/?Page=Login'>ورود</a></li>" + _
            "<li class='current'><a href='/FM/'>صفحه اصلی</a></li>"
        ManList.InnerHtml = "<h2>مدیریت فایل ها</h2>" + _
                "<div class='featured'><h3>ایجاد فایل</h3>" + _
                "<table width=100% border=0 cellspacing=0 cellpadding=0><tr><td align=center>شما قادر به ورود به بخش مدیریت فایل ها نمی باشید، ممکن است تنظيمات کوکي در سيستم شما غیرفعال باشد.</td></tr></table>" + _
                "<br></div><br>"
        SBList.InnerHtml = ""
    End Sub

End Class