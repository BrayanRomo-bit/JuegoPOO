namespace JuegoPOO
{
    public partial class Form1 : Form
    {
        Personaje Jugador;
        Personaje Enemigo;
        int rondaActual = 1;
        int turnoActual = 0;
        int especialAcumulada = 5;
        int curarclick = 0;
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
            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
            ActualizarColorBoton(btnTurnoEnemigo);

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
                    pbJugador.Image = Properties.Resources.goku;
                    Jugador = new Guerrero("koku", 150, 25, 50);
                    txtLog.Clear();
                    txtLog.AppendText($"{Jugador.Nombre} - Vida: {Jugador.Vida} -Ataque {Jugador.Ataque} - Defensa: {Jugador.Defensa} ");
                    break;
                case "Arquero":
                    pbJugador.Image = Properties.Resources.arquero;
                    Jugador = new Arquero("jokai", 100, 40, 30);
                    txtLog.Clear();
                    txtLog.AppendText($"{Jugador.Nombre} - Vida: {Jugador.Vida}  -Ataque {Jugador.Ataque} - Defensa: {Jugador.Defensa} ");
                    break;
                case "Mago":
                    pbJugador.Image = Properties.Resources.Magito;
                    Jugador = new Mago("grifindor", 70, 20, 50);
                    txtLog.Clear();
                    txtLog.AppendText($" {Jugador.Nombre} - Vida: {Jugador.Vida}  -Ataque {Jugador.Ataque} - Defensa: {Jugador.Defensa} ");
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

            pbEnemigo.Image = Properties.Resources.chuerk_png;
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

            PasarTurno();
            btnTurnoEnemigo.Enabled = !btnTurnoEnemigo.Enabled;
            btnCrear.Enabled = !btnCrear.Enabled;
            btnAbandonar.Enabled = !btnAbandonar.Enabled;
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
            ActualizarColorBoton(btnTurnoEnemigo);
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            AplicarDaño(Jugador.Ataque, Enemigo, pbVidaEnemigo, pbDefensaEnemigo);
            txtLog.AppendText($"{Jugador.Nombre} ataca a {Enemigo.Nombre} y le inflige {Jugador.Ataque}.\r\n");

            if (!Jugador.EstaVivo())
            {
                PuntoEnemigo++;
                txtLog.AppendText($"{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}.\r\n");
                txtLog.AppendText($"{Enemigo.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo}");
                AvanzarRound();
            }
            else if (!Enemigo.EstaVivo())
            {
                PuntoJugador++;
                txtLog.AppendText($"{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}.\r\n");
                txtLog.AppendText($"{Jugador.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo}");
                AvanzarRound();
            }
            else
            {
                PasarTurno();
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


                AplicarDaño(Jugador.Ataque * 6, Enemigo, pbVidaEnemigo, pbDefensaEnemigo);
                txtLog.AppendText($"{Jugador.Nombre} utiliza un ataque especial y le inflige {Jugador.Ataque * 2} puntos de daño a {Enemigo.Nombre}.\r\n");

                if (!Jugador.EstaVivo())
                {
                    PuntoEnemigo++;
                    txtLog.AppendText($"{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}.\r\n");
                    txtLog.AppendText($"{Enemigo.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo}\r\n");
                    AvanzarRound();
                }
                else if (!Enemigo.EstaVivo())
                {
                    PuntoJugador++;
                    txtLog.AppendText($"{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}.\r\n");
                    txtLog.AppendText($"{Jugador.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo}\r\n");
                    AvanzarRound();
                }
                else
                {
                    PasarTurno();
                }

                especialAcumulada--;
                label1.Text = $"Especiales acumulados: {especialAcumulada}";
            }
            else
            {
                label1.Text = $"Especiales acumulados: {especialAcumulada}";
                MessageBox.Show("No tienes ataques especiales acumulados. Realiza más ataques normales para acumularlos.");
            }
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            if (Jugador.Defensa==pbDefensaJugador.Maximum && Jugador.Vida==pbVidaJugador.Maximum)
                {
                txtLog.AppendText($"{Jugador.Nombre} ya tiene la defensa al máximo y no puede curarse.");
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
            else if (Jugador.Defensa == pbDefensaJugador.Maximum)
            {
                Jugador.Vida += cura;
                if (Jugador.Vida > pbVidaJugador.Maximum)
                    Jugador.Vida = pbVidaJugador.Maximum;
            }

            pbVidaJugador.Value = Jugador.Vida;
            pbDefensaJugador.Value = Jugador.Defensa;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa} ";

            curarclick++;
            if (!(Jugador is Mago))
            {
                if (curarclick == 1)
                {
                    btnCurar.Enabled = !btnCurar.Enabled;
                    btnCurar.Visible = !btnCurar.Visible;
                    txtLog.AppendText($"{Jugador.Nombre} no es un Mago y pierde la habilidad de curarse por este round.");
                }
            }

            else if ((Jugador is Mago))
            {
                if (curarclick == 3)
                {
                    btnCurar.Enabled = !btnCurar.Enabled;
                    btnCurar.Visible = !btnCurar.Visible;
                    txtLog.AppendText($"{Jugador.Nombre} es un Mago y pierde la habilidad de curarse por este round después de usarla 3 veces.\r\n");
                }
            }

            PasarTurno();
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {

            txtLog.Clear();

            AplicarDaño(Enemigo.Ataque, Jugador, pbVidaJugador, pbDefensaJugador);
            txtLog.AppendText($"{Enemigo.Nombre} ataca a {Jugador.Nombre} y le inflige {Enemigo.Ataque} puntos de daño.");

            if (!Enemigo.EstaVivo())
            {
                PuntoJugador++;
                txtLog.AppendText($"{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}.");
                txtLog.AppendText($"{Jugador.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo}");
                AvanzarRound();
            }
            else if (!Jugador.EstaVivo())
            {
                PuntoEnemigo++;
                txtLog.AppendText($"{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}.\r\n");
                txtLog.AppendText($"{Enemigo.Nombre} obtiene un punto. Puntuación: {Jugador.Nombre} {PuntoJugador} - {Enemigo.Nombre} {PuntoEnemigo}\r\n");
                AvanzarRound();
            }
            else
            {
                PasarTurno();
            }
        }
        private void AvanzarRound()
        {
            if (rondaActual >= 3)
            {
                MessageBox.Show($"Fin del Juego");
                if (PuntoJugador > PuntoEnemigo)
                {
                    MessageBox.Show($"¡{Jugador.Nombre} gana el juego con {PuntoJugador} puntos a {PuntoEnemigo}!");
                }
                else if (PuntoEnemigo > PuntoJugador)
                {
                    MessageBox.Show($"¡{Enemigo.Nombre} gana el juego con {PuntoEnemigo} puntos a {PuntoJugador}!");
                }
                FinalizarJuego();
            }
            else
            {
                rondaActual++;
                pbDefensaEnemigo.Maximum = pbDefensaEnemigo.Maximum + 15;
                pbVidaEnemigo.Maximum = pbVidaEnemigo.Maximum + 15;
                Enemigo.Vida = pbVidaEnemigo.Maximum;
                Enemigo.Defensa = pbDefensaEnemigo.Maximum;
                int curaxround = 60;

                if (!Jugador.EstaVivo())
                {
                    Jugador.Vida = pbVidaJugador.Maximum;
                    Jugador.Defensa = pbDefensaJugador.Maximum;
                }
                else if (Jugador.Defensa != pbDefensaJugador.Maximum)
                {
                    if (Jugador.Defensa + curaxround <= pbDefensaJugador.Maximum)
                        Jugador.Defensa = Jugador.Defensa + curaxround;

                    else if (Jugador.Defensa + curaxround > pbDefensaJugador.Maximum)
                    {
                        int curasobrante = Jugador.Defensa + curaxround - pbDefensaJugador.Maximum;
                        Jugador.Defensa = pbDefensaJugador.Maximum;
                        Jugador.Vida = Jugador.Vida + curasobrante;
                        if (Jugador.Vida > pbVidaJugador.Maximum) Jugador.Vida = pbVidaJugador.Maximum;
                    }
                    else if (Jugador.Defensa + curaxround == pbDefensaJugador.Maximum)
                        Jugador.Defensa = Jugador.Defensa + curaxround;
                }

                curarclick = 0;
                btnCurar.Enabled = true;
                btnCurar.Visible = true;
                ActualizarColorBoton(btnCurar);
            }


            lblRound.Text = $"Round: {rondaActual}";
            txtLog.AppendText($"--- INICIA EL ROUND {rondaActual} ---.");

            pbVidaJugador.Value = Jugador.Vida;
            pbDefensaJugador.Value = Jugador.Defensa;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} -Defensa {Jugador.Defensa}";

            pbVidaEnemigo.Value = Enemigo.Vida;
            pbDefensaEnemigo.Value = Enemigo.Defensa;
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa}";

        }

        private void PasarTurno()
        {
            btnAtacar.Enabled = !btnAtacar.Enabled;
            btnEspecial.Enabled = !btnEspecial.Enabled;
            btnCurar.Enabled = !btnCurar.Enabled;
            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
            btnTurnoEnemigo.Enabled = !btnTurnoEnemigo.Enabled;
            ActualizarColorBoton(btnTurnoEnemigo);
        }
        private void FinalizarJuego()
        {
            btnAtacar.Enabled = false;
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = false;
            btnCrear.Enabled = false;
            btnAbandonar.Enabled =false;
            btnCrear.Enabled = !btnCrear.Enabled;
            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnTurnoEnemigo);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
            rondaActual = 1;
            turnoActual = 0;
            especialAcumulada = 0;
            PuntoEnemigo = 0;
            PuntoJugador = 0;
            int curarclick = 0;
            pbDefensaJugador.Value = pbDefensaJugador.Maximum;
            pbVidaJugador.Value = pbVidaJugador.Maximum;
            Jugador.Vida = pbVidaJugador.Maximum;
            Jugador.Defensa = pbDefensaJugador.Maximum;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} -Defensa {Jugador.Defensa}";
        }
        private void ActualizarColorBoton(Button btn)
        {
            if (!btn.Enabled)
            {
                btn.BackColor = Color.Gray;
            }
            else
            {
                btn.BackColor = Color.White;
            }

        }

        private void AplicarDaño(int daño, Personaje objetivo, ProgressBar pbVidaObjetivo, ProgressBar pbDefensaObjetivo)
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
            pbVidaObjetivo.Value = objetivo.Vida;
            pbDefensaObjetivo.Value = objetivo.Defensa;
            if (objetivo == Jugador)
            {
                lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida} - Defensa: {Jugador.Defensa} ";
            }
            else if (objetivo == Enemigo)
            {
                lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa} ";
            }
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

        private void btnAbandonar_Click(object sender, EventArgs e)
        {
            FinalizarJuego();
            MessageBox.Show("Has abandonado el juego. ¡Gracias por jugar!");
        }
    }
}