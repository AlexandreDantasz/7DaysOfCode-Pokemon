using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using _7daysOfCode_pokemon.Models;
using Pokemon.Request;
public class PokemonTamagochi
{
    static private readonly string _url = new String("https://pokeapi.co/api/v2/pokemon/");

    static private AsciiPokemons Image = new AsciiPokemons();

    static private Mascote Tamagotchi = new Mascote();

    static private List<string> _pokemonOptions = [];

    static private int _choice { get; set; }
    static public async Task Main()
    {
        await getListOfPokemons();
        await escolherPokemon();
    }

    static async Task escolherPokemon()
    {
        int idPokemon;
        do
        {
            Tamagotchi.Habilidades.Clear();
            idPokemon = ListarOpcoes();
        } while (await showStats(idPokemon) != 1);

        Tamagotchi.Nome = _pokemonOptions[idPokemon];

        Console.Clear();
        Console.WriteLine($"Você escolheu o {Tamagotchi.Nome}!");

        string picture = "";
        if (Image.AsciiImages.TryGetValue(Tamagotchi.Nome, out picture!)) 
        {
            Console.WriteLine("Um dos três iniciais da região de Kanto!");
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(picture);
            Console.OutputEncoding = Encoding.UTF8;
        }

        // Limpa as opções
        _pokemonOptions.Clear();
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
        } while (choice < 0 || choice >= _pokemonOptions.Count);

        return choice;
    }

    static private async Task getListOfPokemons()
    {
        // requisição http GET
        HttpClient client = new HttpClient();
        HttpResponseMessage res = await client.GetAsync(_url);

        // Fazendo a conversão do JSON
        PokemonList pokeGet = JsonSerializer.Deserialize<PokemonList>(await res.Content.ReadAsStringAsync())!;

        foreach (var item in pokeGet.Results) _pokemonOptions.Add(item.Name);
    }

    static async Task<int> showStats(int pokeId)
    {
        int choice = -1;

        do
        {
            Console.Clear();
            Console.WriteLine($"Nome: {_pokemonOptions[pokeId]}");
            await getAbilities(_pokemonOptions[pokeId]);
            Console.WriteLine("\n=== Decisão ===");
            Console.WriteLine("Escolher esse pokémon?");
            Console.WriteLine("Digite [1] para sim ou digite [0] para não");
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

        PokemonStats pokeGet = JsonSerializer.Deserialize<PokemonStats>(await res.Content.ReadAsStringAsync())!;

        Console.WriteLine($"Altura = {pokeGet.Height}");
        Console.WriteLine($"Peso: {pokeGet.Weight}");
        Console.WriteLine("\n=== Habilidades ===");
        foreach (var item in pokeGet.Abilities)
        {
            Console.WriteLine(item.Ability.Name);
            Tamagotchi.Habilidades.Add(item.Ability.Name);
        }

        Tamagotchi.Weight = pokeGet.Weight;
        Tamagotchi.Height = pokeGet.Height;
    }


};