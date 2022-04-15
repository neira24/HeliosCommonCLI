namespace HeliosCommonCLI.Options
{
    public record HeliosShellOptions
    {
        public const string Key = "HeliosShell";
        public bool EnableShellCompletionSupport { get; init; }
    }
}
