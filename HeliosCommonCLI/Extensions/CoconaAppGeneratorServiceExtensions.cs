using Cocona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliosCommonCLI
{
    public class CoconaAppGeneratorServiceExtensions
    {
        public static void SetupGeneratorServiceCommands(CoconaApp app)
        {
            app.AddCommand("genid", ([Argument] int count, GeneratorService generatorService) =>
            {
                Executor.TryExecute(() => generatorService.GenerateRandomGuids(count));
            }).WithDescription("Generate the given amount UUID's and print to console");

            app.AddCommand("genidf", async ([Argument] int count, string filePath, GeneratorService generatorService) =>
            {
                Executor.TryExecute(async () => await generatorService.GenerateRandomGuidsToFileAsync(count, filePath));
            }).WithDescription("Generate the given amount UUID's and save to file");
        }
    }
}
