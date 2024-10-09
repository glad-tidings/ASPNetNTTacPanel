Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("Page")
        Dim Client As New Net.WebClient
        Dim ResponseT(2) As String
        Select Case QSTR
            Case "Contact-US"
                ttl.InnerText = "Pars TC - Contact Us"
                MNUList.InnerHtml = "<li class='current'><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='/Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='/News/'>اخبار</a></li>" + _
                    IIf(Session.Item("ALogin") = "True", "<li><a href='/Admin/'>پنل مدیریت</a></li>", "<li><a href='/User/?Page=Login'>پنل کاربری</a></li>") + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("ContactUS.ascx"))
                ULList.Controls.Add(LoadControl("UserLeft.ascx"))
                UMList.Controls.Add(LoadControl("UserMiddle.ascx"))
                URList.Controls.Add(LoadControl("UserRight.ascx"))
            Case "Download-Connection"
                ttl.InnerText = "Pars TC - Download Connection"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='/Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='/News/'>اخبار</a></li>" + _
                    IIf(Session.Item("ALogin") = "True", "<li><a href='/Admin/'>پنل مدیریت</a></li>", "<li><a href='/User/?Page=Login'>پنل کاربری</a></li>") + _
                    "<li><a href='/'>صفحه اصلی</a></li>"
                ManList.InnerHtml = "<h2>دانلود کانکشن ها ، برنامه ها و آموزش ها</h2>" + _
                    "<div class='featured'>" + _
                    "<div><image align=right src='images/zip.png' width=80 height=80></image>نوع فایل : آرشیو<br>نام فایل : کانکشن تمامی سرورها<br>" + _
                    "توضیحات : این آرشیو حاوی کانکشن تمامی سرورها می باشد.<br>حجم فایل : 1.04 مگابایت<br>" + _
                    "<a href='conn/Pars-All.zip'>دانلود فایل</a><br><br></div>" + _
                    "<div><image align=right src='images/zip.png' width=80 height=80></image>نوع فایل : آرشیو<br>نام فایل : کانکشن سرور آمریکا<br>" + _
                    "توضیحات : این آرشیو حاوی کانکشن سرور آمریکا می باشد.<br>حجم فایل : 359 کیلوبایت<br>" + _
                    "<a href='conn/Pars-USA.zip'>دانلود فایل</a><br><br></div>" + _
                    "<div><image align=right src='images/zip.png' width=80 height=80></image>نوع فایل : آرشیو<br>نام فایل : کانکشن سرور انگلیس<br>" + _
                    "توضیحات : این آرشیو حاوی کانکشن سرور انگلیس می باشد.<br>حجم فایل : 1 کیلوبایت<br>" + _
                    "<a href='conn/Pars-UK.zip'>دانلود فایل</a><br><br></div>" + _
                    "<div><image align=right src='images/zip.png' width=80 height=80></image>نوع فایل : آرشیو<br>نام فایل : کانکشن سرور آلمان<br>" + _
                    "توضیحات : این آرشیو حاوی کانکشن سرور آلمان می باشد.<br>حجم فایل : 359 کیلوبایت<br>" + _
                    "<a href='conn/Pars-Germany.zip'>دانلود فایل</a><br><br></div></div><br>"
                ULList.Controls.Add(LoadControl("UserLeft.ascx"))
                UMList.Controls.Add(LoadControl("UserMiddle.ascx"))
                URList.Controls.Add(LoadControl("UserRight.ascx"))
            Case Else
                ttl.InnerText = "Pars TC"
                MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='/Support/'>پشتیبانی</a></li>" + _
                    "<li><a href='/News/'>اخبار</a></li>" + _
                    IIf(Session.Item("ALogin") = "True", "<li><a href='/Admin/'>پنل مدیریت</a></li>", "<li><a href='/User/?Page=Login'>پنل کاربری</a></li>") + _
                    "<li class='current'><a href='/'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("SlideShow.ascx"))
                ULList.Controls.Add(LoadControl("UserLeft.ascx"))
                UMList.Controls.Add(LoadControl("UserMiddle.ascx"))
                URList.Controls.Add(LoadControl("UserRight.ascx"))
        End Select
    End Sub

End Class