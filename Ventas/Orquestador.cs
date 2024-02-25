using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas
{
    class Orquestador
    {
        public static void SubirPedidos() 
        {
            //SUBE CABECERA DEL PEDIDO HACIA EL SERVER
            List<PEDIDO> list = Local.TraerPedidosPendientes();
            if (list.Count > 0)
            {
                List<PEDIDO> list_subidos = Server.SubirPedido(list);

                if (list_subidos.Count > 0)
                {
                    Local.AfectarPedidos(list);
                }

            }
            else 
            {
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
                    Server.AfectaStock(list_detail_up);
                    


                }

            }


        }

        public static void BajarProductos()
        {
            //TRAE ALTAS, BAJAS Y MODIFICACIONES DE PRODUCTOS DESDE EL SERVER
            List<TaskProductos> ListaProductos = Server.TraerProductosCambios();
            if (ListaProductos.Count > 0)
            {
                List<TaskProductos> ListaTrabajados = Local.AfectarProductos(ListaProductos);
                CrearFlagFile();

                if (ListaTrabajados.Count > 0)
                {
                    Server.MarcarProductos(ListaTrabajados);

                    //PARA QUE REFRESQUE LA LISTA DE PRODUCTOS EN MEMORIA
                    General.GuardarConfiguracion("REFRESH_PRODUCTOS", "1");
                }

            }
            else 
            {
                General.Log("Productos, sin novedadades!", "INFO");
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
