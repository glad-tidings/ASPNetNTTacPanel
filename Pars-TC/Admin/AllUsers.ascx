<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AllUsers.ascx.vb" Inherits="Pars_TC.AllUsers" %>

<h2>پنل مدیریت</h2><div class='featured'><h3>تمامی کاربران</h3>
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
<asp:DropDownList ID="AUsers" runat="server" Width="250px" AutoPostBack="True">
</asp:DropDownList>
</td><td>
<a id="EU" runat="server"><img src="/images/user-edit.png" style="margin:0;" /></a>
<a id="DU" runat="server"><img src="/images/user-delete.png" style="margin:0;" /></a>
<a id="DEU" runat="server"><img src="/images/user-disable.png" style="margin:0;" id="PDEU" runat="server" /></a>
</td></tr>
</table><br>
<div id="RUI" runat="server"></div>
</ContentTemplate>
</asp:UpdatePanel>
</form>
<br></div><br>