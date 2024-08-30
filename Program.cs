using System.Text.Json;
using Pokemon.Request;
public class PokemonTamagochi
{
    static private readonly string _url = new String("https://pokeapi.co/api/v2/pokemon/");

    static private List<string> _pokemonOptions = new List<string>();

    static private int _choice { get; set; }
    static public async Task Main()
    {
        await getListOfPokemons();
        await escolherPokemon();
    }

    static async Task escolherPokemon()
    {
        do
        {
            int showId = ListarOpcoes();
            await showAbilities(showId);
        } while (_choice != 1 && _choice != 0);

    }

    static private int ListarOpcoes()
    {
        int option;
        int choice = -1;
        do
        {
            Console.Clear();
            option = 0;
            foreach (var name in _pokemonOptions)
            {
                Console.WriteLine($"[{option}] - {name}");
                option++;
            }

            Console.Write("Digite o número da sua escolha: ");
            choice = int.Parse(Console.ReadLine()!);
        } while (choice < 0 || choice > _pokemonOptions.Count);

        return choice;
    }

    static private async Task getListOfPokemons()
    {
        // requisição http GET
        HttpClient client = new HttpClient();
        HttpResponseMessage res = await client.GetAsync(_url);

        // Fazendo a conversão do JSON
        GetNamedList pokeGet = JsonSerializer.Deserialize<GetNamedList>(await res.Content.ReadAsStringAsync())!;

        foreach (var item in pokeGet.results) _pokemonOptions.Add(item.name);
    }

    static async Task<int> showAbilities(int pokeId)
    {
        int choice = -1;

        do
        {
            Console.Clear();
            Console.WriteLine($"Nome: {_pokemonOptions[pokeId]}");
            await getAbilities(_pokemonOptions[pokeId]);
            Console.WriteLine("\n=== Decisão ===");
            Console.WriteLine("Escolher esse pokémon?");
            Console.WriteLine("Digite 1 para sim e 0 para não");
            Console.Write("Digite sua decisão: ");
            choice = int.Parse(Console.ReadLine()!);
        } while (choice != 1 && choice != 0);
        
        _choice = choice;
        return choice;
    }

    static private async Task getAbilities(string name)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage res = await client.GetAsync(_url + name);

        GetAbilities pokeGet = JsonSerializer.Deserialize<GetAbilities>(await res.Content.ReadAsStringAsync())!;

        Console.WriteLine("\n=== Habilidades ===");
        foreach (var item in pokeGet.abilities) Console.WriteLine(item.ability.name);
    }


};