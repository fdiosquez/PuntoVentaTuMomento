﻿namespace Ventas.Forms
{
    partial class FrmCtaCteDeudores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCtaCteDeudores));
            dgPedidos = new DataGridView();
            panelTitleBar = new Panel();
            button2 = new Button();
            btnCerrar = new Button();
            btnDetalle = new Button();
            btnNuevoMov = new Button();
            button1 = new Button();
            btnToolImprimir = new Button();
            btnGuardar = new Button();
            label1 = new Label();
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
            dgPedidos.Location = new Point(5, 80);
            dgPedidos.Name = "dgPedidos";
            dgPedidos.RowHeadersVisible = false;
            dgPedidos.RowTemplate.Height = 25;
            dgPedidos.Size = new Size(918, 437);
            dgPedidos.TabIndex = 24;
            dgPedidos.CellDoubleClick += dgPedidos_CellDoubleClick;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(button2);
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
            panelTitleBar.Size = new Size(935, 74);
            panelTitleBar.TabIndex = 25;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Image = Properties.Resources.casilla_de_verificacionX24;
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(817, 8);
            button2.Name = "button2";
            button2.Size = new Size(107, 59);
            button2.TabIndex = 8;
            button2.Text = "Seleccionar";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.Image = Properties.Resources.factura_blanco_x24;
            btnCerrar.ImageAlign = ContentAlignment.TopCenter;
            btnCerrar.Location = new Point(1558, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(107, 59);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "F8 - Cerrar";
            btnCerrar.TextAlign = ContentAlignment.BottomCenter;
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnDetalle
            // 
            btnDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetalle.Image = Properties.Resources.impresora_blanco_x241;
            btnDetalle.ImageAlign = ContentAlignment.TopCenter;
            btnDetalle.Location = new Point(1443, 8);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(107, 59);
            btnDetalle.TabIndex = 6;
            btnDetalle.Text = "F7 - Imprimir";
            btnDetalle.TextAlign = ContentAlignment.BottomCenter;
            btnDetalle.UseVisualStyleBackColor = true;
            // 
            // btnNuevoMov
            // 
            btnNuevoMov.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoMov.Image = Properties.Resources.flujo_de_efectivo;
            btnNuevoMov.ImageAlign = ContentAlignment.TopCenter;
            btnNuevoMov.Location = new Point(1329, 8);
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
            button1.Location = new Point(2243, 8);
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
            btnToolImprimir.Location = new Point(2121, 8);
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
            btnGuardar.Location = new Point(2768, 7);
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
            label1.Size = new Size(294, 30);
            label1.TabIndex = 1;
            label1.Text = "Deudores en Cuenta Corriente";
            // 
            // FrmCtaCteDeudores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 540);
            Controls.Add(dgPedidos);
            Controls.Add(panelTitleBar);
            Name = "FrmCtaCteDeudores";
            Text = "FrmCtaCteDeudores";
            Load += FrmCtaCteDeudores_Load;
            ((System.ComponentModel.ISupportInitialize)dgPedidos).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgPedidos;
        private Panel panelTitleBar;
        private Button btnCerrar;
        private Button btnDetalle;
        private Button btnNuevoMov;
        private Button button1;
        private Button btnToolImprimir;
        private Button btnGuardar;
        private Label label1;
        private Button button2;
    }
}