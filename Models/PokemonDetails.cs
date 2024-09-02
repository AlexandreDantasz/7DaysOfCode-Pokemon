using System.Text.Json.Serialization;

namespace _7daysOfCode_pokemon.Models
{
    public class PokemonDetails
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<PokemonAbility> Abilities { get; set; } = [];
    }
}
