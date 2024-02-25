namespace Ventas.Forms
{
    partial class FrmFechaDesdeHasta
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
            dateTimePickerFD = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dateTimePickerFH = new DateTimePicker();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // dateTimePickerFD
            // 
            dateTimePickerFD.Format = DateTimePickerFormat.Short;
            dateTimePickerFD.Location = new Point(112, 32);
            dateTimePickerFD.Name = "dateTimePickerFD";
            dateTimePickerFD.Size = new Size(146, 23);
            dateTimePickerFD.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 38);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Fecha Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 78);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha Hasta";
            // 
            // dateTimePickerFH
            // 
            dateTimePickerFH.Format = DateTimePickerFormat.Short;
            dateTimePickerFH.Location = new Point(112, 72);
            dateTimePickerFH.Name = "dateTimePickerFH";
            dateTimePickerFH.Size = new Size(146, 23);
            dateTimePickerFH.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Image = Properties.Resources.check_blanco_x16;
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(82, 118);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(139, 32);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmFechaDesdeHasta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 180);
            Controls.Add(btnAceptar);
            Controls.Add(dateTimePickerFH);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerFD);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFechaDesdeHasta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccione rango de fechas";
            Load += FrmFechaDesdeHasta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerFD;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerFH;
        private Button btnAceptar;
    }
}