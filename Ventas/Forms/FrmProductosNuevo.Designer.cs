namespace Ventas.Forms
{
    partial class FrmProductosNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductosNuevo));
            groupBox1 = new GroupBox();
            label5 = new Label();
            txtStock = new TextBox();
            label4 = new Label();
            txtPrecioVenta = new TextBox();
            label3 = new Label();
            txtCodigoBarra = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtCodigo = new TextBox();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPrecioVenta);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCodigoBarra);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(371, 326);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingrese Información";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(22, 227);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 37;
            label5.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtStock.Location = new Point(22, 245);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(105, 29);
            txtStock.TabIndex = 36;
            txtStock.TextAlign = HorizontalAlignment.Right;
            txtStock.KeyPress += txtStock_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(22, 177);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 35;
            label4.Text = "Precio de Venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrecioVenta.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioVenta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrecioVenta.Location = new Point(22, 195);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(105, 29);
            txtPrecioVenta.TabIndex = 34;
            txtPrecioVenta.TextAlign = HorizontalAlignment.Right;
            txtPrecioVenta.KeyPress += txtPrecioVenta_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(22, 125);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 33;
            label3.Text = "Código Barra";
            // 
            // txtCodigoBarra
            // 
            txtCodigoBarra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCodigoBarra.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoBarra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoBarra.Location = new Point(22, 143);
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new Size(305, 29);
            txtCodigoBarra.TabIndex = 32;
            txtCodigoBarra.KeyPress += txtCodigoBarra_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(22, 75);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 31;
            label2.Text = "Descripción";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(22, 25);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 30;
            label1.Text = "Código";
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigo.Location = new Point(22, 43);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(105, 29);
            txtCodigo.TabIndex = 16;
            txtCodigo.KeyPress += txtCodigo_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescripcion.Location = new Point(22, 93);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(305, 29);
            txtDescripcion.TabIndex = 14;
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(398, 22);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 59);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "F5 - Guardar";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(398, 87);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(139, 34);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cerrar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmProductosNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 369);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProductosNuevo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProductosNuevo";
            Load += FrmProductosNuevo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtCodigo;
        private TextBox txtDescripcion;
        private Label label4;
        private TextBox txtPrecioVenta;
        private Label label3;
        private TextBox txtCodigoBarra;
        private Label label2;
        private Label label1;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label5;
        private TextBox txtStock;
    }
}