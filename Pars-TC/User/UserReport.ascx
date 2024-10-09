<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserReport.ascx.vb" Inherits="Pars_TC.UserReport" %>

<h2>کنترل پنل کاربران</h2>
<div class='featured'><h3>زمانهای استفاده و حجم مصرفی اکانت شما</h3>
<form id="usermur" runat="server">
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
<div id="MainUR" runat="server"></div><br>
<table style="width:100%;"><tr>
<td style="width:50px;"><asp:Button ID="fbtn" runat="server" Text="صفحه اول" CssClass="flatblue" /></td>
<td style="width:50px;"><asp:Button ID="pbtn" runat="server" Text="صفحه قبل" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn1" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn2" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn3" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn4" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn5" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn6" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="text-align:center;"><asp:Button ID="btn7" runat="server" Text="1" CssClass="flatblue" /></td>
<td style="width:50px;"><asp:Button ID="nbtn" runat="server" Text="صفحه بعد" CssClass="flatblue" /></td>
<td style="width:50px;"><asp:Button ID="lbtn" runat="server" Text="صفحه آخر" CssClass="flatblue" /></td>
</tr></table>
<table style="width:100%;"><tr>
<td style="text-align:right;"><span>صفحه </span><input id="gotopage" type="text" runat="server" style="text-align:center;width:50px" /><span> </span><input id="gotobtn" type="button" value="برو" class="flatblue" runat="server" /></td>
<td id="pagefl" style="text-align:left;" runat="server"></td>
</tr></table>
</ContentTemplate>
</asp:UpdatePanel>
</form><br></div><br>