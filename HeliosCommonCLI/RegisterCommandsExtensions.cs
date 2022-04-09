// See https://aka.ms/new-console-template for more information
using Cocona;
using HeliosCommonCLI;
using HeliosCommonCLI.Extensions;

public class RegisterCommandsExtensions
{
    public static void Register(CoconaApp app)
    {
        CoconaAppJsonServiceExtensions.SetupJsonServiceCommands(app);
        CoconaAppGeneratorServiceExtensions.SetupGeneratorServiceCommands(app);
        CoconaAppMainEventsExtensions.ShutdownEventHandling(app);
    }
}