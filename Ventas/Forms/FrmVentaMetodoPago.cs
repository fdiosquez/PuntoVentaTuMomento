using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Ventas.Forms
{
    public partial class FrmVentaMetodoPago : Form
    {
        int PANEL_X = 12;
        int PANEL_Y = 91;

        int PANEL_W = 848;
        int PANEL_H = 185;


        private Cliente _CLIENTE_DEFAULT;
        private Button currentButton;
        private double _TOTAL;
        private double _DESCUENTO;
        private double _TOTAL_FINAL;


        private string m_METEDO_OBSERVACION;
        private double m_VALOR_EFECTIVO;
        private double m_VALOR_TRANSFERENCIA;
        private double m_VALOR_DEBITO;
        private double m_VALOR_QR;
        private double m_VALOR_DESCUENTO;
        private double m_VALOR_FINAL;
        private int m_VALOR_TIPO;
        private int m_TIPO_DE_VENTA;
        private Cliente m_CLIENTE;


        public Cliente _CLIENTE //cliente seleccionado
        {
            get { return m_CLIENTE; }
            set { m_CLIENTE = value; }
        }

        public int _TIPO_DE_VENTA //1 = VENTA DIRECTA / 2 = HACIA CTA CTE
        {
            get { return m_TIPO_DE_VENTA; }
            set { m_TIPO_DE_VENTA = value; }
        }

        public int _VALOR_TIPO //corresponde al ID
        {
            get { return m_VALOR_TIPO; }
            set { m_VALOR_TIPO = value; }
        }

        public string _METEDO_OBSERVACION
        {
            get { return m_METEDO_OBSERVACION; }
            set { m_METEDO_OBSERVACION = value; }
        }

        public double _VALOR_EFECTIVO
        {
            get { return m_VALOR_EFECTIVO; }
            set { m_VALOR_EFECTIVO = value; }
        }

        public double _VALOR_TRANSFERENCIA
        {
            get { return m_VALOR_TRANSFERENCIA; }
            set { m_VALOR_TRANSFERENCIA = value; }
        }

        public double _VALOR_DEBITO
        {
            get { return this.m_VALOR_DEBITO; }
            set { m_VALOR_DEBITO = value; }
        }

        public double _VALOR_QR
        {
            get { return m_VALOR_QR; }
            set { m_VALOR_QR = value; }
        }

        public double _VALOR_DESCUENTO
        {
            get { return m_VALOR_DESCUENTO; }
            set { m_VALOR_DESCUENTO = value; }
        }

        public double _VALOR_FINAL
        {
            get { return m_VALOR_FINAL; }
            set { m_VALOR_FINAL = value; }
        }


        public FrmVentaMetodoPago()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(double total)
        {
            _TOTAL = total;
            _DESCUENTO = 0;
            _TOTAL_FINAL = total;
            return ShowDialog();
        }

        private void MuestraTotales()
        {
            lblTotal.Text = string.Format("$ {0:N}", _TOTAL);

            if (_DESCUENTO > 0)
            {
                labelDescuento.Visible = true;
                labelTotalFinal.Visible = true;
                lblDescuento.Visible = true;
                lblTotalFinal.Visible = true;

                lblDescuento.Text = string.Format("% {0:N}", _DESCUENTO);
                lblTotalFinal.Text = string.Format("$ {0:N}", (object)this._TOTAL_FINAL);
            }
            else
            {
                labelDescuento.Visible = false;
                labelTotalFinal.Visible = false;
                lblDescuento.Visible = false;
                lblTotalFinal.Visible = false;
            }

        }

        private void FrmVentaMetodoPago_Load(object sender, EventArgs e)
        {
            DisableButton();
            ActivateButton(btnEfectivo);
            MuestraTotales();
            SetColorTheme();
            BuscarClientePorDefecto();

            btnAceptarCliente.Visible = false;
            btnCancelarCliente.Visible = false;

        }

        private void BuscarClientePorDefecto()
        {

            _CLIENTE = General._LISTA_CLIENTES.Find(x => x.SISTEMA == true);

            if (_CLIENTE == null)
            {
                MessageBox.Show("Falta el cliente de sistema por defecto", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            RecargarDatosCliente();
        }

        private void RecargarDatosCliente()
        {
            txtTelefono.Text = _CLIENTE.TELEFONO;
            txtNombreCompleto.Text = _CLIENTE.DESCRIPCION;
            txtEmail.Text = _CLIENTE.EMAIL;
            if (_CLIENTE.SISTEMA)
            {
                txtTelefono.Enabled = false;
                txtNombreCompleto.Enabled = false;
                txtEmail.Enabled = false;

                //HAGO UNA COPIA DEL CLIENTE EN MEMORIA.
                _CLIENTE_DEFAULT = _CLIENTE;
                gBoxTipoVenta.Enabled = false;
            }
            else
                gBoxTipoVenta.Enabled = true;
        }
        private void SetColorTheme()
        {
            btnCancelar.BackColor = ColorTranslator.FromHtml("#FF5722");
            btnCancelar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;

            btnAceptar.BackColor = ThemeColor.PrimaryColor;
            btnAceptar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ForeColor = Color.White;


            btnBuscar.BackColor = ThemeColor.PrimaryColor;
            btnBuscar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;

            btnBuscar2.BackColor = ThemeColor.PrimaryColor;
            btnBuscar2.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnBuscar2.FlatStyle = FlatStyle.Flat;
            btnBuscar2.ForeColor = Color.White;


            btnBuscar.BackColor = ThemeColor.PrimaryColor;
            btnBuscar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;

            btnAceptarCliente.BackColor = Color.FromArgb(0, 150, 136);
            btnAceptarCliente.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnAceptarCliente.FlatStyle = FlatStyle.Flat;
            btnAceptarCliente.ForeColor = Color.White;


            btnNuevoCliente.BackColor = Color.FromArgb(0, 150, 136);
            btnNuevoCliente.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnNuevoCliente.FlatStyle = FlatStyle.Flat;
            btnNuevoCliente.ForeColor = Color.White;


            btnCancelarCliente.BackColor = Color.FromArgb(0, 150, 136);
            btnCancelarCliente.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnCancelarCliente.FlatStyle = FlatStyle.Flat;
            btnCancelarCliente.ForeColor = Color.White;


        }

        private void DisableButton()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    switch (btn.Name)
                    {
                        case "btnEfectivo":
                            btn.Image = Properties.Resources.dinero_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        case "btnMixto":
                            btn.Image = Properties.Resources.transferencia_movil_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        case "btnQR":
                            btn.Image = Properties.Resources.codigo_qr_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        case "btnTransferencia":
                            btn.Image = Properties.Resources.banco_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        case "btnDebito":
                            btn.Image = Properties.Resources.tarjetas_de_credito_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        case "btnDescuento":
                            btn.Image = Properties.Resources.descuento_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        case "btnCliente":
                            btn.Image = Properties.Resources.descuento_negro;
                            btn.BackColor = Color.FromArgb(224, 224, 224);
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.FlatStyle = FlatStyle.Flat;
                            break;

                    }


                }
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;

                    switch (currentButton.Name)
                    {
                        case "btnEfectivo":
                            currentButton.Image = Properties.Resources.dinero_blanco;
                            this.ActiveControl = txtEfectivoPaga;
                            MuestraPanelEfectivo();
                            break;
                        case "btnMixto":
                            currentButton.Image = Properties.Resources.transferencia_movil_blanco;
                            MuestraPanelMixto();
                            break;
                        case "btnQR":
                            currentButton.Image = Properties.Resources.codigo_qr_blanco;
                            MuestraPanelReferencia("Ejemplo: Mercado Pago, comp N° : 123456");
                            break;
                        case "btnTransferencia":
                            currentButton.Image = Properties.Resources.banco_blanco;
                            MuestraPanelReferencia("Ejemplo: Bco Pcia, comp N° : 123456");
                            break;
                        case "btnDebito":
                            currentButton.Image = Properties.Resources.tarjetas_de_credito_blanco;
                            MuestraPanelReferencia("Ejemplo: Banco HSBC, - comp N° : 123456");
                            break;
                        case "btnDescuento":
                            currentButton.Image = Properties.Resources.descuento_blanco;
                            this.ActiveControl = txtPorcentajeDescuento;
                            MuestraPanelDescuento();
                            break;
                        case "btnCliente":
                            currentButton.Image = Properties.Resources.descuento_blanco;
                            //this.ActiveControl = txtPorcentajeDescuento;
                            MuestraPanelClientes();
                            break;
                    }

                    currentButton.ForeColor = Color.White;
                    currentButton.BackColor = ThemeColor.PrimaryColor;
                }
            }
        }

        private void MuestraPanelEfectivo()
        {
            OcultaPaneles();
            CalculaEfectivo();
            panelEfectivo.Visible = true;
            panelEfectivo.Location = new Point(PANEL_X, PANEL_Y);
            panelEfectivo.Size = new Size(PANEL_W, PANEL_H);

        }

        private void MuestraPanelDescuento()
        {
            OcultaPaneles();
            panelDescuento.Visible = true;
            panelDescuento.Location = new Point(PANEL_X, PANEL_Y);
            panelDescuento.Size = new Size(PANEL_W, PANEL_H);
        }

        private void MuestraPanelReferencia(string PlaceHolder)
        {
            OcultaPaneles();
            txtReferencia.PlaceholderText = PlaceHolder;
            panelReferencia.Visible = true;
            panelReferencia.Location = new Point(PANEL_X, PANEL_Y);
            panelReferencia.Size = new Size(PANEL_W, PANEL_H);
        }

        private void MuestraPanelMixto()
        {
            OcultaPaneles();
            CalculaResto();
            panelMixto.Visible = true;
            panelMixto.Location = new Point(PANEL_X, PANEL_Y);
            panelMixto.Size = new Size(PANEL_W, PANEL_H);
        }

        private void MuestraPanelClientes()
        {
            OcultaPaneles();
            CalculaResto();
            panelCliente.Visible = true;
            panelCliente.Location = new Point(PANEL_X, PANEL_Y);
            panelCliente.Size = new Size(PANEL_W, PANEL_H);

        }

        private void OcultaPaneles()
        {
            foreach (Control panels in this.Controls)
            {
                if (panels.GetType() == typeof(Panel))
                {
                    Panel pnl = (Panel)panels;
                    if (pnl.Name != "panelTitleBar")
                    {
                        pnl.Visible = false;
                    }
                }
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnMixto_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void txtEfectivoPaga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtEfectivoPaga.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;
                btnAceptar.Focus();
                e.Handled = true;
            }
        }

        private void txtEfectivoPaga_TextChanged(object sender, EventArgs e)
        {
            CalculaEfectivo();
        }

        private void CalculaEfectivo()
        {
            if (txtEfectivoPaga.Text == "")
            {
                txtEfectivoVuelto.Text = "0";
            }
            else
            {
                double num = Convert.ToDouble(this.txtEfectivoPaga.Text) - this._TOTAL_FINAL;
                if (num >= 0.0)
                    this.txtEfectivoVuelto.Text = string.Format("{0:N}", (object)num);
                else
                    this.txtEfectivoVuelto.Text = "0";
            }
        }

        private void txtEfectivoVuelto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcentajeDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtPorcentajeDescuento.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                e.Handled = true;
            }
        }

        private void txtPorcentajeDescuento_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPorcentajeDescuento.Text == "" || this.txtPorcentajeDescuento.Text == "0")
            {
                _DESCUENTO = 0;
                _TOTAL_FINAL = _TOTAL; //restaura el valor origninal
            }
            else
            {
                _DESCUENTO = Convert.ToDouble(txtPorcentajeDescuento.Text);
                _TOTAL_FINAL = _TOTAL - Math.Round(_TOTAL * _DESCUENTO / 100, 2);

            }
            MuestraTotales();
        }

        private void txtMixtoEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMixtoEfectivo.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                e.Handled = true;
            }
        }

        private void txtMixtoTransferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMixtoTransferencia.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                e.Handled = true;
            }
        }

        private void txtMixtoDebito_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtMixtoDebito.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                e.Handled = true;
            }
        }

        private void txtMixtoQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMixtoQR.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                e.Handled = true;
            }
        }

        private void CalculaResto()
        {

            double totalPedido = this._TOTAL_FINAL;


            double num1 = this.txtMixtoEfectivo.Text == "" ? 0.0 : Convert.ToDouble(this.txtMixtoEfectivo.Text);
            double num2 = this.txtMixtoTransferencia.Text == "" ? 0.0 : Convert.ToDouble(this.txtMixtoTransferencia.Text);
            double num3 = this.txtMixtoDebito.Text == "" ? 0.0 : Convert.ToDouble(this.txtMixtoDebito.Text);
            double num4 = this.txtMixtoQR.Text == "" ? 0.0 : Convert.ToDouble(this.txtMixtoQR.Text);

            if (num1 > 0.0)
                totalPedido -= num1;
            if (num2 > 0.0)
                totalPedido -= num2;
            if (num3 > 0.0)
                totalPedido -= num3;
            if (num4 > 0.0)
                totalPedido -= num4;

            this.lblMixtoResta.Text = string.Format("${0:N}", totalPedido);
        }

        private void txtMixtoEfectivo_TextChanged(object sender, EventArgs e)
        {
            CalculaResto();
        }

        private void txtMixtoTransferencia_TextChanged(object sender, EventArgs e)
        {
            CalculaResto();
        }

        private void txtMixtoDebito_TextChanged(object sender, EventArgs e)
        {
            CalculaResto();
        }

        private void txtMixtoQR_TextChanged(object sender, EventArgs e)
        {
            CalculaResto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            if (_CLIENTE == null)
            {
                MessageBox.Show("Debe Seleccionar un Cliente para poder realizar el pedido", "Ferrar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            

            switch (currentButton.Name)
            {
                case "btnEfectivo":
                    if (txtEfectivoPaga.Text == "")
                        txtEfectivoPaga.Text = "0";

                    if (Convert.ToDouble(txtEfectivoPaga.Text) <= 0.0)
                    {
                        MessageBox.Show("Debe Ingresar un valor de cobro", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtEfectivoPaga.Focus();
                        return;
                    }

                    if (_TOTAL_FINAL - Convert.ToDouble(txtEfectivoPaga.Text) > 0.0)
                    {
                        MessageBox.Show("El valor ingresado es menor a la venta", "Ferrar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtEfectivoPaga.Focus();
                        txtEfectivoPaga.SelectAll();
                        return;
                    }

                    _METEDO_OBSERVACION = "EFECTIVO";
                    _VALOR_EFECTIVO = _TOTAL_FINAL;
                    _VALOR_TIPO = 2; //ID TABLA CAJA_TIPO
                    break;

                case "btnTransferencia":
                    _METEDO_OBSERVACION = "TRANSFERENCIA: " + txtReferencia.Text;
                    _VALOR_TRANSFERENCIA = _TOTAL_FINAL;
                    _VALOR_TIPO = 3; //ID TABLA CAJA_TIPO
                    break;

                case "btnDebito":
                    _METEDO_OBSERVACION = "DEBITO: " + txtReferencia.Text;
                    _VALOR_DEBITO = _TOTAL_FINAL;
                    _VALOR_TIPO = 4; //ID TABLA CAJA_TIPO
                    break;

                case "btnQR":
                    _METEDO_OBSERVACION = "QR: " + txtReferencia.Text;
                    _VALOR_QR = _TOTAL_FINAL;
                    _VALOR_TIPO = 5; //ID TABLA CAJA_TIPO
                    break;
                case "btnMixto":


                    if (txtMixtoEfectivo.Text == "" && txtMixtoTransferencia.Text == "" && txtMixtoDebito.Text == "" && this.txtMixtoQR.Text == "")
                    {
                        int num = (int)MessageBox.Show("Debe completar almenos  un metedo de pago", "Ferrar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMixtoEfectivo.Focus();
                        return;
                    }

                    double num1 = Convert.ToDouble(lblMixtoResta.Text.Replace(",", ".").Replace(".", "").Replace("$", ""));
                    if (num1 < 0.0)
                    {
                        MessageBox.Show("El valor ingresado es mayor a la venta", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMixtoEfectivo.Focus();
                        return;
                    }

                    if (num1 > 0.0)
                    {
                        MessageBox.Show("Falta ingresar dinero", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMixtoEfectivo.Focus();
                        return;
                    }

                    double num4 = txtMixtoEfectivo.Text == "" ? 0.0 : Convert.ToDouble(txtMixtoEfectivo.Text);
                    double num5 = txtMixtoTransferencia.Text == "" ? 0.0 : Convert.ToDouble(txtMixtoTransferencia.Text);
                    double num6 = txtMixtoDebito.Text == "" ? 0.0 : Convert.ToDouble(txtMixtoDebito.Text);
                    double num7 = txtMixtoQR.Text == "" ? 0.0 : Convert.ToDouble(txtMixtoQR.Text);

                    _VALOR_EFECTIVO = num4;
                    _VALOR_TRANSFERENCIA = num5;
                    _VALOR_DEBITO = num6;
                    _VALOR_QR = num7;

                    List<string> stringList = new List<string>();
                    if (_VALOR_EFECTIVO > 0.0)
                        stringList.Add("EFECTIVO:" + string.Format("${0:N}", _VALOR_EFECTIVO));
                    if (_VALOR_TRANSFERENCIA > 0.0)
                        stringList.Add("TRANSF:" + string.Format("${0:N}", _VALOR_TRANSFERENCIA));
                    if (_VALOR_DEBITO > 0.0)
                        stringList.Add("DEBITO:" + string.Format("${0:N}", _VALOR_DEBITO));
                    if (_VALOR_QR > 0.0)
                        stringList.Add("QR:" + string.Format("${0:N}", _VALOR_QR));

                    _METEDO_OBSERVACION = string.Join("|", stringList.ToArray());
                    _VALOR_TIPO = 6; //ID TABLA CAJA_TIPO
                    break;

                case "btnDescuento":
                    MessageBox.Show("El descuento no es un metedo de pago.\n Debe seleccionar entre Efectivo, Transferencia, Debito , QR ó Mixto", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;

                case "btnCliente": //PARADO EN CTA CTE
                    _METEDO_OBSERVACION = "CTA CTE";
                    _VALOR_TRANSFERENCIA = _TOTAL_FINAL;
                    _VALOR_TIPO = -1; 
                    break;
            }

            _VALOR_DESCUENTO = _DESCUENTO;
            _VALOR_FINAL = _TOTAL_FINAL;


            if (rdoVentaDirecta.Checked)
                this._TIPO_DE_VENTA = 1; //Venta directa
            else
                this._TIPO_DE_VENTA = 2; //cta cte


            this.DialogResult = DialogResult.OK;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {

            //LIMPIO EL CLIENTE POR DEFECTO QUE ESTA EN MEMORIA
            _CLIENTE = new Cliente();

            //RECARGO LOS DATOS VISAULES
            RecargarDatosCliente();

            txtTelefono.Enabled = true;
            txtNombreCompleto.Enabled = true;
            txtEmail.Enabled = true;

            btnNuevoCliente.Visible = false;

            btnAceptarCliente.Visible = true;
            btnCancelarCliente.Visible = true;


            txtTelefono.Focus();

        }

        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            //LIMPIO EL CLIENTE POR DEFECTO QUE ESTA EN MEMORIA
            _CLIENTE = _CLIENTE_DEFAULT;

            //RECARGO LOS DATOS VISAULES
            RecargarDatosCliente();

            txtTelefono.Enabled = false;
            txtNombreCompleto.Enabled = false;
            txtEmail.Enabled = false;

            btnNuevoCliente.Visible = true;

            btnAceptarCliente.Visible = false;
            btnCancelarCliente.Visible = false;

            btnCliente.Focus();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMixtoQR.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                e.Handled = true;
            }
        }

        private void btnAceptarCliente_Click(object sender, EventArgs e)
        {

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Debe Ingresar el telefono", "Ferrar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTelefono.Focus();
                return;
            }



            if (txtNombreCompleto.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Nombre del cliente", "Ferrar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtNombreCompleto.Focus();
                return;
            }

            Cliente cli = new Cliente();
            cli.DESCRIPCION = txtNombreCompleto.Text;
            cli.TELEFONO = txtTelefono.Text;
            cli.EMAIL = txtEmail.Text;

            if (Local.GrabaCliente(cli))
            {
                MessageBox.Show("Cliente Agregado con Exito", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //RECARGO EN MEMORIA

                Cursor.Current = Cursors.WaitCursor;
                General.CargarDatosDeClientes();
                Cursor.Current = Cursors.Default;

                _CLIENTE = General._LISTA_CLIENTES.Find(x => x.TELEFONO == cli.TELEFONO);

                if (_CLIENTE == null)
                {
                    MessageBox.Show("Error interno de sistema no puedo recargar el cliente", "App", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                RecargarDatosCliente();

                txtTelefono.Enabled = false;
                txtNombreCompleto.Enabled = false;
                txtEmail.Enabled = false;

                btnNuevoCliente.Visible = true;

                btnAceptarCliente.Visible = false;
                btnCancelarCliente.Visible = false;

            }




        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }

        private void SeleccionarCliente()
        {

            btnCancelarCliente_Click(null, null);

            FrmVentaConsultasCliente frm = new FrmVentaConsultasCliente();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _CLIENTE = frm._CLIENTE;
                RecargarDatosCliente();
            }



        }

        private void rdoVentaDirecta_CheckedChanged(object sender, EventArgs e)
        {
            btnEfectivo.Enabled = true;
            btnTransferencia.Enabled = true;
            btnDebito.Enabled = true;
            btnQR.Enabled = true;
            btnMixto.Enabled = true;
            btnDescuento.Enabled = true;

        }

        private void rdoCuentaCorriente_CheckedChanged(object sender, EventArgs e)
        {
            btnEfectivo.Enabled = false;
            btnTransferencia.Enabled = false;
            btnDebito.Enabled = false;
            btnQR.Enabled = false;
            btnMixto.Enabled = false;
            btnDescuento.Enabled = false;
        }
    }
}
