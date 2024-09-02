using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using _7daysOfCode_pokemon.Models;

namespace _7daysOfCode_pokemon.Service
{
    public class PokemonAPI
    {
        private readonly string Url = new String("https://pokeapi.co/api/v2/pokemon/");
        private HttpClient Client = new HttpClient();
        public async Task<List<PokemonBasicInfo>> BuscarEspecies()
        {
            // Buscando na API as 20 primeiras espécies de pokémons
            string res = await Client.GetStringAsync(Url);
            PokemonsSpecies result = JsonSerializer.Deserialize<PokemonsSpecies>(res)!;
            return result.Results;
        }

        public async Task<PokemonDetails> BuscarDetalhes(PokemonBasicInfo pokemon)
        {
            // Buscando detalhes sobre o pokémon
            string res = await Client.GetStringAsync(Url + pokemon.Name);
            PokemonDetails result = JsonSerializer.Deserialize<PokemonDetails>(res)!;
            return result;
        }
    }
}
