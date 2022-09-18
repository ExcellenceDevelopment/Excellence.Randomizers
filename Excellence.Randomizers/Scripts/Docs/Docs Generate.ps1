param
(
    $configuration = "Release",
    $framework = "net6.0"
);

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$scriptsDirectoryPath = Join-Path $solutionDirectoryPath "Scripts";

$docsConfigTemplateFilePath = Join-Path $scriptsDirectoryPath "Docs" "Docs Config Template.json";
$docsConfigFilePath = Join-Path $solutionDirectoryPath "Local" "Docs" "Configs" "Docs Config.json";
$buildScriptFilePath = Join-Path $scriptsDirectoryPath "Build" "Build.ps1";


& $buildScriptFilePath -configuration $configuration;

$docsConfigTemplate = Get-Content $docsConfigTemplateFilePath;
$docsConfig = $docsConfigTemplate.replace("{{{solutionRoot}}}", $solutionDirectoryPath.replace("\", "\\")).replace("{{{framework}}}", $framework);

New-Item -Path $docsConfigFilePath -Force -ItemType "file" -Value ($docsConfig | Out-String);

DefaultDocumentation --ConfigurationFilePath $docsConfigFilePath;
