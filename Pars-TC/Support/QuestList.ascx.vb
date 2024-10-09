Public Class QuestList
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        QuesList.InnerHtml = "<table>"
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM QuestList;")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    QuesList.InnerHtml += "<tr><td><div class='featureddddd'>" & d("QQuestion".ToString) & "</div></td></tr>"
                    QuesList.InnerHtml += "<tr><td><div class='featuredddddd'>" & d("QAnswer".ToString) & "</div></td></tr>"
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        QuesList.InnerHtml += "</table>"
    End Sub
End Class