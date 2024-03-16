using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using Microsoft.VisualBasic.Logging;
using System.Collections;
using Mysqlx.Crud;
using static System.Net.Mime.MediaTypeNames;


namespace Ventas
{
    class Server
    {

        public static string ConnectStringMySql()
        {
            /*
                bd:	rabgxsdc_tumomento
                pwd: NY=L;WN#MJ@N,]@%X$
                user: rabgxsdc_userdbmomento
                www: www.io-server.com


                string str1 = "localhost";
                string str2 = "tumomento";
                string str3 = "root";
                string str4 = "";
             */
            /*
            string server = "www.io-server.com";
            string bd = "rabgxsdc_tumomento";
            string user = "rabgxsdc_userdbmomento";
            string pass = "NY=L;WN#MJ@N,]@%X$";

   

            return  "Database=" + bd + "; Data Source=" + server + "; User Id= " + user + "; Password=" + pass + ";Port=3306;";

            www.io-server.com

            */

            string str1 = "www.io-server.com";
            string str2 = "rabgxsdc_tumomento";
            string str3 = "rabgxsdc_usrtumomento";
            string str4 = "Fernando2023!";
            return "Database=" + str2 + "; Data Source=" + str1 + "; User Id= " + str3 + "; Password=" + str4 + ";Port=3306;";
        }

        public static bool VerificaLogin(string user,string pass)
        {
            /*
                VERIFICA SI EL PASSWORD Y USUARIO DEL SERVIDOR SON CORRECTOS
             */

            bool b = false;

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    connection.Open();
                    string SQL = @"SELECT COUNT(id_usuario) as N FROM usuarios where usuario = '" + user + "' and password = '" + pass  + "'";


                    MySqlDataReader mySqlDataReader = new MySqlCommand(SQL, connection).ExecuteReader();
                    if (mySqlDataReader.HasRows)
                    {
                        while (mySqlDataReader.Read())
                        {
                            b = Convert.ToInt32(mySqlDataReader["n"]) > 0;
                        }                                                     
                    }
                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return b;
        }

        public static List<TaskProductos> TraerProductosCambios()
        {
            /*		IsSecurityCritical	No se puede llamar al método System.Reflection.RuntimeMethodInfo.get_IsSecurityCritical en este contexto.	bool

             TRAE TODOS LOS PRODUCTOS QUE HAYAN MODIFICADOS EN EL SERVER
             PARA ESTA SUCURSAL
             */
            
            List<TaskProductos> modificadosDesdeServer = new List<TaskProductos>();

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    connection.Open();
                    string SQL = @"SELECT   task_id_producto, 
                                             tipo, 
                                            id_producto, 
                                            codigo_producto, 
                                            codigo_barra, 
                                            descripcion, 
                                            stock, 
                                            precio 
                                    FROM task_productos 
                                    WHERE procesado = 0 and id_sucursal = " + General._SUCURSAL + " order by task_id_producto";


                    MySqlDataReader mySqlDataReader = new MySqlCommand(SQL, connection).ExecuteReader();
                    if (mySqlDataReader.HasRows)
                    {
                        while (mySqlDataReader.Read())
                            modificadosDesdeServer.Add(new TaskProductos()
                            {
                                
                                task_id_producto = Convert.ToInt32(mySqlDataReader["task_id_producto"]),
                                tipo = Convert.ToString(mySqlDataReader["tipo"]),
                                id_producto = Convert.ToInt32(mySqlDataReader["id_producto"]),
                                codigo_producto = Convert.ToString(mySqlDataReader["codigo_producto"]),
                                codigo_barra = Convert.ToString(mySqlDataReader["codigo_barra"]),
                                descripcion = Convert.ToString(mySqlDataReader["descripcion"]),
                                stock = Convert.ToInt32(mySqlDataReader["stock"]),
                                precio = Convert.ToDouble (mySqlDataReader["precio"])

                            });
                    }
                }
                catch (Exception ex)
                {
                    General.Log(ex.Message,"ERROR");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return modificadosDesdeServer;

        }


        public static List<TaskProductos> TraerTodosLosProductos()
        {
            /*		
             TRAE TODOS LOS PRODUCTOS DEL SERVIDOR
             */

            List<TaskProductos> modificadosDesdeServer = new List<TaskProductos>();

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    connection.Open();
                    string SQL = @"SELECT   id_producto AS task_id_producto, 
                                            'A' AS tipo, 
                                            id_producto, 
                                            codigo_producto, 
                                            codigo_barra, 
                                            descripcion, 
                                            stock, 
                                            precio 
                                    FROM productos 
                                    order by id_producto";


                    MySqlDataReader mySqlDataReader = new MySqlCommand(SQL, connection).ExecuteReader();
                    if (mySqlDataReader.HasRows)
                    {
                        while (mySqlDataReader.Read())
                            modificadosDesdeServer.Add(new TaskProductos()
                            {

                                task_id_producto = Convert.ToInt32(mySqlDataReader["task_id_producto"]),
                                tipo = Convert.ToString(mySqlDataReader["tipo"]),
                                id_producto = Convert.ToInt32(mySqlDataReader["id_producto"]),
                                codigo_producto = Convert.ToString(mySqlDataReader["codigo_producto"]),
                                codigo_barra = Convert.ToString(mySqlDataReader["codigo_barra"]),
                                descripcion = Convert.ToString(mySqlDataReader["descripcion"]),
                                stock = Convert.ToInt32(mySqlDataReader["stock"]),
                                precio = Convert.ToDouble(mySqlDataReader["precio"])

                            });
                    }
                }
                catch (Exception ex)
                {
                    General.Log(ex.Message, "ERROR");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return modificadosDesdeServer;

        }


        public static void MarcarProductos(List<TaskProductos> pro)
        {
            /*
                RECIBE UNA LISTA DE LOS PRODUCTOS QUE SE VAN A MARCAR EN EL SERVIDOR
                PARA NO VOLVERLA TRAER PARA ESTA SUCURSAL
             */

            List<string> stringList = new List<string>();
            foreach (TaskProductos producto in pro)
            {
                stringList.Add(producto.task_id_producto.ToString());
            }
                
            string LISTA = string.Join(",", stringList.ToArray());
            
            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("update task_productos set procesado = 1 where task_id_producto in("+ LISTA + ")", connection);
                    cmd.CommandType = CommandType.Text;                   
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
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


        public static List<PEDIDO> SubirPedido(List<PEDIDO> _pedido)
        {
            /*
                RECIBE UNA LISTA DE PEDIDOS A SUBIR
             */

            List<PEDIDO> _subidos = new List< PEDIDO >();

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    connection.Open();

                    foreach (PEDIDO p in _pedido)
                    {

                        string SQL = @"INSERT INTO pedidos (ID_SUCURSAL,ID_PEDIDO,FECHA,TOTAL_PEDIDO,DESCUENTO,TOTAL_FINAL,EFECTIVO,TRANSFERENCIA,DEBITO,QR,OBSERVACIONES)
                                        VALUES (@ID_SUCURSAL,@ID_PEDIDO,@FECHA,@TOTAL_PEDIDO,@DESCUENTO,@TOTAL_FINAL,@EFECTIVO,@TRANSFERENCIA,@DEBITO,@QR,@OBSERVACIONES)";

                        MySqlCommand cmd = new MySqlCommand(SQL, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new MySqlParameter("@ID_SUCURSAL", p.ID_SUCURSAL ));
                        cmd.Parameters.Add(new MySqlParameter("@ID_PEDIDO", p.ID_PEDIDO ));
                        cmd.Parameters.Add(new MySqlParameter("@FECHA", p.FECHA ));
                        cmd.Parameters.Add(new MySqlParameter("@TOTAL_PEDIDO", p.TOTAL_PEDIDO ));
                        cmd.Parameters.Add(new MySqlParameter("@DESCUENTO", p.DESCUENTO ) );
                        cmd.Parameters.Add(new MySqlParameter("@TOTAL_FINAL", p.TOTAL_FINAL ));
                        cmd.Parameters.Add(new MySqlParameter("@EFECTIVO", p.EFECTIVO ));
                        cmd.Parameters.Add(new MySqlParameter("@TRANSFERENCIA", p.TRANSFERENCIA ));
                        cmd.Parameters.Add(new MySqlParameter("@DEBITO", p.DEBITO ));
                        cmd.Parameters.Add(new MySqlParameter("@QR", p.QR ));
                        cmd.Parameters.Add(new MySqlParameter("@OBSERVACIONES", p.OBSERVACIONES ));
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            _subidos.Add(p);
                        }
                        cmd.Dispose();
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

            return _subidos;

        }


        public static List<PEDIDO_DETALLE> SubirPedidoDetalle(List<PEDIDO_DETALLE> _pedido_detalle)
        {
            /*
                RECIBE UNA LISTA DE PEDIDOS_DETALLES A SUBIR
             */

            List<PEDIDO_DETALLE> _subidos = new List<PEDIDO_DETALLE>();

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    connection.Open();

                    foreach (PEDIDO_DETALLE p in _pedido_detalle)
                    {

                        string SQL = @"INSERT INTO pedidos_detalle (ID_SUCURSAL,ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO,SUBTOTAL)
                                        VALUES (@ID_SUCURSAL,@ID_PEDIDO,@ID_PRODUCTO,@CANTIDAD,@PRECIO,@SUBTOTAL)";

                        MySqlCommand cmd = new MySqlCommand(SQL, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new MySqlParameter("@ID_SUCURSAL", p.ID_SUCURSAL));
                        cmd.Parameters.Add(new MySqlParameter("@ID_PEDIDO", p.ID_PEDIDO));
                        cmd.Parameters.Add(new MySqlParameter("@ID_PRODUCTO", p.ID_PRODUCTO));
                        cmd.Parameters.Add(new MySqlParameter("@CANTIDAD", p.CANTIDAD));
                        cmd.Parameters.Add(new MySqlParameter("@PRECIO", p.PRECIO));
                        cmd.Parameters.Add(new MySqlParameter("@SUBTOTAL", p.SUBTOTAL));                        
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            _subidos.Add(p);
                        }
                        cmd.Dispose();
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

            return _subidos;

        }


        public static void AfectaStock(List<PEDIDO_DETALLE> _pedido_detalle)
        {
            /*
               AFECTA EL STOCK DE LOS PRODUCTOS QUE PARTICIPARON  DE UN PEDIDO
            */

            var lista_pedidos = _pedido_detalle.Select(x => x.ID_PEDIDO).Distinct();
            int ID_SUCURSAL = Convert.ToInt32(General._SUCURSAL);            

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    connection.Open();

                    foreach (var p in lista_pedidos)
                    {

                        string SQL = @"UPDATE stock AS b
                                        INNER JOIN pedidos_detalle as g ON b.ID_PRODUCTO = g.ID_PRODUCTO AND b.ID_SUCURSAL = g.ID_SUCURSAL
                                        SET b.STOCK = (CASE WHEN b.STOCK - g.CANTIDAD < 0 THEN 0 ELSE b.STOCK - g.CANTIDAD END) 
                                        WHERE g.ID_PEDIDO = @ID_PEDIDO AND g.ID_SUCURSAL = @ID_SUCURSAL";


                        MySqlCommand cmd = new MySqlCommand(SQL, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new MySqlParameter("@ID_PEDIDO", Convert.ToInt32(p) ));
                        cmd.Parameters.Add(new MySqlParameter("@ID_SUCURSAL", ID_SUCURSAL));                        
                        cmd.ExecuteNonQuery();                        
                        cmd.Dispose();
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

        public static bool CancelarPedido(int ID_PEDIDO)
        {

            /*
              CANCELAR PEDIDO DE UNA SUCURSAL
           */

            bool result = false;

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    connection.Open();                   
                    string SQL = @"UPDATE pedidos SET CANCELADO = 1 WHERE ID_SUCURSAL = @ID_SUCURSAL AND ID_PEDIDO = @ID_PEDIDO";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("@ID_SUCURSAL", Convert.ToInt32(General._SUCURSAL)) );
                    cmd.Parameters.Add(new MySqlParameter("@ID_PEDIDO", ID_PEDIDO ));
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                    cmd.Dispose();                   
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

            //REGRESA EL STOCK DE LOS PRODUCTOS AFECTADOS
            RegresaStock(ID_PEDIDO);

            return result;

        }

        public static void RegresaStock(int ID_PEDIDO)
        {
            /*
               REGRESA EL STOCK DE LOS PRODUCTOS CUANDO UN PEDIDO SE CANCELA
            */
            
            int ID_SUCURSAL = Convert.ToInt32(General._SUCURSAL);

            using (MySqlConnection connection = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {
                    connection.Open();

                    
                    string SQL = @"UPDATE stock AS b
                                    INNER JOIN pedidos_detalle as g ON b.ID_PRODUCTO = g.ID_PRODUCTO AND b.ID_SUCURSAL = g.ID_SUCURSAL
                                    SET b.STOCK = b.STOCK + g.CANTIDAD
                                    WHERE g.ID_PEDIDO = @ID_PEDIDO AND g.ID_SUCURSAL = @ID_SUCURSAL";


                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new MySqlParameter("@ID_PEDIDO", ID_PEDIDO));
                    cmd.Parameters.Add(new MySqlParameter("@ID_SUCURSAL", ID_SUCURSAL));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    

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

        public static string VerificaNuevasVersiones()
        {
            string app_version = "";

            MySqlDataReader reader = null;

            string sql = "select * from actualizacion order by id_actualizacion desc limit 1";

            using (MySqlConnection Cnn = new MySqlConnection(ConnectStringMySql()))
            {
                try
                {


                    Cnn.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Cnn);
                    reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            app_version = Convert.ToString(reader["version"]);                            
                        }
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al buscar ultima version " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    if (Cnn.State == ConnectionState.Open)
                        Cnn.Close();
                }
            }

            return app_version;
        }



    }
}
