namespace JuegoPOO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCrear = new Button();
            btnAtacar = new Button();
            btnEspecial = new Button();
            lblJugador = new Label();
            lblVidaJugador = new Label();
            lblVidaEnemigo = new Label();
            cmbPersonaje = new ComboBox();
            pbVidaJugador = new ProgressBar();
            pbVidaEnemigo = new ProgressBar();
            txtLog = new TextBox();
            btnTurnoEnemigo = new Button();
            pbJugador = new PictureBox();
            pbEnemigo = new PictureBox();
            btnCurar = new Button();
            lblroundescription = new Label();
            lblRound = new Label();
            ((System.ComponentModel.ISupportInitialize)pbJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEnemigo).BeginInit();
            SuspendLayout();
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(650, 537);
            btnCrear.Margin = new Padding(3, 4, 3, 4);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(110, 31);
            btnCrear.TabIndex = 0;
            btnCrear.Text = "Iniciar Partida";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnAtacar
            // 
            btnAtacar.Location = new Point(55, 651);
            btnAtacar.Margin = new Padding(3, 4, 3, 4);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(86, 31);
            btnAtacar.TabIndex = 1;
            btnAtacar.Text = "Atacar";
            btnAtacar.UseVisualStyleBackColor = true;
            btnAtacar.Click += btnAtacar_Click;
            // 
            // btnEspecial
            // 
            btnEspecial.Location = new Point(172, 651);
            btnEspecial.Margin = new Padding(3, 4, 3, 4);
            btnEspecial.Name = "btnEspecial";
            btnEspecial.Size = new Size(143, 31);
            btnEspecial.TabIndex = 2;
            btnEspecial.Text = "Ataque Especial";
            btnEspecial.UseVisualStyleBackColor = true;
            btnEspecial.Click += btnEspecial_Click;
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Location = new Point(55, 60);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(62, 20);
            lblJugador.TabIndex = 3;
            lblJugador.Text = "Jugador";
            // 
            // lblVidaJugador
            // 
            lblVidaJugador.AutoSize = true;
            lblVidaJugador.Location = new Point(55, 93);
            lblVidaJugador.Name = "lblVidaJugador";
            lblVidaJugador.Size = new Size(109, 20);
            lblVidaJugador.TabIndex = 4;
            lblVidaJugador.Text = "lblVidaJugador";
            // 
            // lblVidaEnemigo
            // 
            lblVidaEnemigo.AutoSize = true;
            lblVidaEnemigo.Location = new Point(688, 93);
            lblVidaEnemigo.Name = "lblVidaEnemigo";
            lblVidaEnemigo.Size = new Size(115, 20);
            lblVidaEnemigo.TabIndex = 5;
            lblVidaEnemigo.Text = "lblVidaEnemigo";
            // 
            // cmbPersonaje
            // 
            cmbPersonaje.FormattingEnabled = true;
            cmbPersonaje.Location = new Point(650, 600);
            cmbPersonaje.Margin = new Padding(3, 4, 3, 4);
            cmbPersonaje.Name = "cmbPersonaje";
            cmbPersonaje.Size = new Size(138, 28);
            cmbPersonaje.TabIndex = 6;
            // 
            // pbVidaJugador
            // 
            pbVidaJugador.Location = new Point(55, 117);
            pbVidaJugador.Margin = new Padding(3, 4, 3, 4);
            pbVidaJugador.Name = "pbVidaJugador";
            pbVidaJugador.Size = new Size(114, 31);
            pbVidaJugador.TabIndex = 7;
            // 
            // pbVidaEnemigo
            // 
            pbVidaEnemigo.Location = new Point(688, 117);
            pbVidaEnemigo.Margin = new Padding(3, 4, 3, 4);
            pbVidaEnemigo.Name = "pbVidaEnemigo";
            pbVidaEnemigo.Size = new Size(114, 31);
            pbVidaEnemigo.TabIndex = 8;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(55, 528);
            txtLog.Margin = new Padding(3, 4, 3, 4);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(569, 100);
            txtLog.TabIndex = 9;
            // 
            // btnTurnoEnemigo
            // 
            btnTurnoEnemigo.Enabled = false;
            btnTurnoEnemigo.Location = new Point(481, 651);
            btnTurnoEnemigo.Margin = new Padding(3, 4, 3, 4);
            btnTurnoEnemigo.Name = "btnTurnoEnemigo";
            btnTurnoEnemigo.Size = new Size(143, 31);
            btnTurnoEnemigo.TabIndex = 10;
            btnTurnoEnemigo.Text = "Turno del Enemigo";
            btnTurnoEnemigo.UseVisualStyleBackColor = true;
            btnTurnoEnemigo.Click += btnTurno_Click;
            // 
            // pbJugador
            // 
            pbJugador.BackgroundImageLayout = ImageLayout.Stretch;
            pbJugador.Location = new Point(55, 229);
            pbJugador.Margin = new Padding(3, 4, 3, 4);
            pbJugador.Name = "pbJugador";
            pbJugador.Size = new Size(203, 219);
            pbJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbJugador.TabIndex = 11;
            pbJugador.TabStop = false;
            // 
            // pbEnemigo
            // 
            pbEnemigo.BackgroundImageLayout = ImageLayout.Center;
            pbEnemigo.Location = new Point(599, 229);
            pbEnemigo.Margin = new Padding(3, 4, 3, 4);
            pbEnemigo.Name = "pbEnemigo";
            pbEnemigo.Size = new Size(203, 219);
            pbEnemigo.SizeMode = PictureBoxSizeMode.Zoom;
            pbEnemigo.TabIndex = 12;
            pbEnemigo.TabStop = false;
            // 
            // btnCurar
            // 
            btnCurar.Location = new Point(354, 653);
            btnCurar.Name = "btnCurar";
            btnCurar.Size = new Size(94, 29);
            btnCurar.TabIndex = 13;
            btnCurar.Text = "Curar";
            btnCurar.UseVisualStyleBackColor = true;
            btnCurar.Click += btnCurar_Click;
            // 
            // lblroundescription
            // 
            lblroundescription.AutoSize = true;
            lblroundescription.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblroundescription.ForeColor = Color.Red;
            lblroundescription.Location = new Point(354, 60);
            lblroundescription.Name = "lblroundescription";
            lblroundescription.Size = new Size(144, 37);
            lblroundescription.TabIndex = 14;
            lblroundescription.Text = "Rounds";
            // 
            // lblRound
            // 
            lblRound.AutoSize = true;
            lblRound.Location = new Point(398, 97);
            lblRound.Name = "lblRound";
            lblRound.Size = new Size(0, 20);
            lblRound.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            BackgroundImage = Properties.Resources.castillo1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 739);
            Controls.Add(lblRound);
            Controls.Add(lblroundescription);
            Controls.Add(btnCurar);
            Controls.Add(pbEnemigo);
            Controls.Add(pbJugador);
            Controls.Add(btnTurnoEnemigo);
            Controls.Add(txtLog);
            Controls.Add(pbVidaEnemigo);
            Controls.Add(pbVidaJugador);
            Controls.Add(cmbPersonaje);
            Controls.Add(lblVidaEnemigo);
            Controls.Add(lblVidaJugador);
            Controls.Add(lblJugador);
            Controls.Add(btnEspecial);
            Controls.Add(btnAtacar);
            Controls.Add(btnCrear);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbJugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEnemigo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCrear;
        private Button btnAtacar;
        private Button btnEspecial;
        private Label lblJugador;
        private Label lblVidaJugador;
        private Label lblVidaEnemigo;
        private ComboBox cmbPersonaje;
        private ProgressBar pbVidaJugador;
        private ProgressBar pbVidaEnemigo;
        private TextBox txtLog;
        private Button btnTurnoEnemigo;
        private PictureBox pbJugador;
        private PictureBox pbEnemigo;
        private Button btnCurar;
        private Label lblroundescription;
        private Label lblRound;
    }
}
