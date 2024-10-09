<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Pars_TC.NDefault" %>

<script runat="server">
    Dim NewsNull As Boolean = True
</script>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title id="ttl" runat="server"></title>
</asp:Content>
<asp:Content ID="MenContent" runat="server" ContentPlaceHolderID="MenuContent">
    <ul id="MNUList" runat="server">
	    
	</ul>
</asp:Content>
<asp:Content ID="ManContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="ManList" runat="server">
        <h2>اخبار</h2>
        <div class='featured'>
            <asp:Repeater ID="RepeaterNews" runat="server">
                <HeaderTemplate>
                   <h3><%Dim QSTR As String = Request.QueryString("Page")
                           Select Case QSTR
                               Case "Server"%>
                                   اخبار سرور
                               <%Case "Internet"%>
                                   اخبار اینترنت
                               <%Case Else%>
                                   اخبار سایت
                               <%End Select%>
                   </h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <%NewsNull = False%>
                    <a href="?Page=<%# DataBinder.Eval(Container.DataItem, "NCat")%>&ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>">
                        <span class="NewsTitle"><%# DataBinder.Eval(Container.DataItem, "NTitle")%></span>
                    </a><br><span class="NewsAuth">توسط <%# DataBinder.Eval(Container.DataItem, "NAuthor")%> در تاریخ <span dir="ltr"><%# Format(DataBinder.Eval(Container.DataItem, "NDate"), "yyyy MMM dd")%></span></span>
                    <p class="NewsDesc"><%# DataBinder.Eval(Container.DataItem, "NDesc")%></p>
                </ItemTemplate>
                <FooterTemplate>
                    <%If NewsNull Then%>
                        <p style="width: 100%;text-align: center;">هیچ خبری یافت نشد.</p>
                    <%End If%>
                </FooterTemplate>
            </asp:Repeater>
         </div>
        <br />
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