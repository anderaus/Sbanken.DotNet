var target = Argument("Target", "Default");

var configuration =
    HasArgument("Configuration") ? Argument<string>("Configuration") :
    EnvironmentVariable("Configuration") != null ? EnvironmentVariable("Configuration") : "Release";

// The build number to use in the version number of the built NuGet packages.
// There are multiple ways this value can be passed, this is a common pattern.
// 1. If command line parameter parameter passed, use that.
// 2. Otherwise if running on AppVeyor, get it's build number.
// 3. Otherwise if running on Travis CI, get it's build number.
// 4. Otherwise if an Environment variable exists, use that.
// 5. Otherwise default the build number to 1.
var buildNumber =
    HasArgument("BuildNumber") ? Argument<int>("BuildNumber") :
    AppVeyor.IsRunningOnAppVeyor ? AppVeyor.Environment.Build.Number :
    TravisCI.IsRunningOnTravisCI ? TravisCI.Environment.Build.BuildNumber :
    EnvironmentVariable("BuildNumber") != null ? int.Parse(EnvironmentVariable("BuildNumber")) : 1;

// Assume we're building on appveyor for publishing NuGets
// So always add a beta prefix if not doing a tag
var isTag = EnvironmentVariable("APPVEYOR_REPO_TAG") != null && EnvironmentVariable("APPVEYOR_REPO_TAG") == "true" ;
var revision = isTag ? null : "beta-" + buildNumber.ToString("D4");

// A directory path to an Artifacts directory.
var artifactsDirectory = Directory("./artifacts");

// Deletes the contents of the Artifacts folder if it should contain anything from a previous build.
Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDirectory);
    });

// Run dotnet restore to restore all package references.
Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore();
    });

// Find all csproj projects and build them using the build configuration specified as an argument.
Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var solutions = GetFiles("./*.sln");
        foreach(var solution in solutions)
        {
            Information("Building solution " + solution);
            Information("Version suffix " + revision);
            DotNetCoreBuild(
                solution.ToString(),
                new DotNetCoreBuildSettings()
                {
                    Configuration = configuration,
                    VersionSuffix = revision
                });
        }
    });

// Look under a 'test' folder and run dotnet test against all of those projects.
Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var projects = GetFiles("./test/**/*.csproj");
        foreach(var project in projects)
        {
            Information("Testing project " + project);
            DotNetCoreTest(
                project.GetDirectory().FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true
                });
        }
    });

// Run dotnet pack to produce NuGet packages from our projects. Versions the package
// using the build number argument on the script which is used as the revision number
// (Last number in 1.0.0.0). The packages are dropped in the Artifacts directory.
Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        foreach (var project in GetFiles("./src/**/*.csproj"))
        {
            Information("Packing project " + project);
            Information("Revision " + revision);
            DotNetCorePack(
                project.GetDirectory().FullPath,
                new DotNetCorePackSettings()
                {
                    Configuration = configuration,
                    OutputDirectory = artifactsDirectory,
                    VersionSuffix = revision
                });
        }
    });

Task("Default")
    .IsDependentOn("Pack");

RunTarget(target);