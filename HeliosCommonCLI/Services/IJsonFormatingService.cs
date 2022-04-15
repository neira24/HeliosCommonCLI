namespace HeliosCommonCLI
{
    public interface IJsonFormatingService
    {
        void Escape(string fileName);
        Task EscapeTo(string fileName, string toFile);
    }
}