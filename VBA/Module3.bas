Attribute VB_Name = "Module3"
Private Function CreateMyFolder(fso As Scripting.FileSystemObject, strPath As String)
Dim strTempPath As String
Dim lngPath As Long
Dim vPath As Variant
    vPath = Split(strPath, "\")
    strPath = vPath(0) & "\"
    For lngPath = 1 To UBound(vPath)
        strPath = strPath & vPath(lngPath) & "\"
        If Not fso.FolderExists(strPath) Then MkDir strPath
    Next lngPath
lbl_Exit:
    Exit Function
End Function

Private Function WriteLog(ts As TextStream, strText As String)
    ts.WriteLine Strings.Format(Now, "YYYY-MM-DD HH:nn:ss") & "." & Strings.Right(Strings.Format(Timer, "#0.00"), 2) & " > " & CStr(strText)
End Function
' Ham nay de tranh loi do email dang dat code Korea, etc dan den khong the luu file duoc
Private Function ChangeCodeBase() As String

Dim objOL As Outlook.Application
Dim objItems As Outlook.Items
Dim objFolder As Outlook.MAPIFolder
Dim olItem As Object
 
Set objOL = Outlook.Application
Set objFolder = objOL.ActiveExplorer.CurrentFolder
Set objItems = objFolder.Items

Dim num As Integer

For Each olItem In objItems
    If (TypeName(olItem) = "MailItem") Then
      If olItem.InternetCodepage <> 65001 Then
            olItem.InternetCodepage = 65001
            olItem.Save
            num = num + 1
      End If
    End If
Next

ChangeCodeBase = "Total mails changed to Unicode: " & CStr(num)

Set objItems = Nothing
Set objFolder = Nothing
Set objOL = Nothing

End Function

Private Function SaveOutlookItem(oItem As Object, strPath As String, strFileName As String, _
                                    tsSucess As TextStream, tsErr As TextStream, fso As Scripting.FileSystemObject) As Integer
Dim result As Integer

On Error GoTo WriteLog
    If fso.FileExists(strPath & strFileName) = False Then
        oItem.SaveAs strPath & strFileName, OlSaveAsType.olMSGUnicode
        WriteLog tsSucess, "Luu thanh cong: " & strPath & strFileName
        result = 0
    End If
    
Exit_Func:
    SaveOutlookItem = result
    Exit Function

WriteLog:
    WriteLog tsErr, Err.Number & ":" & Err.Description
    WriteLog tsErr, "Khong luu duoc file: " & strPath & strFileName
    WriteLog tsErr, "================================="
    result = -1
    GoTo Exit_Func

End Function

Private Function SaveOutlookItems() As String

Dim objOL As Outlook.Application
Dim objItems As Outlook.Items
Dim objFolder As Outlook.MAPIFolder
Dim olItem As Object
 
Set objOL = Outlook.Application
Set objFolder = objOL.ActiveExplorer.CurrentFolder
Set objItems = objFolder.Items

Dim fso As Scripting.FileSystemObject
Set fso = CreateObject("Scripting.FileSystemObject")

Dim numItem As Integer
Dim numMailItem As Integer
Dim numReportItem As Integer
Dim numMeetingItem As Integer
Dim numSaveErr As Integer
Dim otherItemName As String

numItem = objItems.Count
numSaveErr = 0
numOther = 0

Dim fPath As String
fPath = "D:\Mail"
    fPath = InputBox("Enter the path to save the message." & vbCr & _
                     "The path will be created if it doesn't exist.", _
                     "Save Message", fPath)
    
    CreateMyFolder fso, fPath
    
    'Tao file ghi log
    Dim tsSucess As TextStream
    Dim tsErr As TextStream
    
    sFileNameLogSucess = "\SucessLog.txt"
    sFileNameLogError = "\ErrorLog.txt"
    
    If fso.FileExists(fPath & sFileNameLogSucess) Then
       Set tsSucess = fso.OpenTextFile(fPath & sFileNameLogSucess, ForAppending)
       tsSucess.WriteLine Strings.Format(Now, "YYYY-MM-DD HH:nn:ss") & "." & Strings.Right(Strings.Format(Timer, "#0.00"), 2) & " > " & "=== LogFile Append ==="
    Else
       Set tsSucess = fso.CreateTextFile(fPath & sFileNameLogSucess, True)
       tsSucess.WriteLine Strings.Format(Now, "YYYY-MM-DD HH:nn:ss") & "." & Strings.Right(Strings.Format(Timer, "#0.00"), 2) & " > " & "=== LogFile Creates ==="
    End If
    
    If fso.FileExists(fPath & sFileNameLogError) Then
       Set tsErr = fso.OpenTextFile(fPath & sFileNameLogError, ForAppending)
       tsErr.WriteLine Strings.Format(Now, "YYYY-MM-DD HH:nn:ss") & "." & Strings.Right(Strings.Format(Timer, "#0.00"), 2) & " > " & "=== LogFile Append ==="
    Else
       Set tsErr = fso.CreateTextFile(fPath & sFileNameLogError, True)
       tsErr.WriteLine Strings.Format(Now, "YYYY-MM-DD HH:nn:ss") & "." & Strings.Right(Strings.Format(Timer, "#0.00"), 2) & " > " & "=== LogFile Creates ==="
    End If
                
       For Each olItem In objItems
           If (TypeName(olItem) = "MailItem") Or (TypeName(olItem) = "MeetingItem") Or (TypeName(olItem) = "ReportItem") Then
            
                Dim fname As String
                Dim fPath2 As String
                
                If (TypeName(olItem) = "ReportItem") Then
                    fPath2 = fPath & Format(olItem.LastModificationTime, "yyyy")
                    numReportItem = numReportItem + 1
                Else
                    fPath2 = fPath & Format(olItem.SentOn, "yyyy")
                    If (TypeName(olItem) = "MeetingItem") Then
                        numMeetingItem = numMeetingItem + 1
                    Else
                        numMailItem = numMailItem + 1
                    End If
                End If
                
                CreateMyFolder fso, fPath2
                
                'Ten file mail luu
                If (TypeName(olItem) = "ReportItem") Then
                    fname = Format(olItem.LastModificationTime, "yyyymmdd") & "r" & Format(olItem.LastModificationTime, "HH.MM") & "-" & "Mail_Server" & "-" & LamSachChuoi(olItem.Subject)
                Else
                 '   If olItem.SenderEmailAddress Like "tuankhang@lotte.vn" Then    'Your mail khangnt.ho@mcredit.com.vn
                    If olItem.SenderEmailAddress Like "khangnt.ho@mcredit.com.vn" Then    'Your mail
                        fname = Format(olItem.SentOn, "yyyymmdd") & "s" & Format(olItem.SentOn, "HH.MM") & "-" & LamSachChuoi(olItem.SenderName) & "-" & LamSachChuoi(olItem.Subject)
                    Else
                        fname = Format(olItem.ReceivedTime, "yyyymmdd") & "i" & Format(olItem.ReceivedTime, "HH.MM") & "-" & LamSachChuoi(olItem.SenderName) & "-" & LamSachChuoi(olItem.Subject)
                    End If
                End If
                
                fname = TenFileMSG(fname)
                Dim iErr As Integer
                iErr = SaveOutlookItem(olItem, fPath2, fname, tsSucess, tsErr, fso)
                
                'Danh dau file khong luu duoc
                If (TypeName(olItem) = "MailItem") Or (TypeName(olItem) = "MeetingItem") Then
                    If (iErr = -1) Then
                        olItem.Categories = "NotSave"
                        olItem.Save
                    End If
                
                    If (iErr = 0 & olItem.Categories = "NotSave") Then
                        olItem.Categories = ""
                        olItem.Save
                    End If
                End If
                
                'Thong ke loi
               numSaveErr = numSaveErr - iErr
           Else
               'Thong ke item khong nam trong danh muc
               numOther = numOther + 1
           End If
       Next
    
    tsErr.Close
    tsSucess.Close
    
Set tsSucess = Nothing
Set tsErr = Nothing
Set fso = Nothing

Set objItems = Nothing
Set objFolder = Nothing
Set objOL = Nothing

SaveOutlookItems = "Total item: " & CStr(numItem) & ", not save: " & CStr(numSaveErr) & " other items: " & CStr(numOther) & " . Please check log file for further information."

End Function

Public Sub ClearCategory()

Dim objOL As Outlook.Application
Dim objItems As Outlook.Items
Dim objFolder As Outlook.MAPIFolder
Dim olItem As Object
 
Set objOL = Outlook.Application
Set objFolder = objOL.ActiveExplorer.CurrentFolder
Set objItems = objFolder.Items

Dim num As Integer

For Each olItem In objItems
    If (TypeName(olItem) = "MailItem") Or (TypeName(olItem) = "MeetingItem") Then
           If olItem.Categories = "NotSave" Then
                 olItem.Categories = ""
                 olItem.Save
           End If
    End If
Next

Set objItems = Nothing
Set objFolder = Nothing
Set objOL = Nothing

End Sub

Public Sub Export2Msg()
    Dim s1 As String
    Dim s2 As String
    
    s1 = ChangeCodeBase
    s2 = SaveOutlookItems
    MsgBox s1
    MsgBox s2
End Sub
