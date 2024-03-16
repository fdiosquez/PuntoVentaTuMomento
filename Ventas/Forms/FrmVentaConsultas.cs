using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Ventas.Forms
{
    public partial class FrmVentaConsultas : Form
    {
        private Button currentButton;


        public FrmVentaConsultas()
        {
            InitializeComponent();
        }

        private void FrmVentaConsultas_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            SetColorTheme();
            DisableButtonFecha();
            ActivateButton(btnFechaHoy);
            ResumeLayout(false);
            PerformLayout();
        }

        public void Refrescar() 
        {
            ActivateButton(btnFechaHoy);
        }

        private void Imprimir(int id_pedido)
        {

            if (!File.Exists(General._COMERCIO_LOGO))
            {
                MessageBox.Show("No se puede imprimir ticket, Falta configurar el logo.");
                return;
            }

            Ticket.ID_PEDIDO = id_pedido;

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = General._PRINTER_TICKET;
                printDoc.PrintPage += new PrintPageEventHandler(Ticket.Crear);
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void Buscar()
        {

            OleDbDataReader Dr;
            OleDbCommand Cmd;
            OleDbConnection Cnn;
            DataTable Dt = new DataTable();

            string sql = @"SELECT   PEDIDOS.ID_PEDIDO, 
                                    PEDIDOS.FECHA, 
                                    PEDIDOS.ID_PEDIDO as NRO_COMPROBANTE, 
                                    PEDIDOS.TOTAL_FINAL, 
                                    PEDIDOS.OBSERVACIONES,
                                    PEDIDOS.CANCELADO,
                                    PEDIDOS.PROCESADO
                            FROM PEDIDOS
                            WHERE 1=1 ";

            //    
            //; WHERE(PEDIDOS.Fecha Between #" + dtpFechaDesde.Value.ToString("MM/dd/yyyy") + "# And #" + dtpFechaHasta.Value.ToString("MM/dd/yyyy") + "#)";        
            // 46


            switch (currentButton.Name)
            {
                case "btnFechaHoy":
                    sql += "AND PEDIDOS.Fecha = #" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#";
                    lblFiltroAplicado.Text = "";
                    txtInput.Text = "";
                    break;
                case "btnFechaAyer":
                    DateTime yesterday = DateTime.Today.AddDays(-1);
                    sql += "AND PEDIDOS.Fecha = #" + yesterday.ToString("MM/dd/yyyy") + "#";
                    lblFiltroAplicado.Text = "";
                    txtInput.Text = "";
                    break;
                case "btnFechaSemana":

                    int thisWeekNumber = General.GetIso8601WeekOfYear(DateTime.Today);

                    DateTime firstDayOfWeek = General.FirstDateOfWeek(DateTime.Now.Year, thisWeekNumber, CultureInfo.CurrentCulture);
                    firstDayOfWeek = firstDayOfWeek.AddDays(1);
                    DateTime firstDayOfLastYearWeek = firstDayOfWeek.AddDays(6);

                    sql += "AND PEDIDOS.Fecha Between #" + firstDayOfWeek.ToString("MM/dd/yyyy") + "# AND # " + firstDayOfLastYearWeek.ToString("MM/dd/yyyy") + "#";

                    lblFiltroAplicado.Text = "";
                    txtInput.Text = "";
                    break;
                case "btnFechaPersonalizado":

                    FrmFechaDesdeHasta frm = new FrmFechaDesdeHasta();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                        sql += "AND PEDIDOS.Fecha Between #" + frm._fechaDesde.ToString("MM/dd/yyyy") + "# AND # " + frm._fechaHasta.ToString("MM/dd/yyyy") + "#";

                        lblFiltroAplicado.Text = "Filtro Aplicado :" + frm._fechaTexto;
                    }
                    else
                    {
                        // si no elige rango, listo la del dia
                        ActivateButton(btnFechaHoy);
                        return;
                    }
                    txtInput.Text = "";
                    frm.Dispose();
                    break;
                case "btnBuscar":

                    lblFiltroAplicado.Text = "";



                    if (txtInput.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe ingresar el nro de comprobante", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtInput.Focus();
                        return;
                    }

                    sql += "AND PEDIDOS.ID_PEDIDO = " + txtInput.Text;

                    break;
            }

            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            Cmd = new OleDbCommand(sql, Cnn);
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            dgPedidos.DataSource = Dt;

            dgPedidos.Columns[0].Visible = false;
            dgPedidos.Columns[6].Visible = false;

            dgPedidos.Columns[0].Width = 80; // id
            dgPedidos.Columns[1].Width = 80; //fecha
            dgPedidos.Columns[2].Width = 90; //NRO_COMPROBANTE
            dgPedidos.Columns[3].Width = 100; //TOTAL_FINAL
            dgPedidos.Columns[4].Width = 300; //metedo pago

            dgPedidos.Columns[2].HeaderText = "COMP."; //NRO_COMPROBANTE
            dgPedidos.Columns[3].HeaderText = "TOTAL"; //TOTAL_FINAL
            dgPedidos.Columns[4].HeaderText = "METEDO PAGO"; //metedo pago

            dgPedidos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns[3].DefaultCellStyle.Format = "N2";


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

        private void btnFechaSemana_Click(object sender, EventArgs e)
        {
            ActivateButton(btnFechaSemana);
        }

        private void btnFechaPersonalizado_Click(object sender, EventArgs e)
        {
            ActivateButton(btnFechaPersonalizado);
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs? e)
        {
            ActivateButton(btnBuscar);
        }

        private void btnToolImprimir_Click(object sender, EventArgs? e)
        {

            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {
                int ID_PEDIDO = Convert.ToInt32(dgPedidos.CurrentRow.Cells[0].Value);
                Imprimir(ID_PEDIDO);
            }
        }

        private void button1_Click(object sender, EventArgs? e)
        {
            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {
                int ID_PEDIDO = Convert.ToInt32(dgPedidos.CurrentRow.Cells[0].Value);
                bool CANCELADO = Convert.ToBoolean(dgPedidos.CurrentRow.Cells["CANCELADO"].Value);
                bool PROCESADO = Convert.ToBoolean(dgPedidos.CurrentRow.Cells["PROCESADO"].Value);
               

                if (Caja.PerteneceACajaCerradA(ID_PEDIDO))
                {
                    MessageBox.Show("El pedido no puede cancelarse por que la caja a la que pertence ya fue cerrada", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (General._CONNECTED == "1")
                {
                    if (!PROCESADO)
                    {
                        MessageBox.Show("El pedido debe poder procesarse antes de ser cancelado, espere unos minutos!.", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                

                if (CANCELADO)
                {
                    MessageBox.Show("El pedido ya se encuentra cancelado !.", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                

                if (MessageBox.Show("¿Seguro que desea cancelar el comprobante Nro " + ID_PEDIDO.ToString() + "?", "App", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
                
               

                if (General._CONNECTED == "1")
                {

                    if (new FrmLogin().ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }


                    if (!Server.CancelarPedido(ID_PEDIDO))
                    {
                        MessageBox.Show("No se ha podido cancelar el pedido en el servidor, avisar al administrador", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (Local.CancelaPedido(ID_PEDIDO))
                {
                    MessageBox.Show("Pedido cancelado con Exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //para resfrescar segun donde este parado
                    ActivateButton(currentButton);
                }
              
                

            }
        }

        private void dgPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (bool.Parse(dgPedidos["CANCELADO", e.RowIndex].Value.ToString()) == true)
            {
                e.CellStyle.BackColor = ColorTranslator.FromHtml("#EA676C");
                e.CellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
            }
        }

        private void FrmVentaConsultas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnToolImprimir_Click(btnToolImprimir, null);

            }

            if (e.KeyCode == Keys.F7)
            {
                button1_Click(button1, null);
            }

        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtInput.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;

                btnBuscar_Click(btnBuscar, null);

                e.Handled = true;
            }
        }
    }
}
