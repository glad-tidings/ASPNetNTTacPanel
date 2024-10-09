<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserServerInfo.ascx.vb" Inherits="Pars_TC.UserServerInfo" %>

<form id="usersi" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div id="MainAP" runat="server"></div>
<asp:Timer ID="ServerInfoUpdateTimer" runat="server" Enabled="False" Interval="60000"></asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
</form>