namespace JuegoPOO
{
    internal class Mago : Personaje
    {
        public Mago(string nombre, int vida, int ataque, int defensa) : base(nombre, vida, ataque, defensa)
        {
        }
        public override int Atacar(Personaje objetivo)
        {
            // El mago tiene un ataque especial que inflige daño adicional
            int dañoBase = base.Atacar(objetivo);
            int dañoAdicional = 10; // Daño adicional fijo para el mago
            return dañoBase + dañoAdicional;
        }

    }
}