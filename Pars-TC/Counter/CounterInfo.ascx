<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CounterInfo.ascx.vb" Inherits="Pars_TC.CounterInfo" %>

<div id="MainCI" runat="server"></div><br>
<li><h3>کاربران آنلاین</h3></li><table>
<tr><td align=left>مجموع : </td><td><%=Application("ActiveUsers")%> کاربر</td></tr>
</table>