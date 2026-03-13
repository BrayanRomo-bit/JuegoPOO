namespace JuegoPOO
{
    public partial class Form1 : Form
    {
        // Cambiar el tipo de lblDescripcion de object a Label
        private Label lblDescripcion;
        Personaje Jugador;
        Personaje Enemigo;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            cmbPersonaje.Items.AddRange(new string[] { "Guerrero", "Arquero", "Mago" });
            cmbPersonaje.SelectedIndex = 0; // Selecciona un valor por defecto  
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

        private void label3_Click(object sender, EventArgs e)
        {

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
                    // cargar la picturebox gerrero

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
            Enemigo = new Guerrero("chuerk", 100, 25, 40);
            MessageBox.Show($"Has creado a {Jugador.Nombre} y te enfrentarás a {Enemigo.Nombre}.");

            pbVidaJugador.Maximum = Math.Max(Jugador.Vida, Enemigo.Vida);
            pbVidaEnemigo.Maximum = Math.Max(Jugador.Vida, Enemigo.Vida);
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida}";
            pbVidaEnemigo.Value = Enemigo.Vida;
            pbVidaJugador.Value = Jugador.Vida;

            btnAtacar.Enabled = true;
            btnEspecial.Enabled = true;
            if (Jugador.EstaVivo() || Enemigo.EstaVivo())
            { btnCrear.Enabled = false; }
            else if (!Jugador.EstaVivo() || !Enemigo.EstaVivo())
            { btnCrear.Enabled = true; }

        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            int dañoJugador = Jugador.Ataque;

            if (dañoJugador < 0)
            {
                dañoJugador = 0;
            }

            Enemigo.Vida = Enemigo.Vida - dañoJugador;
            if (Enemigo.Vida < 0) Enemigo.Vida = 0;

            txtLog.AppendText($"\n {Jugador.Nombre} ataca a {Enemigo.Nombre} e inflige {dañoJugador} puntos de daño.\n");


            if (!Jugador.EstaVivo())
            {
                MessageBox.Show($"\n {Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}. ¡Fin del juego!");
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = false;
            }
            else if (!Enemigo.EstaVivo())
            {
                MessageBox.Show($"\n {Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}. ¡Has ganado!");
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = false;
            }
            else
            {
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = true;
            }
            if (!Jugador.EstaVivo() || !Enemigo.EstaVivo())
            { btnCrear.Enabled = true; }
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";
            pbVidaEnemigo.Value = Enemigo.Vida;



        }

        private void btnEspecial_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            int dañoEspecial = Jugador.Ataque * 2;
            Enemigo.Vida = Enemigo.Vida - dañoEspecial;

            if (!Enemigo.EstaVivo()) Enemigo.Vida = 0;


            txtLog.AppendText($"\n{Jugador.Nombre} ataca a {Enemigo.Nombre} e inflige {dañoEspecial} puntos de daño.\n");

            if (!Jugador.EstaVivo())
            {
                MessageBox.Show($"\n{Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}. ¡Fin del juego!");
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = false;
            }
            else if (!Enemigo.EstaVivo())
            {
                MessageBox.Show($"\n{Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}. ¡Has ganado!");
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = false;
            }
            else
            {
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = true;
            }
            if (!Jugador.EstaVivo() || !Enemigo.EstaVivo())
            { btnCrear.Enabled = true; }
            pbVidaEnemigo.Value = Enemigo.Vida;
            lblVidaEnemigo.Text = $"{Enemigo.Nombre} - Vida: {Enemigo.Vida}";

        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            if (Enemigo.EstaVivo())
            {
                int dañoEnemigo = Enemigo.Ataque;
                if (dañoEnemigo < 0) dañoEnemigo = 0;

                Jugador.Vida = Jugador.Vida - dañoEnemigo;
                txtLog.AppendText($"\n {Enemigo.Nombre} ataca a {Jugador.Nombre} e inflige {dañoEnemigo} puntos de daño.\n");


                if (!Jugador.EstaVivo()) Jugador.Vida = 0;
            }

            if (!Jugador.EstaVivo())
            {
                MessageBox.Show($"\n {Jugador.Nombre} ha sido derrotado por {Enemigo.Nombre}. ¡Fin del juego!");
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = false;
            }
            else if (!Enemigo.EstaVivo())
            {
                MessageBox.Show($"\n {Enemigo.Nombre} ha sido derrotado por {Jugador.Nombre}. ¡Has ganado!");
                btnAtacar.Enabled = false;
                btnEspecial.Enabled = false;
                btnTurnoEnemigo.Enabled = false;
            }
            else
            {
                btnAtacar.Enabled = true;
                btnEspecial.Enabled = true;
                btnTurnoEnemigo.Enabled = false;
            }

            if (!Jugador.EstaVivo() || !Enemigo.EstaVivo())
            { btnCrear.Enabled = true; }
            pbVidaJugador.Value = Jugador.Vida;
            lblVidaJugador.Text = $"{Jugador.Nombre} - Vida: {Jugador.Vida}";

        }

        private void pbJugador_Click(object sender, EventArgs e)
        {

        }
    }
}

