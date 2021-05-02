$version = "0.0.1";
$projectPath = "$PSScriptRoot/../Typeset/CLI/CLI.csproj"
$outputDirectory = "$PSScriptRoot/output/typeset-cli-windows"
$zipOutputPath  = "$PSScriptRoot/output/typeset-v$version-cli-windows.zip"

Remove-Item $outputDirectory -Recurse -ErrorAction Ignore
New-Item -Path $outputDirectory -ItemType Directory

Copy-Item "$PSScriptRoot/windows-cli-template/*" $outputDirectory -Recurse

dotnet publish $projectPath -c Release -r win-x64 -o "$outputDirectory/bin" /p:Version=$version

$compress = @{
  Path = $outputDirectory
  CompressionLevel = "Fastest"
  DestinationPath = $zipOutputPath
}

Compress-Archive @compress -Force