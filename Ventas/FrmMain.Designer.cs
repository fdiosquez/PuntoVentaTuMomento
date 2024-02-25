namespace Ventas
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            statusStrip1 = new StatusStrip();
            toolLabelBD = new ToolStripStatusLabel();
            toolLabelSucursal = new ToolStripStatusLabel();
            toolLabelPuesto = new ToolStripStatusLabel();
            panelMenu = new Panel();
            btnConfiguracion = new Button();
            btnEventos = new Button();
            btnProductos = new Button();
            btnCaja = new Button();
            btnConsultaPedidos = new Button();
            btnNuevo = new Button();
            panelLogo = new Panel();
            lblNombreEmpresa = new Label();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            panelDesktopPane = new Panel();
            bindingSource1 = new BindingSource(components);
            printPreviewDialog1 = new PrintPreviewDialog();
            statusStrip1.SuspendLayout();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolLabelBD, toolLabelSucursal, toolLabelPuesto });
            statusStrip1.Location = new Point(0, 512);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(833, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolLabelBD
            // 
            toolLabelBD.Name = "toolLabelBD";
            toolLabelBD.Size = new Size(70, 17);
            toolLabelBD.Text = "toolLabelbd";
            // 
            // toolLabelSucursal
            // 
            toolLabelSucursal.Name = "toolLabelSucursal";
            toolLabelSucursal.Size = new Size(100, 17);
            toolLabelSucursal.Text = "toolLabelSucursal";
            // 
            // toolLabelPuesto
            // 
            toolLabelPuesto.Name = "toolLabelPuesto";
            toolLabelPuesto.Size = new Size(92, 17);
            toolLabelPuesto.Text = "toolLabelPuesto";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(btnConfiguracion);
            panelMenu.Controls.Add(btnEventos);
            panelMenu.Controls.Add(btnProductos);
            panelMenu.Controls.Add(btnCaja);
            panelMenu.Controls.Add(btnConsultaPedidos);
            panelMenu.Controls.Add(btnNuevo);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 512);
            panelMenu.TabIndex = 4;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Dock = DockStyle.Top;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfiguracion.ForeColor = Color.Gainsboro;
            btnConfiguracion.Image = (Image)resources.GetObject("btnConfiguracion.Image");
            btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.Location = new Point(0, 374);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(12, 0, 0, 0);
            btnConfiguracion.Size = new Size(220, 60);
            btnConfiguracion.TabIndex = 6;
            btnConfiguracion.Text = "  Configuracion";
            btnConfiguracion.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracion.UseVisualStyleBackColor = true;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // btnEventos
            // 
            btnEventos.Dock = DockStyle.Top;
            btnEventos.FlatAppearance.BorderSize = 0;
            btnEventos.FlatStyle = FlatStyle.Flat;
            btnEventos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEventos.ForeColor = Color.Gainsboro;
            btnEventos.Image = (Image)resources.GetObject("btnEventos.Image");
            btnEventos.ImageAlign = ContentAlignment.MiddleLeft;
            btnEventos.Location = new Point(0, 314);
            btnEventos.Name = "btnEventos";
            btnEventos.Padding = new Padding(12, 0, 0, 0);
            btnEventos.Size = new Size(220, 60);
            btnEventos.TabIndex = 5;
            btnEventos.Text = "  Eventos";
            btnEventos.TextAlign = ContentAlignment.MiddleLeft;
            btnEventos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEventos.UseVisualStyleBackColor = true;
            btnEventos.Click += btnEventos_Click;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnProductos.ForeColor = Color.Gainsboro;
            btnProductos.Image = Properties.Resources.productos_cosmeticos;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(0, 254);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(12, 0, 0, 0);
            btnProductos.Size = new Size(220, 60);
            btnProductos.TabIndex = 4;
            btnProductos.Text = "  Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCaja
            // 
            btnCaja.Dock = DockStyle.Top;
            btnCaja.FlatAppearance.BorderSize = 0;
            btnCaja.FlatStyle = FlatStyle.Flat;
            btnCaja.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCaja.ForeColor = Color.Gainsboro;
            btnCaja.Image = (Image)resources.GetObject("btnCaja.Image");
            btnCaja.ImageAlign = ContentAlignment.MiddleLeft;
            btnCaja.Location = new Point(0, 194);
            btnCaja.Name = "btnCaja";
            btnCaja.Padding = new Padding(12, 0, 0, 0);
            btnCaja.Size = new Size(220, 60);
            btnCaja.TabIndex = 3;
            btnCaja.Text = "  Caja";
            btnCaja.TextAlign = ContentAlignment.MiddleLeft;
            btnCaja.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCaja.UseVisualStyleBackColor = true;
            btnCaja.Click += btnCaja_Click;
            // 
            // btnConsultaPedidos
            // 
            btnConsultaPedidos.Dock = DockStyle.Top;
            btnConsultaPedidos.FlatAppearance.BorderSize = 0;
            btnConsultaPedidos.FlatStyle = FlatStyle.Flat;
            btnConsultaPedidos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnConsultaPedidos.ForeColor = Color.Gainsboro;
            btnConsultaPedidos.Image = (Image)resources.GetObject("btnConsultaPedidos.Image");
            btnConsultaPedidos.ImageAlign = ContentAlignment.MiddleLeft;
            btnConsultaPedidos.Location = new Point(0, 134);
            btnConsultaPedidos.Name = "btnConsultaPedidos";
            btnConsultaPedidos.Padding = new Padding(12, 0, 0, 0);
            btnConsultaPedidos.Size = new Size(220, 60);
            btnConsultaPedidos.TabIndex = 2;
            btnConsultaPedidos.Text = "  Listado Pedidos";
            btnConsultaPedidos.TextAlign = ContentAlignment.MiddleLeft;
            btnConsultaPedidos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConsultaPedidos.UseVisualStyleBackColor = true;
            btnConsultaPedidos.Click += btnConsultaPedidos_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Dock = DockStyle.Top;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNuevo.ForeColor = Color.Gainsboro;
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(0, 74);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Padding = new Padding(12, 0, 0, 0);
            btnNuevo.Size = new Size(220, 60);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "  Nueva Venta";
            btnNuevo.TextAlign = ContentAlignment.MiddleLeft;
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(lblNombreEmpresa);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 74);
            panelLogo.TabIndex = 0;
            // 
            // lblNombreEmpresa
            // 
            lblNombreEmpresa.AutoSize = true;
            lblNombreEmpresa.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreEmpresa.ForeColor = Color.LightGray;
            lblNombreEmpresa.Location = new Point(12, 20);
            lblNombreEmpresa.Name = "lblNombreEmpresa";
            lblNombreEmpresa.Size = new Size(198, 28);
            lblNombreEmpresa.TabIndex = 0;
            lblNombreEmpresa.Text = "{NOMBRE_EMPRESA}";
            lblNombreEmpresa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(613, 74);
            panelTitleBar.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(281, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(55, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HOME";
            // 
            // panelDesktopPane
            // 
            panelDesktopPane.Dock = DockStyle.Fill;
            panelDesktopPane.Location = new Point(220, 74);
            panelDesktopPane.Name = "panelDesktopPane";
            panelDesktopPane.Size = new Size(613, 438);
            panelDesktopPane.TabIndex = 6;
            panelDesktopPane.Paint += panelDesktopPane_Paint;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 534);
            Controls.Add(panelDesktopPane);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Controls.Add(statusStrip1);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Punto de Venta";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private Panel panelMenu;
        private Panel panelLogo;
        private Button btnNuevo;
        private Button btnConfiguracion;
        private Button btnEventos;
        private Button btnProductos;
        private Button btnCaja;
        private Button btnConsultaPedidos;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Label lblNombreEmpresa;
        private Panel panelDesktopPane;
        private BindingSource bindingSource1;
        private ToolStripStatusLabel toolLabelBD;
        private ToolStripStatusLabel toolLabelSucursal;
        private ToolStripStatusLabel toolLabelPuesto;
        private PrintPreviewDialog printPreviewDialog1;
    }
}