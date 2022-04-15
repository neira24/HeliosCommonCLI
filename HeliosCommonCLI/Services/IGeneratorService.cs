// See https://aka.ms/new-console-template for more information
public interface IGeneratorService
{
    void GenerateRandomGuids(int numberOfGuids);
    Task GenerateRandomGuidsToFileAsync(int numberOfGuids, string filePath);
}