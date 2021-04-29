$projectPath = "$PSScriptRoot/../Typeset/Typeset/Typeset.csproj"
$outputDirectory = "$PSScriptRoot/output/nupkgs"

dotnet pack $projectPath -c Release -o $outputDirectory