using MySqlX.XDevAPI;
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
    public partial class FrmCtaCte : Form
    {
        int _ID_CLIENTE;
        bool FLAG_AUTENTICADA = false;
        public FrmCtaCte()
        {
            InitializeComponent();
        }

        private void FrmCtaCte_Load(object sender, EventArgs e)
        {
            SetColorTheme();
            Listar();
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

        private void Listar()
        {

            OleDbDataReader Dr;
            OleDbCommand Cmd;
            OleDbConnection Cnn;
            DataTable Dt = new DataTable();

            string FECHA_DESDE = dtpFechaDesde.Value.ToString("MM/dd/yyyy");
            string FECHA_DESDE2 = dtpFechaDesde.Value.ToString("dd/MM/yyyy");
            string FECHA_HASTA = dtpFechaHasta.Value.ToString("MM/dd/yyyy");
            string ID = _ID_CLIENTE.ToString();

            string sql = @" SELECT  0 AS ID_CUENTA_CORRIENTE,
                                    #{FECHA_DESDE}# AS FECHA, 
                                    'SALDO ANTERIOR AL  {FECHA_DESDE2} ' AS COMPROBANTE, 
                                    (SELECT IIF(ISNULL(SUM(DEBE)),0,SUM(DEBE)) FROM CUENTA_CORRIENTE WHERE ID_CLIENTE = {ID} AND FECHA < #{FECHA_DESDE}# ) AS DEBE, 
                                    (SELECT IIF(ISNULL(SUM(HABER)),0,SUM(HABER)) FROM CUENTA_CORRIENTE WHERE ID_CLIENTE = {ID} AND FECHA < #{FECHA_DESDE}# ) AS HABER 
                            FROM CUENTA_CORRIENTE
                            UNION
                            SELECT  CUENTA_CORRIENTE.ID_CUENTA_CORRIENTE,
                                    CUENTA_CORRIENTE.FECHA, 
                                    IIf(CUENTA_CORRIENTE.ID_CUENTA_CORRIENTE_TIPO=1,'PEDIDO NRO:' & CUENTA_CORRIENTE.ID_COMPROBANTE,'PAGO NRO:' & CUENTA_CORRIENTE.ID_CUENTA_CORRIENTE) AS COMPROBANTE,
                                    CUENTA_CORRIENTE.DEBE, 
                                    CUENTA_CORRIENTE.HABER
                            FROM CUENTA_CORRIENTE_TIPO INNER JOIN CUENTA_CORRIENTE 
                                    ON CUENTA_CORRIENTE_TIPO.ID_CUENTA_CORRIENTE_TIPO = CUENTA_CORRIENTE.ID_CUENTA_CORRIENTE_TIPO
                            WHERE (((CUENTA_CORRIENTE.ID_CLIENTE)={ID}) AND ( CUENTA_CORRIENTE.FECHA Between #{FECHA_DESDE}# AND #{FECHA_HASTA}#))";



            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            sql = sql.Replace("{FECHA_DESDE}", FECHA_DESDE);
            sql = sql.Replace("{FECHA_DESDE2}", FECHA_DESDE2);
            sql = sql.Replace("{FECHA_HASTA}", FECHA_HASTA);
            sql = sql.Replace("{ID}", ID);


            Cmd = new OleDbCommand(sql, Cnn);
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            dgPedidos.DataSource = Dt;


            dgPedidos.Columns["ID_CUENTA_CORRIENTE"].Visible = false;

            dgPedidos.Columns["COMPROBANTE"].Width = 270;

            dgPedidos.Columns["DEBE"].Width = 140;
            dgPedidos.Columns["HABER"].Width = 140;

            dgPedidos.Columns["DEBE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns["DEBE"].DefaultCellStyle.Format = "N2";

            dgPedidos.Columns["HABER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns["HABER"].DefaultCellStyle.Format = "N2";


            dgPedidos.MultiSelect = false;
            dgPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPedidos.AllowUserToAddRows = false;
            dgPedidos.ReadOnly = true;

            CalculoTotales();
        }


        private void CalculoTotales()
        {
            Int32 i;
            double TOTAL_DEBE = 0;
            double TOTAL_HABER = 0;
            double SALDO_FINAL = 0;
            DataGridViewCell CELDA_DEBE;
            DataGridViewCell CELDA_HABER;


            //Recorremos el DataGridView con un bucle for
            for (i = 0; i < dgPedidos.Rows.Count; i++)
            {
                CELDA_DEBE = dgPedidos.Rows[i].Cells["DEBE"];
                TOTAL_DEBE += Convert.ToDouble(CELDA_DEBE.Value);

                CELDA_HABER = dgPedidos.Rows[i].Cells["HABER"];
                TOTAL_HABER += Convert.ToDouble(CELDA_HABER.Value);

            }

            SALDO_FINAL = TOTAL_HABER + TOTAL_DEBE;

            txtDebe.Text = String.Format("{0:N}", TOTAL_DEBE);
            txtHaber.Text = String.Format("{0:N}", TOTAL_HABER);
            txtSaldoFinal.Text = String.Format("{0:N}", SALDO_FINAL);



        }

        public DialogResult ShowDialog(int idCliente)
        {
            _ID_CLIENTE = idCliente;


            string NOMBRE = General._LISTA_CLIENTES.Find(x => x.ID_CLIENTE == _ID_CLIENTE).DESCRIPCION;

            lblTitulo.Text = NOMBRE;

            return ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoMov_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (General._CONNECTED == "1")
            {
                if (!FLAG_AUTENTICADA)
                {
                    if (new FrmLogin().ShowDialog() == DialogResult.OK)                    
                        FLAG_AUTENTICADA = true;                     
                    else
                        return;
                }               
                             
            }

            if (new FrmCtaCtePago().ShowDialog(_ID_CLIENTE) == DialogResult.OK)
            {
                Listar();
            }

        }
    }
}
