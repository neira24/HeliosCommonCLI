namespace HeliosCommonCLI
{
    public static class FileManager
    {
        public static string GetFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (IsExisting(filePath)) { throw new FileNotFoundException(); }
            return filePath;
        }
        public static bool IsExisting(string path)
        {
            var exists = File.Exists(path);
            if (!exists)
            {
                Console.WriteLine($"File not found. Path: {path}");
            }
            return exists;
        }

        public static void CreateFileWhenNotExisting(string toFile)
        {
            if (!File.Exists(toFile)) { File.Create(toFile); };
        }

        public static string GetFilePath(string fileName)
        {
            return Directory.GetCurrentDirectory() + "\\" + fileName;
        }
    }
}
