// See https://aka.ms/new-console-template for more information
using Cocona;
using HeliosCommonCLI;
using HeliosCommonCLI.Extensions;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
            var builder = CoconaApp.CreateBuilder();
            builder.Services.AddTransient<JsonFormatingService>();
            builder.Services.AddTransient<GeneratorService>();
            var app = builder.Build();
            CoconaAppJsonServiceExtensions.SetupJsonServiceCommands(app);
            CoconaAppGeneratorServiceExtensions.SetupGeneratorServiceCommands(app);
            CoconaAppMainEventsExtensions.ShutdownEventHandling(app);
            app.Run();
    }
}
