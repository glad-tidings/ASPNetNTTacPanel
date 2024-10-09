<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ResellerOnlineUsers.ascx.vb" Inherits="Pars_TC.ResellerOnlineUsers" %>

<form id="resellermou" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div id="MainOU" runat="server"></div><br>
<asp:Timer ID="OnlineUserTimer" runat="server" Enabled="False" Interval="5000"></asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
</form><br>