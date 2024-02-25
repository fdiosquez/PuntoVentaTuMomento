namespace Ventas.Forms
{
    partial class FrmVentaConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentaConsultas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnFechaHoy = new Button();
            btnFechaAyer = new Button();
            btnFechaSemana = new Button();
            btnFechaPersonalizado = new Button();
            btnBuscar = new Button();
            txtInput = new TextBox();
            dgPedidos = new DataGridView();
            panelTitleBar = new Panel();
            button1 = new Button();
            btnToolImprimir = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            lblFiltroAplicado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgPedidos).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // btnFechaHoy
            // 
            btnFechaHoy.Image = Properties.Resources.calendario_negrox16;
            btnFechaHoy.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaHoy.Location = new Point(12, 78);
            btnFechaHoy.Name = "btnFechaHoy";
            btnFechaHoy.Size = new Size(139, 32);
            btnFechaHoy.TabIndex = 9;
            btnFechaHoy.Text = "Hoy";
            btnFechaHoy.UseVisualStyleBackColor = true;
            btnFechaHoy.Click += btnFechaHoy_Click;
            // 
            // btnFechaAyer
            // 
            btnFechaAyer.Image = Properties.Resources.calendario_negrox16;
            btnFechaAyer.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaAyer.Location = new Point(157, 78);
            btnFechaAyer.Name = "btnFechaAyer";
            btnFechaAyer.Size = new Size(139, 32);
            btnFechaAyer.TabIndex = 10;
            btnFechaAyer.Text = "Ayer";
            btnFechaAyer.UseVisualStyleBackColor = true;
            btnFechaAyer.Click += btnFechaAyer_Click;
            // 
            // btnFechaSemana
            // 
            btnFechaSemana.Image = Properties.Resources.calendario_negrox16;
            btnFechaSemana.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaSemana.Location = new Point(302, 78);
            btnFechaSemana.Name = "btnFechaSemana";
            btnFechaSemana.Size = new Size(139, 32);
            btnFechaSemana.TabIndex = 11;
            btnFechaSemana.Text = "Esta semana";
            btnFechaSemana.UseVisualStyleBackColor = true;
            btnFechaSemana.Click += btnFechaSemana_Click;
            // 
            // btnFechaPersonalizado
            // 
            btnFechaPersonalizado.Image = Properties.Resources.calendario_negrox16;
            btnFechaPersonalizado.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaPersonalizado.Location = new Point(447, 78);
            btnFechaPersonalizado.Name = "btnFechaPersonalizado";
            btnFechaPersonalizado.Size = new Size(139, 32);
            btnFechaPersonalizado.TabIndex = 12;
            btnFechaPersonalizado.Text = "Personalizado";
            btnFechaPersonalizado.UseVisualStyleBackColor = true;
            btnFechaPersonalizado.Click += btnFechaPersonalizado_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(798, 80);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(30, 29);
            btnBuscar.TabIndex = 14;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInput.Location = new Point(592, 80);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Ingrese Nro Comprobante";
            txtInput.Size = new Size(208, 29);
            txtInput.TabIndex = 13;
            txtInput.TextChanged += txtInput_TextChanged;
            txtInput.KeyPress += txtInput_KeyPress;
            // 
            // dgPedidos
            // 
            dgPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgPedidos.BorderStyle = BorderStyle.None;
            dgPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Coral;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgPedidos.ColumnHeadersHeight = 30;
            dgPedidos.EnableHeadersVisualStyles = false;
            dgPedidos.Location = new Point(12, 116);
            dgPedidos.Name = "dgPedidos";
            dgPedidos.RowHeadersVisible = false;
            dgPedidos.RowTemplate.Height = 25;
            dgPedidos.Size = new Size(817, 405);
            dgPedidos.TabIndex = 15;
            dgPedidos.CellFormatting += dgPedidos_CellFormatting;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(button1);
            panelTitleBar.Controls.Add(btnToolImprimir);
            panelTitleBar.Controls.Add(btnGuardar);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(888, 74);
            panelTitleBar.TabIndex = 16;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Image = Properties.Resources.cancelar_blanco_x24;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(769, 8);
            button1.Name = "button1";
            button1.Size = new Size(107, 59);
            button1.TabIndex = 4;
            button1.Text = "F7 - Cancelar";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnToolImprimir
            // 
            btnToolImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToolImprimir.Image = Properties.Resources.impresora_blanco_x24;
            btnToolImprimir.ImageAlign = ContentAlignment.TopCenter;
            btnToolImprimir.Location = new Point(647, 8);
            btnToolImprimir.Name = "btnToolImprimir";
            btnToolImprimir.Size = new Size(107, 59);
            btnToolImprimir.TabIndex = 3;
            btnToolImprimir.Text = "F5 - Imprimir";
            btnToolImprimir.TextAlign = ContentAlignment.BottomCenter;
            btnToolImprimir.UseVisualStyleBackColor = true;
            btnToolImprimir.Click += btnToolImprimir_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(1294, 7);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 59);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "F5 - Guardar";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(187, 30);
            label1.TabIndex = 1;
            label1.Text = "Listado de pedidos";
            // 
            // lblFiltroAplicado
            // 
            lblFiltroAplicado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFiltroAplicado.AutoSize = true;
            lblFiltroAplicado.Location = new Point(12, 532);
            lblFiltroAplicado.Name = "lblFiltroAplicado";
            lblFiltroAplicado.Size = new Size(102, 15);
            lblFiltroAplicado.TabIndex = 17;
            lblFiltroAplicado.Text = "{lblFiltroAplicado}";
            // 
            // FrmVentaConsultas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 556);
            Controls.Add(lblFiltroAplicado);
            Controls.Add(panelTitleBar);
            Controls.Add(dgPedidos);
            Controls.Add(btnBuscar);
            Controls.Add(txtInput);
            Controls.Add(btnFechaPersonalizado);
            Controls.Add(btnFechaSemana);
            Controls.Add(btnFechaAyer);
            Controls.Add(btnFechaHoy);
            KeyPreview = true;
            Name = "FrmVentaConsultas";
            Text = "Listado de pedidos";
            Load += FrmVentaConsultas_Load;
            KeyDown += FrmVentaConsultas_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgPedidos).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFechaHoy;
        private Button btnFechaAyer;
        private Button btnFechaSemana;
        private Button btnFechaPersonalizado;
        private Button btnBuscar;
        private TextBox txtInput;
        private DataGridView dgPedidos;
        private Panel panelTitleBar;
        private Button btnGuardar;
        private Label label1;
        private Label lblFiltroAplicado;
        private Button btnToolImprimir;
        private Button button1;
    }
}