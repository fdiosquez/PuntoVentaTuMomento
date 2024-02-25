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

    }
}
