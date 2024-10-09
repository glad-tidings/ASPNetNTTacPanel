Public Class Login
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub loginbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        loginerror.InnerText = ""
        If Not LoginCaptcha.IsValid Then loginerror.InnerHtml += "<ul><li>" & LoginCaptcha.ErrorMessage & "</li></ul>" ': Exit Sub
        Toolz = New Tools
        Dim passTemp As String = ""
        If username.Value = "" Then loginerror.InnerHtml += "<ul><li>" & "لطفا نام کاربری را وارد کنید" & "</li></ul>" ': Exit Sub
        If password.Value = "" Then loginerror.InnerHtml += "<ul><li>" & "لطفا کلمه عبور را وارد کنید" & "</li></ul>" ': Exit Sub
        If (InStr(username.Value, "'") <> 0) Or (InStr(username.Value, ";") <> 0) Or (InStr(username.Value, "-") <> 0) Then loginerror.InnerHtml += "<ul><li>" & "لطفا نام کاربری را صحیح وارد کنید" & "</li></ul>" ': Exit Sub
        If (InStr(password.Value, "'") <> 0) Or (InStr(password.Value, ";") <> 0) Or (InStr(password.Value, "-") <> 0) Then loginerror.InnerHtml += "<ul><li>" & "لطفا کلمه عبور را صحیح وارد کنید" & "</li></ul>" ': Exit Sub
        If loginerror.InnerText <> "" Then Exit Sub
        passTemp = Toolz.Get_Admin_Info(username.Value, "AdminPass")
        If GenerateHash(password.Value, EncodingType.HEX, Algorithm.MD5) = passTemp Then
            If rememberme.Checked Then
                If (Request.Cookies("PBLOGIN") Is Nothing) Then
                    Response.Cookies("PBLOGIN").Expires = DateTime.Now.AddDays(90)
                    Response.Cookies("PBLOGIN").Item("UNAME") = username.Value
                    Response.Cookies("PBLOGIN").Item("UPASS") = GenerateHash(password.Value, EncodingType.HEX, Algorithm.MD5)
                Else
                    Response.Cookies("PBLOGIN").Item("UNAME") = username.Value
                    Response.Cookies("PBLOGIN").Item("UPASS") = GenerateHash(password.Value, EncodingType.HEX, Algorithm.MD5)
                End If
            Else
                If (Request.Cookies("PBLOGIN") Is Nothing) Then
                    Response.Cookies("PBLOGIN").Expires = DateTime.Now.AddDays(1)
                    Response.Cookies("PBLOGIN").Item("UNAME") = username.Value
                    Response.Cookies("PBLOGIN").Item("UPASS") = GenerateHash(password.Value, EncodingType.HEX, Algorithm.MD5)
                Else
                    Response.Cookies("PBLOGIN").Item("UNAME") = username.Value
                    Response.Cookies("PBLOGIN").Item("UPASS") = GenerateHash(password.Value, EncodingType.HEX, Algorithm.MD5)
                End If
            End If
            Response.Redirect("/")
            Else
                loginerror.InnerHtml = "<ul><li>" & "نام کاربری یا کلمه عبور اشتباه است" & "</li></ul>" : Exit Sub
            End If
    End Sub
End Class