namespace Ventas.Forms
{
    partial class FrmVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgPedidos = new DataGridView();
            btnEliminar = new Button();
            txtInput = new TextBox();
            panelTitleBar = new Panel();
            pnlActualizacion = new Panel();
            btnActualizar = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnGuardar = new Button();
            label1 = new Label();
            lblTotal = new Label();
            btnBuscar = new Button();
            btnSumar = new Button();
            btnBajar = new Button();
            dgBusqueda = new DataGridView();
            PanelBusquedaSugerida = new Panel();
            btnCerrarBuscador = new Button();
            btnCancelar = new Button();
            btnMovimientoCaja = new Button();
            ((System.ComponentModel.ISupportInitialize)dgPedidos).BeginInit();
            panelTitleBar.SuspendLayout();
            pnlActualizacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgBusqueda).BeginInit();
            PanelBusquedaSugerida.SuspendLayout();
            SuspendLayout();
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
            dgPedidos.Location = new Point(12, 109);
            dgPedidos.Name = "dgPedidos";
            dgPedidos.RowHeadersVisible = false;
            dgPedidos.RowTemplate.Height = 25;
            dgPedidos.Size = new Size(588, 422);
            dgPedidos.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(606, 189);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(139, 34);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar Item";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += button1_Click;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInput.Location = new Point(12, 76);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "  INGRESE CÓDIGO DE BARRA";
            txtInput.Size = new Size(554, 29);
            txtInput.TabIndex = 2;
            txtInput.TextChanged += txtInput_TextChanged;
            txtInput.KeyDown += txtInput_KeyDown;
            txtInput.KeyPress += txtInput_KeyPress;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(pnlActualizacion);
            panelTitleBar.Controls.Add(btnGuardar);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Controls.Add(lblTotal);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(757, 74);
            panelTitleBar.TabIndex = 6;
            // 
            // pnlActualizacion
            // 
            pnlActualizacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActualizacion.BackColor = Color.White;
            pnlActualizacion.BackgroundImageLayout = ImageLayout.Center;
            pnlActualizacion.Controls.Add(btnActualizar);
            pnlActualizacion.Controls.Add(label2);
            pnlActualizacion.Controls.Add(pictureBox1);
            pnlActualizacion.Location = new Point(243, 12);
            pnlActualizacion.Name = "pnlActualizacion";
            pnlActualizacion.Size = new Size(354, 49);
            pnlActualizacion.TabIndex = 3;
            pnlActualizacion.Visible = false;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(267, 10);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(53, 15);
            label2.Name = "label2";
            label2.Size = new Size(424, 17);
            label2.TabIndex = 2;
            label2.Text = "Nueva lista de precios !!!, presione actualizar para aceptar los cambios";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 31);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(606, 7);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 59);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "F5 - Guardar";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(89, 30);
            label1.TabIndex = 1;
            label1.Text = "TOTAL : ";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(94, 22);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(68, 30);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "$ 0.00";
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(565, 76);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(35, 29);
            btnBuscar.TabIndex = 7;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnSumar
            // 
            btnSumar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSumar.Image = (Image)resources.GetObject("btnSumar.Image");
            btnSumar.ImageAlign = ContentAlignment.MiddleLeft;
            btnSumar.Location = new Point(606, 109);
            btnSumar.Name = "btnSumar";
            btnSumar.Size = new Size(139, 34);
            btnSumar.TabIndex = 8;
            btnSumar.Text = "Sumar Item";
            btnSumar.UseVisualStyleBackColor = true;
            btnSumar.Click += button2_Click;
            // 
            // btnBajar
            // 
            btnBajar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBajar.Image = (Image)resources.GetObject("btnBajar.Image");
            btnBajar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBajar.Location = new Point(606, 149);
            btnBajar.Name = "btnBajar";
            btnBajar.Size = new Size(139, 34);
            btnBajar.TabIndex = 9;
            btnBajar.Text = "Bajar Item";
            btnBajar.UseVisualStyleBackColor = true;
            btnBajar.Click += btnBajar_Click;
            // 
            // dgBusqueda
            // 
            dgBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgBusqueda.BorderStyle = BorderStyle.None;
            dgBusqueda.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgBusqueda.ColumnHeadersHeight = 30;
            dgBusqueda.EnableHeadersVisualStyles = false;
            dgBusqueda.Location = new Point(1, 2);
            dgBusqueda.Name = "dgBusqueda";
            dgBusqueda.RowHeadersVisible = false;
            dgBusqueda.RowTemplate.Height = 25;
            dgBusqueda.Size = new Size(585, 191);
            dgBusqueda.TabIndex = 1;
            dgBusqueda.KeyDown += dgBusqueda_KeyDown;
            // 
            // PanelBusquedaSugerida
            // 
            PanelBusquedaSugerida.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelBusquedaSugerida.BorderStyle = BorderStyle.FixedSingle;
            PanelBusquedaSugerida.Controls.Add(btnCerrarBuscador);
            PanelBusquedaSugerida.Controls.Add(dgBusqueda);
            PanelBusquedaSugerida.Location = new Point(12, 104);
            PanelBusquedaSugerida.Name = "PanelBusquedaSugerida";
            PanelBusquedaSugerida.Size = new Size(589, 248);
            PanelBusquedaSugerida.TabIndex = 10;
            // 
            // btnCerrarBuscador
            // 
            btnCerrarBuscador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarBuscador.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarBuscador.Location = new Point(497, 201);
            btnCerrarBuscador.Name = "btnCerrarBuscador";
            btnCerrarBuscador.Size = new Size(87, 34);
            btnCerrarBuscador.TabIndex = 9;
            btnCerrarBuscador.Text = "Cerrar";
            btnCerrarBuscador.UseVisualStyleBackColor = true;
            btnCerrarBuscador.Click += btnCerrarBuscador_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(607, 269);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(139, 34);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar Venta";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnMovimientoCaja
            // 
            btnMovimientoCaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMovimientoCaja.Image = Properties.Resources.flujo_de_efectivo_x16;
            btnMovimientoCaja.ImageAlign = ContentAlignment.MiddleLeft;
            btnMovimientoCaja.Location = new Point(607, 229);
            btnMovimientoCaja.Name = "btnMovimientoCaja";
            btnMovimientoCaja.Size = new Size(139, 34);
            btnMovimientoCaja.TabIndex = 12;
            btnMovimientoCaja.Text = "Mov. Caja";
            btnMovimientoCaja.UseVisualStyleBackColor = true;
            btnMovimientoCaja.Click += btnMovimientoCaja_Click;
            // 
            // FrmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 543);
            Controls.Add(btnMovimientoCaja);
            Controls.Add(btnCancelar);
            Controls.Add(PanelBusquedaSugerida);
            Controls.Add(btnBajar);
            Controls.Add(btnSumar);
            Controls.Add(btnBuscar);
            Controls.Add(panelTitleBar);
            Controls.Add(txtInput);
            Controls.Add(btnEliminar);
            Controls.Add(dgPedidos);
            KeyPreview = true;
            Name = "FrmVenta";
            Text = "FrmVenta";
            Load += FrmVenta_Load;
            KeyDown += FrmVenta_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgPedidos).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            pnlActualizacion.ResumeLayout(false);
            pnlActualizacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgBusqueda).EndInit();
            PanelBusquedaSugerida.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgPedidos;
        private Button btnEliminar;
        private TextBox txtInput;
        private Panel panelTitleBar;
        private Label lblTotal;
        private Label label1;
        private Button btnBuscar;
        private Button btnSumar;
        private Button btnBajar;
        private Button btnGuardar;
        private DataGridView dgBusqueda;
        private Panel PanelBusquedaSugerida;
        private Button btnCerrarBuscador;
        private Button btnCancelar;
        private Button btnMovimientoCaja;
        private Panel pnlActualizacion;
        private Button btnActualizar;
        private Label label2;
        private PictureBox pictureBox1;
    }
}