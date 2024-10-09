Public Class ResellerUserPassChange
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QSTR As String = Request.QueryString("UserName")
        cpusername.Value = QSTR
    End Sub

    Private Sub cpsavesubmit_ServerClick(sender As Object, e As System.EventArgs) Handles cpsavesubmit.ServerClick
        cperror.InnerHtml = ""
        Toolz = New Tools
        Dim TMP As ArrayList = New ArrayList
        TMP = Toolz.Get_Reseller_Info(Session.Item("RUser"))
        If Left(cpusername.Value, 4) <> TMP.Item(1) Then cperror.InnerHtml &= "<ul><li>شما مجاز به تغییر کلمه عبور کاربر مورد نظر نمی باشید</li></ul>" ': Exit Sub
        If cpnewpass.Value = "" Then cperror.InnerHtml &= "<ul><li>لطفا کلمه عبور جدید را وارد کنید</li></ul>" ': Exit Sub
        If cprepeatpass.Value = "" Then cperror.InnerHtml &= "<ul><li>لطفا تکرار کلمه عبور را وارد کنید</li></ul>" ': Exit Sub
        If cpnewpass.Value <> cprepeatpass.Value Then cperror.InnerHtml &= "<ul><li>کلمه عبور جدید با تکرار آن هماهنگ نیست</li></ul>" ': Exit Sub
        If cperror.InnerHtml <> "" Then Exit Sub
        Toolz.Edit_User_Info(cpusername.Value, "[Global]Passwd", cpnewpass.Value)
        Response.Redirect("/Reseller/?Page=AllUser")
    End Sub
End Class