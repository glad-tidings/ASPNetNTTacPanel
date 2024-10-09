<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AdminsLogin.ascx.vb" Inherits="Pars_TC.AdminsLogin" %>
<%@ Register Assembly="WebControlCaptcha" Namespace="WebControlCaptcha" TagPrefix="cc1" %>

<h2>پنل مدیریت</h2><div class='featured'><h3>ورود به پنل مدیریت</h3>
<form id="loginform" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress id="updateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <table style="width:100%;height:100%;margin:0;padding:0;border:0;">
                    <tr>
                        <td style="text-align:center;vertical-align:middle">
                        <img src="/images/loading.gif" />
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <label id="loginerror" runat="server" style="color: red;"></label>
            <table>
                <tr>
                    <td style="text-align:left">نام کاربری : </td>
                    <td><input dir="ltr" id="username" type="text" runat="server" class="login" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:left">کلمه عبور : </td>
                    <td><input dir="ltr" id="password" type="password" runat="server" class="login" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:left">کد امنیتی : </td>
                    <td><cc1:CaptchaControl ID="LoginCaptcha" runat="server" LayoutStyle="Vertical" CaptchaBackgroundNoise="Medium" CaptchaLineNoise="Low" /></td>
                    <td><a id="CaptchaRefresh" runat="server"><img src="/images/refresh.png" /></a></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input id="loginbtn" type="submit" class="blue" value="ورود" runat="Server" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
<br>
</div>
<br>