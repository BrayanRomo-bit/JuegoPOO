using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPOO
{
    public class ControlarPartida
    {

        public int _rondaActual = 1;
        private int _turnoActual = 1;
        private int _especialAcumulada = 0;
        private int _puntojugador;
        private int _puntoenemigo;
        public int rondaActual { get { return _rondaActual; } private set => _rondaActual = value; }
        public int turnoActual { get { return _turnoActual; } set => _turnoActual = value; }
        public int especialAcumulada { get { return _especialAcumulada; } private set => _especialAcumulada = value; }


        public int PuntoEnemigo
        {
            get { return _puntoenemigo; }
            private set { _puntoenemigo = value; }
        }
        public Personaje Jugador { get; set; }
        public Enemigo enemigo { get; set; }

        public int PuntoJugador
        {
            get { return _puntojugador; }
            private set { _puntojugador = value; }
        }


        public void SumarPuntos()
        {
            if (!enemigo.EstaVivo()) PuntoJugador++;
            else if (!Jugador.EstaVivo()) PuntoEnemigo++;

        }

        public bool EspecialUsada()
        {
            especialAcumulada--;
            turnoActual = 0;
            return true;
        }
        public void AvanzarTurno()
        {

            if (Jugador.YaAtaco == true)
            {
                turnoActual++;
                Jugador.YaAtaco = false;
            }
            if (turnoActual == 3)
            {
                especialAcumulada++;
                turnoActual = 0;
            }
        }
        public string AvanzarRound()
        {

            if (PuntoJugador == 2 || PuntoEnemigo == 2)
            {
                string ganadoracion = "";

                if (PuntoJugador == 2)
                    ganadoracion = $"¡{Jugador.Nombre} gana el juego con {PuntoJugador} puntos a {PuntoEnemigo}!";
                else
                    ganadoracion = $"¡{enemigo.Nombre} gana el juego con {PuntoEnemigo} puntos a {PuntoJugador}!";

                FinalizarJuego();
                return ganadoracion;
            }
            else
            {
                turnoActual = 0;
                rondaActual++;
                Jugador.CuracionesUsadas = 0;
                enemigo.DefensaMaxima = enemigo.DefensaMaxima + 15;
                enemigo.VidaMaxima = enemigo.VidaMaxima + 15;
                enemigo.Vida = enemigo.VidaMaxima;
                enemigo.Defensa = enemigo.DefensaMaxima;

                int curaxround = 60;

                if (!Jugador.EstaVivo())
                {
                    Jugador.Vida = Jugador.VidaMaxima;
                    Jugador.Defensa = Jugador.DefensaMaxima;
                }
                else if (Jugador.Defensa != Jugador.DefensaMaxima)
                {
                    if (Jugador.Defensa + curaxround <= Jugador.DefensaMaxima)
                        Jugador.Defensa = Jugador.Defensa + curaxround;
                    else if (Jugador.Defensa + curaxround > Jugador.DefensaMaxima)
                    {
                        int curasobrante = Jugador.Defensa + curaxround - Jugador.DefensaMaxima;
                        Jugador.Defensa = Jugador.DefensaMaxima;
                        Jugador.Vida = Jugador.Vida + curasobrante;
                        if (Jugador.Vida > Jugador.VidaMaxima) Jugador.Vida = Jugador.VidaMaxima;
                    }
                    else if (Jugador.Defensa + curaxround == Jugador.DefensaMaxima)
                        Jugador.Defensa = Jugador.Defensa + curaxround;
                }
            }
            return "";
        }

        public bool FinalizarJuego()
        {

            _rondaActual = 1;
            _turnoActual = 0;
            _especialAcumulada = 0;
            PuntoEnemigo = 0;
            PuntoJugador = 0;

            if (Jugador != null)
            {
                Jugador.Defensa = Jugador.DefensaMaxima;
                Jugador.Vida = Jugador.VidaMaxima;
            }
            return true;
        }

    }
}