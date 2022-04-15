// See https://aka.ms/new-console-template for more information
using Ardalis.GuardClauses;

namespace HeliosCommonCLI.Services
{
    public class GeneratorService : IGeneratorService
    {
        public void GenerateRandomGuids(int numberOfGuids)
        {
            Guard.Against.NegativeOrZero(numberOfGuids);

            Console.WriteLine($"Started Guid generation");
            for (int x = 0; x <= numberOfGuids - 1; x++)
            {
                Console.WriteLine(Guid.NewGuid().ToString());
            }
            Console.WriteLine($"Finished generating {numberOfGuids} guids");
        }

        //is it faster to do one write or multiple writes
        public async Task GenerateRandomGuidsToFileAsync(int numberOfGuids, string filePath)
        {
            Guard.Against.NegativeOrZero(numberOfGuids);
            Guard.Against.NullOrWhiteSpace(filePath);

            Console.WriteLine($"Started Guid generation and writing to file");
            using StreamWriter file = new(filePath);
            for (int x = 0; x <= numberOfGuids - 1; x++)
            {
                await file.WriteLineAsync(Guid.NewGuid().ToString());
            }
            Console.WriteLine($"Finished writing guids to file {filePath}");
        }
    }
}