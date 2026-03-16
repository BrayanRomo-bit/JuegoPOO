using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPOO
{ 
    internal class Personaje
    {
        // Propiedades comunes a todos los personajes
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }

        public Personaje(string nombre, int vida, int ataque, int defensa)
        {
            Nombre = nombre;
            Vida = vida;
            Ataque = ataque;
            Defensa = defensa;
        }
        public virtual int Atacar(Personaje objetivo)
        {
            return Ataque;
        }

        public bool EstaVivo()
        {
            return Vida > 0;
        }

    }
}