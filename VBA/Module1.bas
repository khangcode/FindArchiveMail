Attribute VB_Name = "Module1"
'
'PHAN NAY XU LY TEN FILE
'
'

Private Function TiengVietKhongDau(ByVal sContent As String) As String
     Dim i As Long
     Dim intCode As Long
     Dim sChar As String
     Dim sConvert As String
     For i = 1 To Len(sContent)
        sChar = Mid(sContent, i, 1)
        If sChar <> "" Then
            intCode = AscW(sChar)
        End If
        Select Case intCode
            Case 273
                sConvert = sConvert & "d"
            Case 272
                sConvert = sConvert & "D"
            Case 224, 225, 226, 227, 259, 7841, 7843, 7845, 7847, 7849, 7851, 7853, 7855, 7857, 7859, 7861, 7863
                sConvert = sConvert & "a"
            Case 192, 193, 194, 195, 258, 7840, 7842, 7844, 7846, 7848, 7850, 7852, 7854, 7856, 7858, 7860, 7862
                sConvert = sConvert & "A"
            Case 232, 233, 234, 7865, 7867, 7869, 7871, 7873, 7875, 7877, 7879
                sConvert = sConvert & "e"
            Case 200, 201, 202, 7864, 7866, 7868, 7870, 7872, 7874, 7876, 7878
                sConvert = sConvert & "E"
            Case 236, 237, 297, 7881, 7883
                sConvert = sConvert & "i"
            Case 204, 205, 296, 7880, 7882
                sConvert = sConvert & "I"
            Case 242, 243, 244, 245, 417, 7885, 7887, 7889, 7891, 7893, 7895, 7897, 7899, 7901, 7903, 7905, 7907
                sConvert = sConvert & "o"
            Case 210, 211, 212, 213, 416, 7884, 7886, 7888, 7890, 7892, 7894, 7896, 7898, 7900, 7902, 7904, 7906
                sConvert = sConvert & "O"
            Case 249, 250, 361, 432, 7909, 7911, 7913, 7915, 7917, 7919, 7921
                sConvert = sConvert & "u"
            Case 217, 218, 360, 431, 7908, 7910, 7912, 7914, 7916, 7918, 7920
                sConvert = sConvert & "U"
            Case 253, 7923, 7925, 7927, 7929
                sConvert = sConvert & "y"
            Case 221, 7922, 7924, 7926, 7928
                sConvert = sConvert & "Y"
            Case Else
                sConvert = sConvert & sChar
        End Select
     Next
     TiengVietKhongDau = sConvert
  End Function
  
Public Function ThayTheKyTuDacBiet(strIn As String, strChar As String) As String
    Dim strSpecialChars As String
    Dim i As Long
    strSpecialChars = "~""#%&*:<>?{|}/\[]-_" & Chr(10) & Chr(13) 'Thay the cac ky tu dac biet khong su dung de dat ten file

    For i = 1 To Len(strSpecialChars)
        strIn = Replace(strIn, Mid$(strSpecialChars, i, 1), strChar)
    Next

    ThayTheKyTuDacBiet = strIn
End Function

Public Function SoHoacChu(str As String) As String
    Dim i As Integer

    For i = 1 To Len(str)
        If InStr(1, "01234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz. _-", Mid(str, i, 1)) Then 'Xoa het cac ky tu khong thuoc danh muc nay
            SoHoacChu = SoHoacChu & Mid(str, i, 1)
        End If
    Next
End Function

Function LoaiBoSpace(ByVal parmString As String) As String 'Xoa cac ky tu trang
    '================================================
    'Replace all three consecutive spaces with one space,
    'then replace all two consecutive spaces with one space
    '================================================
    Dim strTemp As String
    strTemp = parmString

    'Replace three space strings with a single space until
    'no more instances of three space strings exist
    Do Until InStr(strTemp, "   ") = 0
        strTemp = Replace(strTemp, "   ", " ")
    Loop

    'Replace two space strings with a single space until no
    'more instances of two space strings exist
    Do Until InStr(strTemp, "  ") = 0
        strTemp = Replace(strTemp, "  ", " ")
    Loop
    LoaiBoSpace = Trim(strTemp)
End Function

Public Function LamSachChuoi(str As String) As String
    Dim result As String
    result = TiengVietKhongDau(str)
    result = ThayTheKyTuDacBiet(result, " ")
    result = SoHoacChu(result)
    result = LoaiBoSpace(result)
    result = Replace(result, " ", "_")
    
    LamSachChuoi = result
End Function

Public Function TenFileMSG(str As String) As String
    If Len(str) > 200 Then
       str = Left(str, 200)
    End If
    str = str & ".msg"
   TenFileMSG = str
   
End Function
'
'HET PHAN XU LY TEN FILE
'
'

