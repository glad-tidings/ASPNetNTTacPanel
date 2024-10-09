<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserOnline.ascx.vb" Inherits="Pars_TC.UserOnline" %>

<form id="usermuo" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div id="MainUO" runat="server"></div><br>
<asp:Timer ID="OnlineUserTimer" runat="server" Enabled="False" Interval="5000"></asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
</form>