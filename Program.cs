using _7daysOfCode_pokemon.Controller;

public class PokemonTamagochi
{
    static public async Task Main()
    {
        GameController controller = new GameController();
        await controller.ComecarJogoAsync();
    }
};