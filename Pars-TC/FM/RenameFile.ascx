<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RenameFile.ascx.vb" Inherits="Pars_TC.RenameFile" %>

<h2>پنل مدیریت فایل ها</h2><div class='featured'><h3>تغییر نام فایل</h3>
<form id="renameform" runat="server">
<label id="renameerror" runat="server" style="color: red;"></label>
<table><tr><td align="left">نام فعلی فایل : </td><td><input dir="ltr" id="oldname" type="text" runat="server" style="width: 300px" /></td></tr>
<tr><td align="left">نام جدید فایل : </td><td><input dir="ltr" id="newname" type="text" runat="server" style="width: 300px" /></td></tr>
<tr><td></td><td><asp:ImageButton ID="editbtn" runat="Server" ImageUrl="/images/editbtn.png" /></td></tr></table></form><br></div><br>