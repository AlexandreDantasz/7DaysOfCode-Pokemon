using System.Text.Json.Serialization;

namespace _7daysOfCode_pokemon.Models
{
    public class PokemonAbility
    {
        [JsonPropertyName("is_hidden")]
        public Boolean Is_hidden { get; set; }
        [JsonPropertyName("slot")]
        public int Slot { get; set; }
        [JsonPropertyName("ability")]
        public PokemonBasicInfo Info { get; set; } = new PokemonBasicInfo();
    }
}
