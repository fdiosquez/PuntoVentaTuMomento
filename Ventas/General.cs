using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ventas
{
    class General
    {
     
        //CONFIGURACION
        static public string _SYS_UBICACION_DB = "";
        static public string _SYS_THEME = "";
        static public string _PRINTER_TICKET = "";
        static public string _COMERCIO_NOMBRE = "";
        static public string _COMERCIO_LOGO = "";
        static public string _SUCURSAL = "";
        static public string _PUESTO = "";
        static public string _REFRESH_PRODUCTOS = "";
        static public string _CONNECTED = "";

        //USO GLOBAL DEL SISTEMA
        static public int _ID_CAJA_ACTUAL = 0;

        static public List<Producto> _LISTA_PRODUCTOS = new();

        public static string GetConnectionString()
        {
            //return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\oManeger.mdb;";
            //return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\FerrarDB.mdb;Jet OLEDB:Database Password=sh4sh1r0;";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _SYS_UBICACION_DB + ";Jet OLEDB:Database Password=sh4sh1r0;";
        }

        public static void CargarConfiguracion()
        {                            
            _SYS_UBICACION_DB = ConfigurationManager.AppSettings["UBICACION_DB"].ToString();
            _SYS_THEME = ConfigurationManager.AppSettings["THEME"].ToString();
            _PRINTER_TICKET = ConfigurationManager.AppSettings["PRINTER_TICKET"].ToString();
            _COMERCIO_NOMBRE = ConfigurationManager.AppSettings["COMERCIO_NOMBRE"].ToString();
            _COMERCIO_LOGO = ConfigurationManager.AppSettings["COMERCIO_LOGO"].ToString();
            _SUCURSAL = ConfigurationManager.AppSettings["SUCURSAL"].ToString();
            _PUESTO = ConfigurationManager.AppSettings["PUESTO"].ToString();
            _REFRESH_PRODUCTOS = ConfigurationManager.AppSettings["REFRESH_PRODUCTOS"].ToString();
            _CONNECTED = ConfigurationManager.AppSettings["CONNECTED"].ToString();
        }

        
        public static void GuardarConfiguracion(string CONSTANTE, string VALOR)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[CONSTANTE].Value = VALOR;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            CargarConfiguracion();
        }

        public static void CargarDatosDeProductos()
        {

            OleDbDataReader Dr;
            OleDbConnection Cnn;
            OleDbCommand Cmd;
             
            try
            {

                DataTable Dt = new();

                string  Sql = @"SELECT PRODUCTOS.ID_PRODUCTO, 
                                       UCASE(PRODUCTOS.CODIGO_PRODUCTO) AS [CODIGO_PRODUCTO], 
                                       UCASE(PRODUCTOS.DESCRIPCION) AS [DESCRIPCION], 
                                       PRODUCTOS.PRECIO_VENTA,
                                       PRODUCTOS.CODIGO_BARRA, 
                                       PRODUCTOS.FECHA_MODIFICACION,
                                       PRODUCTOS.STOCK
                                 FROM PRODUCTOS";

                Cnn = new OleDbConnection(GetConnectionString());
                Cnn.Open();

                Cmd = new OleDbCommand(Sql, Cnn);                
                Dr = Cmd.ExecuteReader();
                _LISTA_PRODUCTOS.Clear();
                while (Dr.Read())
                {
                   
                    _LISTA_PRODUCTOS.Add(new Producto() { 
                        ID_PRODUCTO = Convert.ToInt32( Dr["ID_PRODUCTO"]),
                        CODIGO_PRODUCTO = (DBNull.Value.Equals(Dr["CODIGO_PRODUCTO"])) ? "" : Dr["CODIGO_PRODUCTO"].ToString() ,
                        DESCRIPCION = (DBNull.Value.Equals(Dr["DESCRIPCION"])) ? "" : Dr["DESCRIPCION"].ToString() ,
                        CODIGO_BARRA = (DBNull.Value.Equals(Dr["CODIGO_BARRA"])) ? "" : Dr["CODIGO_BARRA"].ToString(),
                        PRECIO_VENTA = (DBNull.Value.Equals(Dr["DESCRIPCION"])) ? 0 :  Math.Round( Convert.ToDouble( Dr["PRECIO_VENTA"]),2) ,
                        FECHA_MODIFICACION = (DBNull.Value.Equals(Dr["FECHA_MODIFICACION"])) ? null : Convert.ToDateTime(Dr["FECHA_MODIFICACION"]),
                        STOCK = (DBNull.Value.Equals(Dr["STOCK"])) ? 0 : Convert.ToInt32(Dr["STOCK"])
                    });

                }
               

                Dr.Close();
                Cnn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }

        public static void Log(string Descripcion, string Estado = "OK")
        {

            try
            {

                string Sql = @"INSERT INTO LOG (FECHA,HORA,DESCRIPCION,ESTADO) VALUES ( Date(),TIME(),@DESCRIPCION,@ESTADO)";

                OleDbConnection connection = new OleDbConnection(General.GetConnectionString());
                connection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand(Sql, connection);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.Parameters.Add(new OleDbParameter("@DESCRIPCION", Descripcion));
                oleDbCommand.Parameters.Add(new OleDbParameter("@ESTADO", Estado));
                oleDbCommand.ExecuteNonQuery();
                connection.Close();
                oleDbCommand.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void FillCajaTipo(ComboBox Cbo, string DefaultText, int Tipo)
        {
            
            OleDbDataReader Dr;
            OleDbConnection Cnn;
            OleDbCommand Cmd;
            OleDbDataAdapter DA;                         
            try
            {
                Cnn = new OleDbConnection(General.GetConnectionString() );
                Cnn.Open();

                string SQL = "";

                switch (Tipo)
                {
                    case 1:
                        SQL = "SELECT ID_CAJA_TIPO,DESCRIPCION FROM CAJA_TIPO WHERE ID_CAJA_TIPO = 1 ORDER BY DESCRIPCION";
                        break;
                    case 7:
                    case 8:
                        SQL = "SELECT ID_CAJA_TIPO,DESCRIPCION FROM CAJA_TIPO WHERE ID_CAJA_TIPO IN( 7,8) ORDER BY DESCRIPCION";
                        break;                    
                    default:
                        Console.WriteLine("Número no reconocido.");
                        break;
                }
            




                Cbo.Items.Clear();

                Cmd = new OleDbCommand(SQL, Cnn);
                DA = new OleDbDataAdapter(Cmd);
                DataSet DS = new DataSet();

                DA.Fill(DS, "CAJA_TIPO");

                DataTable DT = new DataTable();
                DataColumn DC_ID = new DataColumn("ID_CAJA_TIPO");
                DataColumn DC_DESCRIPCION = new DataColumn("DESCRIPCION");

                DT.Columns.Add(DC_ID);
                DT.Columns.Add(DC_DESCRIPCION);


                if (DefaultText.Length > 0)
                {
                    object[] arr = { 0, DefaultText };
                    DT.Rows.Add(arr);
                }


                for (int j = 0; j <= DS.Tables[0].Rows.Count - 1; j++)
                {
                    object[] arr = { DS.Tables["CAJA_TIPO"].Rows[j]["ID_CAJA_TIPO"], DS.Tables["CAJA_TIPO"].Rows[j]["DESCRIPCION"] };
                    DT.Rows.Add(arr);
                }

                Cbo.DataSource = DT;
                Cbo.DisplayMember = "DESCRIPCION";
                Cbo.ValueMember = "ID_CAJA_TIPO";
                Cbo.SelectedIndex = 0;
                Cnn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

    }
}
