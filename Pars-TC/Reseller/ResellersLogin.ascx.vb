Public Class ResellersLogin
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoginCaptcha.CaptchaLangs = "fa-IR"
    End Sub

    Protected Sub loginbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rloginbtn.ServerClick
        Dim TMP As ArrayList = New ArrayList
        rloginerror.InnerHtml = ""
        If Not LoginCaptcha.IsValid Then rloginerror.InnerHtml &= "<ul><li>" & LoginCaptcha.ErrorMessage & "</li></ul>" ': Exit Sub
        Toolz = New Tools
        If rusername.Value = "" Then rloginerror.InnerHtml &= "<ul><li>لطفا نام کاربری را وارد کنید</li></ul>" ': Exit Sub
        If rpassword.Value = "" Then rloginerror.InnerHtml &= "<ul><li>لطفا کلمه عبور را وارد کنید</li></ul>" ': Exit Sub
        If (InStr(rusername.Value, "'") <> 0) Or (InStr(rusername.Value, ";") <> 0) Or (InStr(rusername.Value, "-") <> 0) Then rloginerror.InnerHtml &= "<ul><li>لطفا نام کاربری را صحیح وارد کنید</li></ul>" ': Exit Sub
        If (InStr(rpassword.Value, "'") <> 0) Or (InStr(rpassword.Value, ";") <> 0) Or (InStr(rpassword.Value, "-") <> 0) Then rloginerror.InnerHtml &= "<ul><li>لطفا کلمه عبور را صحیح وارد کنید</li></ul>" ': Exit Sub
        If rloginerror.InnerHtml <> "" Then Exit Sub
        TMP = Toolz.Get_Reseller_Info(rusername.Value)
        If TMP.Count <> 0 Then
            If GenerateHash(rpassword.Value, EncodingType.HEX, Algorithm.MD5) = TMP.Item(0) Then
                Session.Add("RLogin", "True")
                Session.Add("RUser", rusername.Value)
                Response.Redirect("/Reseller/")
            Else
                rloginerror.InnerHtml = "<ul><li>نام کاربری یا کلمه عبور اشتباه است</li></ul>" : Exit Sub
            End If
        Else
            rloginerror.InnerHtml = "<ul><li>نام کاربری یا کلمه عبور اشتباه است</li></ul>" : Exit Sub
        End If
    End Sub

    Private Sub CaptchaRefresh_ServerClick(sender As Object, e As EventArgs) Handles CaptchaRefresh.ServerClick
        'CaptchaRefresh IS Very GOOD
    End Sub

End Class