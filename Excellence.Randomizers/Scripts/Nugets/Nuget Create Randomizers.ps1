param ($configuration = "Release");

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$projectFilePath = Join-Path $solutionDirectoryPath "Sources" "Excellence.Randomizers" "Excellence.Randomizers.csproj";
$outputDirectoryPath = Join-Path $solutionDirectoryPath "Local" "Nugets";

dotnet pack $projectFilePath --configuration $configuration --output $outputDirectoryPath;
