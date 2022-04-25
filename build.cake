#tool "nuget:?package=NUnit.ConsoleRunner&version=3.9.0"
#addin "nuget:?package=Cake.DoInDirectory&version=4.0.2"

var target = Argument("target", "Build");
var configuration = Argument("buildConfiguration", "Debug");
var packageVersion = Argument("buildVersion", "8.8.8");
var apiKey = Argument("nugetKey", "");

Task("Clean")
    .Does(() =>
{
	CleanDirectory("Cake.XComponent/bin");
	CleanDirectory("Cake.XComponent/obj");
	CleanDirectory("Cake.XComponent.Test/bin");
	CleanDirectory("Cake.XComponent.Test/obj");
});

Task("Build")
  .IsDependentOn("Clean")
  .Does(() =>
{
	DotNetCoreRestore("Cake.XComponent.sln");
	DotNetCoreBuild(
		"Cake.XComponent.sln", 
		new DotNetCoreBuildSettings { 
			Configuration = configuration,
			VersionSuffix = packageVersion,
			MSBuildSettings = new DotNetCoreMSBuildSettings{}.SetVersion(packageVersion),
		}
	);
});


Task("Test")
  .IsDependentOn("Build")
  .Does(() =>
{
	var projectFiles = GetFiles("./**/*Test.csproj");
	foreach(var file in projectFiles)
	{
			DotNetCoreTest(file.FullPath);
	}
});

Task("Package")
  .IsDependentOn("Test")
  .Does(() =>
{
	DotNetCorePack(
		"Cake.XComponent/Cake.XComponent.csproj", 
		new DotNetCorePackSettings { 
			Configuration = configuration,
			IncludeSymbols = true,
			NoBuild = true,
			OutputDirectory = @"nuget",
			VersionSuffix = packageVersion,
			MSBuildSettings = new DotNetCoreMSBuildSettings{}.SetVersion(packageVersion),
		}
	);
});

Task("Deploy")
  .IsDependentOn("Package")
  .Does(() =>
{
	if (!string.IsNullOrEmpty(apiKey))
	{
		DoInDirectory("./nuget", () =>
		{
			var package = "Cake.XComponent." + packageVersion + ".nupkg";
			DotNetCoreNuGetPush(package, new DotNetCoreNuGetPushSettings 
			{
				Source = "https://api.nuget.org/v3/index.json",
				ApiKey = apiKey
			});
		});
	}
	else
	{
		Error("No Api Key provided. Can't deploy package to Nuget.");
	}
});

RunTarget(target);