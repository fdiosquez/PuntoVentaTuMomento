namespace Ventas.Forms
{
    partial class FrmVentaMetodoPago
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
            btnQR = new Button();
            btnTransferencia = new Button();
            btnEfectivo = new Button();
            btnDebito = new Button();
            btnMixto = new Button();
            btnDescuento = new Button();
            panelTitleBar = new Panel();
            lblTotalFinal = new Label();
            labelTotalFinal = new Label();
            lblDescuento = new Label();
            labelDescuento = new Label();
            lblTotal = new Label();
            lblTitle = new Label();
            panelEfectivo = new Panel();
            label7 = new Label();
            txtEfectivoVuelto = new TextBox();
            label6 = new Label();
            txtEfectivoPaga = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            panelDescuento = new Panel();
            label2 = new Label();
            txtPorcentajeDescuento = new TextBox();
            panelReferencia = new Panel();
            label1 = new Label();
            txtReferencia = new TextBox();
            panelMixto = new Panel();
            lblMixtoResta = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            txtMixtoQR = new TextBox();
            label5 = new Label();
            txtMixtoDebito = new TextBox();
            label4 = new Label();
            txtMixtoTransferencia = new TextBox();
            label3 = new Label();
            txtMixtoEfectivo = new TextBox();
            panelTitleBar.SuspendLayout();
            panelEfectivo.SuspendLayout();
            panelDescuento.SuspendLayout();
            panelReferencia.SuspendLayout();
            panelMixto.SuspendLayout();
            SuspendLayout();
            // 
            // btnQR
            // 
            btnQR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQR.Image = Properties.Resources.codigo_qr_negro;
            btnQR.ImageAlign = ContentAlignment.MiddleLeft;
            btnQR.Location = new Point(418, 48);
            btnQR.Name = "btnQR";
            btnQR.Size = new Size(116, 34);
            btnQR.TabIndex = 15;
            btnQR.Text = "QR";
            btnQR.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnQR.UseVisualStyleBackColor = true;
            btnQR.Click += btnQR_Click;
            // 
            // btnTransferencia
            // 
            btnTransferencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTransferencia.Image = Properties.Resources.banco_negro;
            btnTransferencia.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransferencia.Location = new Point(174, 48);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(116, 34);
            btnTransferencia.TabIndex = 14;
            btnTransferencia.Text = "Transferencia";
            btnTransferencia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTransferencia.UseVisualStyleBackColor = true;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // btnEfectivo
            // 
            btnEfectivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEfectivo.Image = Properties.Resources.dinero_negro;
            btnEfectivo.ImageAlign = ContentAlignment.MiddleLeft;
            btnEfectivo.Location = new Point(52, 48);
            btnEfectivo.Name = "btnEfectivo";
            btnEfectivo.Size = new Size(116, 34);
            btnEfectivo.TabIndex = 13;
            btnEfectivo.Text = "Efectivo";
            btnEfectivo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEfectivo.UseVisualStyleBackColor = true;
            btnEfectivo.Click += btnEfectivo_Click;
            // 
            // btnDebito
            // 
            btnDebito.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDebito.Image = Properties.Resources.tarjetas_de_credito_negro;
            btnDebito.ImageAlign = ContentAlignment.MiddleLeft;
            btnDebito.Location = new Point(296, 48);
            btnDebito.Name = "btnDebito";
            btnDebito.Size = new Size(116, 34);
            btnDebito.TabIndex = 12;
            btnDebito.Text = "Debito";
            btnDebito.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDebito.UseVisualStyleBackColor = true;
            btnDebito.Click += btnDebito_Click;
            // 
            // btnMixto
            // 
            btnMixto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMixto.Image = Properties.Resources.transferencia_movil_negro;
            btnMixto.ImageAlign = ContentAlignment.MiddleLeft;
            btnMixto.Location = new Point(540, 48);
            btnMixto.Name = "btnMixto";
            btnMixto.Size = new Size(116, 34);
            btnMixto.TabIndex = 16;
            btnMixto.Text = "Mixto";
            btnMixto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMixto.UseVisualStyleBackColor = true;
            btnMixto.Click += btnMixto_Click;
            // 
            // btnDescuento
            // 
            btnDescuento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDescuento.BackColor = Color.FromArgb(224, 224, 224);
            btnDescuento.Image = Properties.Resources.descuento_negro;
            btnDescuento.ImageAlign = ContentAlignment.MiddleLeft;
            btnDescuento.Location = new Point(662, 48);
            btnDescuento.Name = "btnDescuento";
            btnDescuento.Size = new Size(116, 34);
            btnDescuento.TabIndex = 17;
            btnDescuento.Text = "Descuento";
            btnDescuento.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDescuento.UseVisualStyleBackColor = false;
            btnDescuento.Click += btnDescuento_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(lblTotalFinal);
            panelTitleBar.Controls.Add(labelTotalFinal);
            panelTitleBar.Controls.Add(lblDescuento);
            panelTitleBar.Controls.Add(labelDescuento);
            panelTitleBar.Controls.Add(lblTotal);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(797, 42);
            panelTitleBar.TabIndex = 18;
            // 
            // lblTotalFinal
            // 
            lblTotalFinal.Anchor = AnchorStyles.None;
            lblTotalFinal.AutoSize = true;
            lblTotalFinal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalFinal.ForeColor = Color.White;
            lblTotalFinal.Location = new Point(684, 9);
            lblTotalFinal.Name = "lblTotalFinal";
            lblTotalFinal.Size = new Size(101, 21);
            lblTotalFinal.TabIndex = 5;
            lblTotalFinal.Text = "$ 000.000,00";
            // 
            // labelTotalFinal
            // 
            labelTotalFinal.Anchor = AnchorStyles.None;
            labelTotalFinal.AutoSize = true;
            labelTotalFinal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTotalFinal.ForeColor = Color.White;
            labelTotalFinal.Location = new Point(586, 9);
            labelTotalFinal.Name = "labelTotalFinal";
            labelTotalFinal.Size = new Size(106, 21);
            labelTotalFinal.TabIndex = 4;
            labelTotalFinal.Text = "TOTAL FINAL :";
            // 
            // lblDescuento
            // 
            lblDescuento.Anchor = AnchorStyles.None;
            lblDescuento.AutoSize = true;
            lblDescuento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescuento.ForeColor = Color.White;
            lblDescuento.Location = new Point(418, 9);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(41, 21);
            lblDescuento.TabIndex = 3;
            lblDescuento.Text = "%00";
            // 
            // labelDescuento
            // 
            labelDescuento.Anchor = AnchorStyles.None;
            labelDescuento.AutoSize = true;
            labelDescuento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescuento.ForeColor = Color.White;
            labelDescuento.Location = new Point(318, 9);
            labelDescuento.Name = "labelDescuento";
            labelDescuento.Size = new Size(105, 21);
            labelDescuento.TabIndex = 2;
            labelDescuento.Text = "DESCUENTO :";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.None;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(118, 9);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(101, 21);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "$ 000.000,00";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(11, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(111, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TOTAL VENTA :";
            // 
            // panelEfectivo
            // 
            panelEfectivo.BorderStyle = BorderStyle.FixedSingle;
            panelEfectivo.Controls.Add(label7);
            panelEfectivo.Controls.Add(txtEfectivoVuelto);
            panelEfectivo.Controls.Add(label6);
            panelEfectivo.Controls.Add(txtEfectivoPaga);
            panelEfectivo.Location = new Point(52, 91);
            panelEfectivo.Name = "panelEfectivo";
            panelEfectivo.Size = new Size(726, 185);
            panelEfectivo.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(53, 66);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 6;
            label7.Text = "Su vuelto :";
            // 
            // txtEfectivoVuelto
            // 
            txtEfectivoVuelto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEfectivoVuelto.BorderStyle = BorderStyle.FixedSingle;
            txtEfectivoVuelto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEfectivoVuelto.Location = new Point(121, 59);
            txtEfectivoVuelto.Name = "txtEfectivoVuelto";
            txtEfectivoVuelto.ReadOnly = true;
            txtEfectivoVuelto.Size = new Size(116, 29);
            txtEfectivoVuelto.TabIndex = 5;
            txtEfectivoVuelto.Text = "0";
            txtEfectivoVuelto.TextAlign = HorizontalAlignment.Right;
            txtEfectivoVuelto.TextChanged += txtEfectivoVuelto_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 31);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 4;
            label6.Text = "Paga con :";
            // 
            // txtEfectivoPaga
            // 
            txtEfectivoPaga.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEfectivoPaga.BorderStyle = BorderStyle.FixedSingle;
            txtEfectivoPaga.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEfectivoPaga.Location = new Point(121, 24);
            txtEfectivoPaga.Name = "txtEfectivoPaga";
            txtEfectivoPaga.Size = new Size(116, 29);
            txtEfectivoPaga.TabIndex = 3;
            txtEfectivoPaga.TextAlign = HorizontalAlignment.Right;
            txtEfectivoPaga.TextChanged += txtEfectivoPaga_TextChanged;
            txtEfectivoPaga.KeyPress += txtEfectivoPaga_KeyPress;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAceptar.BackColor = Color.FromArgb(224, 224, 224);
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(662, 282);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(116, 34);
            btnAceptar.TabIndex = 20;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.FromArgb(224, 224, 224);
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(51, 282);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 34);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panelDescuento
            // 
            panelDescuento.BorderStyle = BorderStyle.FixedSingle;
            panelDescuento.Controls.Add(label2);
            panelDescuento.Controls.Add(txtPorcentajeDescuento);
            panelDescuento.Location = new Point(52, 335);
            panelDescuento.Name = "panelDescuento";
            panelDescuento.Size = new Size(726, 185);
            panelDescuento.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 31);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "% Descuento :";
            // 
            // txtPorcentajeDescuento
            // 
            txtPorcentajeDescuento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPorcentajeDescuento.BorderStyle = BorderStyle.FixedSingle;
            txtPorcentajeDescuento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPorcentajeDescuento.Location = new Point(121, 24);
            txtPorcentajeDescuento.Name = "txtPorcentajeDescuento";
            txtPorcentajeDescuento.Size = new Size(117, 29);
            txtPorcentajeDescuento.TabIndex = 3;
            txtPorcentajeDescuento.TextAlign = HorizontalAlignment.Right;
            txtPorcentajeDescuento.TextChanged += txtPorcentajeDescuento_TextChanged;
            txtPorcentajeDescuento.KeyPress += txtPorcentajeDescuento_KeyPress;
            // 
            // panelReferencia
            // 
            panelReferencia.BorderStyle = BorderStyle.FixedSingle;
            panelReferencia.Controls.Add(label1);
            panelReferencia.Controls.Add(txtReferencia);
            panelReferencia.Location = new Point(759, 522);
            panelReferencia.Name = "panelReferencia";
            panelReferencia.Size = new Size(726, 185);
            panelReferencia.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 31);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 4;
            label1.Text = "Referencia  :";
            // 
            // txtReferencia
            // 
            txtReferencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReferencia.BorderStyle = BorderStyle.FixedSingle;
            txtReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtReferencia.Location = new Point(121, 24);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(568, 29);
            txtReferencia.TabIndex = 3;
            // 
            // panelMixto
            // 
            panelMixto.BorderStyle = BorderStyle.FixedSingle;
            panelMixto.Controls.Add(lblMixtoResta);
            panelMixto.Controls.Add(label10);
            panelMixto.Controls.Add(label9);
            panelMixto.Controls.Add(label8);
            panelMixto.Controls.Add(txtMixtoQR);
            panelMixto.Controls.Add(label5);
            panelMixto.Controls.Add(txtMixtoDebito);
            panelMixto.Controls.Add(label4);
            panelMixto.Controls.Add(txtMixtoTransferencia);
            panelMixto.Controls.Add(label3);
            panelMixto.Controls.Add(txtMixtoEfectivo);
            panelMixto.Location = new Point(52, 526);
            panelMixto.Name = "panelMixto";
            panelMixto.Size = new Size(726, 185);
            panelMixto.TabIndex = 24;
            // 
            // lblMixtoResta
            // 
            lblMixtoResta.AutoSize = true;
            lblMixtoResta.Location = new Point(170, 154);
            lblMixtoResta.Name = "lblMixtoResta";
            lblMixtoResta.Size = new Size(70, 15);
            lblMixtoResta.TabIndex = 13;
            lblMixtoResta.Text = "$ 100,000.00";
            lblMixtoResta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(83, 139);
            label10.Name = "label10";
            label10.Size = new Size(157, 15);
            label10.TabIndex = 12;
            label10.Text = "------------------------------";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(71, 154);
            label9.Name = "label9";
            label9.Size = new Size(41, 15);
            label9.TabIndex = 11;
            label9.Text = "Resta :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(64, 82);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 10;
            label8.Text = "Debito :";
            // 
            // txtMixtoQR
            // 
            txtMixtoQR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMixtoQR.BorderStyle = BorderStyle.FixedSingle;
            txtMixtoQR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMixtoQR.Location = new Point(121, 110);
            txtMixtoQR.Name = "txtMixtoQR";
            txtMixtoQR.Size = new Size(117, 29);
            txtMixtoQR.TabIndex = 9;
            txtMixtoQR.TextAlign = HorizontalAlignment.Right;
            txtMixtoQR.TextChanged += txtMixtoQR_TextChanged;
            txtMixtoQR.KeyPress += txtMixtoQR_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(83, 117);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 8;
            label5.Text = "QR :";
            // 
            // txtMixtoDebito
            // 
            txtMixtoDebito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMixtoDebito.BorderStyle = BorderStyle.FixedSingle;
            txtMixtoDebito.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMixtoDebito.Location = new Point(121, 75);
            txtMixtoDebito.Name = "txtMixtoDebito";
            txtMixtoDebito.Size = new Size(117, 29);
            txtMixtoDebito.TabIndex = 7;
            txtMixtoDebito.TextAlign = HorizontalAlignment.Right;
            txtMixtoDebito.TextChanged += txtMixtoDebito_TextChanged;
            txtMixtoDebito.KeyPress += txtMixtoDebito_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 47);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 6;
            label4.Text = "Transferencia :";
            // 
            // txtMixtoTransferencia
            // 
            txtMixtoTransferencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMixtoTransferencia.BorderStyle = BorderStyle.FixedSingle;
            txtMixtoTransferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMixtoTransferencia.Location = new Point(121, 40);
            txtMixtoTransferencia.Name = "txtMixtoTransferencia";
            txtMixtoTransferencia.Size = new Size(117, 29);
            txtMixtoTransferencia.TabIndex = 5;
            txtMixtoTransferencia.TextAlign = HorizontalAlignment.Right;
            txtMixtoTransferencia.TextChanged += txtMixtoTransferencia_TextChanged;
            txtMixtoTransferencia.KeyPress += txtMixtoTransferencia_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 15);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Efectivo :";
            // 
            // txtMixtoEfectivo
            // 
            txtMixtoEfectivo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMixtoEfectivo.BorderStyle = BorderStyle.FixedSingle;
            txtMixtoEfectivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMixtoEfectivo.Location = new Point(121, 5);
            txtMixtoEfectivo.Name = "txtMixtoEfectivo";
            txtMixtoEfectivo.Size = new Size(117, 29);
            txtMixtoEfectivo.TabIndex = 3;
            txtMixtoEfectivo.TextAlign = HorizontalAlignment.Right;
            txtMixtoEfectivo.TextChanged += txtMixtoEfectivo_TextChanged;
            txtMixtoEfectivo.KeyPress += txtMixtoEfectivo_KeyPress;
            // 
            // FrmVentaMetodoPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 328);
            Controls.Add(panelMixto);
            Controls.Add(panelReferencia);
            Controls.Add(panelDescuento);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(panelEfectivo);
            Controls.Add(panelTitleBar);
            Controls.Add(btnDescuento);
            Controls.Add(btnMixto);
            Controls.Add(btnQR);
            Controls.Add(btnTransferencia);
            Controls.Add(btnEfectivo);
            Controls.Add(btnDebito);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVentaMetodoPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Metedo de Pago";
            Load += FrmVentaMetodoPago_Load;
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelEfectivo.ResumeLayout(false);
            panelEfectivo.PerformLayout();
            panelDescuento.ResumeLayout(false);
            panelDescuento.PerformLayout();
            panelReferencia.ResumeLayout(false);
            panelReferencia.PerformLayout();
            panelMixto.ResumeLayout(false);
            panelMixto.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnQR;
        private Button btnTransferencia;
        private Button btnEfectivo;
        private Button btnDebito;
        private Button btnMixto;
        private Button btnDescuento;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Label lblTotalFinal;
        private Label labelTotalFinal;
        private Label lblDescuento;
        private Label labelDescuento;
        private Label lblTotal;
        private Panel panelEfectivo;
        private TextBox txtEfectivoPaga;
        private Label label7;
        private TextBox txtEfectivoVuelto;
        private Label label6;
        private Button btnAceptar;
        private Button btnCancelar;
        private Panel panelDescuento;
        private Label label2;
        private TextBox txtPorcentajeDescuento;
        private Panel panelReferencia;
        private Label label1;
        private TextBox txtReferencia;
        private Panel panelMixto;
        private Label lblMixtoResta;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtMixtoQR;
        private Label label5;
        private TextBox txtMixtoDebito;
        private Label label4;
        private TextBox txtMixtoTransferencia;
        private Label label3;
        private TextBox txtMixtoEfectivo;
    }
}