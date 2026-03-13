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
            ((System.ComponentModel.ISupportInitialize)pbJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEnemigo).BeginInit();
            SuspendLayout();
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(569, 325);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(96, 23);
            btnCrear.TabIndex = 0;
            btnCrear.Text = "Iniciar Partida";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnAtacar
            // 
            btnAtacar.Location = new Point(48, 424);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(75, 23);
            btnAtacar.TabIndex = 1;
            btnAtacar.Text = "btnAtacar";
            btnAtacar.UseVisualStyleBackColor = true;
            btnAtacar.Click += btnAtacar_Click;
            // 
            // btnEspecial
            // 
            btnEspecial.Location = new Point(140, 424);
            btnEspecial.Name = "btnEspecial";
            btnEspecial.Size = new Size(75, 23);
            btnEspecial.TabIndex = 2;
            btnEspecial.Text = "btnEspecial";
            btnEspecial.UseVisualStyleBackColor = true;
            btnEspecial.Click += btnEspecial_Click;
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Location = new Point(48, 45);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(49, 15);
            lblJugador.TabIndex = 3;
            lblJugador.Text = "Jugador";
            // 
            // lblVidaJugador
            // 
            lblVidaJugador.AutoSize = true;
            lblVidaJugador.Location = new Point(48, 70);
            lblVidaJugador.Name = "lblVidaJugador";
            lblVidaJugador.Size = new Size(85, 15);
            lblVidaJugador.TabIndex = 4;
            lblVidaJugador.Text = "lblVidaJugador";
            // 
            // lblVidaEnemigo
            // 
            lblVidaEnemigo.AutoSize = true;
            lblVidaEnemigo.Location = new Point(612, 45);
            lblVidaEnemigo.Name = "lblVidaEnemigo";
            lblVidaEnemigo.Size = new Size(90, 15);
            lblVidaEnemigo.TabIndex = 5;
            lblVidaEnemigo.Text = "lblVidaEnemigo";
            lblVidaEnemigo.Click += label3_Click;
            // 
            // cmbPersonaje
            // 
            cmbPersonaje.FormattingEnabled = true;
            cmbPersonaje.Location = new Point(569, 367);
            cmbPersonaje.Name = "cmbPersonaje";
            cmbPersonaje.Size = new Size(121, 23);
            cmbPersonaje.TabIndex = 6;
            // 
            // pbVidaJugador
            // 
            pbVidaJugador.Location = new Point(48, 88);
            pbVidaJugador.Name = "pbVidaJugador";
            pbVidaJugador.Size = new Size(100, 23);
            pbVidaJugador.TabIndex = 7;
            // 
            // pbVidaEnemigo
            // 
            pbVidaEnemigo.Location = new Point(602, 88);
            pbVidaEnemigo.Name = "pbVidaEnemigo";
            pbVidaEnemigo.Size = new Size(100, 23);
            pbVidaEnemigo.TabIndex = 8;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(48, 326);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(498, 76);
            txtLog.TabIndex = 9;
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // btnTurnoEnemigo
            // 
            btnTurnoEnemigo.Enabled = false;
            btnTurnoEnemigo.Location = new Point(247, 424);
            btnTurnoEnemigo.Name = "btnTurnoEnemigo";
            btnTurnoEnemigo.Size = new Size(125, 23);
            btnTurnoEnemigo.TabIndex = 10;
            btnTurnoEnemigo.Text = "Turno del Enemigo";
            btnTurnoEnemigo.UseVisualStyleBackColor = true;
            btnTurnoEnemigo.Click += btnTurno_Click;
            // 
            // pbJugador
            // 
            pbJugador.Location = new Point(48, 143);
            pbJugador.Name = "pbJugador";
            pbJugador.Size = new Size(178, 164);
            pbJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbJugador.TabIndex = 11;
            pbJugador.TabStop = false;
            pbJugador.Click += pbJugador_Click;
            // 
            // pbEnemigo
            // 
            pbEnemigo.Location = new Point(524, 143);
            pbEnemigo.Name = "pbEnemigo";
            pbEnemigo.Size = new Size(178, 164);
            pbEnemigo.SizeMode = PictureBoxSizeMode.Zoom;
            pbEnemigo.TabIndex = 12;
            pbEnemigo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 554);
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
    }
}
