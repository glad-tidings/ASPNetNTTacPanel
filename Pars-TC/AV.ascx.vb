Public Class AV1
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Toolz = New Tools
        Dim TMP As ArrayList = New ArrayList
        Dim QSTR As String = Request.QueryString("Page")
        TMP = Toolz.AV_Ver(QSTR)
        Select Case QSTR
            Case "Eset"
                MainAP.InnerHtml = "<h2>آنتی ویروس نود 32 (Eset Nod32)</h2><div class=av>" + _
            "<image src='images/eset.png'></image><div class=avui><h3>Update Informations</h3>" + _
            "<table width=100% border=0 cellspacing=0 cellpadding=0>"
                MainAP.InnerHtml += "<tr bgcolor=#dcdcdc><td width=30%>Eset Update Version :</td><td>" & Microsoft.VisualBasic.Right(TMP.Item(2), (Len(TMP.Item(2)) - InStr(TMP.Item(2), "="))) & "</td></tr>"
                MainAP.InnerHtml += "<tr><td width=30%>Eset Update Build :</td><td>" & Microsoft.VisualBasic.Right(TMP.Item(3), (Len(TMP.Item(3)) - InStr(TMP.Item(3), "="))) & "</td></tr>"
                MainAP.InnerHtml += "<tr bgcolor=#dcdcdc><td width=30%>Eset Update Base :</td><td>" & Microsoft.VisualBasic.Right(TMP.Item(6), (Len(TMP.Item(6)) - InStr(TMP.Item(6), "="))) & "</td></tr>"
                MainAP.InnerHtml += "<tr><td width=30%>Eset Update Date :</td><td>" & Microsoft.VisualBasic.Right(TMP.Item(7), (Len(TMP.Item(7)) - InStr(TMP.Item(7), "="))) & "</td></tr>"
                MainAP.InnerHtml += "<tr bgcolor=#dcdcdc><td width=30%>Eset Update NUV :</td><td>" & Microsoft.VisualBasic.Right(TMP.Item(14), (Len(TMP.Item(14)) - InStr(TMP.Item(14), "="))) & "</td></tr>"
                MainAP.InnerHtml += "</table></div><br></div><br>"
        End Select
    End Sub

End Class