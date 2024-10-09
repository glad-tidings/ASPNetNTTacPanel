<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UploadFile.ascx.vb" Inherits="Pars_TC.UploadFile" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<h2>مدیریت فایل ها</h2><div class='featured'><h3>آپلود فایل</h3>
<form id="uploadfile" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<CuteWebUI:Uploader runat="server" ID="FileUploader" InsertText="Upload File">
</CuteWebUI:Uploader>
<br>
<label id="uploadstat" runat="server" style="color: green;"></label>
</ContentTemplate>
</asp:UpdatePanel>
</form><br></div><br>