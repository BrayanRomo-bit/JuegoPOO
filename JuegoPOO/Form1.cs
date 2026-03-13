using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoPOO
{
    public partial class Form1 : Form
    {
        
        private Label lblDescripcion;
        Personaje Jugador;
        Personaje Enemigo;
        Random random = new Random();

        int rondaActual = 1; 

        public Form1()
        {
            InitializeComponent();
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = false;
            btnAtacar.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPersonaje.Items.AddRange(new string[] { "Guerrero", "Arquero", "Mago" });
            cmbPersonaje.SelectedIndex = 0;
        }

        private void cmbPersonaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guerrero guerrero = new Guerrero("koku", 100, 20, 50);
            Arquero arquero = new Arquero("jokai", 80, 15, 30);
            Mago mago = new Mago("chuerk", 70, 25, 25);
            string personajeSeleccionado = cmbPersonaje.SelectedItem.ToString();

            switch (personajeSeleccionado)
            {
                case "Guerrero":
                    lblDescripcion.Text = $"Has seleccionado a {guerrero.Nombre}, un guerrero con {guerrero.Vida} puntos de vida, {guerrero.Ataque} de ataque y {guerrero.Defensa} de defensa.";
                    break;
                case "Arquero":
                    lblDescripcion.Text = $"Has seleccionado a {arquero.Nombre}, un arquero con {arquero.Vida} puntos de vida, {arquero.Ataque} de ataque y {arquero.Defensa} de defensa.";
                    break;
                case "Mago":
                    lblDescripcion.Text = $"Has seleccionado a {mago.Nombre}, un mago con {mago.Vida} puntos de vida, {mago.Ataque} de ataque y {mago.Defensa} de defensa.";
                    break;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPersonaje.Text))
            {
                MessageBox.Show("Por favor, selecciona un personaje.");
                return;
            }

            switch (cmbPersonaje.Text)
            {
                case "Guerrero":
                    pbJugador.Image = Properties.Resources.KOKU;
                    Jugador = new Guerrero("koku", 100, 20, 50);
                    break;
                case "Arquero":
                    pbJugador.Image = Properties.Resources.Jokai;
                    Jugador = new Arquero("jokai", 80, 15, 30);
                    break;
                case "Mago":
                    pbJugador.Image = Properties.Resources.Magito;
                    Jugador = new Mago("grifindor", 70, 25, 25);
                    break;
                default:
                    MessageBox.Show("Personaje no válido.");
                    return;
            }

            pbEnemigo.Image = Properties.Resources.Chuerk;
            Enemigo = new Enemigo("chuerk", 100, 25, 40);
            MessageBox.Show($"Has creado a {Jugador.Nombre} y te enfrentarás a {Enemigo.Nombre}.");

           
            pbVidaJugador.Maximum = Math.Max(Jugador.Vida, Enemigo.Vida);
            pbVidaEnemigo.Maximum = Math.Max(Jugador.Vida, Enemigo.Vida);
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida}";
            pbVidaEnemigo.Value = Enemigo.Vida;
            pbVidaJugador.Value = Jugador.Vida;

            
            rondaActual = 1;
            lblRound.Text = $"Round: {rondaActual}";
            txtLog.Clear();

            btnAtacar.Enabled = true;
            btnEspecial.Enabled = true;
            btnCurar.Enabled = true;
            btnTurnoEnemigo.Enabled = false;
            btnCrear.Enabled = false;
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            int dañoJugador = Jugador.Ataque;
            if (dañoJugador < 0) dañoJugador = 0;

            Enemigo.Vida = Enemigo.Vida - dañoJugador;
            if (Enemigo.Vida < 0) Enemigo.Vida = 0;

            txtLog.AppendText($"\n{Jugador.Nombre} ataca a {Enemigo.Nombre} e inflige {dañoJugador} puntos de daño.\n");

            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";
            pbVidaEnemigo.Value = Enemigo.Vida;

            if (!Jugador.EstaVivo())
            {
                MessageBox.Show($"\n{Jugador.Nombre} ha sido derrotado. ¡Fin del juego!");
                FinalizarJuego();
            }
            else if (!Enemigo.EstaVivo())
            {
                AvanzarRound();
            }
            else
            {
                PasarTurnoAEnemigo();
            }
        }

        private async void btnEspecial_Click(object sender, EventArgs e)
        {
            //se hace async para poder usar await Task.Delay() y mostrar la animación del ataque especial
            txtLog.Clear();

            Image imagenOriginal = pbJugador.Image;
            pbJugador.Image = Properties.Resources.goku_kamehameha;
            await Task.Delay(1800);
            pbJugador.Image = imagenOriginal;

            int dañoEspecial = Jugador.Ataque * 2;
            Enemigo.Vida = Enemigo.Vida - dañoEspecial;
            if (Enemigo.Vida < 0) Enemigo.Vida = 0;

            txtLog.AppendText($"\n{Jugador.Nombre} ataca a {Enemigo.Nombre} e inflige {dañoEspecial} puntos de daño.\n");

            pbVidaEnemigo.Value = Enemigo.Vida;
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";

            if (!Jugador.EstaVivo())
            {
                MessageBox.Show($"\n{Jugador.Nombre} ha sido derrotado. ¡Fin del juego!");
                FinalizarJuego();
            }
            else if (!Enemigo.EstaVivo())
            {
                AvanzarRound();
            }
            else
            {
                PasarTurnoAEnemigo();
            }
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            int cura = 25;
            Jugador.Vida = Jugador.Vida + cura;

            if (Jugador.Vida > pbVidaJugador.Maximum) Jugador.Vida = pbVidaJugador.Maximum;

            txtLog.AppendText($"\n{Jugador.Nombre} se cura y recupera {cura} puntos de vida.\n");

            pbVidaJugador.Value = Jugador.Vida;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida}";

            PasarTurnoAEnemigo();
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            if (Enemigo.EstaVivo())
            {
                int dañoEnemigo = Enemigo.Ataque;
                if (dañoEnemigo < 0) dañoEnemigo = 0;

                Jugador.Vida = Jugador.Vida - dañoEnemigo;
                if (Jugador.Vida < 0) Jugador.Vida = 0;

                txtLog.AppendText($"\n{Enemigo.Nombre} ataca a {Jugador.Nombre} e inflige {dañoEnemigo} puntos de daño.\n");

                pbVidaJugador.Value = Jugador.Vida;
                lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida}";
            }

            if (!Jugador.EstaVivo())
            {
                MessageBox.Show($"\n{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}. ¡Fin del juego!");
                FinalizarJuego();
            }
            else
            {
                btnAtacar.Enabled = true;
                btnEspecial.Enabled = true;
                btnCurar.Enabled = true;
                btnTurnoEnemigo.Enabled = false;
            }
        }
        private void AvanzarRound()
        {
            if (rondaActual >= 3)
            {
                MessageBox.Show($"¡Felicidades! Has derrotado a las 3 oleadas y ganaste el juego.");
                FinalizarJuego();
            }
            else
            {
                rondaActual++;
                Jugador.Vida = Jugador.Vida + 50;
                if (Jugador.Vida > pbVidaJugador.Maximum) pbVidaJugador.Maximum = Jugador.Vida;

                Enemigo.Vida = 100;
                if (Enemigo.Vida > pbVidaEnemigo.Maximum) pbVidaEnemigo.Maximum = Enemigo.Vida;

                MessageBox.Show($"¡Enemigo derrotado! Ganas 50 de vida. Prepárate para el Round {rondaActual}");

                lblRound.Text = $"Round: {rondaActual}";
                txtLog.Clear();
                txtLog.AppendText($"--- INICIA EL ROUND {rondaActual} ---\n");

                pbVidaJugador.Value = Jugador.Vida;
                lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida}";

                pbVidaEnemigo.Value = Enemigo.Vida;
                lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";

                btnAtacar.Enabled = true;
                btnEspecial.Enabled = true;
                btnCurar.Enabled = true;
                btnTurnoEnemigo.Enabled = false;
            }
        }

        private void PasarTurnoAEnemigo()
        {
            btnAtacar.Enabled = false;
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = true;
        }

        private void FinalizarJuego()
        {
            btnAtacar.Enabled = false;
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = false;
            btnCrear.Enabled = true;
        }
    }
}