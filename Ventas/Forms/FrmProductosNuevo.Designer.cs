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
            groupBox1 = new GroupBox();
            cboCajaTipo = new ComboBox();
            txtDescripcion = new TextBox();
            txtValor = new TextBox();
            lblBalanceTeorico = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblBalanceTeorico);
            groupBox1.Controls.Add(cboCajaTipo);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtValor);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 294);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingrese Información";
            // 
            // cboCajaTipo
            // 
            cboCajaTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCajaTipo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCajaTipo.FormattingEnabled = true;
            cboCajaTipo.ItemHeight = 21;
            cboCajaTipo.Location = new Point(22, 193);
            cboCajaTipo.Name = "cboCajaTipo";
            cboCajaTipo.Size = new Size(372, 29);
            cboCajaTipo.TabIndex = 17;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescripcion.Location = new Point(22, 43);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(110, 29);
            txtDescripcion.TabIndex = 16;
            // 
            // txtValor
            // 
            txtValor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtValor.BorderStyle = BorderStyle.FixedSingle;
            txtValor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtValor.Location = new Point(22, 93);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(354, 29);
            txtValor.TabIndex = 14;
            // 
            // lblBalanceTeorico
            // 
            lblBalanceTeorico.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBalanceTeorico.AutoSize = true;
            lblBalanceTeorico.Location = new Point(4, 175);
            lblBalanceTeorico.Name = "lblBalanceTeorico";
            lblBalanceTeorico.Size = new Size(39, 15);
            lblBalanceTeorico.TabIndex = 29;
            lblBalanceTeorico.Text = "Rubro";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(4, 25);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 30;
            label1.Text = "Código";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(4, 75);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 31;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(4, 125);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 33;
            label3.Text = "Código Barra";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(22, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(354, 29);
            textBox1.TabIndex = 32;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(4, 230);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 35;
            label4.Text = "Precio de Venta";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(22, 248);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(110, 29);
            textBox2.TabIndex = 34;
            // 
            // FrmProductosNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 349);
            Controls.Add(groupBox1);
            Name = "FrmProductosNuevo";
            Text = "FrmProductosNuevo";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cboCajaTipo;
        private TextBox txtDescripcion;
        private TextBox txtValor;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Label lblBalanceTeorico;
    }
}