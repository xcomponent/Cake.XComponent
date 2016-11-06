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

Task("Deploy")
  .Does(() =>
{
	NuGetPack("Cake.XComponent.dll.nuspec", new NuGetPackSettings()
    { 
      OutputDirectory = @"."
    });
});

RunTarget(target);