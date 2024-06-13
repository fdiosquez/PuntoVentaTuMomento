namespace Ventas.Forms
{
    partial class FrmVentaConsultasCliente
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentaConsultasCliente));
            dgClientes = new DataGridView();
            btnBuscar = new Button();
            txtBuscadorClientes = new TextBox();
            btnSumar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgClientes).BeginInit();
            SuspendLayout();
            // 
            // dgClientes
            // 
            dgClientes.BorderStyle = BorderStyle.None;
            dgClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgClientes.ColumnHeadersHeight = 30;
            dgClientes.EnableHeadersVisualStyles = false;
            dgClientes.Location = new Point(8, 47);
            dgClientes.Name = "dgClientes";
            dgClientes.RowHeadersVisible = false;
            dgClientes.RowTemplate.Height = 25;
            dgClientes.Size = new Size(764, 284);
            dgClientes.TabIndex = 1;
            dgClientes.KeyDown += dgClientes_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(737, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(35, 29);
            btnBuscar.TabIndex = 24;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscadorClientes
            // 
            txtBuscadorClientes.BorderStyle = BorderStyle.FixedSingle;
            txtBuscadorClientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBuscadorClientes.Location = new Point(8, 12);
            txtBuscadorClientes.Name = "txtBuscadorClientes";
            txtBuscadorClientes.PlaceholderText = " Buscar por Nombre ó Nro de telefono";
            txtBuscadorClientes.Size = new Size(730, 29);
            txtBuscadorClientes.TabIndex = 23;
            txtBuscadorClientes.KeyPress += txtBuscadorClientes_KeyPress;
            // 
            // btnSumar
            // 
            btnSumar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSumar.ImageAlign = ContentAlignment.MiddleLeft;
            btnSumar.Location = new Point(784, 60);
            btnSumar.Name = "btnSumar";
            btnSumar.Size = new Size(106, 34);
            btnSumar.TabIndex = 25;
            btnSumar.Text = "Seleccionar";
            btnSumar.UseVisualStyleBackColor = true;
            btnSumar.Click += btnSumar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(785, 100);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(106, 34);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmVentaConsultasCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 353);
            Controls.Add(btnCancelar);
            Controls.Add(btnSumar);
            Controls.Add(dgClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscadorClientes);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVentaConsultasCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de  Clientes";
            Load += FrmVentaConsultasCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgClientes;
        private Button btnBuscar;
        private TextBox txtBuscadorClientes;
        private Button btnSumar;
        private Button btnCancelar;
    }
}