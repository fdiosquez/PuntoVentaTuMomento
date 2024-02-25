namespace VentasUpdate
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
            components = new System.ComponentModel.Container();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelSpeed = new Label();
            labelPerc = new Label();
            labelDownloaded = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(59, 28);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(386, 23);
            progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 65);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "Velocidad :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 86);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "Porcentaje :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 107);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "Tamaño :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSpeed
            // 
            labelSpeed.AutoSize = true;
            labelSpeed.Location = new Point(101, 66);
            labelSpeed.Name = "labelSpeed";
            labelSpeed.Size = new Size(163, 15);
            labelSpeed.TabIndex = 4;
            labelSpeed.Text = "Verificando Actualizaciones ...";
            labelSpeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPerc
            // 
            labelPerc.AutoSize = true;
            labelPerc.Location = new Point(101, 86);
            labelPerc.Name = "labelPerc";
            labelPerc.Size = new Size(163, 15);
            labelPerc.TabIndex = 5;
            labelPerc.Text = "Verificando Actualizaciones ...";
            labelPerc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDownloaded
            // 
            labelDownloaded.AutoSize = true;
            labelDownloaded.Location = new Point(101, 107);
            labelDownloaded.Name = "labelDownloaded";
            labelDownloaded.Size = new Size(163, 15);
            labelDownloaded.TabIndex = 6;
            labelDownloaded.Text = "Verificando Actualizaciones ...";
            labelDownloaded.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 145);
            Controls.Add(labelDownloaded);
            Controls.Add(labelPerc);
            Controls.Add(labelSpeed);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizador";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelSpeed;
        private Label labelPerc;
        private Label labelDownloaded;
        private System.Windows.Forms.Timer timer1;
    }
}