

namespace CatFacts.Services
{
    public interface ICatFactsService
    {
        Task<CatFactsDto?> GetRandomCatFactAsync();
    }
    public class CatFactsService : ICatFactsService
    {
        private readonly HttpClient _httpClient;
        private readonly IFileWriter _fileWriter;
        private const string FilePath = "catfacts.txt";
        private string ApiUrl = "https://catfact.ninja/fact";

        public CatFactsService(HttpClient httpClient, IFileWriter fileWriter)
        {
            _httpClient = httpClient;
            _fileWriter = fileWriter;
        }

        public async Task<CatFactsDto?> GetRandomCatFactAsync()
        {
            var fact = await _httpClient.GetFromJsonAsync<CatFactsDto>(ApiUrl);

            if (fact != null && !string.IsNullOrWhiteSpace(fact.Fact))
            {
                var newFact = fact.Fact.Trim();
                await _fileWriter.AppendAllTextAsync(FilePath, newFact + Environment.NewLine);
            }
            return fact;
        }
    }
}
