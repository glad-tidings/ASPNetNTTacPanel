<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserPassChange.ascx.vb" Inherits="Pars_TC.UserPassChange" %>

<h2>کنترل پنل کاربران</h2><div class='featured'><h3>تغییر کلمه عبور</h3>
<form id="changepassform" runat="server">
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
<label id="cperror" runat="server" style="color: red;"></label>
<table><tr><td style="text-align:left">کلمه عبور فعلی : </td><td><input dir="ltr" id="cpoldpass" type="password" runat="server" class="login" /></td></tr>
<tr><td style="text-align:left">کلمه عبور جدید : </td><td><input dir="ltr" id="cpnewpass" type="password" runat="server" class="login" /></td></tr>
<tr><td style="text-align:left">تکرار کلمه عبور : </td><td><input dir="ltr" id="cprepeatpass" type="password" runat="server" class="login" /></td></tr>
<tr><td></td><td><input id="cpsavesubmit" type="button" value="ذخیره" runat="server" class="blue" /></td></tr></table>
</ContentTemplate>
</asp:UpdatePanel>
</form><br></div><br>