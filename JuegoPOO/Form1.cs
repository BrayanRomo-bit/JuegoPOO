using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoPOO
{
    public partial class Form1 : Form
    {
        Personaje Jugador;
        Personaje Enemigo;
        int rondaActual = 1;
        int turnoActual = 0;
        int especialAcumulada =0;
        int curarclick =0;
        int PuntoEnemigo = 0;
        int PuntoJugador = 0;

        public Form1()
        {
            InitializeComponent();
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = false;
            btnAtacar.Enabled = false;
            btnAbandonar.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPersonaje.Items.AddRange(new string[] { "Guerrero", "Arquero", "Mago" });
            cmbPersonaje.SelectedIndex = 0;
        }

        private void cmbPersonaje_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cmbPersonaje.Text)
            {
                case "Guerrero":
                    pbJugador.Image = Properties.Resources.gokubase1;
                    Jugador = new Guerrero("koku", 150, 20, 50);
                    txtLog.Clear();
                    txtLog.AppendText($"{Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa}");
                    break;
                case "Arquero":
                    pbJugador.Image = Properties.Resources.Jokai;
                    Jugador = new Arquero("jokai", 100, 35, 30);
                    txtLog.Clear();
                    txtLog.AppendText($"{Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa} ");
                    break;
                case "Mago":
                    pbJugador.Image = Properties.Resources.Magito;
                    Jugador = new Mago("grifindor", 70, 20, 50);
                    txtLog.Clear();
                    txtLog.AppendText($" {Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa} ");
                    txtLog.AppendText($"\nEl Mago tiene la habilidad de curarse, pero solo puede usarla 3 veces por round.\n");
                    break;
                default:
                    MessageBox.Show("Personaje no válido.");
                    return;

            }
            pbVidaJugador.Maximum = Math.Max(1, Jugador.Vida);
            pbDefensaJugador.Maximum = Math.Max(1, Jugador.Defensa);
            pbVidaJugador.Value = pbVidaJugador.Maximum;
            pbDefensaJugador.Value = pbDefensaJugador.Maximum;
            lblVidaJugador.Text = $" {Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa} ";
        }




        private void btnCrear_Click(object sender, EventArgs e)
        {
            btnCurar.Visible = true;
            if (string.IsNullOrEmpty(cmbPersonaje.Text))
            {
                MessageBox.Show("Por favor, selecciona un personaje.");
                return;
            }

            pbEnemigo.Image = Properties.Resources.Chuerk;
            Enemigo = new Enemigo("chuerk", 100, 25, 40);
            MessageBox.Show($"Has creado a {Jugador.Nombre} y te enfrentarás a {Enemigo.Nombre}.");

            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa}";
            pbVidaEnemigo.Maximum = Math.Max(1, Enemigo.Vida);
            pbDefensaEnemigo.Maximum = Math.Max(1, Enemigo.Defensa);
            pbVidaEnemigo.Value = Enemigo.Vida;
            pbDefensaEnemigo.Value = Enemigo.Defensa;
            label1.Text = $"Especiales acumulados: {especialAcumulada}";

            rondaActual = 1;
            lblRound.Text = $"Round: {rondaActual}";
            txtLog.Clear();

            btnAtacar.Enabled = true;
            btnEspecial.Enabled = true;
            btnCurar.Enabled = true;
            btnTurnoEnemigo.Enabled = false;
            btnCrear.Enabled = false;
            btnAbandonar.Enabled = true;
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            int daño = Jugador.Ataque;
            if (daño < 0) daño = 0;
            if (Enemigo.Defensa != 0)
            {
                if (daño > Enemigo.Defensa)
                {
                    int dañoSobrante = daño - Enemigo.Defensa;
                    Enemigo.Defensa = 0;
                    Enemigo.Vida = Enemigo.Vida - dañoSobrante;
                }
                else if (daño < Enemigo.Defensa)
                {
                    if (daño < 0) daño = 0;
                    Enemigo.Defensa = Enemigo.Defensa - daño;
                }
                else if (daño == Enemigo.Defensa)
                {
                    Enemigo.Defensa = 0;
                }
            }
            else
            {
                if (daño < 0) daño = 0;
                Enemigo.Vida = Enemigo.Vida - daño;
                if (Enemigo.Vida < 0) Enemigo.Vida = 0;
                txtLog.AppendText($"\n{Jugador.Nombre} ataca a {Enemigo.Nombre} e inflige {daño} puntos de daño.\n");
            }


            lblVidaEnemigo.Text = $" {Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa}";
            pbVidaEnemigo.Value = Enemigo.Vida;
            pbDefensaEnemigo.Value = Enemigo.Defensa;

            if (!Jugador.EstaVivo())
            {
                PuntoEnemigo++;
                txtLog.AppendText($" \n{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}.\n");
                txtLog.AppendText($" \n{Enemigo.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo} \n");
                AvanzarRound();
            }
            else if (!Enemigo.EstaVivo())
            {
                PuntoJugador++;
                txtLog.AppendText($" \n{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}.\n");
                txtLog.AppendText($" \n{Jugador.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo} \n");
                AvanzarRound();
            }
            else
            {
                PasarTurnoAEnemigo();
            }

            turnoActual++;
            if (turnoActual == 3)
            {
                especialAcumulada++;
                turnoActual = 0;
                label1.Text = $"Especiales acumulados: {especialAcumulada}";
            }


        }
        private async void btnEspecial_Click(object sender, EventArgs e)
        {
            if (especialAcumulada > 0)
            {
                txtLog.Clear();
                Image imagenOriginal = pbJugador.Image;

                if (Jugador is Guerrero)
                {
                    pbJugador.Image = Properties.Resources.gokuespecial;
                    await Task.Delay(1900);
                }

                pbJugador.Image = imagenOriginal;

                int dañoEspecial = Jugador.Ataque * 2;
                if (dañoEspecial < 0) dañoEspecial = 0;

                if (Enemigo.Defensa != 0)
                {
                    if (dañoEspecial > Enemigo.Defensa)
                    {
                        int dañoSobrante = dañoEspecial - Enemigo.Defensa;
                        Enemigo.Defensa = 0;
                        Enemigo.Vida = Enemigo.Vida - dañoSobrante;
                    }
                    else if (dañoEspecial < Enemigo.Defensa)
                    {
                        if (dañoEspecial < 0) dañoEspecial = 0;
                        Enemigo.Defensa = Enemigo.Defensa - dañoEspecial;
                    }
                    else if (dañoEspecial == Enemigo.Defensa)
                    {
                        Enemigo.Defensa = 0;
                    }
                }
                else
                {
                    if (dañoEspecial < 0) dañoEspecial = 0;
                    Enemigo.Vida = Enemigo.Vida - dañoEspecial;
                    if (Enemigo.Vida < 0) Enemigo.Vida = 0;
                    txtLog.AppendText($"\n{Jugador.Nombre} usa un ataque especial contra {Enemigo.Nombre} e inflige {dañoEspecial} puntos de daño.\n");
                }

                pbVidaEnemigo.Value = Enemigo.Vida;
                pbDefensaEnemigo.Value = Enemigo.Defensa;
                lblVidaEnemigo.Text = $" {Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa} ";

                if (!Jugador.EstaVivo())
                {
                    PuntoEnemigo++;
                    txtLog.AppendText($"\n{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}.\n");
                    txtLog.AppendText($"\n{Enemigo.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo} \n");
                    AvanzarRound();
                }
                else if (!Enemigo.EstaVivo())
                {
                    PuntoJugador++;
                    txtLog.AppendText($"\n{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}.\n");
                    txtLog.AppendText($"\n{Jugador.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo} \n");
                    AvanzarRound();
                }
                else
                {
                    PasarTurnoAEnemigo();
                }

                // Al final del ataque, restamos el especial y actualizamos el label
                especialAcumulada--;
                label1.Text = $"Especiales acumulados: {especialAcumulada}";
            }
            else
            {
                // Si especialAcumulada es 0, mostramos la advertencia.
                // Usamos las llaves { } para agrupar estas dos acciones correctamente.
                label1.Text = $"Especiales acumulados: {especialAcumulada}";
                MessageBox.Show("No tienes ataques especiales acumulados. Realiza más ataques normales para acumularlos.");
            }
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            
            if (Jugador.Defensa == pbDefensaJugador.Maximum && Jugador.Vida == pbVidaEnemigo.Maximum)
            {
                txtLog.AppendText($" \n{Jugador.Nombre} ya tiene la defensa al máximo y no puede curarse.\n ");
                return;
            }

            int cura = 50;
            if (Jugador.Defensa != pbDefensaJugador.Maximum)
            {
                if (Jugador.Defensa + cura <= pbDefensaJugador.Maximum)
                    Jugador.Defensa = Jugador.Defensa + cura;

                else if (Jugador.Defensa + cura > pbDefensaJugador.Maximum)
                {
                    int curasobrante = Jugador.Defensa + cura - pbDefensaJugador.Maximum;
                    Jugador.Defensa = pbDefensaJugador.Maximum;
                    Jugador.Vida = Jugador.Vida + curasobrante;
                    if (Jugador.Vida > pbVidaJugador.Maximum)
                        Jugador.Vida = pbVidaJugador.Maximum;
                }
                else if (Jugador.Defensa + cura == pbDefensaJugador.Maximum)
                    Jugador.Defensa = Jugador.Defensa + cura;
            }
            else if (Jugador.Defensa==pbDefensaJugador.Maximum)
            { 
                Jugador.Vida += cura;
                if (Jugador.Vida > pbVidaJugador.Maximum)
                     Jugador.Vida = pbVidaJugador.Maximum;
            }

            pbVidaJugador.Value = Jugador.Vida;
            pbDefensaJugador.Value = Jugador.Defensa;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa} ";

            curarclick++;
            PasarTurnoAEnemigo();
            if (!(Jugador is Mago))
            {
                if (curarclick == 1)
                {
                    btnCurar.Enabled = false;
                    btnCurar.Visible = false;
                    txtLog.AppendText($" \n{Jugador.Nombre} no es un Mago y pierde la habilidad de curarse por este round.\n");
                }
            }
            else if ((Jugador is Mago))
            { 
            if (curarclick == 3)
                {
                    btnCurar.Enabled = false;
                    btnCurar.Visible = false;
                    txtLog.AppendText($" \n{Jugador.Nombre} es un Mago y pierde la habilidad de curarse por este round después de usarla 3 veces.\n");
                }
            }

                turnoActual++;
            if (turnoActual == 3)
            {
                especialAcumulada++;
                turnoActual = 0;
                label1.Text = $"Especiales acumulados: {especialAcumulada}";
            }
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            int dañoE = Enemigo.Ataque;
            if (dañoE < 0) dañoE = 0;
            if (Jugador.Defensa != 0)
            {
                if (dañoE > Jugador.Defensa)
                {
                    int dañoSobrante = dañoE - Jugador.Defensa;
                    Jugador.Defensa = 0;
                    Jugador.Vida = Jugador.Vida - dañoSobrante;
                }
                else if (dañoE < Jugador.Defensa)
                {
                    if (dañoE < 0) dañoE = 0;
                    Jugador.Defensa = Jugador.Defensa - dañoE;
                }
                else if (dañoE == Jugador.Defensa)
                {
                    Jugador.Defensa = 0;
                }
            }
            else
            {
                if (dañoE < 0) dañoE = 0;
                Jugador.Vida = Jugador.Vida - dañoE;
                if (Jugador.Vida < 0) Jugador.Vida = 0;
                txtLog.AppendText($"\n{Enemigo.Nombre} ataca a {Jugador.Nombre} e inflige {dañoE} puntos de daño.\n");
            }


            lblVidaJugador.Text = $" {Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa}";
            pbVidaJugador.Value = Jugador.Vida;
            pbDefensaJugador.Value = Jugador.Defensa;

            if (!Enemigo.EstaVivo())
            {
                PuntoJugador++;
                txtLog.AppendText($" \n{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}.\n");
                txtLog.AppendText($" \n{Jugador.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo} \n");
                AvanzarRound();
            }
            else if (!Jugador.EstaVivo())
            {
                PuntoEnemigo++;
                txtLog.AppendText($" \n{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}.\n");
                txtLog.AppendText($" \n{Enemigo.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo} \n");
                AvanzarRound();
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
                MessageBox.Show($"Fin del Juego");
                if (PuntoJugador > PuntoEnemigo)
                {
                    MessageBox.Show($"¡{Jugador.Nombre} gana el juego con {PuntoJugador} puntos a {PuntoEnemigo}!\n");
                }
                else if (PuntoEnemigo > PuntoJugador)
                {
                    MessageBox.Show($"¡{Enemigo.Nombre} gana el juego con {PuntoEnemigo} puntos a {PuntoJugador}!\n");
                }
                FinalizarJuego();
            }
            else
            {
                rondaActual++;
                Enemigo.Vida = pbVidaEnemigo.Maximum;
                Enemigo.Defensa = pbDefensaEnemigo.Maximum;
                pbDefensaEnemigo.Maximum = Enemigo.Defensa + 15;
                pbDefensaEnemigo.Value = Enemigo.Defensa + 15;
                Enemigo.Defensa = Enemigo.Defensa + 15;

                if (Enemigo.Vida > pbVidaEnemigo.Maximum) pbVidaEnemigo.Maximum = Enemigo.Vida;
                if (!Jugador.EstaVivo())
                {
                    Jugador.Vida = pbVidaJugador.Maximum;
                    Jugador.Defensa = pbDefensaJugador.Maximum;
                }
                int curaxround = 60;
                if (Jugador.Defensa != pbDefensaJugador.Maximum)
                {
                    if (Jugador.Defensa + curaxround <= pbDefensaJugador.Maximum)
                        Jugador.Defensa = Jugador.Defensa + curaxround;

                    else if (Jugador.Defensa + curaxround > pbDefensaJugador.Maximum)
                    {
                        int curasobrante = Jugador.Defensa + curaxround - pbDefensaJugador.Maximum;
                        Jugador.Defensa = pbDefensaJugador.Maximum;
                        Jugador.Vida = Jugador.Vida + curasobrante;
                    }
                    else if (Jugador.Defensa + curaxround == pbDefensaJugador.Maximum)
                        Jugador.Defensa = Jugador.Defensa + curaxround;

                }
            }


                lblRound.Text = $"Round: {rondaActual}";
                txtLog.AppendText($"--- INICIA EL ROUND {rondaActual} ---\n");

                pbVidaJugador.Value = Jugador.Vida;
                pbDefensaJugador.Value = Jugador.Defensa;
                lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} -Defensa {Jugador.Defensa}";

                pbVidaEnemigo.Value = Enemigo.Vida;
                pbDefensaEnemigo.Value = Enemigo.Defensa;
                lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa}";

                btnAtacar.Enabled = true;
                btnEspecial.Enabled = true;
                btnCurar.Enabled = true;
                btnTurnoEnemigo.Enabled = false;
                curarclick = 0;
                btnCurar.Enabled = true;
                btnCurar.Visible = true;


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
            rondaActual = 1;
            turnoActual = 0;
            especialAcumulada = 0;
            PuntoEnemigo = 0;
            PuntoJugador = 0;
            pbDefensaJugador.Value = pbDefensaJugador.Maximum;
            pbVidaJugador.Value = pbVidaJugador.Maximum;
            Jugador.Vida= pbVidaJugador.Maximum;
            Jugador.Defensa= pbDefensaJugador.Maximum;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} -Defensa {Jugador.Defensa}";
        }
















        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void pbVidaJugador_Click(object sender, EventArgs e)
        {

        }

        private void lblVidaJugador_Click(object sender, EventArgs e)
        {

        }

        private void pbEnemigo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalizarJuego();
            MessageBox.Show("Has abandonado el juego. ¡Gracias por jugar!");
        }
    }
}