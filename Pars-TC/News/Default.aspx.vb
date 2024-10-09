Public Class NDefault
    Inherits System.Web.UI.Page

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("Page")
        Select Case QSTR
            Case "Server"
                ttl.InnerText = "Pars TC - Server News"
            Case "Internet"
                ttl.InnerText = "Pars TC - Internet News"
            Case Else
                ttl.InnerText = "Pars TC - Site News"
        End Select
        MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
                    "<li><a href='/Support/'>پشتیبانی</a></li>" + _
                    "<li class='current'><a href='/News/'>اخبار</a></li>"
        If Session.Item("ALogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Admin/'>پنل مدیریت</a></li>"
        ElseIf Session.Item("RLogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Reseller/'>پنل فروشنده</a></li>"
        Else
            MNUList.InnerHtml &= "<li><a href='/User/'>پنل کاربری</a></li>"
        End If
        MNUList.InnerHtml &= "<li><a href='/'>صفحه اصلی</a></li>"
        Try
            DBConn = New DBConnection
            Select Case QSTR
                Case "Server"
                    DBConn.AdminConnect("SELECT * FROM News WHERE NCat='Server';")
                Case "Internet"
                    DBConn.AdminConnect("SELECT * FROM News WHERE NCat='Internet';")
                Case Else
                    DBConn.AdminConnect("SELECT * FROM News WHERE NCat='Site';")
            End Select
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                RepeaterNews.DataSource = DBConn.OLEComm.ExecuteReader()
                RepeaterNews.DataBind()
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        SBList.InnerHtml = "<li><h3>منوی اخبار</h3></li><table>" + _
            "<tr><td><image src='/images/news.png'></image></td><td><a href='/News/'>اخبار سایت</a></td></tr>" + _
            "<tr><td><image src='/images/server.png'></image></td><td><a href='/News/?Page=Server'>اخبار سرورها</a></td></tr>" + _
            "<tr><td><image src='/images/internet.png'></image></td><td><a href='/News/?Page=Internet'>اخبار اینترنت</a></td></tr>" + _
            "</table></div>"
        ULList.Controls.Add(LoadControl("/UserLeft.ascx"))
        UMList.Controls.Add(LoadControl("/UserMiddle.ascx"))
        URList.Controls.Add(LoadControl("/UserRight.ascx"))
    End Sub

End Class