Public Class UserOnline
    Inherits System.Web.UI.UserControl
    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OnlineUser()
        OnlineUserTimer.Enabled = True
    End Sub

    Protected Sub OnlineUserTimer_Tick(sender As Object, e As EventArgs) Handles OnlineUserTimer.Tick
        OnlineUser()
    End Sub

    Private Sub OnlineUser()
        Dim LoginCount As Integer = 0
        Dim LoginTF As Boolean = False
        Dim LoginTime As DateTime
        Dim Span1 As TimeSpan
        Dim LOC As String
        MainUO.InnerHtml = "<h2>کنترل پنل کاربران</h2>" + _
            "<div class='featured'><h3>وضعیت آنلاین بودن اکانت شما</h3>" + _
            "<table width=100% border=0 cellspacing=0 cellpadding=0><tr bgcolor=#8a9fb6><td align=center>ردیف</td><td align=center>شناسه</td><td align=center>سرور</td><td align=center>زمان ورود</td><td align=center>مدت زمان (دقیقه)</td><td align=center>آی پی</td></tr>"
        Try
            DBConn = New DBConnection
            DBConn.statConnect("SELECT * FROM ActiveUsers WHERE Username = '" & Session.Item("VUser") & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    Select Case d("NAS".ToString)
                        Case "127.0.0.1", "31.3.234.133"
                            LOC = "انگلیس"
                        Case "198.23.143.118"
                            LOC = "آمریکا"
                        Case "46.21.145.80"
                            LOC = "هلند"
                        Case "5.9.195.249"
                            LOC = "آلمان"
                        Case "31.7.57.121"
                            LOC = "سویس"
                        Case Else
                            LOC = "نامشخص"
                    End Select
                    LoginCount += 1
                    LoginTF = Not LoginTF
                    LoginTime = d("LoginTime".ToString)
                    Span1 = Date.Now.Subtract(LoginTime)
                    MainUO.InnerHtml += "<tr" + IIf(LoginTF, "", " bgcolor=#dcdcdc") + "><td align=center>" & LoginCount & "</td><td align=center>" & d("UserID".ToString) & "</td><td align=center>" & LOC & "</td><td align=center>" & LoginTime & "</td><td align=center>" & Span1.Minutes & "</td><td align=center>" & d("CallerID".ToString) & "</td></tr>"
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        MainUO.InnerHtml += "</table><br></div><br>"
    End Sub
End Class