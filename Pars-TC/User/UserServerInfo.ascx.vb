Public Class UserServerInfo
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools
    Dim Servers As ArrayList
    Dim Client As New Net.WebClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Toolz = New Tools
        Servers = Toolz.Get_All_Servers
        Servers(0) = "216.246.49.26"
        Get_Info()
        ServerInfoUpdateTimer.Enabled = True
    End Sub

    Protected Sub ServerInfoUpdateTimer_Tick(sender As Object, e As EventArgs) Handles ServerInfoUpdateTimer.Tick
        Get_Info()
    End Sub

    Private Sub Get_Info()
        Dim TMP As String
        Dim SInfo(9) As String
        Dim TZ As String
        Dim ResponseT As String
        MainAP.InnerHtml = "<h2>کنترل پنل کاربران</h2><div class='featured'><h3>مشخصات سرورها</h3><table width=100% border=0 cellspacing=0 cellpadding=0>"
        For I As Integer = 0 To Servers.Count - 1
            Try
                TMP = Client.DownloadString("http://api.ipinfodb.com/v3/ip-city/?key=15f330382a05a3aba0c657bab3b32eb65ee512d1ff7d8f5daf4884cf85382180&ip=" & Servers(I)) & ";"
            Catch ex As Exception
                TMP = ""
            End Try
            For J As Integer = 0 To 9
                SInfo(J) = Microsoft.VisualBasic.Left(TMP, (InStr(TMP, ";") - 1))
                TMP = Microsoft.VisualBasic.Right(TMP, (Len(TMP) - IIf(J = 0, (InStr(TMP, ";") + 1), InStr(TMP, ";"))))
            Next
            If SInfo(2).ToLower = "gb" Then SInfo(2) = "uk"
            TZ = Replace(SInfo(9), ":", ".")
            TZ = Replace(TZ, "30", "50")
            Try
                ResponseT = Client.DownloadString("http://localhost:81/status/" & SInfo(2).ToLower & ".php")
            Catch ex As Exception
                ResponseT = ""
            End Try
            MainAP.InnerHtml &= "<tr bgcolor=#dcdcdc><td width=50%>سرور " & Toolz.CountryEn2Fa(SInfo(2)) & "</td><td dir=ltr><img src='/images/" & SInfo(2).ToLower & ".png' /></td></tr>" + _
                "<tr><td width=50%>زمان</td><td dir=ltr>" & Date.Now.ToUniversalTime().AddHours(CDbl(TZ)).ToString("g") & "</td></tr>" + _
                "<tr><td>آدرس اینترنتی</td><td dir=ltr>" & SInfo(2).ToLower & ".pars-tc.com</td></tr>" + _
                "<tr><td>آی پی</td><td dir=ltr>" & Replace(SInfo(1), "216.246.49.26", "198.23.143.118") & "</td></tr>" + _
                "<tr><td>وضعیت</td><td dir=ltr>" & IIf(ResponseT = "up", "فعال", "غیر فعال") & "</td></tr>" + _
                "<tr><td>موقعیت</td><td dir=ltr>" & SInfo(3) & ", " & SInfo(4) & ", " & SInfo(5) & "</td></tr>" + _
                "<tr><td>کد پستی</td><td dir=ltr>" & SInfo(6) & "</td></tr>" + _
                "<tr><td>طول جغرافیایی</td><td dir=ltr>" & SInfo(8) & "</td></tr>" + _
                "<tr><td>عرض جغرافیایی</td><td dir=ltr>" & SInfo(7) & "</td></tr>" + _
                "<tr><td>موقعیت زمانی</td><td dir=ltr>" & SInfo(9) & "</td></tr>"
        Next
        MainAP.InnerHtml &= "</table><br></div><br>"
    End Sub

End Class