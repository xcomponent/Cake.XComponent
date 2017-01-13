#tool "nuget:?package=NUnit.Runners&version=2.6.4"

var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");
var packageVersion = Argument("PackageVersion", "8.8.8");

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
	NuGetRestore(GetFiles("Cake.XComponent.sln"), new NuGetRestoreSettings { NoCache = true });
	MSBuild("Cake.XComponent.sln", new MSBuildSettings { Configuration = configuration });
});

Task("Test")
  .Does(() =>
{
	var assemblies = GetFiles("./**/bin/*/*.Test.dll");
	NUnit(assemblies);
});

Task("Package")
  .Does(() =>
{
	CreateDirectory("nuget");
	NuGetPack("Cake.XComponent.nuspec", new NuGetPackSettings()
    { 
      OutputDirectory = @"./nuget",
	  Version = packageVersion
    });
});

Task("Deploy")
  .Does(() =>
{
	var package = "./nuget/Cake.XComponent." + packageVersion + ".nupkg";
	NuGetPush(package, new NuGetPushSettings {
		Source = "https://www.nuget.org/api/v2/package",
		ApiKey = "119a98a7-d371-40a2-8553-fdaaf7dcdeca"
	});
});


RunTarget(target);