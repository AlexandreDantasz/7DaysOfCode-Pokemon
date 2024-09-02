using _7daysOfCode_pokemon.Models;

namespace _7daysOfCode_pokemon.View
{
    public class Menu
    {
        public string Nome { get; set; } = string.Empty;
        public void BoasVindas()
        {
            Console.Clear();
            Console.WriteLine("=== Tamagotchi - Pokémon version ===");
            Console.WriteLine("Olá! Qual é o seu nome?");
            Console.Write("Digite o seu nome: ");

            Nome = Console.ReadLine();

            // Caso o usuário não escreva nada, o nome padrão deve ser "Ash"
            Nome = String.IsNullOrEmpty(Nome) ? "Ash" : Nome;

            Console.WriteLine("Bem-vindo {0}!", Nome);
            Console.WriteLine("Que tal conhecer nossos mascotes?");
        }

        public int ReceberEscolhaDoJogador(string modo)
        {
            int low = 0, high = 0;

            if (modo == "Especies")
            {
                low = 1;
                high = 20;
            }
            else
            {
                if (modo == "Menu" || modo == "Pokebola")
                {
                    low = 1;
                    high = 3;
                }
            }

            int escolha = -1;
            do
            {
                Console.Write("Digite sua escolha: ");
                if (!int.TryParse(Console.ReadLine(), out escolha) || escolha < low || escolha > high)
                {
                    Console.WriteLine("Opção inválida, tente novamente");
                }
            } while (escolha < 1 || escolha > 3);

            return escolha;
        }
        public void OpcoesDeVisualizacao()
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("Aperte [1] para adotar um mascote virtual");
            Console.WriteLine("Aperte [2] ver seus mascotes adotados");
            Console.WriteLine("Aperte [3] para sair do jogo");
        }

        public void MostrarEspecies(List<PokemonBasicInfo> lista)
        {
            Console.Clear();
            Console.WriteLine("=== Espécies disponíveis para adoção ===");
            int opcao = 1;
            Console.WriteLine("Opção | Nome");
            foreach (PokemonBasicInfo pokemon in lista)
            {
                Console.WriteLine($" [{opcao++}] | {pokemon.Name}");
            }
            
        }

        public void MostrarOpcoesDeUmPokemon(PokemonBasicInfo pokemon)
        {
            Console.Clear();
            Console.WriteLine($"=== O que você deseja fazer com o {pokemon.Name}? ===");
            Console.WriteLine("Aperte [1] para adotar");
            Console.WriteLine("Aperte [2] para saber mais detalhes sobre o {0}", pokemon.Name);
            Console.WriteLine("Aperte [3] para voltar");
        }

        public void MostrarDetalhesDoPokemon(PokemonDetails pokemon)
        {
            Console.Clear();
            Console.WriteLine("=== Detalhes sobre o {0} ===", pokemon.Name);
            Console.WriteLine("Altura: {0}", pokemon.Height);
            Console.WriteLine("Peso: {0}", pokemon.Weight);
            Console.WriteLine("Habilidades:");

            for (int i = 0; i < pokemon.Abilities.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, pokemon.Abilities[i].Info.Name);
            }
        }

    }
}
