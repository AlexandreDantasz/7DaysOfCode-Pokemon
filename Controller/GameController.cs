using _7daysOfCode_pokemon.Service;
using _7daysOfCode_pokemon.Models;
using _7daysOfCode_pokemon.View;

namespace _7daysOfCode_pokemon.Controller
{
    public class GameController
    {
        private Menu Tela = new Menu();
        private List<PokemonBasicInfo> ListaDeOpcoes = [];
        private PokemonAPI ServicoPokemonAPI = new PokemonAPI();
        private PokemonBasicInfo Pokemon = new PokemonBasicInfo();

        public async Task ComecarJogoAsync()
        {
            ListaDeOpcoes = await ServicoPokemonAPI.BuscarEspecies();
            Tela.BoasVindas();
            bool JogadorPresente = true;
            do
            {
                Tela.OpcoesDeVisualizacao();
                switch (Tela.ReceberEscolhaDoJogador("Menu"))
                {
                    case 1:
                        // O jogador deseja olhar as espécies disponíveis
                        Tela.MostrarEspecies(ListaDeOpcoes);
                        Pokemon = ListaDeOpcoes[Tela.ReceberEscolhaDoJogador("Especies") - 1];
                        Tela.MostrarOpcoesDeUmPokemon(Pokemon);
                        switch (Tela.ReceberEscolhaDoJogador("Pokebola"))
                        {
                            case 1:
                                // O jogador deseja adotar o pokémon escolhido
                                break;
                            case 2:
                                // O jogador deseja saber mais detalhes sobre o pokémon
                                Tela.MostrarDetalhesDoPokemon(await ServicoPokemonAPI.BuscarDetalhes(Pokemon));
                                break;
                        }
                        break;
                    case 2:
                        // Jogador deseja visualizar seus mascotes adotados
                        break;
                    case 3:
                        JogadorPresente = false;
                        break;
                }
            } while (JogadorPresente);
        }
    }
}
