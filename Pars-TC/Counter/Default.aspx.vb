Public Class _Default2
    Inherits System.Web.UI.Page

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RUA As String = Request.Url.Authority
        If (Microsoft.VisualBasic.Left(RUA, 3)).ToLower = "upd" Then Response.Redirect("http://upd.pars-tc.com:81/") : Exit Sub
        Dim QSTR As String = Request.QueryString("CID")
        Dim QSTR2 As String = Request.QueryString("CAct")
        If QSTR2 = "Counter" Then
            Try
                DBConn = New DBConnection
                DBConn.CoDBConnect("Insert Into CountList (CID,CDate,CAddress,CIP) Values (" & QSTR & ",'" & Format(Date.Now, "dd/MM/yyyy") & "','" & Request.Url.Authority & "','" & HttpContext.Current.Request.UserHostAddress & "');")
                DBConn.OLEComm.Connection = DBConn.OLEConn
                DBConn.OLEComm.ExecuteNonQuery()
                DBConn.OLEConn.Close()
            Catch err As System.Exception
            End Try
        End If
    End Sub

End Class