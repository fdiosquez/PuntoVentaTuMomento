namespace Ventas.Forms
{
    partial class FrmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaja));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgPedidos = new DataGridView();
            button1 = new Button();
            btnToolImprimir = new Button();
            panelTitleBar = new Panel();
            btnCerrar = new Button();
            btnDetalle = new Button();
            btnNuevoMov = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            btnFechaPersonalizado = new Button();
            btnFechaSemana = new Button();
            btnFechaAyer = new Button();
            btnFechaHoy = new Button();
            lblFiltroAplicado = new Label();
            txtFechaCierre = new TextBox();
            lblFecha = new Label();
            lblBalanceTeorico = new Label();
            txtBalanceTeorico = new TextBox();
            lblEfectivoReal = new Label();
            txtEfectivoReal = new TextBox();
            lblDiferencia = new Label();
            txtDiferencia = new TextBox();
            btnCajaCierre = new Button();
            dgResumen = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgPedidos).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgResumen).BeginInit();
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
            dgPedidos.Location = new Point(12, 115);
            dgPedidos.Name = "dgPedidos";
            dgPedidos.RowHeadersVisible = false;
            dgPedidos.RowTemplate.Height = 25;
            dgPedidos.Size = new Size(918, 409);
            dgPedidos.TabIndex = 22;
            dgPedidos.CellFormatting += dgPedidos_CellFormatting;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Image = Properties.Resources.cancelar_blanco_x24;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(1508, 8);
            button1.Name = "button1";
            button1.Size = new Size(107, 59);
            button1.TabIndex = 4;
            button1.Text = "F7 - Cancelar";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnToolImprimir
            // 
            btnToolImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToolImprimir.Image = Properties.Resources.impresora_blanco_x24;
            btnToolImprimir.ImageAlign = ContentAlignment.TopCenter;
            btnToolImprimir.Location = new Point(1386, 8);
            btnToolImprimir.Name = "btnToolImprimir";
            btnToolImprimir.Size = new Size(107, 59);
            btnToolImprimir.TabIndex = 3;
            btnToolImprimir.Text = "F5 - Imprimir";
            btnToolImprimir.TextAlign = ContentAlignment.BottomCenter;
            btnToolImprimir.UseVisualStyleBackColor = true;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(btnCerrar);
            panelTitleBar.Controls.Add(btnDetalle);
            panelTitleBar.Controls.Add(btnNuevoMov);
            panelTitleBar.Controls.Add(button1);
            panelTitleBar.Controls.Add(btnToolImprimir);
            panelTitleBar.Controls.Add(btnGuardar);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(939, 74);
            panelTitleBar.TabIndex = 23;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.Image = Properties.Resources.factura_blanco_x24;
            btnCerrar.ImageAlign = ContentAlignment.TopCenter;
            btnCerrar.Location = new Point(823, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(107, 59);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "F8 - Cerrar";
            btnCerrar.TextAlign = ContentAlignment.BottomCenter;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnDetalle
            // 
            btnDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetalle.Image = Properties.Resources.impresora_blanco_x241;
            btnDetalle.ImageAlign = ContentAlignment.TopCenter;
            btnDetalle.Location = new Point(708, 8);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(107, 59);
            btnDetalle.TabIndex = 6;
            btnDetalle.Text = "F7 - Imprimir";
            btnDetalle.TextAlign = ContentAlignment.BottomCenter;
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // btnNuevoMov
            // 
            btnNuevoMov.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoMov.Image = Properties.Resources.flujo_de_efectivo;
            btnNuevoMov.ImageAlign = ContentAlignment.TopCenter;
            btnNuevoMov.Location = new Point(594, 8);
            btnNuevoMov.Name = "btnNuevoMov";
            btnNuevoMov.Size = new Size(107, 59);
            btnNuevoMov.TabIndex = 5;
            btnNuevoMov.Text = "F5 - Nuevo Mov.";
            btnNuevoMov.TextAlign = ContentAlignment.BottomCenter;
            btnNuevoMov.UseVisualStyleBackColor = true;
            btnNuevoMov.Click += btnNuevoMov_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(2033, 7);
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
            label1.Size = new Size(53, 30);
            label1.TabIndex = 1;
            label1.Text = "Caja";
            // 
            // btnFechaPersonalizado
            // 
            btnFechaPersonalizado.Image = Properties.Resources.calendario_negrox16;
            btnFechaPersonalizado.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaPersonalizado.Location = new Point(447, 77);
            btnFechaPersonalizado.Name = "btnFechaPersonalizado";
            btnFechaPersonalizado.Size = new Size(139, 32);
            btnFechaPersonalizado.TabIndex = 20;
            btnFechaPersonalizado.Text = "Personalizado";
            btnFechaPersonalizado.UseVisualStyleBackColor = true;
            btnFechaPersonalizado.Click += btnFechaPersonalizado_Click;
            // 
            // btnFechaSemana
            // 
            btnFechaSemana.Image = Properties.Resources.calendario_negrox16;
            btnFechaSemana.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaSemana.Location = new Point(302, 77);
            btnFechaSemana.Name = "btnFechaSemana";
            btnFechaSemana.Size = new Size(139, 32);
            btnFechaSemana.TabIndex = 19;
            btnFechaSemana.Text = "Esta semana";
            btnFechaSemana.UseVisualStyleBackColor = true;
            btnFechaSemana.Click += btnFechaSemana_Click;
            // 
            // btnFechaAyer
            // 
            btnFechaAyer.Image = Properties.Resources.calendario_negrox16;
            btnFechaAyer.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaAyer.Location = new Point(157, 77);
            btnFechaAyer.Name = "btnFechaAyer";
            btnFechaAyer.Size = new Size(139, 32);
            btnFechaAyer.TabIndex = 18;
            btnFechaAyer.Text = "Ayer";
            btnFechaAyer.UseVisualStyleBackColor = true;
            btnFechaAyer.Click += btnFechaAyer_Click;
            // 
            // btnFechaHoy
            // 
            btnFechaHoy.Image = Properties.Resources.calendario_negrox16;
            btnFechaHoy.ImageAlign = ContentAlignment.MiddleLeft;
            btnFechaHoy.Location = new Point(12, 77);
            btnFechaHoy.Name = "btnFechaHoy";
            btnFechaHoy.Size = new Size(139, 32);
            btnFechaHoy.TabIndex = 17;
            btnFechaHoy.Text = "Hoy";
            btnFechaHoy.UseVisualStyleBackColor = true;
            btnFechaHoy.Click += btnFechaHoy_Click;
            // 
            // lblFiltroAplicado
            // 
            lblFiltroAplicado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFiltroAplicado.AutoSize = true;
            lblFiltroAplicado.Location = new Point(12, 534);
            lblFiltroAplicado.Name = "lblFiltroAplicado";
            lblFiltroAplicado.Size = new Size(102, 15);
            lblFiltroAplicado.TabIndex = 24;
            lblFiltroAplicado.Text = "{lblFiltroAplicado}";
            // 
            // txtFechaCierre
            // 
            txtFechaCierre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFechaCierre.BorderStyle = BorderStyle.FixedSingle;
            txtFechaCierre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFechaCierre.Location = new Point(715, 133);
            txtFechaCierre.Name = "txtFechaCierre";
            txtFechaCierre.Size = new Size(167, 29);
            txtFechaCierre.TabIndex = 25;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(715, 115);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 26;
            lblFecha.Text = "Fecha";
            // 
            // lblBalanceTeorico
            // 
            lblBalanceTeorico.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBalanceTeorico.AutoSize = true;
            lblBalanceTeorico.Location = new Point(715, 327);
            lblBalanceTeorico.Name = "lblBalanceTeorico";
            lblBalanceTeorico.Size = new Size(89, 15);
            lblBalanceTeorico.TabIndex = 28;
            lblBalanceTeorico.Text = "Balance Teórico";
            // 
            // txtBalanceTeorico
            // 
            txtBalanceTeorico.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBalanceTeorico.BorderStyle = BorderStyle.FixedSingle;
            txtBalanceTeorico.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBalanceTeorico.Location = new Point(715, 345);
            txtBalanceTeorico.Name = "txtBalanceTeorico";
            txtBalanceTeorico.Size = new Size(167, 29);
            txtBalanceTeorico.TabIndex = 27;
            // 
            // lblEfectivoReal
            // 
            lblEfectivoReal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEfectivoReal.AutoSize = true;
            lblEfectivoReal.Location = new Point(715, 385);
            lblEfectivoReal.Name = "lblEfectivoReal";
            lblEfectivoReal.Size = new Size(74, 15);
            lblEfectivoReal.TabIndex = 30;
            lblEfectivoReal.Text = "Efectivo Real";
            // 
            // txtEfectivoReal
            // 
            txtEfectivoReal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEfectivoReal.BorderStyle = BorderStyle.FixedSingle;
            txtEfectivoReal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEfectivoReal.Location = new Point(715, 403);
            txtEfectivoReal.Name = "txtEfectivoReal";
            txtEfectivoReal.Size = new Size(167, 29);
            txtEfectivoReal.TabIndex = 29;
            txtEfectivoReal.TextChanged += txtEfectivoReal_TextChanged;
            txtEfectivoReal.KeyPress += txtEfectivoReal_KeyPress;
            // 
            // lblDiferencia
            // 
            lblDiferencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDiferencia.AutoSize = true;
            lblDiferencia.Location = new Point(715, 441);
            lblDiferencia.Name = "lblDiferencia";
            lblDiferencia.Size = new Size(60, 15);
            lblDiferencia.TabIndex = 32;
            lblDiferencia.Text = "Diferencia";
            // 
            // txtDiferencia
            // 
            txtDiferencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDiferencia.BorderStyle = BorderStyle.FixedSingle;
            txtDiferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDiferencia.Location = new Point(715, 459);
            txtDiferencia.Name = "txtDiferencia";
            txtDiferencia.Size = new Size(167, 29);
            txtDiferencia.TabIndex = 31;
            // 
            // btnCajaCierre
            // 
            btnCajaCierre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCajaCierre.Image = Properties.Resources.check_blanco_x16;
            btnCajaCierre.ImageAlign = ContentAlignment.MiddleLeft;
            btnCajaCierre.Location = new Point(715, 512);
            btnCajaCierre.Name = "btnCajaCierre";
            btnCajaCierre.Size = new Size(167, 34);
            btnCajaCierre.TabIndex = 33;
            btnCajaCierre.Text = "Cerrar Caja";
            btnCajaCierre.UseVisualStyleBackColor = true;
            btnCajaCierre.Click += btnCajaCierre_Click;
            // 
            // dgResumen
            // 
            dgResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgResumen.BackgroundColor = SystemColors.Control;
            dgResumen.BorderStyle = BorderStyle.None;
            dgResumen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Coral;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgResumen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgResumen.ColumnHeadersHeight = 30;
            dgResumen.EnableHeadersVisualStyles = false;
            dgResumen.Location = new Point(715, 168);
            dgResumen.Name = "dgResumen";
            dgResumen.RowHeadersVisible = false;
            dgResumen.RowTemplate.Height = 25;
            dgResumen.Size = new Size(212, 156);
            dgResumen.TabIndex = 34;
            // 
            // FrmCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 558);
            Controls.Add(dgResumen);
            Controls.Add(btnCajaCierre);
            Controls.Add(lblDiferencia);
            Controls.Add(txtDiferencia);
            Controls.Add(lblEfectivoReal);
            Controls.Add(txtEfectivoReal);
            Controls.Add(lblBalanceTeorico);
            Controls.Add(txtBalanceTeorico);
            Controls.Add(lblFecha);
            Controls.Add(txtFechaCierre);
            Controls.Add(lblFiltroAplicado);
            Controls.Add(dgPedidos);
            Controls.Add(panelTitleBar);
            Controls.Add(btnFechaPersonalizado);
            Controls.Add(btnFechaSemana);
            Controls.Add(btnFechaAyer);
            Controls.Add(btnFechaHoy);
            KeyPreview = true;
            Name = "FrmCaja";
            Text = "FrmCaja";
            Load += FrmCaja_Load;
            KeyDown += FrmCaja_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgPedidos).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgResumen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgPedidos;
        private Button button1;
        private Button btnToolImprimir;
        private Panel panelTitleBar;
        private Button btnGuardar;
        private Label label1;
        private Button btnFechaPersonalizado;
        private Button btnFechaSemana;
        private Button btnFechaAyer;
        private Button btnFechaHoy;
        private Label lblFiltroAplicado;
        private Button btnDetalle;
        private Button btnNuevoMov;
        private Button btnCerrar;
        private TextBox txtFechaCierre;
        private Label lblFecha;
        private Label lblBalanceTeorico;
        private TextBox txtBalanceTeorico;
        private Label lblEfectivoReal;
        private TextBox txtEfectivoReal;
        private Label lblDiferencia;
        private TextBox txtDiferencia;
        private Button btnCajaCierre;
        private DataGridView dgResumen;
    }
}