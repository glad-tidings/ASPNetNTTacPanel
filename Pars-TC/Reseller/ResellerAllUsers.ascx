<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ResellerAllUsers.ascx.vb" Inherits="Pars_TC.ResellerAllUsers" %>

<h2>کنترل پنل فروشندگان</h2><div class='featured'><h3>تمامی کاربران</h3>
<form id="alluserform" runat="server">
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
<table><tr><td>
<asp:DropDownList ID="RUsers" runat="server" Width="250px" AutoPostBack="True">
</asp:DropDownList>
</td><td>
<a class="blue" id="CUP" runat="server" style="color:white;">تغییر کلمه عبور</a>
</td></tr>
</table>
<br>
<div id="RUI" runat="server"></div>
<br>
</ContentTemplate>
</asp:UpdatePanel>
</form><br></div><br>