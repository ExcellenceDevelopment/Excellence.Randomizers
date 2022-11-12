param
(
    $configuration = "Release",
    $framework = "net7.0"
);

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$solutionFileName = "Excellence.Randomizers.sln";
$solutionFilePath = Join-Path $solutionDirectoryPath $solutionFileName;

$localDirectoryPath = Join-Path $solutionDirectoryPath  "Local";

$testResultsDirectoryPath = Join-Path $localDirectoryPath "Tests" $framework;

$testCoverageDirectoryPath = Join-Path $testResultsDirectoryPath "Coverage";
$testCoverageFilePath = Join-Path $testCoverageDirectoryPath "coverage.xml";
$testCoverageReportsDirectoryPath = Join-Path $testCoverageDirectoryPath "Reports";

dotnet dotcover test $solutionFilePath --configuration=$configuration --framework=$framework --dcReportType="DetailedXML" --dcOutput=$testCoverageFilePath;

ReportGenerator -reports:$testCoverageFilePath -targetdir:$testCoverageReportsDirectoryPath -reporttypes:"Html_Dark";
