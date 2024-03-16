using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasService
{
    class General
    {
        static public string _SYS_UBICACION_DB = "";
        static public string _SUCURSAL = "";

        public static string GetConnectionString()
        {            
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _SYS_UBICACION_DB + ";Jet OLEDB:Database Password=sh4sh1r0;";
        }

        public static void Log(string Descripcion, string Estado = "OK")
        {
            //logueo en txt todo lo que caiga.
            LogTXT(Descripcion);

            using (OleDbConnection connection = new OleDbConnection(General.GetConnectionString()))
                {
                    try
                    {
                        
                        connection.Open();
                        string Sql = @"INSERT INTO LOG (FECHA,HORA,DESCRIPCION,ESTADO) VALUES ( Date(),TIME(),@DESCRIPCION,@ESTADO)";                        
                        
                        OleDbCommand oleDbCommand = new OleDbCommand(Sql, connection);
                        oleDbCommand.CommandType = CommandType.Text;
                        oleDbCommand.Parameters.Add(new OleDbParameter("@DESCRIPCION", Descripcion));
                        oleDbCommand.Parameters.Add(new OleDbParameter("@ESTADO", Estado));
                        oleDbCommand.ExecuteNonQuery();
                        connection.Close();
                        oleDbCommand.Dispose();
                     }
                    catch (Exception ex)
                    {                        
                        LogTXT("Log():" + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }

        }

        public static void LogTXT(string description)
        {
            // Obtener la fecha y hora actual
            DateTime now = DateTime.Now;

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;            

            string logFilePath = Path.Combine(baseDirectory, "logServices.txt");

            // Formatear la fecha y hora
            string formattedDateTime = now.ToString("yyyy-MM-dd HH:mm:ss");

            // Crear el mensaje a escribir en el archivo de log
            string logMessage = $"[{formattedDateTime}] {description}\n";

            

            // Verificar si el archivo de log tiene más de un mes de antigüedad
            DateTime oneMonthAgo = now.AddMonths(-1);
            if (File.Exists(logFilePath))
            {
                DateTime creationTime = File.GetCreationTime(logFilePath);
                if (creationTime < oneMonthAgo)
                {
                    //El archivo de log ha sido eliminado debido a su antigüedad.
                    File.Delete(logFilePath);                    
                }
            }

            // Escribir en el archivo de log
            File.AppendAllText(logFilePath, logMessage);
        }



    }
}
