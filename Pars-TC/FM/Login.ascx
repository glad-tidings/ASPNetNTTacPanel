<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Login.ascx.vb" Inherits="Pars_TC.Login" %>
<%@ Register Assembly="WebControlCaptcha" Namespace="WebControlCaptcha" TagPrefix="cc1" %>

<h2>پنل مدیریت فایل ها</h2><div class='featured'><h3>ورود به پنل مدیریت فایل ها</h3>
<form id="loginform" runat="server">
<label id="loginerror" runat="server" style="color: red;"></label>
<table><tr><td align="left">نام کاربری : </td><td><input dir="ltr" id="username" type="text" runat="server" class="login" /></td></tr>
<tr><td align="left">کلمه عبور : </td><td><input dir="ltr" id="password" type="password" runat="server" class="login" /></td></tr>
<tr><td align="left">کد امنیتی : </td><td>
<cc1:CaptchaControl ID="LoginCaptcha" runat="server" LayoutStyle="Vertical" CaptchaBackgroundNoise="Medium" CaptchaLineNoise="Low" />
</td></tr>
<tr><td></td><td><input dir="ltr" id="rememberme" type="checkbox" runat="server" class="login" />ذخیره؟</td></tr>
<tr><td></td><td><asp:ImageButton ID="loginbtn" runat="Server" ImageUrl="/images/loginbtn.png" /></td></tr></table></form><br></div><br>