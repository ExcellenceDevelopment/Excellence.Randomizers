$currentDirectory = $PSCommandPath | Split-Path;
$configuration = "Release";

& (Join-Path $currentDirectory "Nuget Create Randomizers.Core.ps1") -configuration $configuration;
& (Join-Path $currentDirectory "Nuget Create Randomizers.ps1") -configuration $configuration;
