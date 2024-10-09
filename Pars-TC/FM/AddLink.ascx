<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddLink.ascx.vb" Inherits="Pars_TC.AddLink" %>

<h2>پنل مدیریت فایل ها</h2><div class='featured'><h3>افزودن لینک</h3>
<form id="sendform" runat="server">
<label id="senderror" runat="server" style="color: red;"></label>
<table width="100%"><tr><td width="70" align="left">آدرس لینک : </td><td><input dir="ltr" id="link" type="text" runat="server" style="width: 100%" /></td></tr>
<tr><td></td><td><asp:ImageButton ID="sendbtn" runat="Server" ImageUrl="/images/sendbtn.png" /></td></tr></table>
</form>
<br></div><br>