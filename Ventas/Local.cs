using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx;
using Microsoft.VisualBasic;
using Mysqlx.Crud;

namespace Ventas
{
    class Local
    {

        

            public static void AfectarPedidosdDetalles(List<PEDIDO_DETALLE> _pedidos)
        {

            /*
                MARCA LOS PEDIDOS_DETALLES QUE YA FUERON SUBIDOS AL SERVER
                PARA NO VOLVERLOS A PROCESAR
             */

            List <string> strings = new List <string>();   
            foreach (PEDIDO_DETALLE P in _pedidos)
            {
                strings.Add (P.ID_PEDIDO_DETALLE.ToString() );
            }

            string ID_PEDIDOS_DETALLE = string.Join(",", strings.ToArray());

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    connection.Open();                    
                    string SQL = @"UPDATE PEDIDOS_DETALLE SET PROCESADO = TRUE WHERE ID_PEDIDO_DETALLE IN(" + ID_PEDIDOS_DETALLE + ")";
                    OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection);
                    oleDbCommand.CommandType = CommandType.Text;                        
                    oleDbCommand.ExecuteNonQuery();
                    oleDbCommand.Dispose();
                    

                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }


        }

        public static void AfectarPedidos(List<PEDIDO> _pedidos)
        {

            /*
                MARCA LOS PEDIDOS QUE YA FUERON SUBIDOS AL SERVER
                PARA NO VOLVERLOS A PROCESAR
             */            

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    foreach (PEDIDO P in _pedidos)
                    {
                        
                        string SQL = @"UPDATE PEDIDOS SET PROCESADO = TRUE WHERE ID_PEDIDO = @ID_PEDIDO" ;
                        OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection);
                        oleDbCommand.CommandType = CommandType.Text;
                        oleDbCommand.Parameters.Add(new OleDbParameter("@ID_PEDIDO", P.ID_PEDIDO ));                        
                        oleDbCommand.ExecuteNonQuery();
                        oleDbCommand.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            

        }

        public static void RegresarStock(int ID_PEDIDO)
        {
            
             /*
                REGRESA EL STOCK CUANDO PEDIDO SE CANCELA UN PEDIDO
             */
            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    
                    string SQL = @"UPDATE PRODUCTOS
                                    INNER JOIN PEDIDOS_DETALLE ON PRODUCTOS.ID_PRODUCTO = PEDIDOS_DETALLE.ID_PRODUCTO
                                    SET PRODUCTOS.STOCK = PRODUCTOS.STOCK + PEDIDOS_DETALLE.CANTIDAD
                                    WHERE PEDIDOS_DETALLE.ID_PEDIDO = @ID_PEDIDO";
                    OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection);
                    oleDbCommand.CommandType = CommandType.Text;
                    oleDbCommand.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                    oleDbCommand.ExecuteNonQuery();
                    oleDbCommand.Dispose();
                    

                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

        }

        public static bool CancelaPedido(int ID_PEDIDO)
        {

            /*
               CANCELA UN PEDIDO
            */
            bool result = false;
            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string SQL = @"UPDATE PEDIDOS SET CANCELADO = TRUE WHERE ID_PEDIDO =  @ID_PEDIDO";
                    OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection);
                    oleDbCommand.CommandType = CommandType.Text;
                    oleDbCommand.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                    if(oleDbCommand.ExecuteNonQuery()>0)
                        result = true;
                    
                    oleDbCommand.Dispose();


                    

                    SQL = "DELETE FROM CAJA WHERE ID_PEDIDO =  @ID_PEDIDO";
                    OleDbCommand oleDbCmdCaja = new OleDbCommand(SQL, connection);
                    oleDbCmdCaja.CommandType = CommandType.Text;
                    oleDbCmdCaja.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                    if (oleDbCmdCaja.ExecuteNonQuery() > 0)
                        result = true;

                    oleDbCmdCaja.Dispose();


                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            RegresarStock(ID_PEDIDO);

            return result;

        }
         


        public static List<PEDIDO> TraerPedidosPendientes()
        {
            OleDbDataReader Dr;
            OleDbCommand Cmd;
            List<PEDIDO> Lista = new List<PEDIDO>();

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    string sql = @"SELECT * FROM PEDIDOS WHERE PROCESADO = FALSE";
                    connection.Open();
                    Cmd = new OleDbCommand(sql, connection);
                    Dr = Cmd.ExecuteReader();
                    while (Dr.Read()) 
                    {
                        Lista.Add(new PEDIDO()
                        {
                            ID_SUCURSAL = Convert.ToInt32(General._SUCURSAL),
                            ID_PEDIDO = Convert.ToInt32(Dr["ID_PEDIDO"]),
                            FECHA = Convert.ToDateTime(Dr["FECHA"]),
                            TOTAL_PEDIDO = Convert.ToDouble(Dr["TOTAL_PEDIDO"]),
                            DESCUENTO = Convert.ToDouble(Dr["DESCUENTO"]),
                            TOTAL_FINAL = Convert.ToDouble(Dr["TOTAL_FINAL"]),
                            EFECTIVO = Convert.ToDouble(Dr["EFECTIVO"]),
                            TRANSFERENCIA = Convert.ToDouble(Dr["TRANSFERENCIA"]),
                            DEBITO = Convert.ToDouble(Dr["DEBITO"]),
                            QR = Convert.ToDouble(Dr["QR"]),
                            OBSERVACIONES = Convert.ToString(Dr["OBSERVACIONES"])
                        });
                    }

                }
                catch (Exception ex)
                {
                    General.Log("TraerPedidosPendientes():" + ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return Lista;
        }


        public static List<PEDIDO_DETALLE> TraerPedidosDetallesPendientes()
        {
            OleDbDataReader Dr;
            OleDbCommand Cmd;
            List<PEDIDO_DETALLE> Lista = new List<PEDIDO_DETALLE>();

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    string sql = @"SELECT  * FROM PEDIDOS_DETALLE WHERE PROCESADO = FALSE";
                    connection.Open();
                    Cmd = new OleDbCommand(sql, connection);
                    Dr = Cmd.ExecuteReader();
                    while (Dr.Read())
                    {
                        Lista.Add(new PEDIDO_DETALLE()
                        {
                            ID_SUCURSAL = Convert.ToInt32(General._SUCURSAL),
                            ID_PEDIDO_DETALLE = Convert.ToInt32(Dr["ID_PEDIDO_DETALLE"]),
                            ID_PEDIDO = Convert.ToInt32(Dr["ID_PEDIDO"]),
                            ID_PRODUCTO = Convert.ToInt32(Dr["ID_PRODUCTO"]),
                            CANTIDAD = Convert.ToInt32(Dr["CANTIDAD"]),
                            PRECIO = Convert.ToDouble(Dr["PRECIO"]),
                            SUBTOTAL = Convert.ToDouble(Dr["SUBTOTAL"]),
                        });
                    }

                }
                catch (Exception ex)
                {
                    General.Log("TraerPedidosDetallesPendientes():" + ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return Lista;
        }

        public static List<TaskProductos> AfectarProductos(List<TaskProductos> ListaProductos)
        {

            /*
                AFECTA LOS PRODUCTOS DE LA SUCURSAL
                SEGUN LO QUE HAYAN REALIZADO EN EL SERVER
             */
            List<TaskProductos> _OK = new List<TaskProductos>();


            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {                    
                    connection.Open();
                    foreach (TaskProductos pro in ListaProductos)
                    {

                        string SQL = "";
                        switch (pro.tipo)
                        {
                            case "A":
                                try
                                {
                                    SQL = @"INSERT INTO PRODUCTOS (ID_PRODUCTO,CODIGO_PRODUCTO,DESCRIPCION,CODIGO_BARRA,PRECIO_VENTA,STOCK)
                                        VALUES (@ID_PRODUCTO,@CODIGO_PRODUCTO,@DESCRIPCION,@CODIGO_BARRA,@PRECIO_VENTA,@STOCK)";
                                    OleDbCommand cmdA = new OleDbCommand(SQL, connection);
                                    cmdA.CommandType = CommandType.Text;
                                    cmdA.Parameters.Add(new OleDbParameter("@ID_PRODUCTO", pro.id_producto));
                                    cmdA.Parameters.Add(new OleDbParameter("@CODIGO_PRODUCTO", pro.codigo_producto));
                                    cmdA.Parameters.Add(new OleDbParameter("@DESCRIPCION", pro.descripcion));
                                    cmdA.Parameters.Add(new OleDbParameter("@CODIGO_BARRA", pro.codigo_barra));
                                    cmdA.Parameters.Add(new OleDbParameter("@PRECIO_VENTA", pro.precio));
                                    cmdA.Parameters.Add(new OleDbParameter("@STOCK", pro.stock));
                                    cmdA.ExecuteNonQuery();
                                    cmdA.Dispose();
                                    _OK.Add(pro);
                                    General.Log("Producto Agregado:" + pro.id_producto);
                                }
                                catch (Exception ex)
                                {
                                    General.Log("ERROR: id_producto:" + pro.id_producto + "| Accion : A | " + ex.Message, "ERROR");
                                }
                                
                                break;
                            case "B":                               
                                try
                                {
                                    SQL = "DELETE FROM PRODUCTOS WHERE ID_PRODUCTO = @ID_PRODUCTO";
                                    OleDbCommand cmdB = new OleDbCommand(SQL, connection);
                                    cmdB.CommandType = CommandType.Text;
                                    cmdB.Parameters.Add(new OleDbParameter("@ID_PRODUCTO", pro.id_producto));
                                    cmdB.ExecuteNonQuery();
                                    cmdB.Dispose();
                                    _OK.Add(pro);
                                    General.Log("Producto Borrado:" + pro.id_producto);
                                }
                                catch (Exception ex)
                                {
                                    General.Log("ERROR: id_producto:" + pro.id_producto + "| Accion : B | " + ex.Message, "ERROR");
                                }

                                break;
                            case "M":

                                try
                                {
                                    SQL = @"UPDATE PRODUCTOS SET CODIGO_PRODUCTO=@CODIGO_PRODUCTO,
			                                                 DESCRIPCION=@DESCRIPCION,
			                                                CODIGO_BARRA=@CODIGO_BARRA,
			                                                PRECIO_VENTA=@PRECIO_VENTA,
			                                                FECHA_MODIFICACION= Date(),
			                                                STOCK = @STOCK			
                                        WHERE ID_PRODUCTO = @ID_PRODUCTO";
                                    OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection);
                                    oleDbCommand.CommandType = CommandType.Text;
                                    oleDbCommand.Parameters.Add(new OleDbParameter("@CODIGO_PRODUCTO", pro.codigo_producto));
                                    oleDbCommand.Parameters.Add(new OleDbParameter("@DESCRIPCION", pro.descripcion));
                                    oleDbCommand.Parameters.Add(new OleDbParameter("@CODIGO_BARRA", pro.codigo_barra));
                                    oleDbCommand.Parameters.Add(new OleDbParameter("@PRECIO_VENTA", pro.precio));
                                    oleDbCommand.Parameters.Add(new OleDbParameter("@STOCK", pro.stock));
                                    oleDbCommand.Parameters.Add(new OleDbParameter("@ID_PRODUCTO", pro.id_producto));
                                    oleDbCommand.ExecuteNonQuery();
                                    oleDbCommand.Dispose();
                                    _OK.Add(pro);
                                    General.Log("Producto Actualizado:" + pro.id_producto);
                                }
                                catch (Exception ex)
                                {
                                    General.Log("ERROR: id_producto:" + pro.id_producto + "| Accion : M | " + ex.Message, "ERROR");
                                }
                                break;
                        }
                    }
                    
                }
                catch (Exception ex)
                {                    
                    General.Log("AfectarProductos():" + ex.Message, "ERROR");
                }
                finally
                {                    
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return _OK;

        }

        public static void EliminaLogAntiguo()
        {

            /*
               ELIMINA LOG VIEJO DESPUES DE 2 DIAS.
            */
            
            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string SQL = @"DELETE FROM LOG WHERE FECHA <= DateAdd(""d"", -2, Date())";
                    OleDbCommand oleDbCommand = new OleDbCommand(SQL, connection);
                    oleDbCommand.CommandType = CommandType.Text;                    
                    oleDbCommand.ExecuteNonQuery();                        
                    oleDbCommand.Dispose();
                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            

        }



    }
}
