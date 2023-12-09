$solutionPath=".\\Excellence.Randomizers\\Excellence.Randomizers.sln";
$configuration="Release";
$verbosity="normal";

dotnet build $solutionPath --configuration $configuration &&
dotnet test $solutionPath --configuration $configuration --framework "net6.0" --no-build --verbosity $verbosity &&
dotnet test $solutionPath --configuration $configuration --framework "net7.0" --no-build --verbosity $verbosity &&
dotnet test $solutionPath --configuration $configuration --framework "net8.0" --no-build --verbosity $verbosity;
