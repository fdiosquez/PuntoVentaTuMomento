using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Forms
{
    public partial class FrmProductosNuevo : Form
    {
        Producto _pro;
        public FrmProductosNuevo()
        {
            InitializeComponent();
        }

        private void SetColorTheme()
        {


            //BOTONES
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

        private void FrmProductosNuevo_Load(object sender, EventArgs e)
        {
            SetColorTheme();
            if (_pro != null)
            {
                this.Text = "Modificando producto";
                txtCodigo.Text = _pro.CODIGO_PRODUCTO;
                txtDescripcion.Text = _pro.DESCRIPCION;
                txtCodigoBarra.Text = _pro?.CODIGO_BARRA;
                txtPrecioVenta.Text = Convert.ToString(_pro.PRECIO_VENTA);
                txtStock.Text = Convert.ToString(_pro.STOCK);
            }
            else
            {
                this.Text = "Nuevo Producto";
            }

        }

        public DialogResult ShowDialog(Producto p)
        {
            this._pro = p;
            return ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            List<TaskProductos> LP = new List<TaskProductos>();

            if (txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar del producto", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return;
            }


            if (txtPrecioVenta.Text.Length == 0)
            {
                MessageBox.Show("Debe un precio de venta", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Focus();
                return;
            }

            if (txtStock.Text.Length == 0)
                txtStock.Text = "0";


            if (_pro == null)
            {


                TaskProductos taskP = new TaskProductos();

                taskP.task_id_producto = 0;
                taskP.tipo = "A";
                taskP.id_producto = Local.TraerUltimoIdProducto();
                taskP.codigo_producto = txtCodigo.Text;
                taskP.codigo_barra = txtCodigoBarra.Text;
                taskP.descripcion = txtDescripcion.Text;
                taskP.precio = Convert.ToDouble(txtPrecioVenta.Text);
                taskP.stock = Convert.ToInt32(txtStock.Text);

                LP.Add(taskP);


                if (Local.AfectarProductos(LP).Count > 0)
                {
                    MessageBox.Show("Producto Agregado con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    //General._LISTA_PRODUCTOS.Add( General.ConvertTaskProductoToProducto(taskP));
                    General.CargarDatosDeProductos();

                    this.DialogResult = DialogResult.OK;
                }

            }
            else
            {
                TaskProductos taskP = new TaskProductos();

                taskP.task_id_producto = 0;
                taskP.tipo = "M";
                taskP.id_producto = _pro.ID_PRODUCTO;
                taskP.codigo_producto = txtCodigo.Text;
                taskP.codigo_barra = txtCodigoBarra.Text;
                taskP.descripcion = txtDescripcion.Text;
                taskP.precio = Convert.ToDouble(txtPrecioVenta.Text);
                taskP.stock = Convert.ToInt32(txtStock.Text);
                LP.Add(taskP);

                if (Local.AfectarProductos(LP).Count > 0)
                {
                    MessageBox.Show("Producto Modificado con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    General.CargarDatosDeProductos();
                    this.DialogResult = DialogResult.OK;
                }


            }






        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPrecioVenta.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                txtStock.Focus();

                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtStock.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                btnGuardar.Focus();

                e.Handled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                txtDescripcion.Focus();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                txtCodigoBarra.Focus();
            }
        }

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                txtPrecioVenta.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
