// See https://aka.ms/new-console-template for more information
using HeliosCommonCLI;
using HeliosCommonCLI.Services;
using Microsoft.Extensions.DependencyInjection;

public class CoconaAppServicesExtensions
{
    public static void AddServices(Cocona.Builder.CoconaAppBuilder builder)
    {
        builder.Services.AddTransient<IJsonFormatingService, JsonFormatingService>();
        builder.Services.AddTransient<IGeneratorService, GeneratorService>();
    }
}