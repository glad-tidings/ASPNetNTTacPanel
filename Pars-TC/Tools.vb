Imports System.Diagnostics

Public Class Tools

    Dim DBConn As DBConnection
    Private cpu As New System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total")
    Private ram As New System.Diagnostics.PerformanceCounter("Memory", "Available MBytes")

    Function Get_All_Users(MFF As String) As ArrayList
        Dim TMP As ArrayList = New ArrayList
        Dim TMPU As String = ""
        Try
            DBConn = New DBConnection
            DBConn.NTTacDBConnect("SELECT TAC_ID FROM TAC_USR WHERE TAC_ID LIKE '" & IIf(MFF = "admin", "", MFF) & "%' GROUP BY TAC_ID;")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TMPU = d("TAC_ID".ToString).ToString.ToLower
                    If TMPU <> "admin" And TMPU <> "default" And TMPU <> "user" And TMPU <> "isdnuser" And TMPU <> "analogicuser" And TMPU.Length < 15 Then
                        TMP.Add(TMPU)
                    End If
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        Return TMP
    End Function

    Function Get_All_Servers() As ArrayList
        Dim TMP As ArrayList = New ArrayList
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT ServerIP FROM ServerList;")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TMP.Add(d("ServerIP".ToString))
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        Return TMP
    End Function

    Function Get_User_Info(UserID As String, FieldName As String) As String
        Dim TMP As String = ""
        Try
            DBConn = New DBConnection
            DBConn.NTTacDBConnect("SELECT TAC_Val FROM TAC_USR WHERE TAC_ID = '" & UserID & "' AND TAC_Attr = '" & FieldName & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
            Do While d.Read
                TMP = d("TAC_Val".ToString)
            Loop
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
        Return TMP
    End Function

    Sub Edit_User_Info(UserID As String, FieldName As String, Value As String)
        Try
            DBConn = New DBConnection
            DBConn.NTTacDBConnect("Update TAC_USR SET TAC_Val='" & Value & "' WHERE TAC_ID = '" & UserID & "' AND TAC_Attr = '" & FieldName & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            DBConn.OLEComm.ExecuteNonQuery()
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
    End Sub

    Sub Delete_User_Info(UserID As String, FieldName As String)
        Try
            DBConn = New DBConnection
            DBConn.NTTacDBConnect("Delete From TAC_USR WHERE TAC_ID = '" & UserID & "' AND TAC_Attr = '" & FieldName & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                DBConn.OLEComm.ExecuteNonQuery()
                DBConn.OLEConn.Close()
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
    End Sub

    Sub Delete_User(UserID As String)
        Try
            DBConn = New DBConnection
            DBConn.NTTacDBConnect("Delete From TAC_USR WHERE TAC_ID = '" & UserID & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                DBConn.OLEComm.ExecuteNonQuery()
                DBConn.OLEConn.Close()
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        Try
            DBConn = New DBConnection
            DBConn.statConnect("Delete From Accounting WHERE Username = '" & UserID & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                DBConn.OLEComm.ExecuteNonQuery()
                DBConn.OLEConn.Close()
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
    End Sub

    Function Get_Admin_Info(UserID As String, FieldName As String) As String
        Dim TMP As String = ""
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM AdminUsers WHERE AdminUser = '" & UserID & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TMP = d(FieldName.ToString)
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                    TMP = err.Message
                End Try
            Catch err As System.Exception
                TMP = err.Message
            End Try
        Catch err As System.Exception
            TMP = err.Message
        End Try
        Return TMP
    End Function

    Function Get_Reseller_Info(UserID As String) As ArrayList
        Dim TMP As ArrayList = New ArrayList
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM ResellerUsers WHERE ResellerUser = '" & UserID & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TMP.Add(d("ResellerPass".ToString))
                    TMP.Add(d("ResellerMFF".ToString))
                    TMP.Add(d("ResellerAccNum".ToString))
                    TMP.Add(d("ResellerAcc1".ToString))
                    TMP.Add(d("ResellerAcc3".ToString))
                    TMP.Add(d("ResellerAcc6".ToString))
                    TMP.Add(d("ResellerAcc12".ToString))
                    TMP.Add(d("ResellerAccR1".ToString))
                    TMP.Add(d("ResellerAccR3".ToString))
                    TMP.Add(d("ResellerAccR6".ToString))
                    TMP.Add(d("ResellerAccR12".ToString))
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        Catch err As System.Exception
        End Try
        Return TMP
    End Function

    Sub Edit_Reseller_Info(UserID As String, FieldName As String, Value As String)
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("Update ResellerUsers SET " & FieldName & "='" & Value & "' WHERE ResellerUser = '" & UserID & "';")
            DBConn.OLEComm.Connection = DBConn.OLEConn
            DBConn.OLEComm.ExecuteNonQuery()
            DBConn.OLEConn.Close()
        Catch err As System.Exception
        End Try
    End Sub

    Function Get_Error_Info(ByVal ErrorNums As String) As String
        Dim TMP As String = ""
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM ErrorList WHERE ErrorNum='" & ErrorNums & "';")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TMP = d("ErrorDesc".ToString)
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                    TMP = err.Message
                End Try
            Catch err As System.Exception
                TMP = err.Message
            End Try
        Catch err As System.Exception
            TMP = err.Message
        End Try
        Return TMP
    End Function

    Function Get_Error_Num() As ArrayList
        Dim TMP As ArrayList = New ArrayList
        Try
            DBConn = New DBConnection
            DBConn.AdminConnect("SELECT * FROM ErrorList;")
            Try
                DBConn.OLEComm.Connection = DBConn.OLEConn
                Dim d As OleDb.OleDbDataReader = DBConn.OLEComm.ExecuteReader()
                Do While d.Read
                    TMP.Add(d("ErrorNum".ToString))
                Loop
                Try
                    DBConn.OLEConn.Close()
                Catch err As System.Exception
                    TMP.Add(err.Message)
                End Try
            Catch err As System.Exception
                TMP.Add(err.Message)
            End Try
        Catch err As System.Exception
            TMP.Add(err.Message)
        End Try
        Return TMP
    End Function

    Function Convert_STR_Date(DT As String) As Date
        On Error GoTo Err
        Dim Temp As DateTime
        Select Case DT.Length
            Case 10
                Temp = Microsoft.VisualBasic.Mid(DT, 4, 2) & "/" & Microsoft.VisualBasic.Left(DT, 2) & "/" & Microsoft.VisualBasic.Mid(DT, 7, 4)
            Case Else
                Temp = Microsoft.VisualBasic.Mid(DT, 4, 2) & "/" & Microsoft.VisualBasic.Left(DT, 2) & "/" & Microsoft.VisualBasic.Mid(DT, 7, 4) & " " & Microsoft.VisualBasic.Right(DT, 8)
        End Select
        Return Temp
        Exit Function
Err:
        Return Date.Now
    End Function

    Function GetProcessInfo(PInfo As String) As String
        Dim TMP As String = ""
        Select Case PInfo
            Case "PeakMemoryUsed"
                TMP = ram.NextValue() & " مگابایت"
            Case "ProcessID"
                TMP = cpu.NextValue() & "%"
            Case "RequestCount"
            Case "ShutdownReason"
            Case "StartTime"
            Case "Status"
        End Select
        Return TMP
    End Function

    Function CountryEn2Fa(ByVal En As String) As String
        Dim TMP As String = ""
        Select Case En.ToUpper
            Case "US"
                TMP = "آمریکا"
            Case "UK", "GB"
                TMP = "انگلیس"
            Case "NL"
                TMP = "هلند"
            Case "DE"
                TMP = "آلمان"
            Case "CH"
                TMP = "سویس"
            Case "IR"
                TMP = "ایران"
        End Select
        Return TMP
    End Function

    Function File_Exist(ByVal FilePath As String) As Boolean
        If My.Computer.FileSystem.FileExists(FilePath) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function AV_Ver(ByVal AV As String) As ArrayList
        Dim TMP As ArrayList = New ArrayList
        Dim sFilename As String = ""
        Select Case AV
            Case "Eset"
                sFilename = "C:\xampp\htdocs\update\eset_upd\update.ver"
        End Select
        Dim sFileReader = System.IO.File.OpenText(sFilename)
        Dim sInputLine = sFileReader.ReadLine()
        If Not sInputLine Is Nothing Then TMP.Add(sInputLine.ToString)
        Do Until sInputLine Is Nothing
            sInputLine = sFileReader.ReadLine()
            If Not sInputLine Is Nothing Then TMP.Add(sInputLine.ToString)
        Loop
        Return TMP
    End Function

    Public Function Fix_Path(ByVal Path As String) As String
        If Microsoft.VisualBasic.Right(Path, 1) = "\" Or Microsoft.VisualBasic.Right(Path, 1) = "/" Then
            Return Path
        Else
            Return Path & "\"
        End If
    End Function

End Class
