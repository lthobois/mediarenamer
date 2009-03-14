#define AppName "Media Renamer"
#define AppVer "2.0rc1"
#define AppVerLong GetFileVersion("MediaRenamer\bin\Release\MediaRenamer.exe")
#define AppPublisher "Benjamin Schirmer"
#define AppURL "http://code.google.com/p/mediarenamer/"

[Setup]
AppName={#AppName}
AppVersion={#AppVer}
AppContact=Benjamin Schirmer
AppVerName={#AppName} {#AppVer}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}
AppID={{869D06EA-2277-4588-9567-CDFE5C30A399}

VersionInfoCompany={#AppPublisher}
VersionInfoCopyright=©2006-2009 Benjamin Schirmer
VersionInfoDescription=Media Renamer
VersionInfoTextVersion={#AppVerLong}
VersionInfoVersion={#AppVerLong}

DefaultDirName={pf}\Media Renamer
DisableDirPage=false
DefaultGroupName={#AppName}
DisableProgramGroupPage=false
UninstallDisplayName={#AppName}
AllowNoIcons=true
Compression=lzma/ultra
SolidCompression=true
OutputBaseFilename=mediarenamer_{#AppVer}
OutputDir=Setup
InternalCompressLevel=ultra
ShowLanguageDialog=yes
ChangesAssociations=true
LicenseFile=MediaRenamer\Apache2.0.txt
ArchitecturesInstallIn64BitMode=x64

WizardImageFile=compiler:WizModernImage-IS.bmp
WizardSmallImageFile=compiler:WizModernSmallImage-IS.bmp


[Languages]
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl

[CustomMessages]
en.dotNetMissing=You do not have a .NET Framework 2.0 installed. Please install it using Windows Update.
de.dotNetMissing=Sie haben das .NET Framework 2.0 nicht installiert. Bitte installieren sie es über Windows Update.

[Files]
Source: MediaRenamer\bin\Release\MediaRenamer.exe; DestDir: {app}
Source: MediaRenamer\bin\Release\JsonExSerializer.dll; DestDir: {app}
Source: MediaRenamer\bin\Release\JsonExSerializer.license.txt; DestDir: {app}
Source: MediaRenamer\bin\Release\de\MediaRenamer.resources.dll; DestDir: {app}\de\
Source: MediaRenamer\bin\Release\Apache2.0.txt; DestDir: {app}
Source: MediaRenamer\bin\Release\Ionic.Utils.Zip.dll; DestDir: {app}
Source: MediaRenamer\bin\Release\Ionic.Utils.Zip.license.txt; DestDir: {app}

[Dirs]
Name: {app}\de

[Run]
Filename: {code:getDotNetDir}\ngen.exe; Parameters: "install ""{app}\MediaRenamer.exe"" /nologo /silent"; WorkingDir: {code:getDotNetDir}; StatusMsg: optimizing executable for native execution; Flags: runminimized runhidden

[UninstallRun]
Filename: {code:getDotNetDir}\ngen.exe; Parameters: "uninstall ""{app}\MediaRenamer.exe"" /nologo /silent"; WorkingDir: {code:getDotNetDir}; StatusMsg: removing executable from native code cache; Flags: runminimized runhidden

[UninstallDelete]
Name: {userappdata}\MediaRenamer; Type: filesandordirs

[Icons]
Name: {group}\{cm:UninstallProgram,{#AppName}}; Filename: {uninstallexe}
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
  DotNetBase: String;
begin
  result := true;
  if Is64BitInstallMode then
  begin
    DotNetBase := ExpandConstant('{win}\microsoft.net\Framework64\v2.0.50727\');
  end else begin
    DotNetBase := ExpandConstant('{win}\microsoft.net\Framework\v2.0.50727\');
  end;

  if FindFirst(DotNetBase + '*', FindRec) then begin
    try
      repeat
          begin
            curPath := DotNetBase + FindRec.Name;
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
