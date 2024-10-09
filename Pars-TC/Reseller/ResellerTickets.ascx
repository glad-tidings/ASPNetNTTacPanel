<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ResellerTickets.ascx.vb" Inherits="Pars_TC.ResellerTickets" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Pars_TC" %>

<script runat="server">
    Dim LoginTF As Boolean = False
    Dim Count As Integer = 0
    Dim DBConn As DBConnection
    Dim NPost As Boolean = False
    Dim Toolz As New Tools
    Dim TMPS As ArrayList = New ArrayList
    
    Function QSTRID() As Long
        Dim QSTR As Long = IIf(IsNumeric(Request.QueryString("ID")), Request.QueryString("ID"), 0)
        Return QSTR
    End Function
    
    Function RCount() As Integer
        Count += 1
        Return Count
    End Function
    
    Function BGC() As Boolean
        LoginTF = Not LoginTF
        Return LoginTF
    End Function
</script>

<%If QSTRID <> 0 Then%>
<h2>کنترل پنل فروشندگان</h2><div class='featured'><h3>مشخصات درخواست</h3>
<%TMPS = Toolz.Get_Reseller_Info(Session.Item("RUser"))
    Try
        DBConn = New DBConnection
        DBConn.AdminConnect("SELECT * FROM Tickets WHERE ID=" & QSTRID() & ";")
        DBConn.OLEComm.Connection = DBConn.OLEConn
        Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
        Do While d.Read
            If d("TRes".ToString) <> TMPS.Item(1) Then Response.Redirect("/Reseller/?Page=ResellerTickets")
            If d("TStatus".ToString) = "بسته" Then NPost = False Else NPost = True
            %>
<table class="TableTicket">
<tr class="TrTicketInfo" style="background-color: #dcdcdc;">
    <td class="TdTicketInfo">درخواست کننده :</td><td><span class="SpanTicketInfo"><%=d("TSender".ToString)%></span></td>
</tr>
<tr class="TrTicketInfo">
    <td class="TdTicketInfo">موضوع درخواست :</td><td><span class="SpanTicketInfo"><%=d("TSubject".ToString)%></span></td>
</tr>
<tr class="TrTicketInfo" style="background-color: #dcdcdc;">
    <td class="TdTicketInfo">عنوان درخواست :</td><td><span class="SpanTicketInfo"><%=d("TTitle".ToString)%></span></td>
</tr>
<tr class="TrTicketInfo">
    <td class="TdTicketInfo">تاریخ درخواست :</td><td><span class="SpanTicketInfo"><%=Format(d("TDate".ToString), "dd/MM/yyyy")%></span></td>
</tr></table>
        <%Loop
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try%>
<h3>پاسخها</h3>
<%Try
        DBConn = New DBConnection
        DBConn.AdminConnect("SELECT * FROM Tickets WHERE ID=" & QSTRID() & " OR TMainID=" & QSTRID() & ";")
        DBConn.OLEComm.Connection = DBConn.OLEConn
        Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
        Do While d.Read%>
<table class="TableTicket">
<tr class="TicketHeader">
    <td class="TicketSender"><%=d("TSender".ToString)%></td>
    <td class="TicketDate"><%=Format(d("TDate".ToString), "HH:mm dd/MM/yyyy")%></td>
</tr>
</table>
<div class="TicketDesc"><%=d("TDesc".ToString)%></div>
        <%Loop
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try%>
<%If NPost Then%>
    <h3>پاسخ جدید</h3>
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
    <textarea id="TDesc" class="TextAreaTicketSend" runat="server"></textarea><br><br>
    <input id="sendticketbtn" type="submit" class="blue" value="ارسال" runat="Server" />
    <br><br><br>
    <p style="text-align: center;"><input id="closeticketbtn" type="submit" class="gray" value="در صورتی که مشکل حل شده است، در اینجا کلیک کنید." runat="Server" /></p>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form><br>
<%End If%>
</div><br>
<%Else%>
<h2>کنترل پنل فروشندگان</h2><div class='featured'><h3>مشاهده درخواستهای پشتیبانی</h3>
<asp:Repeater ID="RepeaterNews" runat="server">
                <HeaderTemplate>
                    <div class="DivTicket">
                        <div class="TrTicketListHead">
                            <span style="display: table-cell; width: 40px; text-align: center;">ردیف</span>
                            <span style="display: table-cell; width: 100px; text-align: center;">فرستنده</span>
                            <span style="display: table-cell;">عنوان</span>
                            <span style="display: table-cell; width: 90px; text-align: center;">تاریخ</span>
                            <span style="display: table-cell; width: 110px; text-align: center;">وضعیت</span>
                         </div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="DivTicket">
                        <%Select Case BGC()
                                Case True%>
                        <a style="height: 22px; display: table-row;" href="?Page=ResellerTickets&ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>">
                        <%Case false%>
                        <a style="height: 22px; background-color: #dcdcdc; display: table-row;" href="?Page=ResellerTickets&ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>">
                        <%End select%>
                            <span style="display: table-cell; width: 40px; text-align: center;"><%=RCount()%></span>
                            <span style="display: table-cell; width: 100px; text-align: center;"><%# DataBinder.Eval(Container.DataItem, "TSender")%></span>
                            <span style="display: table-cell;"><%# DataBinder.Eval(Container.DataItem, "TTitle")%></span>
                            <span style="display: table-cell; width: 90px; text-align: center;"><%# Format(DataBinder.Eval(Container.DataItem, "TDate"),"dd/MM/yyyy")%></span>
                            <span style="display: table-cell; width: 110px; text-align: center; color: <%# IIf(DataBinder.Eval(Container.DataItem, "TStatus")="باز","#f78d1d",IIf(DataBinder.Eval(Container.DataItem, "TStatus")="بسته","#6e6e6e","#64991e"))%>;"><%# DataBinder.Eval(Container.DataItem, "TStatus")%></span>
                        </a>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
<br></div><br>
<%End If%>