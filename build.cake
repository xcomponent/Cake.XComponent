var target = Argument("target", "Build");

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
	MSBuild("Cake.XComponent.sln");
});

Task("Test")
  .Does(() =>
{
	Information("Hello World!");
});

Task("Package")
  .Does(() =>
{
	CreateDirectory("nuget");
	NuGetPack("Cake.XComponent.nuspec", new NuGetPackSettings()
    { 
      OutputDirectory = @"./nuget"
    });
});

Task("Deploy")
  .Does(() =>
{
	var package = "./nuget/Cake.XComponent.1.0.0.nupkg";
	NuGetPush(package, new NuGetPushSettings {
		Source = "https://www.nuget.org/packages/Cake.XComponent/",
		ApiKey = "119a98a7-d371-40a2-8553-fdaaf7dcdeca"
	});
});


RunTarget(target);