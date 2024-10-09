<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserSendTicket.ascx.vb" Inherits="Pars_TC.UserSendTicket" %>

<h2>کنترل پنل کاربران</h2><div class='featured'><h3>ارسال درخواست پشتیبانی</h3>
<form id="sendticketform" runat="server">
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
<label id="sendticketerror" runat="server" style="color: red;"></label>
<table class="TableTicket">
<tr class="TrTicketSend"><td class="TdTicketSend">موضوع :</td><td><asp:DropDownList ID="TSubject" runat="server" AutoPostBack="True" CssClass="DDListTicketSend"></asp:DropDownList></td></tr>
<tr class="TrTicketSend"><td class="TdTicketSend">عنوان :</td><td><input id="TTitle" type="text" runat="server" class="InputTicketSend" /></td></tr>
<tr><td class="TdTicketSend">متن :</td><td><textarea id="TDesc" class="TextAreaTicketSend" runat="server"></textarea></td></tr>
<tr><td></td><td><br><input id="sendticketbtn" type="submit" class="blue" value="ارسال" runat="Server" /></td></tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</form><br></div><br>