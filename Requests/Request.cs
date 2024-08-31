using System.Text.Json.Serialization;

namespace Pokemon.Request;

public class NamedApiResource
{
    [JsonPropertyName("name")]
    public string Name { get ; set;} = string.Empty;
    [JsonPropertyName("url")]
    public string Url { get ; set;} = string.Empty;
}

public class PokemonList
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("next")]
    public string Next { get; set; } = string.Empty;
    [JsonPropertyName("previous")]
    public string Previous { get; set; } = string.Empty;
    [JsonPropertyName("results")]
    public List<NamedApiResource> Results { get; set; } = [];

}

public class PokemonAbility
{
    [JsonPropertyName("is_hidden")]
    public Boolean Is_hidden { get; set; }
    [JsonPropertyName("slot")]
    public int Slot { get; set; }
    [JsonPropertyName("ability")]
    public NamedApiResource Ability { get; set; } = new NamedApiResource();
}
public class PokemonStats
{
    [JsonPropertyName("height")]
    public int Height { get ; set; }
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
    [JsonPropertyName("abilities")]
    public List<PokemonAbility> Abilities { get; set; } = [];
}
