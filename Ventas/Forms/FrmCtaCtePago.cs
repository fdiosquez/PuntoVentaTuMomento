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
    public partial class FrmCtaCtePago : Form
    {
        int _ID_CLIENTE;
        int _ID_PEDIDO;

        public FrmCtaCtePago()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un valor", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValor.Focus();
                return;
            }


            int ID_CAJA_TIPO = Convert.ToInt32(cboCajaTipo.SelectedValue);
            double VALOR = Convert.ToDouble(txtValor.Text);


            try
            {
                
                OleDbConnection connection = new OleDbConnection(General.GetConnectionString());
                connection.Open();

                //GENERO LA CTA CTE
                String Sql = @"INSERT INTO CUENTA_CORRIENTE (ID_CLIENTE,ID_COMPROBANTE,FECHA,ID_CUENTA_CORRIENTE_TIPO,DEBE,HABER) 
                                                         VALUES  (@ID_CLIENTE,@ID_COMPROBANTE,@FECHA,@ID_CUENTA_CORRIENTE_TIPO,@DEBE,@HABER)";

                OleDbCommand oleDbDEBITO = new OleDbCommand(Sql, connection);
                oleDbDEBITO.CommandType = CommandType.Text;
                oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_CLIENTE", _ID_CLIENTE));
                oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_COMPROBANTE", Convert.ToInt32(0)));
                oleDbDEBITO.Parameters.Add(new OleDbParameter("@FECHA", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"))));
                oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_CUENTA_CORRIENTE_TIPO", Convert.ToInt32(2))); //PAGO
                oleDbDEBITO.Parameters.Add(new OleDbParameter("@DEBE", Convert.ToInt32(0)));
                oleDbDEBITO.Parameters.Add(new OleDbParameter("@HABER", VALOR));
                oleDbDEBITO.ExecuteNonQuery();

                //CALCULO SALDO DEL CLIENTE
                double SALDO_ACTUAL = 0;

                Sql = "SELECT ROUND(SUM(ABS(HABER)) -  SUM(ABS(DEBE)),2)  as SALDO FROM CUENTA_CORRIENTE WHERE ID_CLIENTE = " + _ID_CLIENTE;
                OleDbCommand Cmd = new OleDbCommand(Sql, connection);
                OleDbDataReader Dr = Cmd.ExecuteReader();
                if (Dr.HasRows)
                {
                    Dr.Read();
                    SALDO_ACTUAL = Convert.ToDouble(Dr["SALDO"]);
                    Dr.Close();
                }

                //ACTUALIZO SALDO DEL CLIENTE
                Sql = "UPDATE CLIENTES SET SALDO = @SALDO_ACTUAL WHERE ID_CLIENTE = @ID_CLIENTE";
                Cmd = new OleDbCommand(Sql, connection);
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.Add(new OleDbParameter("@SALDO_ACTUAL", SALDO_ACTUAL));
                Cmd.Parameters.Add(new OleDbParameter("@ID_CLIENTE", _ID_CLIENTE));
                Cmd.ExecuteNonQuery();


                //GENERO EL MOVIMIENTO DE CAJA
                Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                OleDbCommand oleDbCaja = new OleDbCommand(Sql, connection);
                oleDbCaja.CommandType = CommandType.Text;
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", ID_CAJA_TIPO));
                oleDbCaja.Parameters.Add(new OleDbParameter("@VALOR", VALOR));
                oleDbCaja.Parameters.Add(new OleDbParameter("@OBSERVACIONES", "PAGO DESDE CTA CTE" ));
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_PEDIDO",Convert.ToInt32(0) ));
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                oleDbCaja.ExecuteNonQuery();


                connection.Close();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmCtaCtePago_Load(object sender, EventArgs e)
        {
            SetColorTheme();
            //this.ActiveControl = txtValor;
            General.FillCajaTipo(cboCajaTipo, "", 9);

        }

        private void SetColorTheme()
        {

            btnAceptar.BackColor = ThemeColor.PrimaryColor;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnAceptar.FlatStyle = FlatStyle.Flat;

        }

        public DialogResult ShowDialog(int idCliente)
        {
            _ID_CLIENTE = idCliente;
            //_ID_PEDIDO = idPedido;
            return ShowDialog();
        }
    }
}
