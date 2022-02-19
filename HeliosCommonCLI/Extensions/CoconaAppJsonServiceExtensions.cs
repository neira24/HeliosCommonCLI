using Cocona;
using HeliosCommonCLI.Constants;

namespace HeliosCommonCLI
{
    public static class CoconaAppJsonServiceExtensions
    {
        public static void SetupJsonServiceCommands(CoconaApp app)
        {
            app.AddCommand(CommandConstants.UnescapeJson, ([Argument] string filePath, JsonFormatingService jsonService) =>
             {
                 Executor.TryExecute(() => JsonFormatingService.Unescape(filePath));
             }).WithDescription("Unescape json string in file");

            app.AddCommand(CommandConstants.EscapeJson, ([Argument] string filePath, JsonFormatingService jsonService) =>
            {
                Executor.TryExecute(() => jsonService.Escape(filePath));
            }).WithDescription("Escape json string in file");

            app.AddCommand(CommandConstants.EscapeJsonTo, ([Argument] string filePath, [Argument] string fileTo, JsonFormatingService jsonService) =>
            {
                Executor.TryExecute(async() => await jsonService.EscapeTo(filePath, fileTo));
            }).WithDescription("Escape json string in file and save result to another file");

            app.AddCommand(CommandConstants.UnescapeJsonTo, ([Argument] string filePath, [Argument] string fileTo, JsonFormatingService jsonService) =>
            {
                Executor.TryExecute(async () => await JsonFormatingService.UnescapeTo(filePath, fileTo));
            }).WithDescription("Unescape json string in file and save result to another file");
        }
    }
}
