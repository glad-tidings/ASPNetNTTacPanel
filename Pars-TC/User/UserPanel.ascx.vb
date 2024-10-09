Public Class UserPanel
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_Info()
    End Sub

    Private Sub Get_Info()
        Dim Expires As String
        Dim Expire As Integer
        Dim EffectiveFrom As DateTime
        Dim EFT, DisabledT As String
        Dim Span1 As TimeSpan
        Dim ExpireStatus = "", MaxLogins = "", FailedLogins = "", LastFailedLogin As String = ""
        Toolz = New Tools
        Expires = Toolz.Get_User_Info(Session.Item("VUser"), "[Global]Expires")
        Expire = Int(Right(Expires, Len(Expires) - 1))
        EFT = Toolz.Get_User_Info(Session.Item("VUser"), "[Global]EffectiveFrom")
        If EFT <> "" Then
            EffectiveFrom = Toolz.Convert_STR_Date(EFT)
        Else
            EffectiveFrom = Date.Now
        End If
        DisabledT = Toolz.Get_User_Info(Session.Item("VUser"), "[Global]Disabled")
        If DisabledT <> "" Then
            ExpireStatus = DisabledT
        Else
            ExpireStatus = "0"
        End If
        MaxLogins = Toolz.Get_User_Info(Session.Item("VUser"), "[Global]MaxLogins")
        FailedLogins = Toolz.Get_User_Info(Session.Item("VUser"), "[Warning]FailedLogins")
        LastFailedLogin = Toolz.Get_User_Info(Session.Item("VUser"), "[Warning]LastFailedLogin")
        Span1 = Date.Now.Subtract(EffectiveFrom)
        MainAP.InnerHtml = "<h2>کنترل پنل کاربران</h2><div class='featured'><h3>اطلاعات اکانت شما</h3>" + _
            "<table width=100% border=0 cellspacing=0 cellpadding=0>" + _
            "<tr bgcolor=#dcdcdc><td width=50%>تاريخ فعال شدن اکانت</td><td>" & Format(EffectiveFrom, "dd/MM/yyyy") & "</td></tr>" + _
            "<tr><td>مدت زمان اکانت</td><td>" & Expire & " روز</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td>مدت زمان استفاده شده</td><td>" & IIf(Span1.Days > Expire, Expire, Span1.Days) & " روز</td></tr>" + _
            "<tr><td>مدت زمان باقیمانده</td><td>" & IIf((Expire - Span1.Days) < 0, 0, (Expire - Span1.Days)) & " روز</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td>نوع اکانت</td><td>ماهیانه</td></tr>" + _
            "<tr><td>وضعیت اکانت</td><td>" & IIf(ExpireStatus = "0", "فعال", "غیر فعال") & "</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td>قابلیت استفاده همزمان</td><td>" & MaxLogins & " کاربر</td></tr>" + _
            "</table><br>"
        MainAP.InnerHtml &= "<h3>اتصالهای ناموفق</h3>" + _
            "<table width=100% border=0 cellspacing=0 cellpadding=0>" + _
            "<tr bgcolor=#dcdcdc><td width=50%>تعداد</td><td>" & FailedLogins & "</td></tr>" + _
            "<tr><td>تاريخ آخرين اتصال ناموفق</td><td>" & IIf(LastFailedLogin = "", "", Format(Toolz.Convert_STR_Date(LastFailedLogin), "dd/MM/yyyy")) & "</td></tr>" + _
            "<tr bgcolor=#dcdcdc><td>ساعت آخرين اتصال ناموفق</td><td>" & IIf(LastFailedLogin = "", "", Format(Toolz.Convert_STR_Date(LastFailedLogin), "hh:mm:ss")) & "</td></tr>" + _
            "</table><br></div><br>"
    End Sub

End Class