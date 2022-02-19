using Cocona;

namespace HeliosCommonCLI.Extensions
{
    public class CoconaAppMainEventsExtensions
    {
        public static void ShutdownEventHandling(CoconaApp app)
        {
            app.AddCommand(async (CoconaAppContext ctx) =>
            {
                while (!ctx.CancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(100);
                }
            });
        }
    }
}
