param ($configuration = "Release");

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$solutionFileName = "Excellence.Randomizers.sln";
$solutionFilePath = Join-Path $solutionDirectoryPath $solutionFileName;

dotnet build $solutionFilePath --configuration $configuration;