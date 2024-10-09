Imports System.IO

Public Class List
    Inherits System.Web.UI.UserControl

    Dim Toolz As Tools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Toolz = New Tools
        Dim FT As String = ""
        Dim FI As FileInfo
        Dim BKMG As String = "Byte"
        Dim Siz As Long = 0
        Dim Path As String = Toolz.Fix_Path(Request.PhysicalApplicationPath) & "FM\Files\"
        Dim directories() As String = Directory.GetFiles(Path)
        MainFML.InnerHtml = "<h2>مدیریت فایل ها</h2>" + _
                        "<div class='featured'><h3>لیست فایل ها</h3>" + _
                        "<table dir=ltr width=100% border=0 cellspacing=0 cellpadding=0>"
        For i As Integer = 0 To directories.Count - 1
            FI = New FileInfo(directories(i))
            If FI.Length < 1024 Then
                Siz = FI.Length
                BKMG = "Bytes"
            ElseIf FI.Length < 1048576 Then
                Siz = FI.Length / 1024
                BKMG = "KB"
            Else
                Siz = FI.Length / 1048576
                BKMG = "MB"
            End If
            FT = Replace((IO.Path.GetExtension(directories(i))).ToLower, ".", "")
            If File.Exists(Toolz.Fix_Path(Request.PhysicalApplicationPath) & "images\files\" & FT & ".png") = False Then FT = "file"
            If (i Mod 2) = 0 Then MainFML.InnerHtml += "<tr bgcolor=#dcdcdc>" Else MainFML.InnerHtml += "<tr>"
            MainFML.InnerHtml += "<td align=center width=30><image src='/images/files/" & FT & ".png'></image></td>"
            MainFML.InnerHtml += "<td><a href=""Files/" & IO.Path.GetFileName(directories(i)) & """>" & IIf((IO.Path.GetFileName(directories(i)).Length > 45), Left(IO.Path.GetFileName(directories(i)), 45) & " . . . " & FT, IO.Path.GetFileName(directories(i))) & "</a></td>"
            MainFML.InnerHtml += "<td align=center width=80>" & Siz & " " & BKMG & "</td>"
            MainFML.InnerHtml += "<td align=center width=20><a href='/FM/?Page=RenameFile&FileID=" & Base64EnCode(directories(i)) & "'><image src='/images/edit.png' title='تغییر نام فایل' alt='تغییر نام فایل'></image></a></td>"
            MainFML.InnerHtml += "<td align=center width=20><a href='/FM/?Page=DeleteFile&FileID=" & Base64EnCode(directories(i)) & "'><image src='/images/delete.png' title='حذف فایل' alt='حذف فایل'></image></a></td></tr>"
        Next
        MainFML.InnerHtml += "</table><br></div><br>"
    End Sub

End Class