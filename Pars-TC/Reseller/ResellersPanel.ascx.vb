Public Class ResellersPanel
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_Info()
    End Sub

    Private Sub Get_Info()
        Toolz = New Tools
        Dim TMPS As ArrayList = New ArrayList
        TMPS = Toolz.Get_Reseller_Info(Session.Item("RUser"))
        MainAP.InnerHtml = "<h2>پنل فروشندگان</h2><div class=featured>"
        If TMPS.Count <> 0 Then
            MainAP.InnerHtml += "<h3>وضعیت مالی اکانت فروشنده</h3><table width=100% border=0 cellspacing=0 cellpadding=0>" + _
            "<tr bgcolor=#dcdcdc><td width=50%>تعداد اکانت یک ماهه</td><td>" & TMPS.Item(3) & " اکانت</td></tr>" + _
            "<tr><td width=50%>تعداد اکانت سه ماهه</td><td>" & TMPS.Item(4) & " اکانت</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td width=50%>تعداد اکانت شش ماهه</td><td>" & TMPS.Item(5) & " اکانت</td></tr>" + _
            "<tr><td width=50%>تعداد اکانت یک ساله</td><td>" & TMPS.Item(6) & " اکانت</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td width=50%>بدهی اکانت یک ماهه</td><td>" & TMPS.Item(7) & " اکانت</td></tr>" + _
            "<tr><td width=50%>بدهی اکانت سه ماهه</td><td>" & TMPS.Item(8) & " اکانت</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td width=50%>بدهی اکانت شش ماهه</td><td>" & TMPS.Item(9) & " اکانت</td></tr>" + _
            "<tr><td width=50%>بدهی اکانت یک ساله</td><td>" & TMPS.Item(10) & " اکانت</td></tr>" + _
            "</table><br></div><br>"
        End If
    End Sub

End Class