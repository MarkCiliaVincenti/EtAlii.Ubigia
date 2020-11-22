namespace EtAlii.Ubigia.Pipelines
{
    using Nuke.Common;
    using Nuke.Common.CI;
    using Nuke.Common.CI.AzurePipelines;
    using Nuke.Common.Execution;
    using Nuke.Common.Git;
    using Nuke.Common.ProjectModel;

    // We need to give Nuke a bit more time to do it's magic.
    // More info: https://github.com/nuke-build/nuke/issues/260
    [CheckBuildProjectConfigurations(TimeoutInMilliseconds = 2000)] 
    [ShutdownDotNetAfterServerBuild]
    [AzurePipelines( 
        AzurePipelinesImage.WindowsLatest, 
        InvokedTargets = new[]
        {
            nameof(CompileTestAnalyseAndPublish)
        },
        NonEntryTargets = new []
        {
            nameof(Clean), 
            nameof(Restore),
            nameof(PrepareAnalysis),
            nameof(Compile),
            nameof(Test),
            nameof(PackPackages),
            nameof(PublishAnalysisToSonarQube),
            nameof(PublishTestResults),
            nameof(PublishPackages),
            nameof(PublishArtefacts)
        }
        // TriggerPathsInclude = Triggers are still maintained on the server.
    )]
    public partial class Build : NukeBuild
    {
        /// To run nuke locally install it as a global tool:
        /// "dotnet tool install Nuke.GlobalTool --global"
        /// Or "dotnet tool update Nuke.GlobalTool --global" to update.
        /// 
        /// Support plugins are available for:
        ///   - JetBrains ReSharper        https://nuke.build/resharper
        ///   - JetBrains Rider            https://nuke.build/rider
        ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
        ///   - Microsoft VSCode           https://nuke.build/vscode

        public static int Main() => Execute<Build>(build => build.CompileTestAnalyseAndPublish);

        [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
        readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
        
        [Solution] readonly Solution Solution;
        [GitRepository] readonly GitRepository GitRepository;

        [CI] readonly AzurePipelines AzurePipelines;
        
        Target CompileTestAnalyseAndPublish => _ => _
            .Description("Compile, test, analyse and publish")
            // .DependsOn(PublishArtefacts)
            // .DependsOn(PublishPackages)
            .DependsOn(PublishAnalysisToSonarQube)
            .DependsOn(PublishTestResults);
    }
}
