#define MyAppName "MediaRenamer"
#define MyAppVer "2.0"
#define MyAppPublisher "ccMatrix"
#define MyAppURL "http://code.google.com/p/mediarenamer/"

#define DLLVersion "Release"

[Setup]
AppName={#MyAppName}
AppVerName={#MyAppName} {#MyAppVer}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
AppID={{869D06EA-2277-4588-9567-CDFE5C30A399}
VersionInfoCompany={#MyAppPublisher}
VersionInfoCopyright=©2006-2007 ccMatrix
VersionInfoDescription=Media Renamer Suite
VersionInfoTextVersion={#MyAppVer}
VersionInfoVersion={#MyAppVer}
DefaultDirName={pf}\Media Renamer
DisableDirPage=false
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=false
AllowNoIcons=true
OutputBaseFilename=mediarenamer_{#MyAppVer}
OutputDir=IS-Setup\Output
Compression=lzma/ultra
SolidCompression=true
SourceDir=..\
WizardImageFile=compiler:WizModernImage-IS.bmp
WizardSmallImageFile=compiler:WizModernSmallImage-IS.bmp
InfoAfterFile=
InternalCompressLevel=ultra
ShowLanguageDialog=yes
AppVersion={#MyAppVer}
AppContact=ccMatrix
;UninstallDisplayIcon={app}\ccMatrix.ico
UninstallDisplayName={#MyAppName}
ChangesAssociations=true
LicenseFile=IS-Setup\license.txt

[Languages]
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl

[CustomMessages]
en.dotNetMissing=You do not have a .NET Framework 2.0 installed. Please download it from the WindowsUpdate Homepage.
en.Register=Registering Shell Extension
en.UnRegister=Removing Shell Extension

de.dotNetMissing=Sie haben das .NET Framework 2.0 nicht installiert. Bitte laden Sie es sich von WidowsUpdate herunter.
de.Register=Registriere Shell Erweiterung
de.UnRegister=Entferne Shell Erweiterung
de.installSource=Source Code installieren
en.installSource=install Source Code

[Files]
;Source: IS-Setup\regsvrnet\bin\Release\regsvrnet.exe; DestDir: {app}; Flags: ignoreversion


Source: IS-Setup\Language\*.ini; DestDir: {app}\Language
;Source: IS-Setup\MediaRenamer.tar.gz; DestDir: {app}; Components: source
Source: IS-Setup\Files\MovieRenamer\format.dat; DestDir: {userappdata}\MovieRenamer; Flags: onlyifdoesntexist
Source: IS-Setup\Files\TVShowRenamer\format.dat; DestDir: {userappdata}\TVShowRenamer; Flags: onlyifdoesntexist
Source: MediaRenamer\bin\Release\MediaRenamer.exe; DestDir: {app}

[Dirs]
Name: {app}\Language

[Components]
Name: source; Description: Source Code; Types: custom

[Run]
; Unregister if already registered (for Update Installation)
;Filename: {app}\regsvrnet.exe; Parameters: "remove ""{app}\TVShowRenamer.dll"""; WorkingDir: {app}; StatusMsg: {cm:Register}; Flags: runhidden
;Filename: {app}\regsvrnet.exe; Parameters: "removeasm ""{app}\TVShowRenamer.dll"""; WorkingDir: {app}; StatusMsg: {cm:Register}; Flags: runhidden
; Register new Plugin
;Filename: {app}\regsvrnet.exe; Parameters: "install ""{app}\TVShowRenamer.dll"""; WorkingDir: {app}; StatusMsg: {cm:Register}; Flags: runhidden
;Filename: {app}\regsvrnet.exe; Parameters: "installasm ""{app}\TVShowRenamer.dll"""; WorkingDir: {app}; StatusMsg: {cm:Register}; Flags: runhidden

[UninstallRun]
; Unregister if already registered (for Update Installation)
;Filename: {app}\regsvrnet.exe; Parameters: "remove ""{app}\TVShowRenamer.dll"""; WorkingDir: {app}; StatusMsg: {cm:Register}; Flags: runhidden
;Filename: {app}\regsvrnet.exe; Parameters: "removeasm ""{app}\TVShowRenamer.dll"""; WorkingDir: {app}; StatusMsg: {cm:Register}; Flags: runhidden

[UninstallDelete]
Name: {userappdata}\TVShowRenamer; Type: filesandordirs
Name: {userappdata}\MovieRenamer; Type: filesandordirs

[Registry]
Root: HKCU; Subkey: Software\MediaRenamer; ValueType: string; ValueName: locale; ValueData: {language}; Flags: uninsdeletekey deletevalue
Root: HKCU; Subkey: Software\MediaRenamer; ValueType: string; ValueName: path; ValueData: {app}; Flags: uninsdeletekey deletevalue
Root: HKCU; Subkey: Software\MediaRenamer\Series

[Icons]
Name: {group}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {group}\MediaRenamer; Filename: {app}\MediaRenamer.exe; WorkingDir: {app}; IconFilename: {app}\MediaRenamer.exe

[Code]
var
  netpath: String;

procedure DecodeVersion( verstr: String; var verint: array of Integer );
var
  i,p: Integer; s: string;
begin
  // initialize array
  verint := [0,0,0,0];
  i := 0;
  while ( (Length(verstr) > 0) and (i < 4) ) do
  begin
  	p := pos('.', verstr);
  	if p > 0 then
  	begin
      if p = 1 then s:= '0' else s:= Copy( verstr, 1, p - 1 );
  	  verint[i] := StrToInt(s);
  	  i := i + 1;
  	  verstr := Copy( verstr, p+1, Length(verstr));
  	end
  	else
  	begin
  	  verint[i] := StrToInt( verstr );
  	  verstr := '';
  	end;
  end;

end;

// This function compares version string
// return -1 if ver1 < ver2
// return  0 if ver1 = ver2
// return  1 if ver1 > ver2
function CompareVersion( ver1, ver2: String ) : Integer;
var
  verint1, verint2: array of Integer;
  i: integer;
begin

  SetArrayLength( verint1, 4 );
  DecodeVersion( ver1, verint1 );

  SetArrayLength( verint2, 4 );
  DecodeVersion( ver2, verint2 );

  Result := 0; i := 0;
  while ( (Result = 0) and ( i < 4 ) ) do
  begin
  	if verint1[i] > verint2[i] then
  	  Result := 1
  	else
      if verint1[i] < verint2[i] then
  	    Result := -1
  	  else
  	    Result := 0;

  	i := i + 1;
  end;

end;

function initializeSetup(): boolean;
var
  FindRec: TFindRec;
  curPath: String;
begin
  result := true;
  if FindFirst(ExpandConstant('{win}\microsoft.net\Framework\v2.0.50727\*'), FindRec) then begin
    try
      repeat
          begin
            curPath := ExpandConstant('{win}\microsoft.net\Framework\v2.0.50727\')+FindRec.Name;
            if not (FileSearch('IEExec.exe', curPath) = '') then
            begin
              netpath := curPath;
              break;
            end;
          end;
      until not FindNext(FindRec);
    finally
      FindClose(FindRec);
    end;
  end;

  if (length(netpath) = 0) then
  begin
    MsgBox( CustomMessage('dotNetMissing'), mbInformation, MB_OK);
    result := false;
  end;
end;

function getDotNetDir(s: String): String;
begin
  result := netpath;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin

end;
