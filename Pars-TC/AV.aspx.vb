Public Class AV
    Inherits System.Web.UI.Page

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Toolz = New Tools
        Dim QSTR As String = Request.QueryString("Page")
        Select Case QSTR
            Case "Eset", "Kaspersky", "DrWeb", "TrojanRemover", "AVZ"
                ttl.InnerText = "Pars TC - Anti Virus Update Information"
                MNUList.InnerHtml = "<li><a href='AV.aspx?Page=Login'>پنل کاربری</a></li>" + _
                    "<li class='current'><a href='AV.aspx?Page=Eset'>صفحه اصلی</a></li>"
                ManList.Controls.Add(LoadControl("AV.ascx"))
                SBList.InnerHtml = "<li><h3>منوی آنتی ویروس</h3></li><table>" + _
                    "<tr><td><image src='images/admin-pn.png'></image></td><td><a href='AV.aspx?Page=Eset'>آنتی ویروس نود 32</a></td></tr>" + _
                    "<tr><td><image src='images/user-on.png'></image></td><td><a href='AV.aspx?Page=Kaspersky'>آنتی ویروس کاسپر اسکای</a></td></tr>" + _
                    "<tr><td><image src='images/user-all.png'></image></td><td><a href='AV.aspx?Page=DrWeb'>آنتی ویروس دکتر وب</a></td></tr>" + _
                    "<tr><td><image src='images/user-add.png'></image></td><td><a href='AV.aspx?Page=TrojanRemover'>آنتی ویروس تروجان ریمور</a></td></tr>" + _
                    "<tr><td><image src='images/logout.png'></image></td><td><a href='AV.aspx?Page=AVZ'>آنتی ویروس ای وی زد</a></td></tr>" + _
                    "</table>"
            Case Else
                Response.Redirect("AV.aspx?Page=Eset")
        End Select
    End Sub

End Class