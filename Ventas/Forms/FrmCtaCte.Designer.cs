namespace Ventas.Forms
{
    partial class FrmCtaCte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCtaCte));
            dgPedidos = new DataGridView();
            label1 = new Label();
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            label2 = new Label();
            panelTitleBar = new Panel();
            label3 = new Label();
            button2 = new Button();
            btnNuevoMov = new Button();
            lblTitulo = new Label();
            lblTotalFinal = new Label();
            labelTotalFinal = new Label();
            txtDebe = new TextBox();
            txtHaber = new TextBox();
            txtSaldoFinal = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
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
            dgPedidos.Location = new Point(12, 125);
            dgPedidos.Name = "dgPedidos";
            dgPedidos.RowHeadersVisible = false;
            dgPedidos.RowTemplate.Height = 25;
            dgPedidos.Size = new Size(751, 357);
            dgPedidos.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 78);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 27;
            label1.Text = "Fecha Desde";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(6, 96);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(115, 23);
            dtpFechaDesde.TabIndex = 26;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(159, 96);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(113, 23);
            dtpFechaHasta.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(159, 78);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 28;
            label2.Text = "Fecha Hasta";
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(label3);
            panelTitleBar.Controls.Add(button2);
            panelTitleBar.Controls.Add(btnNuevoMov);
            panelTitleBar.Controls.Add(lblTitulo);
            panelTitleBar.Controls.Add(lblTotalFinal);
            panelTitleBar.Controls.Add(labelTotalFinal);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(775, 74);
            panelTitleBar.TabIndex = 30;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 9);
            label3.Name = "label3";
            label3.Size = new Size(217, 30);
            label3.TabIndex = 9;
            label3.Text = "CUENTA CORRIENTE :";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(659, 6);
            button2.Name = "button2";
            button2.Size = new Size(107, 59);
            button2.TabIndex = 8;
            button2.Text = "Nuevo Pago";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnNuevoMov
            // 
            btnNuevoMov.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoMov.Image = (Image)resources.GetObject("btnNuevoMov.Image");
            btnNuevoMov.ImageAlign = ContentAlignment.TopCenter;
            btnNuevoMov.Location = new Point(540, 7);
            btnNuevoMov.Name = "btnNuevoMov";
            btnNuevoMov.Size = new Size(107, 59);
            btnNuevoMov.TabIndex = 7;
            btnNuevoMov.Text = "Buscar";
            btnNuevoMov.TextAlign = ContentAlignment.BottomCenter;
            btnNuevoMov.UseVisualStyleBackColor = true;
            btnNuevoMov.Click += btnNuevoMov_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(165, 25);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "{INFO_PERSONAL}";
            // 
            // lblTotalFinal
            // 
            lblTotalFinal.Anchor = AnchorStyles.None;
            lblTotalFinal.AutoSize = true;
            lblTotalFinal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalFinal.ForeColor = Color.White;
            lblTotalFinal.Location = new Point(1001, -4);
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
            labelTotalFinal.Location = new Point(903, -4);
            labelTotalFinal.Name = "labelTotalFinal";
            labelTotalFinal.Size = new Size(106, 21);
            labelTotalFinal.TabIndex = 4;
            labelTotalFinal.Text = "TOTAL FINAL :";
            // 
            // txtDebe
            // 
            txtDebe.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtDebe.Location = new Point(653, 488);
            txtDebe.Name = "txtDebe";
            txtDebe.ReadOnly = true;
            txtDebe.Size = new Size(110, 27);
            txtDebe.TabIndex = 31;
            txtDebe.TextAlign = HorizontalAlignment.Right;
            // 
            // txtHaber
            // 
            txtHaber.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtHaber.Location = new Point(653, 521);
            txtHaber.Name = "txtHaber";
            txtHaber.ReadOnly = true;
            txtHaber.Size = new Size(110, 27);
            txtHaber.TabIndex = 32;
            txtHaber.TextAlign = HorizontalAlignment.Right;
            // 
            // txtSaldoFinal
            // 
            txtSaldoFinal.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtSaldoFinal.Location = new Point(653, 554);
            txtSaldoFinal.Name = "txtSaldoFinal";
            txtSaldoFinal.ReadOnly = true;
            txtSaldoFinal.Size = new Size(110, 27);
            txtSaldoFinal.TabIndex = 33;
            txtSaldoFinal.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(561, 489);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 34;
            label5.Text = "Total Debe:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(557, 521);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 35;
            label6.Text = "Total Haber:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(562, 557);
            label7.Name = "label7";
            label7.Size = new Size(85, 20);
            label7.TabIndex = 36;
            label7.Text = "Saldo Final:";
            // 
            // FrmCtaCte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 587);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtSaldoFinal);
            Controls.Add(txtHaber);
            Controls.Add(txtDebe);
            Controls.Add(panelTitleBar);
            Controls.Add(dtpFechaHasta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFechaDesde);
            Controls.Add(dgPedidos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCtaCte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de movimientos";
            Load += FrmCtaCte_Load;
            ((System.ComponentModel.ISupportInitialize)dgPedidos).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgPedidos;
        private Label label1;
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label label2;
        private Panel panelTitleBar;
        private Label lblTotalFinal;
        private Label labelTotalFinal;
        private Label lblTitulo;
        private Button button2;
        private Button btnNuevoMov;
        private TextBox txtDebe;
        private TextBox txtHaber;
        private TextBox txtSaldoFinal;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label3;
    }
}