Public Class UsersEdit
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools
    Dim User As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            User = Request.QueryString("UserName")
            If (User = "") Or (InStr(User, "'") <> 0) Or (InStr(User, ";") <> 0) Or (InStr(User, "-") <> 0) Then Response.Redirect("?Page=AllUser") : Exit Sub
            Toolz = New Tools
            ueusername.InnerText = User
            uepassword.Value = Toolz.Get_User_Info(User, "[Global]Passwd")
            ueexpire.Value = Toolz.Get_User_Info(User, "[Global]Expires")
            uestartdate.Value = Toolz.Get_User_Info(User, "[Global]EffectiveFrom")
            uemultilogin.Value = Toolz.Get_User_Info(User, "[Global]MaxLogins")
            uecomment.Value = Toolz.Get_User_Info(User, "[Global]Comment")
        End If
    End Sub

    Private Sub uesavesubmit_Load(sender As Object, e As System.EventArgs) Handles uesavesubmit.ServerClick
        euerror.InnerHtml = ""
        If uepassword.Value = "" Then euerror.InnerHtml &= "لطفا کلمه عبور را وارد کنید" : Exit Sub
        If ueexpire.Value = "" Then euerror.InnerHtml &= "لطفا مدت زمان را وارد کنید" : Exit Sub
        If uestartdate.Value = "" Then euerror.InnerHtml &= "لطفا تاریخ شروع را وارد کنید" : Exit Sub
        If uemultilogin.Value = "" Then euerror.InnerHtml &= "لطفا چند کاربره را وارد کنید" : Exit Sub
        If (InStr(uepassword.Value, "'") <> 0) Or (InStr(uepassword.Value, ";") <> 0) Or (InStr(uepassword.Value, "-") <> 0) Then euerror.InnerHtml &= "لطفا کلمه عبور را صحیح وارد کنید" : Exit Sub
        If (InStr(ueexpire.Value, "#") = 0) Then euerror.InnerHtml &= "لطفا مدت زمان را صحیح وارد کنید" : Exit Sub
        If (InStr(uestartdate.Value, "-") = 0) And uestartdate.Value <> "start" Then euerror.InnerHtml &= "لطفا تاریخ شروع را صحیح وارد کنید" : Exit Sub
        If euerror.InnerHtml <> "" Then Exit Sub
        Toolz = New Tools
        Toolz.Edit_User_Info(User, "[Global]Passwd", uepassword.Value)
        Toolz.Edit_User_Info(User, "[Global]Expires", ueexpire.Value)
        If uestartdate.Value = "start" Then
            Toolz.Delete_User_Info(User, "[Global]EffectiveFrom")
        Else
            Toolz.Edit_User_Info(User, "[Global]EffectiveFrom", uestartdate.Value)
        End If
        Toolz.Edit_User_Info(User, "[Global]MaxLogins", uemultilogin.Value)
        Toolz.Edit_User_Info(User, "[Global]Comment", uecomment.Value)
        Response.Redirect("?Page=AllUser")
    End Sub
End Class