Public Class UserMiddle
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainUM.InnerHtml = "<h3 style='color:#ffd441'>دانلود نرم افزار ها</h3><ul class='soft'>"
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM DownloadList WHERE DCategory='نرم افزار';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    MainUM.InnerHtml &= "<li><a href='download/software/" & d("DName".ToString) & "'>" & d("DTtitle".ToString) & "</a></li>"
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        MainUM.InnerHtml &= "</ul>"
    End Sub

End Class