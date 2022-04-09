// See https://aka.ms/new-console-template for more information
using HeliosCommonCLI;
using Microsoft.Extensions.DependencyInjection;

public class CoconaAppServicesExtensions
{
    public static void AddServices(Cocona.Builder.CoconaAppBuilder builder)
    {
        builder.Services.AddTransient<JsonFormatingService>();
        builder.Services.AddTransient<GeneratorService>();
    }
}