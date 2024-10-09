Public Class SDefault
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("Page")
        Select Case QSTR
            Case "AllError"
                ttl.InnerText = "Pars TC - Support - Errors List"
            Case "FindError"
                ttl.InnerText = "Pars TC - Support - Search Error"
            Case Else
                ttl.InnerText = "Pars TC - Support - Questions List"
        End Select
        MNUList.InnerHtml = "<li><a href='/?Page=Contact-US'>ارتباط با ما</a></li>" + _
            "<li class='current'><a href='/Support/'>پشتیبانی</a></li>" + _
            "<li><a href='/News/'>اخبار</a></li>"
        If Session.Item("ALogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Admin/'>پنل مدیریت</a></li>"
        ElseIf Session.Item("RLogin") = "True" Then
            MNUList.InnerHtml &= "<li><a href='/Reseller/'>پنل فروشنده</a></li>"
        Else
            MNUList.InnerHtml &= "<li><a href='/User/'>پنل کاربری</a></li>"
        End If
        MNUList.InnerHtml &= "<li><a href='/'>صفحه اصلی</a></li>"
        Select Case QSTR
            Case "AllError"
                ManList.Controls.Add(LoadControl("ErrorsList.ascx"))
            Case "FindError"
                ManList.Controls.Add(LoadControl("ErrorList.ascx"))
            Case Else
                ManList.Controls.Add(LoadControl("QuestList.ascx"))
        End Select
        SBList.InnerHtml = "<li><h3>منوی پشتیبانی</h3></li><table>" + _
            "<tr><td><image src='/images/question.png'></image></td><td><a href='/Support/'>سوالات متداول</a></td></tr>" + _
            "<tr><td><image src='/images/error.png'></image></td><td><a href='/Support/?Page=AllError'>مرجع خطاها</a></td></tr>" + _
            "<tr><td><image src='/images/error-f.png'></image></td><td><a href='/Support/?Page=FindError'>جستجوی شماره خطا</a></td></tr>" + _
            "</table>"
        ULList.Controls.Add(LoadControl("/UserLeft.ascx"))
        UMList.Controls.Add(LoadControl("/UserMiddle.ascx"))
        URList.Controls.Add(LoadControl("/UserRight.ascx"))
    End Sub

End Class