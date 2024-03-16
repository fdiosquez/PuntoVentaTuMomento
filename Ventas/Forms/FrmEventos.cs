using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Forms
{
    public partial class FrmEventos : Form
    {
        private Button currentButton;


        public FrmEventos()
        {
            InitializeComponent();
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

        private void DisableButtonFecha()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;

                    if (btn.Name.Substring(0, 8) == "btnFecha")
                    {
                        btn.Image = Properties.Resources.calendario_negrox16;
                        btn.BackColor = Color.FromArgb(224, 224, 224);
                        btn.ForeColor = Color.Black;
                        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                        btn.FlatStyle = FlatStyle.Flat;
                    }
                }
            }
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                DisableButtonFecha();
                currentButton = (Button)btnSender;

                if (((Button)btnSender).Name != "btnBuscar")
                {
                    currentButton.Image = Properties.Resources.calendario_blancox16;
                    currentButton.ForeColor = Color.White;
                    currentButton.BackColor = ThemeColor.PrimaryColor;
                }
                Buscar();

            }
        }

        private void FrmEventos_Load(object sender, EventArgs e)
        {
            SetColorTheme();
            ActivateButton(btnFechaHoy);
        }
        public void Refrescar() 
        {
            ActivateButton(btnFechaHoy);
        }
        private void Buscar()
        {

            OleDbDataReader Dr;
            OleDbCommand Cmd;
            OleDbConnection Cnn;
            DataTable Dt = new DataTable();

            string sql = @"SELECT  ID_LOG AS ID,FECHA,HORA,DESCRIPCION,ESTADO FROM LOG WHERE 1=1 AND ";


            switch (currentButton.Name)
            {
                case "btnFechaHoy":
                    sql += " FECHA = #" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#";

                    break;
                case "btnFechaAyer":
                    DateTime yesterday = DateTime.Today.AddDays(-1);
                    sql += " FECHA = #" + yesterday.ToString("MM/dd/yyyy") + "#";

                    break;
            }

            sql += " ORDER BY ID_LOG DESC ";

            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            Cmd = new OleDbCommand(sql, Cnn);
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            dgPedidos.DataSource = Dt;
            dgPedidos.Columns[0].Width = 80;
            dgPedidos.Columns[1].Width = 100;
            dgPedidos.Columns[2].Width = 100;
            dgPedidos.Columns[3].Width = 400;

            dgPedidos.Columns[2].DefaultCellStyle.Format = "HH:mm:ss";

            dgPedidos.MultiSelect = false;
            dgPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPedidos.AllowUserToAddRows = false;
            dgPedidos.ReadOnly = true;


        }

        private void btnFechaHoy_Click(object sender, EventArgs e)
        {
            ActivateButton(btnFechaHoy);
        }

        private void btnFechaAyer_Click(object sender, EventArgs e)
        {
            ActivateButton(btnFechaAyer);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Orquestador.SubirPedidos();
            //Orquestador.BajarProductos();

            
            FrmEsperar frm = new FrmEsperar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                General.CargarDatosDeProductos();
            }


            ActivateButton(currentButton);
            
        }

        
    }
}
