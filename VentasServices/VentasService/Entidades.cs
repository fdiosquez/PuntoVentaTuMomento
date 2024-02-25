using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasService
{
    public class Producto
    {
        public int ID_PRODUCTO { get; set; }        
        public string? CODIGO_PRODUCTO { get; set; }
        public string? DESCRIPCION { get; set; }
        public double PRECIO_VENTA { get; set; }        
        public string? CODIGO_BARRA { get; set; }
        public int STOCK { get; set; }
        public DateTime? FECHA_MODIFICACION { get; set; }

    }

    public class TaskProductos
    {
        public int task_id_producto { get; set; }
        public string? tipo { get; set; }
        public int id_producto { get; set; }
        public string? codigo_producto { get; set; }
        public string? codigo_barra { get; set; }
        public string? descripcion { get; set; }
        public int stock { get; set; }
        public double precio { get; set; }
    }

    public class PEDIDO
    {
        public int ID_PEDIDO { get; set; }
        public int ID_SUCURSAL { get; set; }
        public DateTime FECHA { get; set; }
        public double TOTAL_PEDIDO { get; set; }
        public double DESCUENTO { get; set; }
        public double TOTAL_FINAL { get; set; }
        public double CANCELADO { get; set; }
        public double EFECTIVO { get; set; }
        public double TRANSFERENCIA { get; set; }
        public double DEBITO { get; set; }
        public double QR { get; set; }
        public string? OBSERVACIONES { get; set; }

    }

    public class PEDIDO_DETALLE
    {
        public int  ID_PEDIDO_DETALLE { get; set; }
        public int ID_SUCURSAL { get; set; }
        public int ID_PEDIDO { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
        public double PRECIO { get; set; }
        public double SUBTOTAL { get; set; }

    }


}

