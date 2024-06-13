namespace Ventas.Forms
{
    partial class FrmCajaNuevo
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
            groupBox1 = new GroupBox();
            cboCajaTipo = new ComboBox();
            txtDescripcion = new TextBox();
            txtValor = new TextBox();
            btnAceptar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboCajaTipo);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtValor);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(344, 155);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingrese Información";
            // 
            // cboCajaTipo
            // 
            cboCajaTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCajaTipo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCajaTipo.FormattingEnabled = true;
            cboCajaTipo.ItemHeight = 21;
            cboCajaTipo.Location = new Point(22, 34);
            cboCajaTipo.Name = "cboCajaTipo";
            cboCajaTipo.Size = new Size(291, 29);
            cboCajaTipo.TabIndex = 17;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescripcion.Location = new Point(22, 69);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "  Observación";
            txtDescripcion.Size = new Size(291, 29);
            txtDescripcion.TabIndex = 16;
            // 
            // txtValor
            // 
            txtValor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtValor.BorderStyle = BorderStyle.FixedSingle;
            txtValor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtValor.Location = new Point(22, 104);
            txtValor.Name = "txtValor";
            txtValor.PlaceholderText = "   Valor";
            txtValor.Size = new Size(83, 29);
            txtValor.TabIndex = 14;
            txtValor.TextChanged += txtValor_TextChanged;
            txtValor.KeyPress += txtValor_KeyPress;
            // 
            // btnAceptar
            // 
            btnAceptar.Image = Properties.Resources.check_blanco_x16;
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(106, 178);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(139, 32);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmCajaNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 222);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCajaNuevo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Movimiento de caja";
            Load += FrmCajaNuevo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtDescripcion;
        private TextBox txtValor;
        private Button btnAceptar;
        private ComboBox cboCajaTipo;
    }
}