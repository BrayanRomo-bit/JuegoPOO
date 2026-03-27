namespace JuegoPOO
{
    internal class Guerrero : Personaje
    {
        public Guerrero(string nombre, int vida, int ataque, int defensa) : base(nombre, vida, ataque, defensa)
        {
        }
        public override int Atacar(Personaje objetivo)
        {
            // El guerrero tiene un ataque especial que inflige daño adicional
            int dañoBase = base.Atacar(objetivo);
            int dañoAdicional = 5; // Daño adicional fijo para el guerrero
            return dañoBase + dañoAdicional;
        }
    }
}