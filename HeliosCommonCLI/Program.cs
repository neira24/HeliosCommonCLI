// See https://aka.ms/new-console-template for more information
using Cocona;
using HeliosCommonCLI;
using HeliosCommonCLI.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Sentry;

class Program
{
    static void Main(string[] args)
    {
        using (SentrySdk.Init(o =>
        {
            o.Dsn = "https://bf77c4c4d1924413a6dfd95c0b30701d@o1049601.ingest.sentry.io/6219538";
            // When configuring for the first time, to see what the SDK is doing:
            o.Debug = true;
            // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
            // We recommend adjusting this value in production.
            o.TracesSampleRate = 1.0;
        }))
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
}
