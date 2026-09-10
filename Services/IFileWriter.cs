namespace CatFacts.Services
{
    public interface IFileWriter
    {
        Task AppendAllTextAsync(string filePath, string content);
    }

    public class FileWriter : IFileWriter
    {
        public async Task AppendAllTextAsync(string filePath, string content)
        {
            await File.AppendAllTextAsync(filePath, content);
        }
    }
}
