Public Class ResellerPassChange
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cpsavesubmit_ServerClick(sender As Object, e As System.EventArgs) Handles cpsavesubmit.ServerClick
        cperror.InnerHtml = ""
        If cpoldpass.Value = "" Then cperror.InnerHtml &= "<ul><li>لطفا کلمه عبور فعلی را وارد کنید</li></ul>" ': Exit Sub
        If cpnewpass.Value = "" Then cperror.InnerHtml &= "<ul><li>لطفا کلمه عبور جدید را وارد کنید</li></ul>" ': Exit Sub
        If cprepeatpass.Value = "" Then cperror.InnerHtml &= "<ul><li>لطفا تکرار کلمه عبور را وارد کنید</li></ul>" ': Exit Sub
        If cpnewpass.Value <> cprepeatpass.Value Then cperror.InnerHtml &= "<ul><li>کلمه عبور جدید با تکرار آن هماهنگ نیست</li></ul>" ': Exit Sub
        If cperror.InnerHtml <> "" Then Exit Sub
        Toolz = New Tools
        Dim TMP As ArrayList = New ArrayList
        TMP = Toolz.Get_Reseller_Info(Session.Item("RUser"))
        If GenerateHash(cpoldpass.Value, EncodingType.HEX, Algorithm.MD5) <> TMP.Item(0) Then cperror.InnerHtml = "<ul><li>کلمه عبور فعلی اشتباه است</li></ul>" : Exit Sub
        Toolz.Edit_Reseller_Info(Session.Item("RUser"), "ResellerPass", GenerateHash(cpnewpass.Value, EncodingType.HEX, Algorithm.MD5))
        Response.Redirect("/Reseller/")
    End Sub
End Class