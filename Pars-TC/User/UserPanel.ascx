<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserPanel.ascx.vb" Inherits="Pars_TC.UserPanel" %>

<form id="usermcp" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div id="MainAP" runat="server"></div>
</ContentTemplate>
</asp:UpdatePanel>
</form>