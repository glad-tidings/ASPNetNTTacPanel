<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ErrorList.ascx.vb" Inherits="Pars_TC.ErrorList" %>

<h2>پشتیبانی</h2><div class='featured'><h3>جستجوی شماره خطا</h3>
<form id="findform" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress id="updateProgress1" runat="server">
<ProgressTemplate>
<div style="position: fixed; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
<tr><td align="center" valign="middle">
<img src="/images/loading.gif" />
</td></tr></table>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<label id="finderror" runat="server" style="color: red;"></label>
<table><tr><td align="left">شماره خطا : </td><td><input dir="rtl" id="errornum" type="text" runat="server" /></td></tr>
<tr><td valign="top" align="left">توضیحات : </td><td><div id="errordesc" runat="server" class="featuredd"></div></td></tr>
<tr><td></td><td><input id="findbtn" type="submit" class="blue" value="جستجو" runat="Server" />
</td></tr></table>
</ContentTemplate>
</asp:UpdatePanel>    
</form><br></div><br>