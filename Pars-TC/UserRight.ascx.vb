Public Class UserRight
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainUR.InnerHtml = "<h3 style='color:#bada8b'>دانلود آموزش ها</h3><ul class='learn'>"
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM DownloadList WHERE DCategory='آموزش';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    MainUR.InnerHtml &= "<li><a href='download/learn/" & d("DName".ToString) & "'>" & d("DTtitle".ToString) & "</a></li>"
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        MainUR.InnerHtml &= "</ul>"
    End Sub

End Class