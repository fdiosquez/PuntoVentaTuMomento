using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace Ventas
{
    class Caja
    {
        static public int ID_CAJA_A_IMPRIMIR;
        public static int ExisteCajaDelDia()
        {
            OleDbDataReader Dr;
            OleDbCommand Cmd;
            int ID_CAJA = 0;
            
            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    string sql = @"SELECT ID_CAJA FROM CAJA WHERE  ID_CAJA_TIPO = 1 AND CERRADO = FALSE";
                    connection.Open();
                    Cmd = new OleDbCommand(sql, connection);
                    Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        ID_CAJA = Convert.ToInt32(Dr["ID_CAJA"]);                     
                    }

                }
                catch (Exception ex)
                {
                    General.Log("ExisteCajaDelDia():" + ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return ID_CAJA;
        }

        public static bool PerteneceACajaCerradA(int ID_PEDIDO)
        {
            /*
             SE FIJA SI EL PEDIDO QUE SE QUIERE CANCELAR PERTENECE A UNA CAJA YA CERRADA
             */        
    
            OleDbDataReader Dr;
            OleDbCommand Cmd;
            bool Pertenece = false;

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    string sql = @"SELECT COUNT(ID_CAJA)  AS N
                                    FROM CAJA 
                                    WHERE CERRADO = TRUE AND ID_CAJA IN(SELECT ID_CAJA_PARENT FROM CAJA WHERE ID_PEDIDO = " + ID_PEDIDO.ToString()  + " )";

                    connection.Open();
                    Cmd = new OleDbCommand(sql, connection);
                    Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        Pertenece = Convert.ToInt32(Dr["n"])>0;
                    }

                }
                catch (Exception ex)
                {
                    General.Log("TotalCajaDelDia():" + ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return Pertenece;

        }
        public static double TotalCajaDelDia()
        {
            OleDbDataReader Dr;
            OleDbCommand Cmd;
            double TOTAL = 0;

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    string sql = @"SELECT SUM(VALOR) AS TOTAL FROM CAJA WHERE ID_CAJA_PARENT = " + General._ID_CAJA_ACTUAL.ToString();
                    connection.Open();
                    Cmd = new OleDbCommand(sql, connection);
                    Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        TOTAL = Convert.ToInt32(Dr["TOTAL"]);
                    }

                }
                catch (Exception ex)
                {
                    General.Log("TotalCajaDelDia():" + ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return TOTAL;
        }

        public static void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            OleDbDataReader Dr;
            OleDbConnection Cnn;
            OleDbCommand Cmd;

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 10;

            

            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();

            string ID_CAJA_PARENT = "";
            string FECHA = "";
            string TEORICO = "";
            string REAL = "";
            string DIFERENCIA = "";


            String Sql = "SELECT * FROM CAJA WHERE ID_CAJA = " + ID_CAJA_A_IMPRIMIR.ToString();
            Cmd = new OleDbCommand(Sql, Cnn);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {

                ID_CAJA_PARENT = Dr["ID_CAJA_PARENT"].ToString();
                FECHA = Convert.ToDateTime(Dr["FECHA"]).ToString("dd/MM/yyyy");
                TEORICO = String.Format("$ {0:N}", Dr["TEORICO"]);
                REAL = String.Format("$ {0:N}", Dr["REAL"]); 
                DIFERENCIA = String.Format("$ {0:N}", Dr["DIFERENCIA"]); 
            }
            Dr.Close();


            Sql = @"SELECT CAJA_TIPO.ABREV AS ITEM, 
                                  Sum(CAJA.VALOR) AS TOTAL
                                   FROM CAJA INNER JOIN CAJA_TIPO 
                                    ON CAJA.ID_CAJA_TIPO = CAJA_TIPO.ID_CAJA_TIPO
                     WHERE CAJA.ID_CAJA_TIPO <> 9 AND CAJA.ID_CAJA_PARENT = " + ID_CAJA_PARENT + "    GROUP BY CAJA_TIPO.ABREV, CAJA_TIPO.ORDEN ORDER BY CAJA_TIPO.ORDEN;";


            Cmd = new OleDbCommand(Sql, Cnn);
            Dr = Cmd.ExecuteReader();



            if (Dr.HasRows)
            {
                //LOGO


                int fila = 0;
                double total = 0;
                double seña = 0;

                while (Dr.Read())
                {



                    if (fila == 0)
                    {
                        
                        graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("CIERRE DE CAJA" , new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("FECHA : " + FECHA, font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);
                                              

                    }
                    

                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString(String.Format("{0,-8} {1,16}", Convert.ToString(Dr["ITEM"]), String.Format("{0:c}", Dr["TOTAL"])), font, new SolidBrush(Color.Black), startX, startY + offset);

                    
                    fila++;

                }


                offset = offset + (int)fontHeight + 5; //make the spacing consistent
                graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);



                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8} {1,16}", "TEÓRICO:", TEORICO), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8} {1,16}", "REAL:", REAL), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8} {1,16}", "DIF.:", DIFERENCIA), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                

            }


        }

    }
}
