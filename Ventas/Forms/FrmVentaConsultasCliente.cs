using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Forms
{
    public partial class FrmVentaConsultasCliente : Form
    {


        private Cliente m_CLIENTE;

        public Cliente _CLIENTE //corresponde al ID
        {
            get { return m_CLIENTE; }
            set { m_CLIENTE = value; }
        }

        public FrmVentaConsultasCliente()
        {
            InitializeComponent();
        }

        private void FrmVentaConsultasCliente_Load(object sender, EventArgs e)
        {
            ListarClientes();
            SetColorTheme();
        }

        private void SetColorTheme()
        {

            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    if (btn.Name == "btnCancelar")
                        btn.BackColor = ColorTranslator.FromHtml("#FF5722");
                    else
                        btn.BackColor = ThemeColor.PrimaryColor;

                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;


                    btn.FlatStyle = FlatStyle.Flat;
                }
            }

        }

        private void ListarClientes()
        {



            if (txtBuscadorClientes.Text.Length > 0)
                dgClientes.DataSource = General._LISTA_CLIENTES.FindAll(a => a.DESCRIPCION.Contains(txtBuscadorClientes.Text.ToUpper()) || a.TELEFONO.Contains(txtBuscadorClientes.Text.ToUpper()));
            else
                dgClientes.DataSource = General._LISTA_CLIENTES;



            dgClientes.Columns["ID_CLIENTE"].Visible = false;
            dgClientes.Columns["SISTEMA"].Visible = false;
            dgClientes.Columns["SALDO"].Visible = false;

            dgClientes.Columns["DESCRIPCION"].Width = 150;
            dgClientes.Columns["TELEFONO"].Width = 150;


            dgClientes.MultiSelect = false;
            dgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgClientes.AllowUserToAddRows = false;
            dgClientes.ReadOnly = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void txtBuscadorClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnBuscar.Focus();
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            if (dgClientes.RowCount >= 1 && dgClientes.CurrentRow.Index != -1)
            {

                DataGridViewRow row = dgClientes.Rows[dgClientes.CurrentRow.Index];

                m_CLIENTE = (Cliente)row.DataBoundItem;


                this.DialogResult = DialogResult.OK;
            }


        }

        private void dgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSumar_Click(btnSumar, null);
            }
        }
    }
}
