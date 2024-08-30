namespace Pokemon.Request;

public class NamedApiResource
{
    public string name { get ; set;} = string.Empty;
    public string url { get ; set;} = string.Empty;
}

public class GetNamedList
{
    public int count { get; set; }
    public string next { get; set; } = string.Empty;

    public string previous { get; set; } = string.Empty;

    public List<NamedApiResource> results { get; set; } = new List<NamedApiResource>();

}

public class PokemonAbility
{
    public Boolean is_hidden { get; set; }
    public int slot { get; set; }
    public NamedApiResource ability { get; set; } = new NamedApiResource();
}
public class GetAbilities
{
        public List<PokemonAbility> abilities { get; set; } = new List<PokemonAbility>();
}
