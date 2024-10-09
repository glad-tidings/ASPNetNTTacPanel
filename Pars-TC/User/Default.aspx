<%@ Page validateRequest="false" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Pars_TC.UDefault" %>

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
<asp:Content ID="SBContent" runat="server" ContentPlaceHolderID="SidebarContent">
    <ul id="SBList" runat="server">
	    
    </ul>
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
