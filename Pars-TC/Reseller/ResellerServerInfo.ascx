<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ResellerServerInfo.ascx.vb" Inherits="Pars_TC.ResellerServerInfo" %>

<form id="resellersi" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div id="MainAP" runat="server"></div>
<asp:Timer ID="ServerInfoUpdateTimer" runat="server" Enabled="False" Interval="60000"></asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
</form>