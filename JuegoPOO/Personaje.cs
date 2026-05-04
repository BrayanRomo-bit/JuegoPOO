namespace JuegoPOO
{
    public class Personaje
    {
        private int _vida;
        private int _defensa;

        public string Nombre { get; set; }
        public int Ataque { get; set; }
        public int CuracionesUsadas { get; set; } = 0;
        public int Vida
        {
            get { return _vida; }
            set
            {
                _vida = value;
                if (_vida < 0) _vida = 0;
                if (_vida > VidaMaxima) _vida = VidaMaxima;
                CambiarEstadisticas?.Invoke();
            }
        }
        public int VidaMaxima { get; set; }
        public int Defensa
        {
            get { return _defensa; }
            set
            {
                _defensa = value;
                if (_defensa < 0) _defensa = 0; 
                if (_defensa>DefensaMaxima) _defensa = DefensaMaxima;
                CambiarEstadisticas?.Invoke();

            }
        }
        public int DefensaMaxima { get; set; }
        public bool YaAtaco { get; set; }
        public event Action CambiarEstadisticas;
        public Personaje(string nombre, int ataque, int vidamaxima, int defensamaxima)
        {

            VidaMaxima = vidamaxima;
            DefensaMaxima = defensamaxima;
            Defensa = DefensaMaxima;
            Vida = VidaMaxima;
            Nombre = nombre;
            Defensa = DefensaMaxima;
            Vida = VidaMaxima;
            Ataque = ataque;
        }

        public string CurarVida(int cura)
        {

            if (Defensa == DefensaMaxima)
            {
                return $"EL jugador ya tiene toda la vida y defensa no puede curarse";
            }

            if (Defensa != DefensaMaxima)
            {
                if (Defensa + cura <= DefensaMaxima)
                {
                    Defensa = Defensa + cura;
                    return $"Te haz curado {cura} puntos de Defensa";
                }


                else if (Defensa + cura > DefensaMaxima)
                {
                    int curasobrante = Defensa + cura - DefensaMaxima;
                    Defensa = DefensaMaxima;
                    Vida = Vida + curasobrante;
                    if (Vida > VidaMaxima)
                        Vida = VidaMaxima;
                    return $"Te haz curado la Defensa por completo y {curasobrante} puntos de Vida";
                }
                else if (Defensa + cura == DefensaMaxima)
                {
                    Defensa = Defensa + cura;
                    return $"Te haz curado la Defensa por completo";
                }
            }
            else if (Defensa == DefensaMaxima)
            {
                Vida += cura;
                if (Vida > VidaMaxima)
                {
                    Vida = VidaMaxima;
                    return $"Te haz curado {cura} de salud";
                }
            }
            return $"{cura}";
        }
        public void Atacar(int daño, Personaje objetivo)
        {
            if (objetivo.Defensa != 0)
            {
                if (daño > objetivo.Defensa)
                {
                    int dañoSobrante = daño - objetivo.Defensa;
                    objetivo.Defensa = 0;
                    objetivo.Vida = objetivo.Vida - dañoSobrante;
                }
                else if (daño < objetivo.Defensa)
                {
                    objetivo.Defensa = objetivo.Defensa - daño;
                }
                else if (daño == objetivo.Defensa)
                {
                    objetivo.Defensa = 0;
                }
            }
            else
            {
                objetivo.Vida = objetivo.Vida - daño;

            }
            if (objetivo.Vida < 0) objetivo.Vida = 0;

            YaAtaco = true;
        }


        public bool EstaVivo()
        {
            return Vida > 0;
        }

    }
}