param
(
    $configuration = "Release",
    $framework = "net6.0"
);

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$solutionFileName = "Excellence.Randomizers.sln";
$solutionFilePath = Join-Path $solutionDirectoryPath $solutionFileName;

$localDirectoryPath = Join-Path $solutionDirectoryPath  "Local";

$testResultsDirectoryPath = Join-Path $localDirectoryPath "Tests" $framework;

$testCoverageResultsDirectoryPath = Join-Path $testResultsDirectoryPath "TestCoverageResults";
$testCoverageResultsReportsDirectoryPath = Join-Path $testCoverageResultsDirectoryPath "Reports";
$testCoverletCoverletJsonFilePath = Join-Path $testCoverageResultsDirectoryPath "coverlet.json";
$testCoverageCoverletOutputFormat = "cobertura";

dotnet test $solutionFilePath --framework $framework --configuration $configuration --verbosity minimal --logger "trx;LogFileName=TestResults.trx" --logger "html;LogFileName=TestResults.html" --logger "console;verbosity=normal" --results-directory $testResultsDirectoryPath -p:CollectCoverage=true -p:CoverletOutput=$testCoverageResultsReportsDirectoryPath -p:MergeWith=$testCoverletCoverletJsonFilePath -p:CoverletOutputFormat=$testCoverageCoverletOutputFormat;

ReportGenerator -reports:(Join-Path $testCoverageResultsDirectoryPath "*.xml") -targetdir:$testCoverageResultsReportsDirectoryPath -reporttypes:"Html_Dark";
