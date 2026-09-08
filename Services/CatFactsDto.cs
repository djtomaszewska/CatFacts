using System.Text.Json.Serialization;

namespace CatFacts.Services
{
    public class CatFactsDto
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; } = string.Empty;
        
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
