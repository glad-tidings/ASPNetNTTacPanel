Public Class ErrorsList
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Toolz = New Tools
        Dim TMP As ArrayList = New ArrayList
        TMP = Toolz.Get_Error_Num
        ErrList.InnerHtml = "<table>"
        For I As Integer = 0 To TMP.Count - 1
            ErrList.InnerHtml += "<tr><td><div class='featuredddd'>شماره خطای " & TMP.Item(I) & "</div></td></tr>"
            ErrList.InnerHtml += "<tr><td><div class='featureddd'>" & Toolz.Get_Error_Info(TMP.Item(I)) & "</div></td></tr>"
        Next
        ErrList.InnerHtml += "</table>"
    End Sub
End Class