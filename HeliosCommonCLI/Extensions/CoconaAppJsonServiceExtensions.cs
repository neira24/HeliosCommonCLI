using Cocona;

namespace HeliosCommonCLI
{
    public static class CoconaAppJsonServiceExtensions
    {
        public static void SetupJsonServiceCommands(CoconaApp app)
        {
            app.AddCommand("unesc", ([Argument] string filePath, JsonFormatingService jsonService) =>
             {
                 Executor.TryExecute(() => JsonFormatingService.Unescape(filePath));
             }).WithDescription("Unescape json string in file");

            app.AddCommand("escape", ([Argument] string filePath, JsonFormatingService jsonService) =>
            {
                Executor.TryExecute(() => jsonService.Escape(filePath));
            }).WithDescription("Escape json string in file");

            app.AddCommand("escapeto", ([Argument] string filePath, [Argument] string fileTo, JsonFormatingService jsonService) =>
            {
                Executor.TryExecute(() => jsonService.EscapeTo(filePath, fileTo));
            }).WithDescription("Escape json string in file and save result to another file");

            app.AddCommand("unescto", ([Argument] string filePath, [Argument] string fileTo, JsonFormatingService jsonService) =>
            {
                Executor.TryExecute(() => JsonFormatingService.UnescapeTo(filePath, fileTo));
            }).WithDescription("Unescape json string in file and save result to another file");
        }
    }
}
