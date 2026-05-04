namespace JuegoPOO
{
    public partial class Form1 : Form
    {
        Personaje Player;
        Personaje Enemigo;
        ControlarPartida controlarPartida = new ControlarPartida();

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
                    Player = new Guerrero("koku", CONSTANTES.ATAQUEGUERRERO, CONSTANTES.VIDAMAXGUERRERO, CONSTANTES.DEFENSAMAXAGUERRERO);
                    controlarPartida.Jugador = Player;
                    Player.CambiarEstadisticas += ActualizarPantalla;
                    txtLog.Clear();
                    txtLog.AppendText($"{Player.Nombre} - Vida: {Player.Vida} -Ataque {Player.Ataque} - Defensa: {Player.Defensa} ");
                    break;
                case "Arquero":
                    pbJugador.Image = Properties.Resources.arquero;
                    Player = new Arquero("jokai", CONSTANTES.ATAQUEARQUERO, CONSTANTES.VIDAMAXARQUERO, CONSTANTES.DEFENSAMAXARQUERO);
                    controlarPartida.Jugador = Player;
                    Player.CambiarEstadisticas += ActualizarPantalla;
                    txtLog.Clear();
                    txtLog.AppendText($"{Player.Nombre} - Vida: {Player.Vida}  -Ataque {Player.Ataque} - Defensa: {Player.Defensa} ");
                    break;
                case "Mago":
                    pbJugador.Image = Properties.Resources.Magito;
                    Player = new Mago("grifindor", CONSTANTES.ATAQUEMAGO, CONSTANTES.VIDAMAXMAGO, CONSTANTES.DEFENSAMAXMAGO);
                    controlarPartida.Jugador = Player;
                    txtLog.Clear();
                    Player.CambiarEstadisticas += ActualizarPantalla;

                    txtLog.AppendText($" {Player.Nombre} - Vida: {Player.Vida}  -Ataque {Player.Ataque} - Defensa: {Player.Defensa} ");
                    txtLog.AppendText($"\nEl Mago tiene la habilidad de curarse, pero solo puede usarla 3 veces por round.\n");
                    break;
                default:
                    txtLog.AppendText("Personaje no válido.");
                    return;

            }
            pbVidaJugador.Maximum = Math.Max(1, Player.Vida);
            pbDefensaJugador.Maximum = Math.Max(1, Player.Defensa);
            pbVidaJugador.Value = pbVidaJugador.Maximum;
            pbDefensaJugador.Value = pbDefensaJugador.Maximum;
        }




        private void btnCrear_Click(object sender, EventArgs e)
        {
            btnCurar.Visible = true;
            cmbPersonaje.Enabled = false;
            if (string.IsNullOrEmpty(cmbPersonaje.Text))
            {
                txtLog.AppendText("Por favor, selecciona un personaje.");
                return;
            }

            pbEnemigo.Image = Properties.Resources.chuerk_png;
            Enemigo = new Enemigo("chuerk", CONSTANTES.ATAQUEENEMIGO, CONSTANTES.VIDAMAXENEMIGO, CONSTANTES.DEFENSAMAXENEMIGO);
            txtLog.AppendText($"Has creado a {Player.Nombre} y te enfrentarás a {Enemigo.Nombre}.");
            Enemigo.CambiarEstadisticas += ActualizarPantalla;
            controlarPartida.enemigo = (Enemigo)Enemigo;
            pbVidaEnemigo.Maximum = Math.Max(1, Enemigo.VidaMaxima);
            pbDefensaEnemigo.Maximum = Math.Max(1, Enemigo.DefensaMaxima);
            pbDefensaEnemigo.Value = Enemigo.Defensa;
            pbVidaEnemigo.Value = Enemigo.Vida;

            txtLog.Clear();
            ActivarTurnoJugador();

            txtLog.AppendText($"--- INICIA EL ROUND {controlarPartida.rondaActual} ---.");
            label1.Text = $"Especiales Acumuladas {controlarPartida.especialAcumulada}";
            lblRound.Text = $"Round: {controlarPartida.rondaActual}";
            label1.Text = $"Especiales Acumuladas {controlarPartida.especialAcumulada}";
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            Player.Atacar(Player.Ataque, Enemigo);
            txtLog.AppendText($"{Player.Nombre} ataca a {Enemigo.Nombre} y le inflige {Player.Ataque}.\r\n");
            controlarPartida.AvanzarTurno();
            string mensajeAtrapado;
            if (!Player.EstaVivo())
            {
                controlarPartida.SumarPuntos();
                txtLog.AppendText($"{Player.Nombre} ha sido derrotado por {Enemigo.Nombre}.\r\n");
                txtLog.AppendText($"{Enemigo.Nombre} obtiene un punto. Puntuación: {Player.Nombre} {controlarPartida.PuntoJugador} - {Enemigo.Nombre} {controlarPartida.PuntoEnemigo}");
                mensajeAtrapado = controlarPartida.AvanzarRound();
                if (mensajeAtrapado != "")
                {
                    txtLog.AppendText($"Juego Acabado\r\n {mensajeAtrapado}");
                    inhabilitarbotones();
                }
            }
            else if (!Enemigo.EstaVivo())
            {
                btnCurar.Visible = true;
                controlarPartida.SumarPuntos();
                txtLog.AppendText($"{Enemigo.Nombre} ha sido derrotado por {Player.Nombre}.\r\n");
                txtLog.AppendText($"{Player.Nombre} obtiene un punto. Puntuación: {Player.Nombre} {controlarPartida.PuntoJugador} - {Enemigo.Nombre} {controlarPartida.PuntoEnemigo}");
                mensajeAtrapado = controlarPartida.AvanzarRound();
                if (mensajeAtrapado != "")
                {
                    txtLog.AppendText($"Juego Acabado\r\n {mensajeAtrapado}");
                    inhabilitarbotones();
                }
            }
            else
            {
                ActivarTurnoEnemigo();
            }
            label1.Text = $"Especiales Acumuladas {controlarPartida.especialAcumulada}";
        }

        private async void btnEspecial_Click(object sender, EventArgs e)
        {
            if (controlarPartida.especialAcumulada > 0)
            {
                BloquearTodo();
                Image imagenOriginal = pbJugador.Image;

                if (Player is Guerrero)
                {
                    pbJugador.Image = Properties.Resources.gokuespecial;
                    await Task.Delay(1900); 
                }

                pbJugador.Image = imagenOriginal;
                controlarPartida.AvanzarTurno();
                txtLog.Clear();
                controlarPartida.EspecialUsada();
                Player.Atacar(Player.Ataque * 2, Enemigo);
                txtLog.AppendText($"{Player.Nombre} utiliza un ataque especial y le inflige {Player.Ataque * 2} puntos de daño a {Enemigo.Nombre}.\r\n");
                string mensajeAtrapado;

                if (!Player.EstaVivo())
                {
                    controlarPartida.SumarPuntos();
                    txtLog.AppendText($"{Player.Nombre} ha sido derrotado por {Enemigo.Nombre}.\r\n");
                    txtLog.AppendText($"{Enemigo.Nombre} obtiene un punto. Puntuación: {Player.Nombre} {controlarPartida.PuntoJugador} - {Enemigo.Nombre} {controlarPartida.PuntoEnemigo}\r\n");
                    mensajeAtrapado = controlarPartida.AvanzarRound();
                    if (mensajeAtrapado != "")
                    {
                        txtLog.AppendText($"Juego Acabado\r\n {mensajeAtrapado}");
                        inhabilitarbotones();
                    }
                    else ActivarTurnoJugador();
                }
                else if (!Enemigo.EstaVivo())
                {
                    btnCurar.Visible = true;
                    controlarPartida.SumarPuntos();
                    txtLog.AppendText($"{Enemigo.Nombre} ha sido derrotado por {Player.Nombre}.\r\n");
                    txtLog.AppendText($"{Player.Nombre} obtiene un punto. Puntuación: {Player.Nombre} {controlarPartida.PuntoJugador} - {Enemigo.Nombre} {controlarPartida.PuntoEnemigo}\r\n");
                    mensajeAtrapado = controlarPartida.AvanzarRound();
                    if (mensajeAtrapado != "")
                    {
                        txtLog.AppendText($"Juego Acabado\r\n {mensajeAtrapado}");
                        inhabilitarbotones();
                    }
                    else ActivarTurnoEnemigo();

                }
                else
                {
                    ActivarTurnoEnemigo();
                }

            }
            else
            {
                label1.Text = $"Especiales acumulados: {controlarPartida.especialAcumulada}";
                txtLog.AppendText("No tienes ataques especiales acumulados. Realiza más ataques normales para acumularlos.");
            }
            label1.Text = $"Especiales Acumuladas {controlarPartida.especialAcumulada}";
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            Player.CurarVida(CONSTANTES.CURACION);
            Player.CuracionesUsadas++;
            controlarPartida.AvanzarTurno();

            if (!(Player is Mago))
            {
                if(Player.CuracionesUsadas == 1)
        {
                    btnCurar.Visible = false; 
                    txtLog.AppendText($"{Player.Nombre} no es un Mago y ya usó su única curación por este round.\r\n");
                }
            }

            else
            {
                if (Player.CuracionesUsadas == 2)
                {
                    btnCurar.Visible = false;
                    txtLog.AppendText($"{Player.Nombre} es un Mago y ha agotado sus 2 curaciones por este round.\r\n");
                }
            }
            ActivarTurnoEnemigo();
            label1.Text = $"Especiales Acumuladas {controlarPartida.especialAcumulada}";
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {

            txtLog.Clear();

            Enemigo.Atacar(Enemigo.Ataque, Player);
            txtLog.AppendText($"{Enemigo.Nombre} ataca a {Player.Nombre} y le inflige {Enemigo.Ataque} puntos de daño.");
            string mensajeAtrapado;

            if (!Enemigo.EstaVivo())
            {
                controlarPartida.SumarPuntos();
                txtLog.AppendText($"{Enemigo.Nombre} ha sido derrotado por {Player.Nombre}.");
                txtLog.AppendText($"{Player.Nombre} obtiene un punto. Puntuación: {Player.Nombre} {controlarPartida.PuntoJugador} - {Enemigo.Nombre} {controlarPartida.PuntoEnemigo}");
                mensajeAtrapado = controlarPartida.AvanzarRound();
                if (mensajeAtrapado != "")
                {
                    txtLog.AppendText($"Juego Acabado\r\n {mensajeAtrapado}");
                    inhabilitarbotones();
                }
            }
            else if (!Player.EstaVivo())
            {

                controlarPartida.SumarPuntos();
                txtLog.AppendText($"{Player.Nombre} ha sido derrotado por {Enemigo.Nombre}.\r\n");
                txtLog.AppendText($"{Enemigo.Nombre} obtiene un punto. Puntuación: {Player.Nombre} {controlarPartida.PuntoJugador} - {Enemigo.Nombre} {controlarPartida.PuntoEnemigo}\r\n");
                mensajeAtrapado = controlarPartida.AvanzarRound();
                if (mensajeAtrapado != "")
                {
                    txtLog.AppendText($"Juego Acabado");
                    inhabilitarbotones();
                }
            }
            else
            {
                ActivarTurnoJugador();
            }
        }

        private void BloquearTodo()
        {
            // Apaga TODO para que el usuario no pueda interferir
            btnAtacar.Enabled = false;
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = false;
            btnCrear.Enabled = false;
            btnAbandonar.Enabled = false;

            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnTurnoEnemigo);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
        }

        private void ActivarTurnoJugador()
        {
            // Solo prende los controles del Jugador
            btnAtacar.Enabled = true;
            btnEspecial.Enabled = true;
            btnCurar.Enabled = true;
            btnTurnoEnemigo.Enabled = false;

            btnCrear.Enabled = false;
            btnAbandonar.Enabled = true;

            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnTurnoEnemigo);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
        }

        private void ActivarTurnoEnemigo()
        {
            // Solo prende los controles del Enemigo
            btnAtacar.Enabled = false;
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = true;

            btnCrear.Enabled = false;
            btnAbandonar.Enabled = true;

            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnTurnoEnemigo);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
        }
        private void ActualizarPantalla()
        {
            pbVidaJugador.Maximum = Player.VidaMaxima;
            pbVidaJugador.Value = Player.Vida;
            pbDefensaJugador.Maximum = Player.DefensaMaxima;
            pbDefensaJugador.Value = Player.Defensa;
            lblVidaJugador.Text = $"{Player.Nombre} - Vida: {Player.Vida} - Defensa: {Player.Defensa}";

            pbVidaEnemigo.Maximum = Enemigo.VidaMaxima;
            pbVidaEnemigo.Value = Enemigo.Vida;
            pbDefensaEnemigo.Maximum = Enemigo.DefensaMaxima;
            pbDefensaEnemigo.Value = Enemigo.Defensa;
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida} - Defensa: {Enemigo.Defensa}";

            lblRound.Text = $"Round: {controlarPartida.rondaActual}";

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

        private void inhabilitarbotones()
        {
            btnAtacar.Enabled = false;
            btnEspecial.Enabled = false;
            btnCurar.Enabled = false;
            btnTurnoEnemigo.Enabled = false;
            btnCrear.Enabled = false;
            btnAbandonar.Enabled = false;
            btnCrear.Enabled = !btnCrear.Enabled;
            ActualizarColorBoton(btnAtacar);
            ActualizarColorBoton(btnEspecial);
            ActualizarColorBoton(btnCurar);
            ActualizarColorBoton(btnTurnoEnemigo);
            ActualizarColorBoton(btnCrear);
            ActualizarColorBoton(btnAbandonar);
        }
        private void btnAbandonar_Click(object sender, EventArgs e)
        {
            cmbPersonaje.Enabled = true;
            controlarPartida.FinalizarJuego();
            inhabilitarbotones();
            txtLog.AppendText("Has abandonado el juego. ¡Gracias por jugar!");
        }
    }
}

    