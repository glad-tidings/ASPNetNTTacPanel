Public Class UserLeft
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainUL.InnerHtml = "<h3 style='color:#10b7f0'>دانلود کانکشن ها</h3><ul class='conn'>"
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM DownloadList WHERE DCategory='کانکشن';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    MainUL.InnerHtml &= "<li><a href='download/conn/" & d("DName".ToString) & "'>" & d("DTtitle".ToString) & "</a></li>"
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        MainUL.InnerHtml &= "</ul>"
    End Sub

End Class