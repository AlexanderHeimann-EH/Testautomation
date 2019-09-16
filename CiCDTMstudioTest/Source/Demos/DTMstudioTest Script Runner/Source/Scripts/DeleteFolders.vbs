Option Explicit

'arguments are: deployment bin folder
Dim shell, fso
Dim deploymentBinFolder

Set shell = WScript.CreateObject("WScript.Shell")

If WScript.Arguments.Count <> 1 Then
    Wscript.Echo "Arguments must be exactly 1!"
	Wscript.Quit
End If

deploymentBinFolder = WScript.Arguments(0)

Set fso = CreateObject("Scripting.FileSystemObject")

'Delete deployment Bin folder first.
DeleteFolder deploymentBinFolder

Sub DeleteFolder(folder)

  ' The trailing backslash must be removed to delete or create folders.
  Dim folderToDelete
  If InStrRev(folder, "\") = Len(folder) Then
    folderToDelete = Left(folder, Len(folder) - 1)
  Else
    folderToDelete = folder
  End If
  
  ' The folder is deleted first, to prevent having possible wrong old files.
  If (fso.FolderExists(folderToDelete)) Then
    Wscript.Echo "Folder: " & folderToDelete & " shall be first deleted."
    fso.DeleteFolder(folderToDelete)
  End If

End Sub
