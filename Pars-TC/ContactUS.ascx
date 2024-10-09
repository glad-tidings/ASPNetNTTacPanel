<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ContactUS.ascx.vb" Inherits="Pars_TC.ContactUS" %>
<%@ Register Assembly="WebControlCaptcha" Namespace="WebControlCaptcha" TagPrefix="cc1" %>
<%@ Register Src="~/SocialNetwork.ascx" TagPrefix="sn1" TagName="SocialNetwork" %>
<%Dim QSTR3 As String = Request.QueryString("Send")%>

<div id="main"><br>
<h2>ارتباط با ما</h2><div class='featured'><h3>ارسال پیام</h3>
<%Select Case QSTR3
        Case "Success"%>
<table width="100%" border=0 cellspacing=0 cellpadding=0><tr><td align="center">کاربر گرامی پیام شما با موفقیت ارسال گردید.<br>اگر مرورگر بطور خودکار به صفحه مورد نظر راهبری نشد، <a href='/'>اینجا را کلیک کنید</a></td></tr>
</table>
<script>
    window.setTimeout(function () { location.href = '/' }, 4000);
</script>
    <% Case Else%>
<form id="sendmailform" runat="server">
<label id="senderror" runat="server" style="color: red;"></label>
<table><tr><td align="left">نام کاربری : </td><td><input dir="ltr" id="username" type="text" runat="server" /></td></tr>
<tr><td align="left">کلمه عبور : </td><td><input dir="ltr" id="password" type="password" runat="server" /></td></tr>
<tr><td align="left">ایمیل : </td><td><input dir="ltr" id="smail" type="text" runat="server" /></td></tr>
<tr><td valign="top" align="left">متن : </td><td>
    <textarea enableviewstate="false" rows="10" dir="rtl" id="message" type="text" 
        runat="server" cols="55" style="resize:none"></textarea></td></tr>
<tr><td align="left">کد امنیتی : </td><td>
<table><tr><td><cc1:CaptchaControl ID="LoginCaptcha" runat="server" LayoutStyle="Vertical" CaptchaLineNoise="Low" CaptchaWidth="130" CaptchaLength="4" /></td>
<td><a id="CaptchaRefresh" runat="server"><img src="/images/refresh.png" /></a></td></tr></table>
</td></tr>
<tr><td></td><td><input id="sendbtn" type="submit" class="blue" value="ارسال" runat="Server" />
</td></tr></table>
</form>
    <%
    End Select%>
<br></div><br></div>
<div id="sidebar">
    <sn1:SocialNetwork runat="server" ID="SocialNetwork" /><br>
</div>

<div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>

<script type="text/javascript">
    window.___gcfg = { lang: 'fa' };

    (function () {
        var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
        po.src = 'https://apis.google.com/js/plusone.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
    })();
</script>