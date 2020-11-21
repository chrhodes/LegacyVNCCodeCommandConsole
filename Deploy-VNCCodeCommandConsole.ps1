$currentDirectory = $PSScriptRoot

cd $currentDirectory

$destinationPath = "B:\bin\CodeCommandConsole"
$sourcePath = ".\bin\Release"
$sourceFiles = "$sourcePath\*"

if (-not (Test-Path -LiteralPath $destinationPath))
{
    try
    {
        New-Item -Path $destinationPath -ItemType Directory -ErrorAction Stop | Out-Null #-Force
	}
    catch
    {
	    Write-Error -Message "Unable to create Directory '$destinationPath'.  Error was: $_"
		Exit
	}

    "Output Directory '$destinationServer' created"
}

if (-not (Test-Path -LiteralPath $sourcePath))
{
     Write-Error -Message "SourcePath: '$sourcePath' does not exist.  Aborting"
	 Exit
}

"Installing new CodeCommandConsole to $destinationPath"

Copy-Item -Path $sourceFiles -Recurse -Force -Destination  $destinationPath
