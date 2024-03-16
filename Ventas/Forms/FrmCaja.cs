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
using Button = System.Windows.Forms.Button;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Drawing.Printing;

namespace Ventas.Forms
{
    public partial class FrmCaja : Form
    {
        private Button currentButton;
        private string _SQL2 = "";
        private int _ANCHO_ORIGINAL = 0;
        private double _TOTAL_CIERRE_CAJA = 0;
        public FrmCaja()
        {
            InitializeComponent();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            InicializaControlesCierre();
            SetColorTheme();
            DisableButtonFecha();
            ActivateButton(btnFechaHoy);
        }
        public void Refrescar()
        {
            ActivateButton(btnFechaHoy);
        }

        private void Imprimir(int id_caja)
        {

            Caja.ID_CAJA_A_IMPRIMIR = id_caja;
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = General._PRINTER_TICKET;
                printDoc.PrintPage += new PrintPageEventHandler(Caja.Imprimir);
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            //BOTON ACEPTAR
            btnCajaCierre.BackColor = ThemeColor.PrimaryColor;
            btnCajaCierre.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnCajaCierre.FlatStyle = FlatStyle.Flat;
            btnCajaCierre.ForeColor = Color.White;

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

        private void Buscar()
        {

            OleDbDataReader Dr;
            OleDbCommand Cmd;
            OleDbConnection Cnn;
            DataTable Dt = new DataTable();



            string sql = "SELECT CAJA.ID_CAJA," +
                     "          CAJA.ID_CAJA_TIPO, " +
                     "          CAJA.FECHA," +
                     "          CAJA.HORA," +
                     "         CAJA_TIPO.DESCRIPCION, " +
                     "         CAJA.VALOR AS TOTAL," +
                     "         IIF(CAJA.ID_PEDIDO=0,CAJA.OBSERVACIONES,'COMP:' & CAJA.ID_PEDIDO & ', ' & CAJA.OBSERVACIONES )  AS [OBSERVACIONES] " +
                     "  FROM CAJA INNER JOIN CAJA_TIPO " +
                     "       ON CAJA.ID_CAJA_TIPO = CAJA_TIPO.ID_CAJA_TIPO" +
                     "   WHERE @@FECHA@@ ";



            string sql2 = "";

            switch (currentButton.Name)
            {
                case "btnFechaHoy":
                    sql2 = " Fecha = #" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#";
                    lblFiltroAplicado.Text = "";
                    break;
                case "btnFechaAyer":
                    DateTime yesterday = DateTime.Today.AddDays(-1);
                    sql2 = " Fecha = #" + yesterday.ToString("MM/dd/yyyy") + "#";
                    lblFiltroAplicado.Text = "";
                    break;
                case "btnFechaSemana":

                    int thisWeekNumber = General.GetIso8601WeekOfYear(DateTime.Today);

                    DateTime firstDayOfWeek = General.FirstDateOfWeek(DateTime.Now.Year, thisWeekNumber, CultureInfo.CurrentCulture);
                    firstDayOfWeek = firstDayOfWeek.AddDays(1);
                    DateTime firstDayOfLastYearWeek = firstDayOfWeek.AddDays(6);

                    sql2 = " Fecha Between #" + firstDayOfWeek.ToString("MM/dd/yyyy") + "# AND # " + firstDayOfLastYearWeek.ToString("MM/dd/yyyy") + "#";

                    lblFiltroAplicado.Text = "";
                    break;
                case "btnFechaPersonalizado":

                    FrmFechaDesdeHasta frm = new FrmFechaDesdeHasta();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                        sql2 = " Fecha Between #" + frm._fechaDesde.ToString("MM/dd/yyyy") + "# AND # " + frm._fechaHasta.ToString("MM/dd/yyyy") + "#";

                        lblFiltroAplicado.Text = "Filtro Aplicado :" + frm._fechaTexto;
                    }
                    else
                    {
                        // si no elige rango, listo la del dia
                        ActivateButton(btnFechaHoy);
                        return;
                    }
                    frm.Dispose();
                    break;

            }

            sql = sql.Replace("@@FECHA@@", sql2);


            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            Cmd = new OleDbCommand(sql, Cnn);
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            dgPedidos.DataSource = Dt;

            //OCULTAR            
            dgPedidos.Columns["ID_CAJA_TIPO"].Visible = false;
            dgPedidos.Columns["ID_CAJA"].Visible = false;


            //DEFINIR WIDTHS
            dgPedidos.Columns["FECHA"].Width = 90;


            dgPedidos.Columns["DESCRIPCION"].Width = 200;
            dgPedidos.Columns["OBSERVACIONES"].Width = 400;



            //FORMATEAR            
            dgPedidos.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns["TOTAL"].DefaultCellStyle.Format = "N2";
            dgPedidos.Columns["HORA"].DefaultCellStyle.Format = "HH:mm:ss";

            dgPedidos.MultiSelect = false;
            dgPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPedidos.AllowUserToAddRows = false;
            dgPedidos.ReadOnly = true;


        }

        private void btnFechaHoy_Click(object sender, EventArgs e)
        {
            if (txtFechaCierre.Visible)
                CierraControlesCierre();

            ActivateButton(btnFechaHoy);
        }

        private void btnFechaAyer_Click(object sender, EventArgs e)
        {
            if (txtFechaCierre.Visible)
                CierraControlesCierre();

            ActivateButton(btnFechaAyer);
        }

        private void btnFechaSemana_Click(object sender, EventArgs e)
        {

            if (txtFechaCierre.Visible)
                CierraControlesCierre();

            ActivateButton(btnFechaSemana);
        }

        private void btnFechaPersonalizado_Click(object sender, EventArgs e)
        {
            if (txtFechaCierre.Visible)
                CierraControlesCierre();

            ActivateButton(btnFechaPersonalizado);
        }

        private void dgPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgPedidos["Tipo", e.RowIndex].Value.ToString() == "TOTAL:")
            //{
            //    e.CellStyle.BackColor = ColorTranslator.FromHtml("#7BCFE9");
            //    e.CellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
            //}
        }

        private void btnNuevoMov_Click(object sender, EventArgs e)
        {

            if (txtFechaCierre.Visible)
                CierraControlesCierre();

            if (General._ID_CAJA_ACTUAL == 0)
            {
                MessageBox.Show("No existe una caja abierta, no se puede pueden agrear movimientos", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (new FrmCajaNuevo().ShowDialog(7) == DialogResult.OK)
            {
                Buscar();
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (txtFechaCierre.Visible)
                CierraControlesCierre();

            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {
                int TIPO = Convert.ToInt32(dgPedidos.CurrentRow.Cells["ID_CAJA_TIPO"].Value);

                if (TIPO != 9)
                {
                    MessageBox.Show("Solo se pueden imprimir cierres de caja", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int ID_CAJA = Convert.ToInt32(dgPedidos.CurrentRow.Cells["ID_CAJA"].Value);

                Imprimir(ID_CAJA);

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            if (General._ID_CAJA_ACTUAL == 0)
            {
                MessageBox.Show("No existe una caja abierta, no se puede cerrar", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            ActivateButton(btnFechaHoy);

            CierraControlesCierre();

            txtFechaCierre.Text = DateTime.Now.ToString("dd/MM/yyyy");


            _TOTAL_CIERRE_CAJA = Caja.TotalCajaDelDia();

            CargaResumen();

            txtBalanceTeorico.Text = String.Format("$ {0:N}", _TOTAL_CIERRE_CAJA);


        }

        private void CargaResumen()
        {



            OleDbDataReader Dr;
            OleDbCommand Cmd;
            OleDbConnection Cnn;
            DataTable Dt = new DataTable();



            String sql = @"SELECT CAJA_TIPO.ABREV AS ITEM, 
                                  Sum(CAJA.VALOR) AS TOTAL
                                   FROM CAJA INNER JOIN CAJA_TIPO 
                                    ON CAJA.ID_CAJA_TIPO = CAJA_TIPO.ID_CAJA_TIPO
                            WHERE CAJA.ID_CAJA_PARENT = " + General._ID_CAJA_ACTUAL.ToString() + "    GROUP BY CAJA_TIPO.ABREV, CAJA_TIPO.ORDEN ORDER BY CAJA_TIPO.ORDEN;";



            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            Cmd = new OleDbCommand(sql, Cnn);
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            dgResumen.DataSource = Dt;


            ////DEFINIR WIDTHS
            dgResumen.Columns["ITEM"].Width = 70;
            dgResumen.Columns["TOTAL"].Width = 100;


            //FORMATEAR            
            dgResumen.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgResumen.Columns["TOTAL"].DefaultCellStyle.Format = "N2";


            dgResumen.MultiSelect = false;
            dgResumen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgResumen.AllowUserToAddRows = false;
            dgResumen.ReadOnly = true;

        }
        private void CierraControlesCierre()
        {
            //GUARDO EN MEMORIA EL ANCHO DE LA GRILLA
            if (_ANCHO_ORIGINAL == 0)
                _ANCHO_ORIGINAL = dgPedidos.Width;

            ToggleControlesCierre();

            if (txtFechaCierre.Visible)
                dgPedidos.Width = dgPedidos.Width - (txtFechaCierre.Width + 60);
            else
                dgPedidos.Width = _ANCHO_ORIGINAL;

        }
        private void ToggleControlesCierre()
        {

            lblFecha.Visible = !lblFecha.Visible;
            txtFechaCierre.Visible = !txtFechaCierre.Visible;

            lblBalanceTeorico.Visible = !lblBalanceTeorico.Visible;
            txtBalanceTeorico.Visible = !txtBalanceTeorico.Visible;

            lblEfectivoReal.Visible = !lblEfectivoReal.Visible;
            txtEfectivoReal.Visible = !txtEfectivoReal.Visible;

            lblDiferencia.Visible = !lblDiferencia.Visible;
            txtDiferencia.Visible = !txtDiferencia.Visible;
            btnCajaCierre.Visible = !btnCajaCierre.Visible;

            dgResumen.Visible = !dgResumen.Visible;

        }

        private void InicializaControlesCierre()
        {

            lblFecha.Visible = false;
            txtFechaCierre.Visible = false;
            txtFechaCierre.ReadOnly = true;

            lblBalanceTeorico.Visible = false;
            txtBalanceTeorico.Visible = false;
            txtBalanceTeorico.ReadOnly = true;

            lblEfectivoReal.Visible = false;
            txtEfectivoReal.Visible = false;

            lblDiferencia.Visible = false;
            txtDiferencia.Visible = false;
            txtDiferencia.ReadOnly = true;

            btnCajaCierre.Visible = false;

            dgResumen.Visible = false;

        }

        private void txtEfectivoReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEfectivoReal.Text.IndexOf('.') > 0 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar != '\r')
                    return;
                btnCajaCierre.Focus();
                e.Handled = true;
            }
        }

        private void txtEfectivoReal_TextChanged(object sender, EventArgs e)
        {
            CalculaResto();
        }

        private void CalculaResto()
        {

            double num1 = this.txtEfectivoReal.Text == "" ? 0.0 : Convert.ToDouble(this.txtEfectivoReal.Text);
            double tot = _TOTAL_CIERRE_CAJA;

            if (num1 > 0)
                tot -= num1;
            else
                tot = 0.0;

            txtDiferencia.Text = string.Format("${0:N}", tot);

        }

        private void btnCajaCierre_Click(object sender, EventArgs e)
        {
            if (txtEfectivoReal.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un valor", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEfectivoReal.Focus();
                return;
            }

            //if (Convert.ToDouble(txtEfectivoReal.Text) <= 0)
            //{
            //    MessageBox.Show("Debe ingresar un valor mayor a cero", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtEfectivoReal.Focus();
            //    return;
            //}

            double efectivoTeorico = Convert.ToDouble(txtBalanceTeorico.Text.Replace("$", ""));
            double efectivoReal = Convert.ToDouble(txtEfectivoReal.Text.Replace("$", ""));
            double efectivoDiferencia = Convert.ToDouble(txtDiferencia.Text.Replace("$", ""));


            try
            {
                OleDbConnection connection = new OleDbConnection(General.GetConnectionString());
                connection.Open();

                int CERO = 0;
                string Observaciones = "Balance Teórico: " + txtBalanceTeorico.Text + "|Efectivo Real: " + txtEfectivoReal.Text + "|Diferencia: " + txtDiferencia.Text;

                //INGRESO MOVIMIENTO DE CAJA DE CIERRE
                string Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,TEORICO,[REAL],DIFERENCIA,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@TEORICO,@REAL,@DIFERENCIA,@ID_CAJA_PARENT)";

                OleDbCommand oleDbCaja = new OleDbCommand(Sql, connection);
                oleDbCaja.CommandType = CommandType.Text;

                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", Convert.ToInt32(9))); //-->ID CIERRE BASE DE DATOS
                oleDbCaja.Parameters.Add(new OleDbParameter("@VALOR", efectivoReal));
                oleDbCaja.Parameters.Add(new OleDbParameter("@OBSERVACIONES", Observaciones));
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_PEDIDO", CERO));
                oleDbCaja.Parameters.Add(new OleDbParameter("@TEORICO", efectivoTeorico));
                oleDbCaja.Parameters.Add(new OleDbParameter("@REAL", efectivoReal));
                oleDbCaja.Parameters.Add(new OleDbParameter("@DIFERENCIA", efectivoDiferencia));
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                oleDbCaja.ExecuteNonQuery();



                //CIERRO CAJA ABIERTA Y TODAS LOS MOVIMIENTO PERTENECIENTES A ESA CAJA
                Sql = @"UPDATE CAJA SET CERRADO = TRUE WHERE ID_CAJA_PARENT = @ID_CAJA OR ID_CAJA = @ID_CAJA";
                OleDbCommand oleDbCajaAbierta = new OleDbCommand(Sql, connection);
                oleDbCajaAbierta.CommandType = CommandType.Text;
                oleDbCajaAbierta.Parameters.Add(new OleDbParameter("@ID_CAJA", General._ID_CAJA_ACTUAL));
                oleDbCajaAbierta.Parameters.Add(new OleDbParameter("@ID_CAJA", General._ID_CAJA_ACTUAL));
                oleDbCajaAbierta.ExecuteNonQuery();

                //CIERRO EL ID DE CAJA ACTUAL
                General._ID_CAJA_ACTUAL = 0;


                DialogResult dialogResult = MessageBox.Show("Cierre de caja realizado con exito!, desea imprimirlo ?", "App", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    int id_caja = 0;
                    OleDbDataReader Dr;
                    OleDbCommand Cmd;
                    Sql = @"SELECT MAX(ID_CAJA) AS ID FROM CAJA";
                    Cmd = new OleDbCommand(Sql, connection);
                    Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        id_caja = Convert.ToInt32(Dr["ID"]);
                    }

                    if (id_caja > 0)
                    {
                        Imprimir(id_caja);
                    }


                }

                btnFechaHoy_Click(btnFechaHoy, null);

                connection.Close();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnNuevoMov_Click(null, null);
            }
            if (e.KeyCode == Keys.F7)
            {
                btnDetalle_Click(null, null);
            }
            if (e.KeyCode == Keys.F8)
            {
                btnCerrar_Click(null, null);
            }

        }
    }
}
