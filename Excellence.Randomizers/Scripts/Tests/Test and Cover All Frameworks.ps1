$currentDirectory = $PSCommandPath | Split-Path;
$frameworks = @("net5.0","net6.0");
$testAndCoverFilePath = Join-Path $currentDirectory "Test and Cover.ps1";

for ($index = 0; $index -lt $frameworks.Length ; $index++)
{
    & $testAndCoverFilePath -configuration "Release" -framework $frameworks[$index];
}
