using System.Text.Json.Serialization;

namespace _7daysOfCode_pokemon.Models
{
    public class PokemonsSpecies
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;
        [JsonPropertyName("previous")]
        public string Previous { get; set; } = string.Empty;
        [JsonPropertyName("results")]
        public List<PokemonBasicInfo> Results { get; set; } = [];
    }
}
