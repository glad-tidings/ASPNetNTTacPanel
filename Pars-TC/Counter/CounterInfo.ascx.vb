Public Class CounterInfo
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_Count()
    End Sub

    Private Sub Get_Count()
        Dim TMP As DateTime
        MainCI.InnerHtml = "<li><h3>آمار بازدید</h3></li><table>"
        TMP = Date.Now
        Try
            DBConn = New DBConnection
            DBConn.CoDBConnect("SELECT COUNT(*) FROM CountList WHERE CDate='" & Format(TMP, "dd/MM/yyyy") & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            Dim d As Integer = DBConn.OLEComm.ExecuteScalar
            MainCI.InnerHtml &= "<tr><td align=left>بازدید امروز : </td><td>" & d & "</td></tr>"
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        TMP = Date.Now.AddDays(-1)
        Try
            DBConn = New DBConnection
            DBConn.CoDBConnect("SELECT COUNT(*) FROM CountList WHERE CDate='" & Format(TMP, "dd/MM/yyyy") & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            Dim d As Integer = DBConn.OLEComm.ExecuteScalar
            MainCI.InnerHtml &= "<tr><td align=left>بازدید دیروز : </td><td>" & d & "</td></tr>"
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        TMP = Date.Now
        Try
            DBConn = New DBConnection
            DBConn.CoDBConnect("SELECT COUNT(*) FROM CountList WHERE CDate LIKE '%" & Format(TMP, "/MM/yyyy") & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            Dim d As Integer = DBConn.OLEComm.ExecuteScalar
            MainCI.InnerHtml &= "<tr><td align=left>بازدید این ماه : </td><td>" & d & "</td></tr>"
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        TMP = Date.Now
        Try
            DBConn = New DBConnection
            DBConn.CoDBConnect("SELECT COUNT(*) FROM CountList WHERE CDate LIKE '%" & Format(TMP, "/yyyy") & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            Dim d As Integer = DBConn.OLEComm.ExecuteScalar
            MainCI.InnerHtml &= "<tr><td align=left>بازدید امسال : </td><td>" & d & "</td></tr>"
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        Try
            DBConn = New DBConnection
            DBConn.CoDBConnect("SELECT COUNT(*) FROM CountList;")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            Dim d As Integer = DBConn.OLEComm.ExecuteScalar
            MainCI.InnerHtml &= "<tr><td align=left>کل بازدید ها : </td><td>" & d & "</td></tr>"
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        MainCI.InnerHtml &= "</table>"
    End Sub
End Class