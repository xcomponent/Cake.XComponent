#tool "nuget:?package=NUnit.ConsoleRunner&version=3.9.0"

var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");
var packageVersion = Argument("PackageVersion", "8.8.8");
var apiKey = Argument("ApiKey", "");

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

	// var assemblies = GetFiles("./**/bin/*/*.Test*.dll");
	// NUnit3(assemblies);
});

Task("Package")
  .IsDependentOn("Test")
  .Does(() =>
{
	DotNetCorePack(
		"Cake.XComponent/Cake.XComponent.csproj", 
		new DotNetCorePackSettings { 
			Configuration = configuration,
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
		var package = "./nuget/Cake.XComponent." + packageVersion + ".nupkg";
		NuGetPush(package, new NuGetPushSettings 
		{
			Source = "https://www.nuget.org/api/v2/package",
			ApiKey = apiKey
		});
	}
	else
	{
		Error("No Api Key provided. Can't deploy package to Nuget.");
	}
});

RunTarget(target);