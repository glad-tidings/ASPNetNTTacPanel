<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UsersEdit.ascx.vb" Inherits="Pars_TC.UsersEdit" %>

<h2>پنل مدیریت</h2><div class="featured"><h3>ویرایش کاربران</h3>
<form id="edituserform" runat="server">
<label id="euerror" runat="server" style="color: red;"></label>
<table><tr><td align="left">نام کاربری : </td><td id="ueusername" runat="server"></td></tr>
<tr><td align="left">کلمه عبور : </td><td><input dir="ltr" id="uepassword" type="text" runat="server" class="textEntry" AutoPostBack="True" /></td></tr>
<tr><td align="left">مدت زمان : </td><td><input dir="ltr" id="ueexpire" type="text" runat="server" class="textEntry" AutoPostBack="True" /></td></tr>
<tr><td align="left">تاریخ شروع : </td><td><input dir="ltr" id="uestartdate" type="text" runat="server" class="textEntry" AutoPostBack="True" /></td></tr>
<tr><td align="left">چند کاربره : </td><td><input dir="ltr" id="uemultilogin" type="text" runat="server" class="textEntry" AutoPostBack="True" /></td></tr>
<tr><td align="left">پیغام : </td><td><input dir="ltr" id="uecomment" type="text" runat="server" class="textEntry" AutoPostBack="True" /></td></tr>
<tr><td></td><td><input id="uesavesubmit" type="button" value="ذخیره" runat="server" class="button" /></td></tr></table></form><br></div><br>