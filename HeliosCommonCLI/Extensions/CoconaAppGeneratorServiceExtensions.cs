using Cocona;
using HeliosCommonCLI.Constants;

namespace HeliosCommonCLI
{
    public class CoconaAppGeneratorServiceExtensions
    {
        public static void SetupGeneratorServiceCommands(CoconaApp app)
        {
            app.AddCommand(Command.GenerateIds, ([Argument] int count, IGeneratorService generatorService) =>
            {
                Executor.TryExecute(() => generatorService.GenerateRandomGuids(count));
            }).WithDescription("Generate the given amount UUID's and print to console");

            app.AddCommand(Command.GenerateIdsToFile, ([Argument] int count, string filePath, IGeneratorService generatorService) =>
            {
                Executor.TryExecute(async () => await generatorService.GenerateRandomGuidsToFileAsync(count, filePath));
                return Task.CompletedTask;
            }).WithDescription("Generate the given amount UUID's and save to file");
        }
    }
}
