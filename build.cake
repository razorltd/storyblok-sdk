var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var publishDirectory = @"./publish";
var sitemapGeneratorPublishDirectory = @"./publish_sitemap";
const string errorMessage = "Process returned an error (exit code {0}).";

Task("Restore")
    .Does(() =>
    {
        var exitCode = StartProcess("dotnet", new ProcessSettings
        {
            Arguments = $@"restore"
        });

        if (exitCode != 0)
        {
            throw new CakeException();
        }
    });

Task("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        CleanDirectories(publishDirectory);

        var exitCode = StartProcess("dotnet", new ProcessSettings
        {
            Arguments = $@"clean --configuration {configuration}"
        });

        if (exitCode != 0)
        {
            throw new CakeException();
        }
    });

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        var exitCode = StartProcess("dotnet", new ProcessSettings
        {
            Arguments = $@"build --configuration {configuration} --no-restore"

        });

        if (exitCode != 0)
        {
            throw new CakeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, errorMessage, exitCode));
        }
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var exitCode = StartProcess("dotnet", new ProcessSettings
        {
            Arguments = $@"test --configuration {configuration} --no-build"
        });

        if (exitCode != 0) {
            throw new CakeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, errorMessage, exitCode));
        }
    });

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
    {
        var exitCode = 0;

        exitCode = StartProcess("dotnet", new ProcessSettings
        {
            Arguments = $@"pack src/Storyblok.Sdk --configuration {configuration} --output {publishDirectory} --no-restore"
        });

        if (exitCode != 0)
        {
            throw new CakeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, errorMessage, exitCode));
        }
    });

Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);
