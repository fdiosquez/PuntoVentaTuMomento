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
    public partial class FrmCajaNuevo : Form
    {
        int _TIPO=0;

        public FrmCajaNuevo()
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

            //EN LA APERTURA NO ES OBLIGATORIO
            if (_TIPO != 1)
            {
                if (txtDescripcion.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar una descripción", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDescripcion.Focus();
                    return;
                }

            }

            string DESCRIPCION = "";
            if (txtDescripcion.Text.Length == 0)            
                DESCRIPCION = "EFECTIVO";            
            else
                DESCRIPCION = txtDescripcion.Text.Trim();


            double num1 = Math.Abs(Convert.ToDouble(this.txtValor.Text));

            //SI ES SALIDA LO CONVIERTO EN NEGATIVO

            if (Convert.ToInt32(cboCajaTipo.SelectedValue) == 8) //SI ES EGRESO
            {
                num1 *= -1.0;
                _TIPO = 8;
            }            
                

            try
            {
                OleDbDataReader Dr;
                OleDbCommand Cmd;
                OleDbConnection connection = new OleDbConnection(General.GetConnectionString());
                connection.Open();

                int CERO = 0;
               

                //INGRESO MOVIMIENTO DE CAJA
                string Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                OleDbCommand oleDbCaja = new OleDbCommand(Sql, connection);
                oleDbCaja.CommandType = CommandType.Text;

                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", _TIPO));
                oleDbCaja.Parameters.Add(new OleDbParameter("@VALOR", num1));
                oleDbCaja.Parameters.Add(new OleDbParameter("@OBSERVACIONES", DESCRIPCION));
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_PEDIDO", CERO));
                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                oleDbCaja.ExecuteNonQuery();


                if (_TIPO == 1) //si es tipo apertura recupero el ID y lo persisto en memoria
                {

                    Sql = @"SELECT MAX(ID_CAJA) AS ID FROM CAJA";                    
                    Cmd = new OleDbCommand(Sql, connection);
                    Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        General._ID_CAJA_ACTUAL = Convert.ToInt32(Dr["ID"]);
                    }
                    
                }
                    


                connection.Close();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void FrmCajaNuevo_Load(object sender, EventArgs e)
        {
            SetColorTheme();
            //this.ActiveControl = txtValor;
            General.FillCajaTipo(cboCajaTipo,"", _TIPO);

        }

        public DialogResult ShowDialog(int tipo)
        {
            _TIPO = tipo;
            return ShowDialog();
        }

        public DialogResult ShowDialog(int tipo, DateTime FechaCierre)
        {
            _TIPO = tipo;
            return ShowDialog();
        }

        private void SetColorTheme()
        {

            btnAceptar.BackColor = ThemeColor.PrimaryColor;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnAceptar.FlatStyle = FlatStyle.Flat;

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor.Text.IndexOf('.') > 0 && e.KeyChar == '.')
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
    }
}
