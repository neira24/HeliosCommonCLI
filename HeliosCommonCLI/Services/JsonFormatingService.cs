using Ardalis.GuardClauses;
using System.Text.RegularExpressions;

namespace HeliosCommonCLI
{
    public class JsonFormatingService : IJsonFormatingService
    {
        public static void Unescape(string fileName)
        {
            Guard.Against.NullOrWhiteSpace(fileName);

            string filePath = Guard.Against.NotFound(fileName, FileManager.GetFile(fileName), nameof(fileName));
            string text = File.ReadAllText(filePath);
            var unescapedText = Regex.Unescape(text);
            File.WriteAllText(filePath, unescapedText);
            Console.WriteLine("Finished unescaping string");
        }

        public static Task UnescapeTo(string fileName, string toFile)
        {
            Guard.Against.NullOrWhiteSpace(fileName);
            Guard.Against.NullOrWhiteSpace(toFile);

            string filePath = Guard.Against.NotFound(fileName, FileManager.GetFile(fileName), nameof(fileName));
            if (FileManager.IsExisting(filePath)) { throw new FileNotFoundException(); }
            string text = File.ReadAllText(filePath);
            var unescapedText = Regex.Unescape(text);
            WriteDataToFile(toFile, unescapedText);
            Console.WriteLine($"Finished unescaping string to {toFile}");
            return Task.CompletedTask;
        }

        private static void WriteDataToFile(string toFile, string unescapedText)
        {
            FileManager.CreateFileWhenNotExisting(toFile);
            File.WriteAllText(toFile, unescapedText);
        }

        public void Escape(string fileName)
        {
            string filePath = FileManager.GetFilePath(fileName);
            string text = File.ReadAllText(filePath);
            var unescapedText = Regex.Escape(text);
            File.WriteAllText(filePath, unescapedText);
            Console.WriteLine("Finished escaping string");
        }

        public Task EscapeTo(string fileName, string toFile)
        {
            string filePath = FileManager.GetFilePath(fileName);
            string text = File.ReadAllText(filePath);
            var unescapedText = Regex.Escape(text);
            FileManager.CreateFileWhenNotExisting(toFile);
            File.WriteAllText(toFile, unescapedText);
            Console.WriteLine($"Finished escaping string to file {toFile}");
            return Task.CompletedTask;
        }
    }
}
