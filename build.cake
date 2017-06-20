
var mainProject = "Soruce/Medium/Medium.csproj";

Task("Watch").Does(() => {
    StartProcess("watchman-make", new ProcessSettings {
        Arguments = "-p '**/*.cs' --make='./build.sh --target' -t Build"
    });
});

Task("Build").Does(() => {
    DotNetCoreBuild(mainProject);
});

Task("Watch-Run").Does(() => {
    var dir = System.IO.Path.GetDirectoryName(mainProject);
    StartProcess("dotnet", new ProcessSettings {
        Arguments = "watch run",
        WorkingDirectory = dir
    });
});

var target = Argument("target", "default");
RunTarget(target);