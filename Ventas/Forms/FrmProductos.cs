using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Forms
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            if (General._CONNECTED == "1")
            {
                btnNuevo.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
            }
            else
            {
                btnNuevo.Visible = true;
                btnModificar.Visible = true;
                btnEliminar.Visible = true;
            }

            SetColorTheme();

            ListarProductos();


        }

        private void SetColorTheme()
        {
            //DATAGRID VIEW
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = ThemeColor.SecondaryColor;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = ThemeColor.SecondaryColor;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;


            //BOTONES EN EL TOOLBAR
            if (General._CONNECTED == "0")
            {
                foreach (Control btns in this.panelTitleBar.Controls)
                {
                    if (btns.GetType() == typeof(Button))
                    {
                        Button btn = (Button)btns;
                        btn.BackColor = ThemeColor.PrimaryColor;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                        btn.FlatStyle = FlatStyle.Flat;

                    }
                }
            }



            //PANEL
            panelTitleBar.BackColor = ThemeColor.PrimaryColor;

        }

        private void ListarProductos()
        {

            if (txtInput.Text.Length > 0)
                dgPedidos.DataSource = General._LISTA_PRODUCTOS.FindAll(a => a.DESCRIPCION.Contains(txtInput.Text.ToUpper()) || a.CODIGO_BARRA.Contains(txtInput.Text.ToUpper()));
            else
                dgPedidos.DataSource = General._LISTA_PRODUCTOS;

            dgPedidos.Columns["ID_PRODUCTO"].Width = 90;
            dgPedidos.Columns["CODIGO_PRODUCTO"].Width = 150;
            dgPedidos.Columns["DESCRIPCION"].Width = 250;
            dgPedidos.Columns["PRECIO_VENTA"].Width = 100;
            dgPedidos.Columns["CODIGO_BARRA"].Width = 150;
            dgPedidos.Columns["FECHA_MODIFICACION"].Width = 100;

            dgPedidos.Columns["ID_PRODUCTO"].HeaderText = "ID";
            dgPedidos.Columns["CODIGO_PRODUCTO"].HeaderText = "CODIGO";
            dgPedidos.Columns["PRECIO_VENTA"].HeaderText = "PRECIO";
            dgPedidos.Columns["CODIGO_BARRA"].HeaderText = "C.BARRA";
            dgPedidos.Columns["FECHA_MODIFICACION"].HeaderText = "F.MODIF.";

            dgPedidos.Columns["PRECIO_VENTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns["PRECIO_VENTA"].DefaultCellStyle.Format = "N2";

            dgPedidos.Columns["STOCK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgPedidos.Columns["STOCK"].DefaultCellStyle.Format = "N2";

            dgPedidos.MultiSelect = false;
            dgPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPedidos.AllowUserToAddRows = false;
            dgPedidos.ReadOnly = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ListarProductos();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmProductosNuevo frm = new FrmProductosNuevo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListarProductos();
            }
        }

        private void dgPedidos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Seleccionar()
        {

            if (General._CONNECTED == "1")
                return;

            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {

                Producto pro = dgPedidos.SelectedRows[0].DataBoundItem as Producto;

                FrmProductosNuevo frm = new FrmProductosNuevo();
                if (frm.ShowDialog(pro) == DialogResult.OK)
                {
                    ListarProductos();
                }

                //MessageBox.Show(pro.DESCRIPCION);

            }

        }

        private void dgPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

                
                if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
                {

                Producto pro = dgPedidos.SelectedRows[0].DataBoundItem as Producto;

                List<TaskProductos> LP = new List<TaskProductos>();

                TaskProductos taskP = new TaskProductos();
                taskP.task_id_producto = 0;
                taskP.tipo = "B";             
                LP.Add(taskP);


                if (MessageBox.Show("Seguro que desea eliminar el producto " + pro.DESCRIPCION + " ?", "App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Local.AfectarProductos(LP).Count > 0)
                    {
                        MessageBox.Show("Producto Eliminado con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        ListarProductos();

                        
                    }
                }

                

            }
        }
    }
}
