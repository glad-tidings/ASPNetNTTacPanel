Public Class AdminsLogin
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub loginbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginbtn.ServerClick
        loginerror.InnerHtml = ""
        If Not LoginCaptcha.IsValid Then loginerror.InnerHtml &= "<ul><li>" & LoginCaptcha.ErrorMessage & "</li></ul>" ': Exit Sub
        Toolz = New Tools
        Dim passTemp As String = ""
        If username.Value = "" Then loginerror.InnerHtml &= "<ul><li>لطفا نام کاربری را وارد کنید</li></ul>" ': Exit Sub
        If password.Value = "" Then loginerror.InnerHtml &= "<ul><li>لطفا کلمه عبور را وارد کنید</li></ul>" ': Exit Sub
        If (InStr(username.Value, "'") <> 0) Or (InStr(username.Value, ";") <> 0) Or (InStr(username.Value, "-") <> 0) Then loginerror.InnerHtml &= "<ul><li>لطفا نام کاربری را صحیح وارد کنید</li></ul>" ': Exit Sub
        If (InStr(password.Value, "'") <> 0) Or (InStr(password.Value, ";") <> 0) Or (InStr(password.Value, "-") <> 0) Then loginerror.InnerHtml &= "<ul><li>لطفا کلمه عبور را صحیح وارد کنید</li></ul>" ': Exit Sub
        If loginerror.InnerHtml <> "" Then Exit Sub
        passTemp = Toolz.Get_Admin_Info(username.Value, "AdminPass")
        If GenerateHash(password.Value, EncodingType.HEX, Algorithm.MD5) = passTemp Then
            Session.Add("ALogin", "True")
            Session.Add("AUser", username.Value)
            Response.Redirect("/Admin/")
        Else
            loginerror.InnerHtml = "<ul><li>نام کاربری یا کلمه عبور اشتباه است</li></ul>" : Exit Sub
        End If
    End Sub

    Private Sub CaptchaRefresh_ServerClick(sender As Object, e As EventArgs) Handles CaptchaRefresh.ServerClick
        'CaptchaRefresh IS Very GOOD
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoginCaptcha.CaptchaLangs = "fa-IR"
    End Sub
End Class