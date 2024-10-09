Public Class OnlineUsers
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools
    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OnlineUser()
        OnlineUserTimer.Enabled = True
    End Sub

    Private Sub OnlineUser()
        Toolz = New Tools
        Dim Loc As String
        Dim LoginCount As Integer = 0
        Dim LoginTF As Boolean = False
        Dim LoginTime As DateTime
        Dim Span1 As TimeSpan
        MainOU.InnerHtml = "<h2>پنل مدیریت</h2>" + _
                    "<div class='featured'><h3>کاربران آنلاین</h3>" + _
                    "<table width=100% border=0 cellspacing=0 cellpadding=0><tr bgcolor=#00316d style='color:#ffffff;'><td align=center>ردیف</td><td align=center>نام کاربری</td><td align=center>سرور</td><td align=center>زمان ورود</td><td align=center>مدت زمان</td><td align=center>آی پی</td><td align=center></td></tr>"
        Try
            DBConn = New DBConnection
            DBConn.statConnect("SELECT * FROM ActiveUsers;")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    If d("Username".ToString).ToString.ToLower <> "admin" Then
                        Select Case d("NAS".ToString)
                            Case "127.0.0.1", "31.3.234.133"
                                Loc = "انگلیس"
                            Case "198.23.143.118"
                                Loc = "آمریکا"
                            Case "46.21.145.80"
                                Loc = "هلند"
                            Case "5.9.195.249"
                                Loc = "آلمان"
                            Case "31.7.57.121"
                                Loc = "سویس"
                            Case Else
                                Loc = "نامشخص"
                        End Select
                        LoginCount += 1
                        LoginTF = Not LoginTF
                        LoginTime = d("LoginTime".ToString)
                        Span1 = Date.Now.Subtract(LoginTime)
                        MainOU.InnerHtml += "<tr height='30px'" + IIf(LoginTF, "", " bgcolor=#4297ff") + "><td align=center>" & LoginCount & "</td><td align=center>" & d("Username".ToString) & "</td><td align=center>" & Loc & "</td><td align=center>" & Format(LoginTime, "dd/MM/yyyy hh:mm:ss") & "</td><td align=center>" & Span1.Minutes & " دقیقه</td><td align=center>" & d("CallerID".ToString) & "</td><td align=center><a class='black' href='?Page=KillUser&UserID=" & Base64EnCode(d("Username".ToString)) & "' style='color:white;'>قطع</a></td></tr>"
                    End If
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        MainOU.InnerHtml += "</table><br></div>"
    End Sub

    Protected Sub OnlineUserTimer_Tick(sender As Object, e As EventArgs) Handles OnlineUserTimer.Tick
        OnlineUser()
    End Sub
End Class