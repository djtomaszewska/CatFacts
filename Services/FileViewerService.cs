namespace CatFacts.Services
{
    public class FileViewerService
    {
        private readonly HttpClient _httpClient;
        private const string FilePath = "catfacts.txt";
        public FileViewerService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetSavedCatFactsAsync()
        {
            var savedFacts = new List<string>();
            if (File.Exists(FilePath))
            {
                var lines = await File.ReadAllLinesAsync(FilePath);
                savedFacts.AddRange(lines);
            }
            return savedFacts;
        }
    }
}
