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
            pbDefensaEnemigo = new ProgressBar();
            pbDefensaJugador = new ProgressBar();
            label1 = new Label();
            btnAbandonar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEnemigo).BeginInit();
            SuspendLayout();
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(569, 380);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(121, 23);
            btnCrear.TabIndex = 0;
            btnCrear.Text = "Iniciar Partida";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnAtacar
            // 
            btnAtacar.Location = new Point(48, 488);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(75, 23);
            btnAtacar.TabIndex = 1;
            btnAtacar.Text = "Atacar";
            btnAtacar.UseVisualStyleBackColor = true;
            btnAtacar.Click += btnAtacar_Click;
            // 
            // btnEspecial
            // 
            btnEspecial.Location = new Point(150, 488);
            btnEspecial.Name = "btnEspecial";
            btnEspecial.Size = new Size(125, 23);
            btnEspecial.TabIndex = 2;
            btnEspecial.Text = "Ataque Especial";
            btnEspecial.UseVisualStyleBackColor = true;
            btnEspecial.Click += btnEspecial_Click;
            // 
            // lblVidaJugador
            // 
            lblVidaJugador.AutoSize = true;
            lblVidaJugador.ForeColor = Color.Yellow;
            lblVidaJugador.Location = new Point(48, 70);
            lblVidaJugador.Name = "lblVidaJugador";
            lblVidaJugador.Size = new Size(85, 15);
            lblVidaJugador.TabIndex = 4;
            lblVidaJugador.Text = "lblVidaJugador";
            lblVidaJugador.Click += lblVidaJugador_Click;
            // 
            // lblVidaEnemigo
            // 
            lblVidaEnemigo.AutoSize = true;
            lblVidaEnemigo.ForeColor = Color.Yellow;
            lblVidaEnemigo.Location = new Point(541, 70);
            lblVidaEnemigo.Name = "lblVidaEnemigo";
            lblVidaEnemigo.RightToLeft = RightToLeft.Yes;
            lblVidaEnemigo.Size = new Size(90, 15);
            lblVidaEnemigo.TabIndex = 5;
            lblVidaEnemigo.Text = "lblVidaEnemigo";
            // 
            // cmbPersonaje
            // 
            cmbPersonaje.FormattingEnabled = true;
            cmbPersonaje.Location = new Point(569, 449);
            cmbPersonaje.Name = "cmbPersonaje";
            cmbPersonaje.Size = new Size(121, 23);
            cmbPersonaje.TabIndex = 6;
            cmbPersonaje.SelectedIndexChanged += cmbPersonaje_SelectedIndexChanged_1;
            // 
            // pbVidaJugador
            // 
            pbVidaJugador.Location = new Point(48, 88);
            pbVidaJugador.Name = "pbVidaJugador";
            pbVidaJugador.Size = new Size(235, 23);
            pbVidaJugador.TabIndex = 7;
            pbVidaJugador.Click += pbVidaJugador_Click;
            // 
            // pbVidaEnemigo
            // 
            pbVidaEnemigo.Location = new Point(467, 88);
            pbVidaEnemigo.Name = "pbVidaEnemigo";
            pbVidaEnemigo.RightToLeft = RightToLeft.Yes;
            pbVidaEnemigo.RightToLeftLayout = true;
            pbVidaEnemigo.Size = new Size(235, 23);
            pbVidaEnemigo.TabIndex = 8;
            pbVidaEnemigo.UseWaitCursor = true;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(48, 380);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(498, 92);
            txtLog.TabIndex = 9;
            // 
            // btnTurnoEnemigo
            // 
            btnTurnoEnemigo.Enabled = false;
            btnTurnoEnemigo.Location = new Point(421, 488);
            btnTurnoEnemigo.Name = "btnTurnoEnemigo";
            btnTurnoEnemigo.Size = new Size(125, 23);
            btnTurnoEnemigo.TabIndex = 10;
            btnTurnoEnemigo.Text = "Turno del Enemigo";
            btnTurnoEnemigo.UseVisualStyleBackColor = true;
            btnTurnoEnemigo.Click += btnTurno_Click;
            // 
            // pbJugador
            // 
            pbJugador.BackColor = Color.Transparent;
            pbJugador.BackgroundImageLayout = ImageLayout.Stretch;
            pbJugador.Location = new Point(48, 198);
            pbJugador.Name = "pbJugador";
            pbJugador.Size = new Size(178, 164);
            pbJugador.SizeMode = PictureBoxSizeMode.StretchImage;
            pbJugador.TabIndex = 11;
            pbJugador.TabStop = false;
            // 
            // pbEnemigo
            // 
            pbEnemigo.BackColor = Color.Transparent;
            pbEnemigo.BackgroundImageLayout = ImageLayout.Center;
            pbEnemigo.Location = new Point(524, 198);
            pbEnemigo.Name = "pbEnemigo";
            pbEnemigo.Size = new Size(178, 164);
            pbEnemigo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEnemigo.TabIndex = 12;
            pbEnemigo.TabStop = false;
            pbEnemigo.Click += pbEnemigo_Click;
            // 
            // btnCurar
            // 
            btnCurar.Location = new Point(310, 490);
            btnCurar.Margin = new Padding(3, 2, 3, 2);
            btnCurar.Name = "btnCurar";
            btnCurar.Size = new Size(82, 22);
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
            lblroundescription.Location = new Point(310, 45);
            lblroundescription.Name = "lblroundescription";
            lblroundescription.Size = new Size(113, 30);
            lblroundescription.TabIndex = 14;
            lblroundescription.Text = "Rounds";
            // 
            // lblRound
            // 
            lblRound.AutoSize = true;
            lblRound.BackColor = Color.Transparent;
            lblRound.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRound.ForeColor = Color.Yellow;
            lblRound.Location = new Point(330, 86);
            lblRound.Name = "lblRound";
            lblRound.Size = new Size(0, 25);
            lblRound.TabIndex = 15;
            // 
            // pbDefensaEnemigo
            // 
            pbDefensaEnemigo.BackColor = Color.Red;
            pbDefensaEnemigo.Location = new Point(524, 117);
            pbDefensaEnemigo.Name = "pbDefensaEnemigo";
            pbDefensaEnemigo.RightToLeft = RightToLeft.Yes;
            pbDefensaEnemigo.RightToLeftLayout = true;
            pbDefensaEnemigo.Size = new Size(178, 23);
            pbDefensaEnemigo.TabIndex = 16;
            // 
            // pbDefensaJugador
            // 
            pbDefensaJugador.Location = new Point(48, 117);
            pbDefensaJugador.Name = "pbDefensaJugador";
            pbDefensaJugador.Size = new Size(178, 23);
            pbDefensaJugador.TabIndex = 17;
            pbDefensaJugador.Click += progressBar2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(254, 342);
            label1.Name = "label1";
            label1.Size = new Size(53, 21);
            label1.TabIndex = 18;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // btnAbandonar
            // 
            btnAbandonar.Location = new Point(569, 420);
            btnAbandonar.Name = "btnAbandonar";
            btnAbandonar.Size = new Size(121, 23);
            btnAbandonar.TabIndex = 19;
            btnAbandonar.Text = "Abandonar Partida";
            btnAbandonar.UseVisualStyleBackColor = true;
            btnAbandonar.Click += btnAbandonar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 554);
            Controls.Add(btnAbandonar);
            Controls.Add(label1);
            Controls.Add(pbDefensaJugador);
            Controls.Add(pbDefensaEnemigo);
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
            Controls.Add(btnEspecial);
            Controls.Add(btnAtacar);
            Controls.Add(btnCrear);
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
        private ProgressBar pbDefensaEnemigo;
        private ProgressBar pbDefensaJugador;
        private Label label1;
        private Button btnAbandonar;
    }
}
