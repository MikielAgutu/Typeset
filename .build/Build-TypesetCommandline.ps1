$projectPath = "$PSScriptRoot/../Typeset/CLI/CLI.csproj"
$outputDirectory = "$PSScriptRoot/output/typeset-cli-windows"

Remove-Item $outputDirectory -Recurse -ErrorAction Ignore
New-Item -Path $outputDirectory -ItemType Directory

Copy-Item "$PSScriptRoot/windows-cli-template/*" $outputDirectory -Recurse

dotnet publish $projectPath -c Release -r win-x64 -o "$outputDirectory/bin" /p:Version=0.0.1