// See https://aka.ms/new-console-template for more information
using Cocona;

class Program
{
    static void Main(string[] args)
    {
        CoconaApp app = AppBuild();
        RegisterCommandsExtensions.Register(app);
        app.Run();
    }

    private static CoconaApp AppBuild()
    {
        var builder = CoconaApp.CreateBuilder();
        CoconaAppServicesExtensions.AddServices(builder);
        var app = builder.Build();
        return app;
    }
}
