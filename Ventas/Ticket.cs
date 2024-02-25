using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas
{
    public class Ticket
    {
        static public long ID_PEDIDO;

        public static void Crear(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            OleDbDataReader Dr;
            OleDbConnection Cnn;
            OleDbCommand Cmd;

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 120;



            string Sql = null;

            Cnn = new OleDbConnection(General.GetConnectionString());
            Cnn.Open();


            Sql = @"SELECT  PEDIDOS.FECHA, 
                            PEDIDOS.TOTAL_FINAL, 
                            PEDIDOS.ID_PEDIDO AS PEDIDONRO, 
                            PRODUCTOS.DESCRIPCION, 
                            PEDIDOS_DETALLE.CANTIDAD, 
                            PEDIDOS_DETALLE.PRECIO, 
                            PEDIDOS_DETALLE.SUBTOTAL
                    FROM (PEDIDOS INNER JOIN PEDIDOS_DETALLE ON PEDIDOS.ID_PEDIDO = PEDIDOS_DETALLE.ID_PEDIDO) 
                                INNER JOIN PRODUCTOS ON PEDIDOS_DETALLE.ID_PRODUCTO = PRODUCTOS.ID_PRODUCTO
                    WHERE PEDIDOS.ID_PEDIDO = " + ID_PEDIDO.ToString();


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
                        System.Drawing.Image img = System.Drawing.Image.FromFile(General._COMERCIO_LOGO);
                        graphic.DrawImage(img, 80, 5, 129 /*ANCHO*/, 129 /*ALTO*/);

                        graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("PRESUPUESTO N°: " + Convert.ToString(Dr["PEDIDONRO"]), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("FECHA : " + String.Format("{0:dd/MM/yyyy}", Dr["FECHA"]), font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);


                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString(Convert.ToString("Consumidor Final"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                        //offset = offset + (int)fontHeight; //make the spacing consistent
                        //graphic.DrawString(Convert.ToString(Dr["DOMICILIO"]), font, new SolidBrush(Color.Black), startX, startY + offset);

                        /**/

                        //offset = offset + (int)fontHeight; //make the spacing consistent
                        //SizeF sf = graphic.MeasureString(Convert.ToString(Dr["DOMICILIO"]), new Font(new FontFamily("Courier New"), 12), 300);

                        //graphic.DrawString(Convert.ToString(Dr["DOMICILIO"]), new Font(new FontFamily("Courier New"), 12), Brushes.Black, new RectangleF(new PointF(startX + 1, startY + offset), sf), StringFormat.GenericTypographic);


                        //offset = offset + (int)fontHeight; //make the spacing consistent
                        //offset = offset + (int)fontHeight; //make the spacing consistent

                        //graphic.DrawString("TEL: " + Convert.ToString(Dr["TELEFONO"]), font, new SolidBrush(Color.Black), startX, startY + offset);


                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);


                       

                    }


                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString(Convert.ToString(Dr["DESCRIPCION"]), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString(String.Format("{0,-8} {1,16}", Convert.ToString(Dr["CANTIDAD"]) + "x" + Convert.ToString(Dr["PRECIO"]), String.Format("{0:c}", Dr["SUBTOTAL"])), font, new SolidBrush(Color.Black), startX, startY + offset);

                    total += Convert.ToDouble(Dr["SUBTOTAL"]);
                    fila++;

                }


                offset = offset + (int)fontHeight + 5; //make the spacing consistent
                graphic.DrawString("=========================", font, new SolidBrush(Color.Black), startX, startY + offset);



                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8} {1,16}", "TOTAL", String.Format("{0:c}", total)), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);


                offset = offset + (int)fontHeight; //make the spacing consistent
                offset = offset + (int)fontHeight; //make the spacing consistent

                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8}", "Cambios o reclamos dentro de las"), new Font("Courier New", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8}", "24hs sin excepción."), new Font("Courier New", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);

                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(String.Format("{0,-8}", "Esmaltes sin cambio."), new Font("Courier New", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);

                //if (seña > 0)
                //{
                //    offset = offset + (int)fontHeight; //make the spacing consistent
                //    graphic.DrawString(String.Format("{0,-8} {1,16}", "SEÑA", String.Format("{0:c}", seña)), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + (int)fontHeight; //make the spacing consistent
                //    graphic.DrawString(String.Format("{0,-8} {1,16}", "A COBRAR", String.Format("{0:c}", total - seña)), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);    

                //}


            }





            //offset = offset + 30; //make some room so that the total stands out.
            //graphic.DrawString("     Thank-you for your custom,", font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 15;
            //graphic.DrawString("       please come back soon!", font, new SolidBrush(Color.Black), startX, startY + offset);

        }

    }
}
