using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ventas
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


    public class Cliente
    {
        public int ID_CLIENTE { get; set; }        
        public string DESCRIPCION { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION { get; set; }
        
        public string EMAIL { get; set; }
        public double SALDO { get; set; }
        public bool SISTEMA { get; set; }


        public Cliente()
        {
            this.ID_CLIENTE = 0;
            this.DESCRIPCION = string.Empty;
            this.DIRECCION   = string.Empty; 
            this.TELEFONO = string.Empty;
            this.EMAIL = string.Empty;
            this.SALDO = 0;
            this.SISTEMA = false;

        }
    }
      

}

