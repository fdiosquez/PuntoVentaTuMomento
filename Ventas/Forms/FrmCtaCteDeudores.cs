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
    public partial class FrmCtaCteDeudores : Form
    {
        public FrmCtaCteDeudores()
        {
            InitializeComponent();
        }

        private void FrmCtaCteDeudores_Load(object sender, EventArgs e)
        {
            SetColorTheme();
            Listar();
        }
        public void Refrescar()
        {
            Listar();
        }
        private void Listar()
        {

            OleDbDataReader Dr;
            OleDbCommand Cmd;
            OleDbConnection Cnn;
            DataTable Dt = new DataTable();

            string sql = @"SELECT   ID_CLIENTE AS ID, 
                                    DESCRIPCION AS CLIENTE, 
                                    TELEFONO, 
                                    EMAIL,
                                    SALDO
                            FROM CLIENTES 
                            WHERE SALDO < 0 AND SISTEMA = FALSE
                            ORDER BY DESCRIPCION";


            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            Cmd = new OleDbCommand(sql, Cnn);
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            dgPedidos.DataSource = Dt;

            dgPedidos.Columns[0].Width = 80;
            dgPedidos.Columns[1].Width = 250;
            dgPedidos.Columns[2].Width = 150;
            dgPedidos.Columns[3].Width = 150;

            dgPedidos.Columns["SALDO"].Width = 150;
            dgPedidos.Columns["SALDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns["SALDO"].DefaultCellStyle.Format = "N2";

            //dgPedidos.Columns[2].DefaultCellStyle.Format = "HH:mm:ss";

            dgPedidos.MultiSelect = false;
            dgPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPedidos.AllowUserToAddRows = false;
            dgPedidos.ReadOnly = true;


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



            //BOTONES EN EL FORM
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;

                    if (btn.Name == "btnBuscar")
                    {
                        btn.BackColor = ThemeColor.PrimaryColor;
                        btn.ForeColor = Color.Black;
                        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                        btn.FlatStyle = FlatStyle.Flat;

                    }
                }
            }


            //BOTONES EN EL TOOLBAR
            foreach (Control btns in panelTitleBar.Controls)
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


            //PANEL
            panelTitleBar.BackColor = ThemeColor.PrimaryColor;


        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {
                int ID_CLIENTE = Convert.ToInt32(dgPedidos.CurrentRow.Cells["ID"].Value);

                if (new FrmCtaCte().ShowDialog(ID_CLIENTE) == DialogResult.OK)
                {
                    Listar();
                }

                //Imprimir(ID_CAJA);

            }
        }

        private void dgPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2_Click(dgPedidos,null);
        }
    }
}
