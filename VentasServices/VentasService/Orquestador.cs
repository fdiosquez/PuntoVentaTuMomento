using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;


namespace VentasService
{
    class Orquestador
    {
        public static void SubirPedidos(ILogger<Worker> _logger) 
        {
            //SUBE CABECERA DEL PEDIDO HACIA EL SERVER
            List<PEDIDO> list = Local.TraerPedidosPendientes();
            if (list.Count > 0)
            {
                _logger.LogInformation("Existen pedidos pendientes");

                List<PEDIDO> list_subidos = Server.SubirPedido(list);

                if (list_subidos.Count > 0)
                {
                    Local.AfectarPedidos(list);
                }

            }
            else 
            {
                _logger.LogInformation("Pedidos, sin novedadades!");
                General.Log("Pedidos, sin novedadades!", "INFO");
            }

            //SUBE DETALLES DEL PEDIDO HACIA EL SERVER
            List<PEDIDO_DETALLE> list_detail = Local.TraerPedidosDetallesPendientes();
            if (list_detail.Count > 0)
            {
                
                List<PEDIDO_DETALLE> list_detail_up = Server.SubirPedidoDetalle(list_detail);

                if (list_detail_up.Count > 0)
                {
                    //MARCA EL PEDIDOS_DETALLE LOCAL
                    Local.AfectarPedidosdDetalles(list_detail_up);

                    //CAMBIA EL STOCK DE LA SUCURSAL EN EL SERVER
                   // Server.AfectaStock(list_detail_up);
                    


                }

            }


        }

        public static void BajarProductos(ILogger<Worker> _logger)
        {
            //TRAE ALTAS, BAJAS Y MODIFICACIONES DE PRODUCTOS DESDE EL SERVER
            List<TaskProductos> ListaProductos = Server.TraerProductosCambios();
            if (ListaProductos.Count > 0)
            {
                _logger.LogInformation("Existe productos con novedades");
                CrearFlagFile();

                List<TaskProductos> ListaTrabajados = Local.AfectarProductos(ListaProductos);

                if (ListaTrabajados.Count > 0)
                {
                    Server.MarcarProductos(ListaTrabajados);
                }

            }
            else 
            {                
                _logger.LogInformation("Productos, sin novedadades!");
            }


        }


        public static void CrearFlagFile()
        {
            
            string directorio = Path.GetDirectoryName(General._SYS_UBICACION_DB);

            string filePath = directorio + "\\Flag.txt";


            // Utiliza la clase File para crear un nuevo archivo de texto
            using (StreamWriter writer = File.CreateText(filePath))
            {
                // Escribe en el archivo
                writer.WriteLine("¡FlagFile!");
                writer.WriteLine("Este es un archivo de texto creado con .NET Core para actualizar productos en una llamda asincronica");
            }
            
        }



    }
}
