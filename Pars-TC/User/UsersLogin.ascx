<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UsersLogin.ascx.vb" Inherits="Pars_TC.UsersLogin" %>
<%@ Register Assembly="WebControlCaptcha" Namespace="WebControlCaptcha" TagPrefix="cc1" %>

<h2>کنترل پنل کاربران</h2><div class='featured'><h3>ورود به پنل کاربری</h3>
<form id="loginform" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress id="updateProgress1" runat="server">
<ProgressTemplate>
<table class="TDCenter">
<tr><td><img src="/images/loading.gif" /></td></tr>
</table>
</ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<label id="loginerror" runat="server" style="color: red;"></label>
<table><tr><td class="Tdlbl">نام کاربری : </td><td><input dir="ltr" id="username" type="text" runat="server" class="login" /></td><td></td></tr>
<tr><td class="Tdlbl">کلمه عبور : </td><td><input dir="ltr" id="password" type="password" runat="server" class="login" /></td><td></td></tr>
<tr><td class="Tdlbl">کد امنیتی : </td><td>
<cc1:CaptchaControl ID="LoginCaptcha" runat="server" LayoutStyle="Vertical" 
        CaptchaLineNoise="Low" CaptchaWidth="130" CaptchaLength="4" />
</td><td>
<a id="CaptchaRefresh" runat="server"><img src="/images/refresh.png" /></a>
</td></tr>
<tr><td></td><td><input id="loginbtn" type="submit" class="blue" value="ورود" runat="Server" />
</td><td></td></tr></table>
</ContentTemplate>
</asp:UpdatePanel>
</form><br></div><br>