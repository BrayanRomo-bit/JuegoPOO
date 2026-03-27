namespace JuegoPOO
{
    internal class Arquero : Personaje
    {
        public Arquero(string nombre, int vida, int ataque, int defensa) : base(nombre, vida, ataque, defensa)
        {
        }
        public override int Atacar(Personaje objetivo)
        {
            // El arquero tiene un ataque especial que inflige daño adicional
            int dañoBase = base.Atacar(objetivo);
            int dañoAdicional = 7; // Daño adicional fijo para el arquero
            return dañoBase + dañoAdicional;
        }

    }
}