using System.Text.Json.Serialization;

namespace _7daysOfCode_pokemon.Models
{
    public class PokemonBasicInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
