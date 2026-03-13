using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPOO
{
    internal class Boss : Personaje
    {
        public Boss(string nombre, int vida, int ataque, int defensa) : base(nombre, vida, ataque, defensa)
        {
        }
    }
}
