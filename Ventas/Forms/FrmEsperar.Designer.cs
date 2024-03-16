namespace Ventas.Forms
{
    partial class FrmEsperar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(32, 59);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(360, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 0;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = SystemColors.ControlLightLight;
            lblMensaje.Location = new Point(32, 32);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(257, 15);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "Sincronizando Base de datos por favor espere ...";
            // 
            // FrmEsperar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 150, 136);
            ClientSize = new Size(427, 130);
            Controls.Add(lblMensaje);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEsperar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmEsperar";
            Load += FrmEsperar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblMensaje;
    }
}