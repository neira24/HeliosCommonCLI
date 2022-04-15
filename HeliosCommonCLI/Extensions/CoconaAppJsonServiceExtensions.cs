using Cocona;
using HeliosCommonCLI.Constants;

namespace HeliosCommonCLI
{
    public static class CoconaAppJsonServiceExtensions
    {
        public static void SetupJsonServiceCommands(CoconaApp app)
        {
            app.AddCommand(Command.UnescapeJson, ([Argument] string filePath) =>
             {
                 Executor.TryExecute(() => JsonFormatingService.Unescape(filePath));
             }).WithDescription("Unescape json string in file");

            app.AddCommand(Command.EscapeJson, ([Argument] string filePath, IJsonFormatingService jsonService) =>
            {
                Executor.TryExecute(() => jsonService.Escape(filePath));
            }).WithDescription("Escape json string in file");

            app.AddCommand(Command.EscapeJsonTo, ([Argument] string filePath, [Argument] string fileTo, IJsonFormatingService jsonService) =>
            {
                Executor.TryExecute(async() => await jsonService.EscapeTo(filePath, fileTo));
            }).WithDescription("Escape json string in file and save result to another file");

            app.AddCommand(Command.UnescapeJsonTo, ([Argument] string filePath, [Argument] string fileTo) =>
            {
                Executor.TryExecute(async () => await JsonFormatingService.UnescapeTo(filePath, fileTo));
            }).WithDescription("Unescape json string in file and save result to another file");
        }
    }
}
