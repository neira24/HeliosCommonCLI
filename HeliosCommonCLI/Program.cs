// See https://aka.ms/new-console-template for more information
using Cocona;
using HeliosCommonCLI.Options;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false)
        .Build();

        CoconaApp app = AppBuild(args, configuration);
        RegisterCommandsExtensions.Register(app);
        app.Run();
    }

    private static CoconaApp AppBuild(string[] args, IConfiguration configuration)
    {
        var shellOptions = configuration.GetSection(HeliosShellOptions.Key).Get<HeliosShellOptions>();

        var builder = CoconaApp.CreateBuilder(args, options =>
        {
            options.EnableShellCompletionSupport = shellOptions.EnableShellCompletionSupport;
        });

        CoconaAppServicesExtensions.AddServices(builder);
        var app = builder.Build();
        return app;
    }
}
