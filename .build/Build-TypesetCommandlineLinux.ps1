$version = "0.0.1";
$projectPath = "$PSScriptRoot/../Typeset/CLI/CLI.csproj"
$outputDirectory = "$PSScriptRoot/output/typeset-cli-linux"
$zipOutputPath  = "$PSScriptRoot/output/typeset-v$version-cli-linux.tar.gz"

Remove-Item $outputDirectory -Recurse -ErrorAction Ignore
New-Item -Path $outputDirectory -ItemType Directory

Copy-Item "$PSScriptRoot/linux-cli-template/*" $outputDirectory -Recurse

dotnet publish $projectPath -c Release -r linux-x64 -o "$outputDirectory/bin" /p:Version=$version

tar -cvzf $zipOutputPath -C $outputDirectory .