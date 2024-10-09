Public Class UserPassChange
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
        If cpoldpass.Value <> Toolz.Get_User_Info(Session.Item("VUser"), "[Global]Passwd") Then cperror.InnerHtml = "<ul><li>کلمه عبور فعلی اشتباه است</li></ul>" : Exit Sub
        Toolz.Edit_User_Info(Session.Item("VUser"), "[Global]Passwd", cpnewpass.Value)
        Response.Redirect("/User/")
    End Sub
End Class