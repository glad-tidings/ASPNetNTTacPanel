<%@ Page Language="vb" MasterPageFile="~/Slide.Master" AutoEventWireup="false"
    CodeBehind="/.vb" Inherits="Pars_TC._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title id="ttl" runat="server"></title>
</asp:Content>
<asp:Content ID="MenContent" runat="server" ContentPlaceHolderID="MenuContent">
    <ul id="MNUList" runat="server">
	    
	</ul>
</asp:Content>
<asp:Content ID="ManContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="ManList" runat="server">
        
    </div>
</asp:Content>
<asp:Content ID="ULContent" runat="server" ContentPlaceHolderID="UserLeftContent">
    <div id="ULList" runat="server">
	    
    </div>
</asp:Content>
<asp:Content ID="UMContent" runat="server" ContentPlaceHolderID="UserMidContent">
    <div id="UMList" runat="server">
	    
    </div>
</asp:Content>
<asp:Content ID="URContent" runat="server" ContentPlaceHolderID="UserRightContent">
    <div id="URList" runat="server">
	    
    </div>
</asp:Content>
