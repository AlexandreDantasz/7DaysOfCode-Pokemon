using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7daysOfCode_pokemon.Models
{
    public class Mascote
    {
        public string Nome { get; set; } = String.Empty;
        public int Vida { get; set; }
        public List<string> Habilidades = [];

        public int Height;
        public int Weight;
    }
}
