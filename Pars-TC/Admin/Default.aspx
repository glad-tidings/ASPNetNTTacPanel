<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Pars_TC.ADefault" %>
<%@ Register src="AdminManList.ascx" tagname="AdminManList" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title id="ttl" runat="server"></title>
</asp:Content>
<asp:Content ID="MenContent" runat="server" ContentPlaceHolderID="MenuContent">
    <ul id="MNUList" runat="server">
	    
	</ul>
</asp:Content>
<asp:Content ID="ManContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="ManList" runat="server">
        <uc1:AdminManList ID="AdminManList2" runat="server" />
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

