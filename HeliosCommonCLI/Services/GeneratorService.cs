// See https://aka.ms/new-console-template for more information
using Ardalis.GuardClauses;
using System.Linq;

namespace HeliosCommonCLI.Services
{
    public class GeneratorService : IGeneratorService
    {
        static ReaderWriterLock locker = new ReaderWriterLock();

        /// <summary>
        /// dotnet run genid 100000 HeliosCommonCLI 
        /// </summary>
        /// <param name="numberOfGuids"></param>
        public void GenerateRandomGuids(int numberOfGuids)
        {
            Guard.Against.NegativeOrZero(numberOfGuids);
            Guard.Against.OutOfRange<int>(numberOfGuids, nameof(numberOfGuids), int.MinValue, 1000000);

            var guids = Enumerable.Range(1, numberOfGuids).ToList();
            guids.ForEach(guid => Console.WriteLine(Guid.NewGuid()));

            Console.WriteLine($"Finished generating {numberOfGuids} guids");
        }
        /// <summary>
        /// dotnet run genidf 100 --file-path C:\Users\xxxxx\Desktop\test.txt HeliosCommonCLI
        /// </summary>
        /// <param name="numberOfGuids"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task GenerateRandomGuidsToFileAsync(int numberOfGuids, string filePath)
        {
            Guard.Against.NegativeOrZero(numberOfGuids);
            Guard.Against.OutOfRange<int>(numberOfGuids, nameof(numberOfGuids), 1, int.MaxValue);
            Guard.Against.NullOrWhiteSpace(filePath);

            Console.WriteLine($"Started Guid generation and writing to file");

            Parallel.For(0, numberOfGuids, async i =>
            {
                try
                {
                    locker.AcquireWriterLock(int.MaxValue);
                    System.IO.File.AppendAllLines(filePath, new[] { Guid.NewGuid().ToString() });
                }
                finally
                {
                    locker.ReleaseWriterLock();
                }
            });

            Console.WriteLine($"Finished writing guids to file {filePath}");
        }
    }
}