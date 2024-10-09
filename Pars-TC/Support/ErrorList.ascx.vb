Public Class ErrorList
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub findbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles findbtn.ServerClick
        Toolz = New Tools
        finderror.InnerHtml = ""
        Dim errorTMP As String = ""
        If errornum.Value = "" Then finderror.InnerHtml &= "<ul><li>لطفا شماره خطا را وارد کنید</li></ul>" ': Exit Sub
        If Not IsNumeric(errornum.Value) Then finderror.InnerHtml &= "<ul><li>لطفا شماره خطا را صحیح وارد کنید</li></ul>" ': Exit Sub
        If finderror.InnerHtml <> "" Then Exit Sub
        errorTMP = Toolz.Get_Error_Info(errornum.Value)
        If errorTMP <> "" Then
            errordesc.InnerText = errorTMP
        Else
            finderror.InnerHtml = "<ul><li>شماره خطای مورد نظر یافت نشد.</li></ul>" : Exit Sub
        End If
    End Sub

End Class