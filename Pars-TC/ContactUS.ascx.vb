Imports System.Net.Mail
Imports System.Net

Public Class ContactUS
    Inherits System.Web.UI.UserControl

    Dim SAEmail As String = "ParsTC Accounting Support <support@acc.pars-tc.com>"

    Protected Sub sendbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendbtn.ServerClick
        senderror.InnerText = ""
        If Not LoginCaptcha.IsValid Then senderror.InnerHtml &= "<ul><li>" & LoginCaptcha.ErrorMessage & "</li></ul>" ': Exit Sub
        If username.Value = "" Then senderror.InnerHtml &= "<ul><li>لطفا نام کاربری را وارد کنید</li></ul>" ': Exit Sub
        If password.Value = "" Then senderror.InnerHtml &= "<ul><li>لطفا کلمه عبور را وارد کنید</li></ul>" ': Exit Sub
        If smail.Value = "" Then senderror.InnerHtml &= "<ul><li>لطفا ایمیل را وارد کنید</li></ul>" ': Exit Sub
        If (InStr(username.Value, "'") <> 0) Or (InStr(username.Value, ";") <> 0) Or (InStr(username.Value, "-") <> 0) Then senderror.InnerHtml &= "<ul><li>لطفا نام کاربری را صحیح وارد کنید</li></ul>" ': Exit Sub
        If (InStr(password.Value, "'") <> 0) Or (InStr(password.Value, ";") <> 0) Or (InStr(password.Value, "-") <> 0) Then senderror.InnerHtml &= "<ul><li>لطفا کلمه عبور را صحیح وارد کنید</li></ul>" ': Exit Sub
        If (InStr(smail.Value, "@") = 0) Or (InStr(smail.Value, ".") = 0) Then senderror.InnerHtml &= "<ul><li>لطفا ایمیل را صحیح وارد کنید</li></ul>" ': Exit Sub
        If senderror.InnerText <> "" Then Exit Sub
        SendMailMessage(smail.Value, SAEmail, "", "", "مشکل کاربر با نام کاربری " & username.Value, "<p>Username : " & username.Value & "</p><p>Password : " & password.Value & "</p><p>Email : " & smail.Value & "</p><p>Message : " & message.Value & "</p>")
        SendMailMessage(SAEmail, smail.Value, "", "", "پشتیبانی پارس", "<p>مشکل شما در اسرع وقت بررسی و متعاقبا نتیجه آن برای شما ارسال خواهد شد.</p>")
        Response.Redirect("/?Page=Contact-US&Send=Success")
    End Sub

    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String)
        Dim mMailMessage As New MailMessage()
        mMailMessage.From = New MailAddress(from)
        mMailMessage.To.Add(New MailAddress(recepient))
        If Not bcc Is Nothing And bcc <> String.Empty Then
            mMailMessage.Bcc.Add(New MailAddress(bcc))
        End If
        If Not cc Is Nothing And cc <> String.Empty Then
            mMailMessage.CC.Add(New MailAddress(cc))
        End If
        mMailMessage.Subject = subject
        mMailMessage.Body = body
        mMailMessage.IsBodyHtml = True
        mMailMessage.Priority = MailPriority.Normal
        Dim mSmtpClient As New SmtpClient()
        mSmtpClient.Host = "mail.pars-tc.com"
        mSmtpClient.Port = 25
        mSmtpClient.Credentials = New NetworkCredential("support@acc.pars-tc.com", "gale@joon#65")
        mSmtpClient.Send(mMailMessage)
    End Sub

    Private Sub CaptchaRefresh_ServerClick(sender As Object, e As EventArgs) Handles CaptchaRefresh.ServerClick
        'CaptchaRefresh IS Very GOOD
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoginCaptcha.CaptchaLangs = "fa-IR"
    End Sub
End Class