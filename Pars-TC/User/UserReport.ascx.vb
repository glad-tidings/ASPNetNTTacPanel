Public Class UserReport
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection
    Dim QSTR As String
    Dim btnArray As New List(Of Button)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Add("ReportPage", 1)
            Get_Report_Info()
        End If
    End Sub

    Private Sub Get_Report_Info()
        Dim SessionCount As Integer = 0
        Dim SessionTF As Boolean = False
        If Session.Count <> 0 Then
            If IsNumeric(Session.Item("ReportPage")) Then
                QSTR = Session.Item("ReportPage")
            End If
        End If
        Dim Count As Integer
        Dim QSTRINT As Integer = 0
        Dim URCount As Integer = 0
        Dim SB = 0, EB As Integer = 0
        Dim ERP As Integer = 0
        Dim tblCount As Integer
        If Not IsNumeric(QSTR) Then
            QSTRINT = 1
        Else
            If Int(QSTR) < 1 Then QSTRINT = 1 Else QSTRINT = CInt(QSTR)
        End If
        Try
            DBConn = New DBConnection
            DBConn.statConnect("SELECT count(*) FROM Accounting WHERE Username = '" & Session.Item("VUser") & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    URCount = d(0)
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        ERP = IIf((URCount Mod 10) = 0, (URCount \ 10), (URCount \ 10) + 1)
        If QSTRINT > ERP Then QSTRINT = ERP
        MainUR.InnerHtml = "<table width=100% border=0 cellspacing=0 cellpadding=0><tr bgcolor=#8a9fb6><td align=center>ردیف</td><td align=center>تاریخ ورود</td><td align=center>ساعت ورود</td><td align=center>تاریخ خروج</td><td align=center>ساعت خروج</td><td align=center>مدت زمان</td><td align=center>دانلود</td><td align=center>آپلود</td></tr>"
        tblCount = 0
        Try
            DBConn = New DBConnection
            DBConn.statConnect("SELECT * FROM Accounting WHERE Username = '" & Session.Item("VUser") & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    SessionCount += 1
                    If SessionCount >= ((QSTRINT * 10) - 9) Then
                        SessionTF = Not SessionTF
                        tblCount += 1
                        MainUR.InnerHtml &= "<tr height='21px'" + IIf(SessionTF, "", " bgcolor=#dcdcdc") + "><td align=center>" & SessionCount & "</td><td align=center>" & Format(d("Start".ToString), "dd/MM/yyyy") & "</td><td align=center>" & Format(d("Start".ToString), "hh:mm:ss") & "</td><td align=center>" & Format(d("Stop".ToString), "dd/MM/yyyy") & "</td><td align=center>" & Format(d("Stop".ToString), "hh:mm:ss") & "</td><td align=center>" & d("SessionTime".ToString) & " " & "دقیقه" & "</td><td dir=ltr align=center>" & d("KBytesOut".ToString) & " " & "KB" & "</td><td dir=ltr align=center>" & d("KBytesIN".ToString) & " " & "KB" & "</td></tr>"
                    End If
                    If SessionCount = (QSTRINT * 10) Then Exit Do
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        If tblCount < 10 Then
            For K As Integer = (tblCount + 1) To 10
                MainUR.InnerHtml &= "<tr height='21px'><td align=center></td><td align=center></td><td align=center></td><td align=center></td><td align=center></td><td align=center></td><td dir=ltr align=center></td><td dir=ltr align=center></td></tr>"
            Next
        End If
        MainUR.InnerHtml &= "</table>"
        If QSTRINT < 4 Then
            SB = 1
            If QSTRINT > (ERP - (3 + (4 - QSTRINT))) Then
                EB = ERP
            Else
                EB = QSTRINT + (3 + (4 - QSTRINT))
            End If
            GoTo Conn
        Else
            SB = QSTRINT - 3
        End If
        If QSTRINT > (ERP - 3) Then
            EB = ERP
            If QSTRINT < (3 + (QSTRINT - (ERP - 3))) Then
                SB = 1
            Else
                SB = QSTRINT - (3 + (QSTRINT - (ERP - 3)))
            End If
        Else
            EB = QSTRINT + 3
        End If
Conn:
        fbtn.CommandArgument = "1"
        pbtn.CommandArgument = IIf(QSTRINT = 1, QSTRINT, (QSTRINT - 1))
        nbtn.CommandArgument = IIf(QSTRINT = ERP, QSTRINT, (QSTRINT + 1))
        lbtn.CommandArgument = ERP
        Count = 0
        btnArray.Add(btn1)
        btnArray.Add(btn2)
        btnArray.Add(btn3)
        btnArray.Add(btn4)
        btnArray.Add(btn5)
        btnArray.Add(btn6)
        btnArray.Add(btn7)
        For J As Integer = 0 To 6
            btnArray.Item(J).Visible = False
        Next
        For I As Integer = SB To EB
            If I = QSTRINT Then
                btnArray.Item(Count).Text = I : btnArray.Item(Count).Enabled = False : btnArray.Item(Count).Visible = True
            Else
                btnArray.Item(Count).Text = I : btnArray.Item(Count).CommandArgument = I : btnArray.Item(Count).Enabled = True : btnArray.Item(Count).Visible = True
            End If
            Count += 1
        Next
        Dim PFLTMP As Integer = QSTR
        If PFLTMP < 1 Then
            PFLTMP = 1
        ElseIf PFLTMP > ERP Then
            PFLTMP = ERP
        End If
        pagefl.InnerText = "صفحه " & PFLTMP & " از " & ERP
    End Sub

    Private Sub fbtn_Click(sender As Object, e As EventArgs) Handles fbtn.Click
        Session.Add("ReportPage", fbtn.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub pbtn_Click(sender As Object, e As EventArgs) Handles pbtn.Click
        Session.Add("ReportPage", pbtn.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Session.Add("ReportPage", btn1.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Session.Add("ReportPage", btn2.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Session.Add("ReportPage", btn3.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Session.Add("ReportPage", btn4.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Session.Add("ReportPage", btn5.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Session.Add("ReportPage", btn6.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Session.Add("ReportPage", btn7.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub nbtn_Command(sender As Object, e As CommandEventArgs) Handles nbtn.Command
        Session.Add("ReportPage", nbtn.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub lbtn_Click(sender As Object, e As EventArgs) Handles lbtn.Click
        Session.Add("ReportPage", lbtn.CommandArgument)
        Get_Report_Info()
    End Sub

    Private Sub gotobtn_ServerClick(sender As Object, e As EventArgs) Handles gotobtn.ServerClick
        If IsNumeric(gotopage.Value) = False Then gotopage.Value = 1
        Session.Add("ReportPage", gotopage.Value)
        Get_Report_Info()
    End Sub
End Class