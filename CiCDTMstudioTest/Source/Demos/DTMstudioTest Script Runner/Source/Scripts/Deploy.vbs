Option Explicit

'arguments are: deployment bin folder, binaries after build, OpcLabs component folder, folder where the Help folder (the BAs) is
Dim shell, fso
Dim targetDir, outDir, opcLabsDir, helpDir

'Global variables.
Dim targetHelpDir
Dim enDir
Dim deDir

targetHelpDir = "Help\"
enDir = "en-US\"
deDir = "de-DE\"

Set shell = WScript.CreateObject("WScript.Shell")

If WScript.Arguments.Count <> 4 Then
    Wscript.Echo "Arguments must be exactly 4!"
	Wscript.Quit
End If

targetDir = WScript.Arguments(0)
outDir = WScript.Arguments(1)
opcLabsDir = WScript.Arguments(2)
helpDir = WScript.Arguments(3)

Set fso = CreateObject("Scripting.FileSystemObject")

'Create deployment Bin folder if not existing. Creates all the subfolders as well.
CreateFolder targetDir
CreateFolder targetDir & enDir
CreateFolder targetDir & deDir
CreateFolder targetDir & targetHelpDir
CreateFolder targetDir & targetHelpDir & enDir
CreateFolder targetDir & targetHelpDir & deDir

'Copy all E+H binaries
CopyFiles outDir, "*.dll", targetDir
CopyFiles outDir, "*.exe", targetDir
CopyFiles outDir, "*.xml", targetDir
CopyFiles outDir, "*.config", targetDir

'Copy all OpcLabs required binaries
'For the first release we do not add these components. They shall be required from the second release.
'CopyFiles opcLabsDir, "*.*", targetDir

'Copy all resources
CopyFiles outDir & enDir, "*.*", targetDir & enDir
CopyFiles outDir & deDir, "*.*", targetDir & deDir

'Copy help files
CopyFiles helpDir & enDir, "*.*", targetDir & targetHelpDir & enDir
CopyFiles helpDir & deDir, "*.*", targetDir & targetHelpDir & deDir

Sub CreateFolder(folder)

  ' The folder is created.
  Wscript.Echo "Folder: " & folder & " shall be created."
  fso.CreateFolder(folder)
  Wscript.Echo "Folder: " & folder & " created."
 
End Sub

Sub CopyFiles(srcFolder, ext, destFolder)

  Wscript.Echo "Copying files from: " & srcFolder & ext
  Wscript.Echo "Copying files to: " & destFolder
  fso.CopyFile srcFolder & ext, destFolder

End Sub
