<%@ Page Language="vb" ContentType="text/xml" AutoEventWireup="true" CodeBehind="RSS.aspx.vb" Inherits="Pars_TC.RSS" %>

<script runat="server">
    Function RemoveIllegalCharacters(ByVal input As Object) As String
        Dim data As String = input.ToString
        data = data.Replace("&", "&amp;")
        data = data.Replace("\", "&quot;")
        data = data.Replace("'", "&apos;")
        data = data.Replace("<", "&lt;")
        data = data.Replace(">", "&gt;")
        Return data
    End Function
</script>
 
<asp:Repeater ID="RepeaterRSS" runat="server">
        <HeaderTemplate>
           <rss version="2.0">
                <channel>
                    <title>Pars TC</title>
                    <link>http://acc.pars-tc.com/</link>
                    <description>
                    Pars Technology And Communications
                    </description>
                    <language>fa-IR</language>
        </HeaderTemplate>
        <ItemTemplate>
            <item>
                <title><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "NTitle"))%></title>
                <link>http://acc.pars-tc.com/news/?Page=<%# DataBinder.Eval(Container.DataItem, "NCat")%>&amp;ID=<%# DataBinder.Eval(Container.DataItem, "ID")%></link>
                <author><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "NAuthor"))%></author>
                <pubDate><%# Format(DataBinder.Eval(Container.DataItem, "NDate"), "dd MMM yyyy")%></pubDate>
                <description><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "NDesc"))%></description>
            </item>
        </ItemTemplate>
        <FooterTemplate>
                </channel>
               </rss>
        </FooterTemplate>
</asp:Repeater>