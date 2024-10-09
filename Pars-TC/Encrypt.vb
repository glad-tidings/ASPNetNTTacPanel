Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.Encoding

Module Encrypt

    Public Enum EncodingType As Integer
        HEX = 0
        BASE_64 = 1
    End Enum

    Public Enum Algorithm As Integer
        SHA1 = 0
        SHA256 = 1
        SHA384 = 2
        Rijndael = 3
        TripleDES = 4
        RSA = 5
        RC2 = 6
        DES = 7
        DSA = 8
        MD5 = 9
        RNG = 10
        Base64 = 11
        SHA512 = 12
    End Enum

    Public Function Base64EnCode(ByVal Text As String) As String
        If Text = "" Then Return "" : Exit Function
        Dim EnCode As New System.Text.UnicodeEncoding
        Dim Buffer As Byte() = EnCode.GetBytes(Text)
        Return System.Convert.ToBase64String(Buffer)
    End Function

    Public Function Base64DeCode(ByVal Text As String) As String
        If Text = "" Then Return "" : Exit Function
        Dim EnCode As New System.Text.UnicodeEncoding
        Dim Buffer As Byte() = System.Convert.FromBase64String(Text)
        Return EnCode.GetString(Buffer)
    End Function

    Public Function GenerateHash(ByVal Content As String, ByVal EnType As EncodingType, ByVal Alg As Algorithm) As String
        Dim HashAlg As HashAlgorithm = Nothing
        Select Case Alg
            Case Algorithm.SHA1
                HashAlg = New SHA1CryptoServiceProvider
            Case Algorithm.SHA256
                HashAlg = New SHA256Managed
            Case Algorithm.SHA384
                HashAlg = New SHA384Managed
            Case Algorithm.SHA512
                HashAlg = New SHA512Managed
            Case Algorithm.MD5
                HashAlg = New MD5CryptoServiceProvider
        End Select
        Dim hash() As Byte = ComputeHash(HashAlg, Content)
        If EnType = EncodingType.HEX Then
            Return BytesToHex(hash)
        Else
            Return System.Convert.ToBase64String(hash)
        End If
    End Function

    Private Function ComputeHash(ByVal Provider As HashAlgorithm, ByVal plainText As String) As Byte()
        Dim hash As Byte() = Provider.ComputeHash(UTF8.GetBytes(plainText))
        Provider.Clear()
        Return hash
    End Function

    Private Function BytesToHex(ByVal bytes() As Byte) As String
        Dim hex As New StringBuilder
        For n As Integer = 0 To bytes.Length - 1
            hex.AppendFormat("{0:X2}", bytes(n))
        Next
        Return hex.ToString
    End Function

End Module
