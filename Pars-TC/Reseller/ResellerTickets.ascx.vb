Public Class ResellerTickets
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection
    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Toolz = New Tools
        Dim TMPS As ArrayList = New ArrayList
        TMPS = Toolz.Get_Reseller_Info(Session.Item("RUser"))
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM Tickets WHERE TMain=True AND TStatus<>'بسته' AND TSender LIKE '" & TMPS.Item(1) & "%';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            RepeaterNews.DataSource = DBConn.OLEComm.ExecuteReader()
            RepeaterNews.DataBind()
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
    End Sub

    Private Sub sendticketbtn_ServerClick(sender As Object, e As EventArgs) Handles sendticketbtn.ServerClick
        If TDesc.Value.Length < 10 Then
            sendticketerror.InnerHtml = "<ul><li>متن باید بیشتر از 10 کاراکتر باشد</li></ul>"
            Exit Sub
        Else
            Dim QSTR As Long = IIf(IsNumeric(Request.QueryString("ID")), Request.QueryString("ID"), 0)
            Try
                DBConn = New DBConnection
                DBConn.AdminConnect("Insert Into Tickets (TMain,TMainID,TSender,TDate,TDesc) Values (False," & QSTR & ",'کارشناس پشتیبانی','" & Date.Now & "','" & TDesc.Value & "');")
                DBConn.OLEComm.Connection = DBConn.OLEConn
                DBConn.OLEComm.ExecuteNonQuery()
                DBConn.OLEConn.Close()
                DBConn.OLEConn.Close()
            Catch err As System.Exception
            End Try
            Try
                DBConn = New DBConnection
                DBConn.AdminConnect("Update Tickets SET TStatus='پاسخ کارشناس' WHERE ID = " & QSTR & ";")
                DBConn.OLEComm.Connection = DBConn.OLEConn
                DBConn.OLEComm.ExecuteNonQuery()
                DBConn.OLEConn.Close()
            Catch err As System.Exception
            End Try
            Response.Redirect("/Reseller/?Page=ResellerTickets")
        End If
    End Sub

    Private Sub closeticketbtn_ServerClick(sender As Object, e As EventArgs) Handles closeticketbtn.ServerClick
        Dim QSTR As Long = IIf(IsNumeric(Request.QueryString("ID")), Request.QueryString("ID"), 0)
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("Update Tickets SET TStatus='بسته' WHERE ID = " & QSTR & ";")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            DBConn.OLEComm.ExecuteNonQuery()
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        Response.Redirect("/Reseller/?Page=ResellerTickets")
    End Sub
End Class