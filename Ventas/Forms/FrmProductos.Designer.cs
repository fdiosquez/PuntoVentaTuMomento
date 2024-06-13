namespace Ventas.Forms
{
    partial class FrmProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductos));
            dgPedidos = new DataGridView();
            panelTitleBar = new Panel();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            btnDetalle = new Button();
            btnNuevoMov = new Button();
            button1 = new Button();
            btnToolImprimir = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            btnBuscar = new Button();
            txtInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgPedidos).BeginInit();
            panelTitleBar.SuspendLayout();
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
            dgPedidos.Location = new Point(9, 115);
            dgPedidos.Name = "dgPedidos";
            dgPedidos.RowHeadersVisible = false;
            dgPedidos.RowTemplate.Height = 25;
            dgPedidos.Size = new Size(903, 372);
            dgPedidos.TabIndex = 24;
            dgPedidos.CellDoubleClick += dgPedidos_CellDoubleClick;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(btnEliminar);
            panelTitleBar.Controls.Add(btnModificar);
            panelTitleBar.Controls.Add(btnNuevo);
            panelTitleBar.Controls.Add(btnDetalle);
            panelTitleBar.Controls.Add(btnNuevoMov);
            panelTitleBar.Controls.Add(button1);
            panelTitleBar.Controls.Add(btnToolImprimir);
            panelTitleBar.Controls.Add(btnGuardar);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(931, 74);
            panelTitleBar.TabIndex = 25;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Image = Properties.Resources.eliminar_x24_blanco;
            btnEliminar.ImageAlign = ContentAlignment.TopCenter;
            btnEliminar.Location = new Point(812, 6);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 59);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = ContentAlignment.BottomCenter;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.Image = Properties.Resources.editar_24_blanco;
            btnModificar.ImageAlign = ContentAlignment.TopCenter;
            btnModificar.Location = new Point(709, 6);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(95, 59);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.BottomCenter;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Visible = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageAlign = ContentAlignment.TopCenter;
            btnNuevo.Location = new Point(601, 6);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(95, 59);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextAlign = ContentAlignment.BottomCenter;
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Visible = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnDetalle
            // 
            btnDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetalle.Image = Properties.Resources.buscar_archivo;
            btnDetalle.ImageAlign = ContentAlignment.TopCenter;
            btnDetalle.Location = new Point(1555, 8);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(107, 59);
            btnDetalle.TabIndex = 6;
            btnDetalle.Text = "F7 - Detalle";
            btnDetalle.TextAlign = ContentAlignment.BottomCenter;
            btnDetalle.UseVisualStyleBackColor = true;
            // 
            // btnNuevoMov
            // 
            btnNuevoMov.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoMov.Image = Properties.Resources.flujo_de_efectivo;
            btnNuevoMov.ImageAlign = ContentAlignment.TopCenter;
            btnNuevoMov.Location = new Point(1433, 8);
            btnNuevoMov.Name = "btnNuevoMov";
            btnNuevoMov.Size = new Size(107, 59);
            btnNuevoMov.TabIndex = 5;
            btnNuevoMov.Text = "F5 - Nuevo Mov.";
            btnNuevoMov.TextAlign = ContentAlignment.BottomCenter;
            btnNuevoMov.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Image = Properties.Resources.cancelar_blanco_x24;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(2239, 8);
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
            btnToolImprimir.Location = new Point(2117, 8);
            btnToolImprimir.Name = "btnToolImprimir";
            btnToolImprimir.Size = new Size(107, 59);
            btnToolImprimir.TabIndex = 3;
            btnToolImprimir.Text = "F5 - Imprimir";
            btnToolImprimir.TextAlign = ContentAlignment.BottomCenter;
            btnToolImprimir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(2764, 7);
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
            label1.Size = new Size(106, 30);
            label1.TabIndex = 1;
            label1.Text = "Productos";
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(881, 80);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(30, 29);
            btnBuscar.TabIndex = 27;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInput.Location = new Point(9, 80);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = " Ingrese descripción ó codigo de barra";
            txtInput.Size = new Size(873, 29);
            txtInput.TabIndex = 26;
            txtInput.KeyPress += txtInput_KeyPress;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 499);
            Controls.Add(btnBuscar);
            Controls.Add(txtInput);
            Controls.Add(dgPedidos);
            Controls.Add(panelTitleBar);
            Name = "FrmProductos";
            Text = "FrmProductos";
            Load += FrmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgPedidos).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgPedidos;
        private Panel panelTitleBar;
        private Button btnDetalle;
        private Button btnNuevoMov;
        private Button button1;
        private Button btnToolImprimir;
        private Button btnGuardar;
        private Label label1;
        private Button btnBuscar;
        private TextBox txtInput;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
    }
}