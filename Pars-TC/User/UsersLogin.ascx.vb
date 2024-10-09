Imports System.Threading
Imports System.Globalization

Public Class UsersLogin
    Inherits System.Web.UI.UserControl
    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginCaptcha.CaptchaLangs = "fa-IR"
    End Sub

    Protected Sub loginbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginbtn.ServerClick
        loginerror.InnerHtml = ""
        If Not LoginCaptcha.IsValid Then loginerror.InnerHtml &= "<ul><li>" & LoginCaptcha.ErrorMessage & "</li></ul>" ': Exit Sub
        Toolz = New Tools
        Dim passTemp As String = ""
        If username.Value = "" Then loginerror.InnerHtml &= "<ul><li>لطفا نام کاربری را وارد کنید</li></ul>" ': Exit Sub
        If password.Value = "" Then loginerror.InnerHtml &= "<ul><li>لطفا کلمه عبور را وارد کنید</li></ul>" ': Exit Sub
        If (InStr(username.Value, "'") <> 0) Or (InStr(username.Value, ";") <> 0) Or (InStr(username.Value, "-") <> 0) Then loginerror.InnerHtml &= "<ul><li>لطفا نام کاربری را صحیح وارد کنید</li></ul>" ': Exit Sub
        If (InStr(password.Value, "'") <> 0) Or (InStr(password.Value, ";") <> 0) Or (InStr(password.Value, "-") <> 0) Then loginerror.InnerHtml &= "<ul><li>لطفا کلمه عبور را صحیح وارد کنید</li></ul>" ': Exit Sub
        If loginerror.InnerHtml <> "" Then GoTo GetError
        passTemp = Toolz.Get_User_Info(username.Value, "[Global]Passwd")
        If password.Value = passTemp Then
            Session.Add("VLogin", "True")
            Session.Add("VUser", username.Value)
            Response.Redirect("/User/")
        Else
            loginerror.InnerHtml = "<ul><li>نام کاربری یا کلمه عبور اشتباه است</li></ul>" : Exit Sub
        End If
        Exit Sub
GetError:
    End Sub

    Private Sub CaptchaRefresh_ServerClick(sender As Object, e As EventArgs) Handles CaptchaRefresh.ServerClick
        'CaptchaRefresh IS Very GOOD
    End Sub
End Class