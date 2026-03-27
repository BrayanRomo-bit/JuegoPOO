namespace JuegoPOO
{
    internal class Enemigo : Personaje
    {
        public Enemigo(string nombre, int vida, int ataque, int defensa) : base(nombre, vida, ataque, defensa)
        { }

        public override int Atacar(Personaje objetivo)
        {
            // El enemigo tiene un ataque especial que inflige daño adicional
            int dañoBase = base.Atacar(objetivo);
            int dañoAdicional = 5; // Daño adicional fijo para el enemigo
            return dañoBase + dañoAdicional;
        }
    }
}
