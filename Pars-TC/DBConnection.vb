Public Class DBConnection

#Region "Class Import"

    Public WithEvents OLEConn As New System.Data.OleDb.OleDbConnection
    Public WithEvents OLEComm As New System.Data.OleDb.OleDbCommand
    Public Shared dataReturned As New ArrayList

#End Region

#Region "class Function"

    Function NTTacDBConnect(ByVal DBString As String) As Boolean
        Dim DBProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0"
        Dim DBMode As String = "Mode=ReadWrite"
        Dim DBPath As String = "Data source=C:\NTTacPlus2\ODBC\NTTacDB.mdb"
        Dim DBUUser As String = "User Id="
        Dim DBUPass As String = "Password="
        Dim DBPass As String = "Jet OLEDB:Database Password=n@jk#d77W#5C85$&43CM"
        Try
            OLEConn.ConnectionString = DBProvider & ";" & DBMode & ";" & DBPath & ";" & DBUUser & ";" & DBUPass '& ";" & DBPass
            OLEConn.Open()
            OLEComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

    Function AdminConnect(ByVal DBString As String) As Boolean
        Dim DBProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0"
        Dim DBMode As String = "Mode=ReadWrite"
        Dim DBPath As String = "Data source=C:\NTTacPlus2\ODBC\admin.mdb"
        Dim DBUUser As String = "User Id="
        Dim DBUPass As String = "Password="
        Dim DBPass As String = "Jet OLEDB:Database Password=n@jk#d77W#5C85$&43CM"
        Try
            OLEConn.ConnectionString = DBProvider & ";" & DBMode & ";" & DBPath & ";" & DBUUser & ";" & DBUPass '& ";" & DBPass
            OLEConn.Open()
            OLEComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

    Function statConnect(ByVal DBString As String) As Boolean
        Dim DBProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0"
        Dim DBMode As String = "Mode=ReadWrite"
        Dim DBPath As String = "Data source=C:\NTTacPlus2\ODBC\stat.mdb"
        Dim DBUUser As String = "User Id="
        Dim DBUPass As String = "Password="
        Dim DBPass As String = "Jet OLEDB:Database Password=n@jk#d77W#5C85$&43CM"
        Try
            OLEConn.ConnectionString = DBProvider & ";" & DBMode & ";" & DBPath & ";" & DBUUser & ";" & DBUPass '& ";" & DBPass
            OLEConn.Open()
            OLEComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

    Function statGetCount(ByVal DBString As String) As Boolean
        Dim DBProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0"
        Dim DBMode As String = "Mode=ReadWrite"
        Dim DBPath As String = "Data source=C:\NTTacPlus2\ODBC\stat.mdb"
        Dim DBUUser As String = "User Id="
        Dim DBUPass As String = "Password="
        Dim DBPass As String = "Jet OLEDB:Database Password=n@jk#d77W#5C85$&43CM"
        Try
            OLEConn.ConnectionString = DBProvider & ";" & DBMode & ";" & DBPath & ";" & DBUUser & ";" & DBUPass '& ";" & DBPass
            OLEConn.Open()
            OLEComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

    Function FMDBConnect(ByVal DBString As String) As Boolean
        Dim DBProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0"
        Dim DBMode As String = "Mode=ReadWrite"
        Dim DBPath As String = "Data source=C:\NTTacPlus2\ODBC\fm.mdb"
        Dim DBUUser As String = "User Id="
        Dim DBUPass As String = "Password="
        Dim DBPass As String = "Jet OLEDB:Database Password=n@jk#d77W#5C85$&43CM"
        Try
            OLEConn.ConnectionString = DBProvider & ";" & DBMode & ";" & DBPath & ";" & DBUUser & ";" & DBUPass '& ";" & DBPass
            OLEConn.Open()
            OLEComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

    Function CoDBConnect(ByVal DBString As String) As Boolean
        Dim DBProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0"
        Dim DBMode As String = "Mode=ReadWrite"
        Dim DBPath As String = "Data source=C:\NTTacPlus2\ODBC\Counter.mdb"
        Dim DBUUser As String = "User Id="
        Dim DBUPass As String = "Password="
        Dim DBPass As String = "Jet OLEDB:Database Password=n@jk#d77W#5C85$&43CM"
        Try
            OLEConn.ConnectionString = DBProvider & ";" & DBMode & ";" & DBPath & ";" & DBUUser & ";" & DBUPass '& ";" & DBPass
            OLEConn.Open()
            OLEComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

#End Region

End Class