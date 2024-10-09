Public Class AddLink
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub sendbtn_Click(sender As Object, e As ImageClickEventArgs) Handles sendbtn.Click
        Try
            DBConn = New DBConnection
            DBConn.FMDBConnect("Insert Into LinkList (LinkAddress) Values ('" & link.Value & "');")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            DBConn.OLEComm.ExecuteNonQuery()
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        link.Value = ""
    End Sub

End Class