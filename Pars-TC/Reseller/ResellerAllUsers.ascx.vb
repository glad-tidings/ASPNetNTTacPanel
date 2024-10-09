Public Class ResellerAllUsers
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools
    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Toolz = New Tools
            Dim TMP As ArrayList = New ArrayList
            Dim Users As ArrayList = New ArrayList
            TMP = Toolz.Get_Reseller_Info(Session.Item("RUser"))
            Users = Toolz.Get_All_Users(TMP.Item(1))
            RUsers.Items.Add("کاربر را انتخاب کنید")
            For I As Integer = 0 To Users.Count - 1
                RUsers.Items.Add(Users.Item(I))
            Next
        End If
    End Sub

    Protected Sub RUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RUsers.SelectedIndexChanged
        Toolz = New Tools
        Dim Expires As String
        Dim Expire As Integer
        Dim EFT, DisabledT As String
        Dim EffectiveFrom As DateTime
        Dim Span1 As TimeSpan
        Dim ES = "خام", ExpireStatus = "", MaxLogins = "", FailedLogins = "", LastFailedLogin As String = ""
        If RUsers.SelectedIndex <> 0 Then
            Expires = Toolz.Get_User_Info(RUsers.Text, "[Global]Expires")
            Expire = Int(Right(Expires, Len(Expires) - 1))
            EFT = Toolz.Get_User_Info(RUsers.Text, "[Global]EffectiveFrom")
            If EFT <> "" Then
                EffectiveFrom = Toolz.Convert_STR_Date(EFT)
            Else
                EffectiveFrom = Date.Now
            End If
            DisabledT = Toolz.Get_User_Info(RUsers.Text, "[Global]Disabled")
            If DisabledT <> "" Then
                ExpireStatus = DisabledT
            Else
                ExpireStatus = "0"
            End If
            MaxLogins = Toolz.Get_User_Info(RUsers.Text, "[Global]MaxLogins")
            FailedLogins = Toolz.Get_User_Info(RUsers.Text, "[Warning]FailedLogins")
            LastFailedLogin = Toolz.Get_User_Info(RUsers.Text, "[Warning]LastFailedLogin")
            Span1 = Date.Now.Subtract(EffectiveFrom)
            Select Case ExpireStatus
                Case "0"
                    ES = "فعال"
                Case Else
                    ES = "غیر فعال"
            End Select
            If (Expire - Span1.Days) <= 0 Then
                ES = "اتمام"
            ElseIf Span1.Days = 0 Then
                ES = "خام"
            End If
            RUI.InnerHtml = "<table width=100% border=0 cellspacing=0 cellpadding=0>" + _
                "<tr bgcolor=#dcdcdc><td width=50%>نام کاربری</td><td>" & RUsers.Text & "</td></tr>" + _
                "<tr><td width=50%>کلمه عبور</td><td>" & Toolz.Get_User_Info(RUsers.Text, "[Global]Passwd") & "</td></tr>" + _
                "<tr bgcolor=#dcdcdc><td width=50%>تاريخ فعال شدن اکانت</td><td>" & Format(EffectiveFrom, "dd/MM/yyyy") & "</td></tr>" + _
                "<tr><td>مدت زمان اکانت</td><td>" & Expire & " روز</td></tr>" + _
                "<tr bgcolor=#dcdcdc><td>مدت زمان استفاده شده</td><td>" & IIf(Span1.Days > Expire, Expire, Span1.Days) & " روز</td></tr>" + _
                "<tr><td>مدت زمان باقیمانده</td><td>" & IIf((Expire - Span1.Days) < 0, 0, (Expire - Span1.Days)) & " روز</td></tr>" + _
                "<tr bgcolor=#dcdcdc><td>نوع اکانت</td><td>ماهیانه</td></tr>" + _
                "<tr><td>وضعیت اکانت</td><td>" & ES & "</td></tr>" + _
                "<tr bgcolor=#dcdcdc><td>قابلیت استفاده همزمان</td><td>" & MaxLogins & " کاربر</td></tr>" + _
                "</table>"
            CUP.HRef = "/Reseller/?Page=ChangeUserPass&UserName=" & RUsers.Text
        Else
            RUI.InnerHtml = ""
            CUP.HRef = ""
        End If
    End Sub
End Class