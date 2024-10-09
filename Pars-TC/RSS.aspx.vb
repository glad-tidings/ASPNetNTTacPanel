Public Class RSS
    Inherits System.Web.UI.Page

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM News WHERE NTop=True;")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                RepeaterRSS.DataSource = DBConn.OLEComm.ExecuteReader()
                RepeaterRSS.DataBind()
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
    End Sub

End Class