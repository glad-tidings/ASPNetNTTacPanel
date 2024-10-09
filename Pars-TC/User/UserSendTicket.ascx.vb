Public Class UserSendTicket
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TSubject.Items.Add("موضوع را انتخاب کنید")
            Try
                DBConn = New DBConnection
                DBConn.AdminConnect("SELECT * FROM TSubjectList;")
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TSubject.Items.Add(d("TSubject".ToString))
                Loop
                DBConn.OLEConn.Close()
            Catch err As System.Exception
            End Try
            TSubject.SelectedIndex = 0
        End If
    End Sub

    Private Sub sendticketbtn_ServerClick(sender As Object, e As EventArgs) Handles sendticketbtn.ServerClick
        sendticketerror.InnerHtml = ""
        If TSubject.SelectedIndex = 0 Then sendticketerror.InnerHtml = "<ul><li>لطفا موضوع را انتخاب کنید</li></ul>"
        If TTitle.Value = "" Then sendticketerror.InnerHtml &= "<ul><li>لطفا عنوان را وارد کنید</li></ul>"
        If TDesc.Value.Length < 10 Then sendticketerror.InnerHtml &= "<ul><li>متن باید بیشتر از 10 کاراکتر باشد</li></ul>"
        If sendticketerror.InnerHtml <> "" Then GoTo GetError
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("Insert Into Tickets (TMain,TMainID,TSender,TSubject,TTitle,TDate,TDesc,TStatus) Values (True,0,'" & Session.Item("VUser") & "','" & TSubject.Text & "','" & TTitle.Value & "','" & Date.Now & "','" & TDesc.Value & "','باز');")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            DBConn.OLEComm.ExecuteNonQuery()
            DBConn.OLEConn.Close()
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        Response.Redirect("/User/?Page=UserTickets")
        Exit Sub
GetError:
    End Sub
End Class