using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using System.Threading;
using static System.Windows.Forms.DataFormats;

namespace Ventas.Forms
{
    public partial class FrmVenta : Form
    {
        public event EventHandler OnChildTextChanged;
        double _TOTAL_PEDIDO = 0;
        bool _FIRST_SEARCH = true;
        private System.Timers.Timer _TIMER;

        public FrmVenta()
        {
            InitializeComponent();

            if (General._CONNECTED == "1")
            {
                InicializaTimer();
            }
        }

        private void InicializaTimer()
        {
            //_TIMER.Interval = 200000;
            //Timer(20 * 60 * 1000);
            _TIMER = new System.Timers.Timer(20 * 60 * 1000);
            //_TIMER.Interval = 200000;
            _TIMER.Elapsed += TIMER_Tick;
            _TIMER.Start();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            _TIMER.Stop();

            //REVISO SI EXISTE ARCHIVO
            string directorio = Path.GetDirectoryName(General._SYS_UBICACION_DB);
            string filePath = directorio + "\\Flag.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    
                    // Accede al panel desde el hilo principal utilizando Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.pnlActualizacion.Visible = true; // Modifica el control en el hilo principal
                    });
                    
                }
                catch (Exception)
                {

                }
                
            }


            _TIMER.Start();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {


            SetColorTheme();
            ConfigGrid();
            ToggleBuscador();
            this.ActiveControl = txtInput;


        }

        private void ToggleBuscador()
        {
            if (PanelBusquedaSugerida.Visible)
                PanelBusquedaSugerida.Visible = false;
            else
                PanelBusquedaSugerida.Visible = true;
        }

        private void ConfigGrid()
        {
            // Create an unbound DataGridView by declaring a column count.
            dgPedidos.ColumnCount = 5;
            dgPedidos.ColumnHeadersVisible = true;
            //Set the column header style.



            //Set the column header names.
            dgPedidos.Columns[0].Name = "ID_PRODUCTO";
            dgPedidos.Columns[1].Name = "DESCRIPCIÓN";
            dgPedidos.Columns[2].Name = "PRECIO";
            dgPedidos.Columns[3].Name = "CANTIDAD";
            dgPedidos.Columns[4].Name = "SUB TOTAL";



            //Dim colImagen As DataGridViewImageColumn = New DataGridViewImageColumn()
            //colImagen.Name = "Adj."
            //colImagen.HeaderText = "Adj."
            //colImagen.Width = 30
            //// añadir columna de imagen a la colección del grid
            //Me.dgPedidos.Columns.Add(colImagen)
            dgPedidos.Columns[0].Visible = false;
            //dgPedidos.Columns[3].DefaultCellStyle.Format = "d";

            dgPedidos.Columns[1].Width = 300; //descripcion
            dgPedidos.Columns[2].Width = 100; //PRECIO
            dgPedidos.Columns[3].Width = 100; //CANTIDAD


            dgPedidos.Columns[1].ReadOnly = true; //descripcion

            //dgPedidos.Columns[4].ReadOnly = true; //%IVA
            //dgPedidos.Columns[5].ReadOnly = true; //$IVAs
            //dgPedidos.Columns[6].ReadOnly = true; //$IVAs


            dgPedidos.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPedidos.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPedidos.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPedidos.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPedidos.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            //dgPedidos.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgPedidos.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;



            dgPedidos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPedidos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgPedidos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgPedidos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgPedidos.Rows.Clear();

            dgPedidos.MultiSelect = false;
            dgPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPedidos.AllowUserToAddRows = false;
            dgPedidos.ReadOnly = true;
            dgPedidos.AllowUserToDeleteRows = false;


        }

        private void SetColorTheme()
        {
            //DATAGRID VIEW
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = ThemeColor.SecondaryColor;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = ThemeColor.SecondaryColor;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //PANEL
            panelTitleBar.BackColor = ThemeColor.PrimaryColor;

            //BOTONES
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    if (btn.Name == "btnCancelar")
                        btn.BackColor = ColorTranslator.FromHtml("#FF5722");
                    else
                        btn.BackColor = ThemeColor.PrimaryColor;

                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;


                    btn.FlatStyle = FlatStyle.Flat;
                }
            }

            //PANEL TITLE
            foreach (Control btns in panelTitleBar.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }

            //PANEL BUSQUEDA SUGERIDA
            foreach (Control btns in PanelBusquedaSugerida.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (OnChildTextChanged != null)
            //    OnChildTextChanged("HOLAAAAAAALAAAAAA", null);

            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {
                dgPedidos.Rows.RemoveAt(dgPedidos.CurrentRow.Index);
                CalculaTotalPedido();
            }

        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnBuscar_Click(null, null);
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SumarCantidadProducto();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string CODE_BAR = txtInput.Text.Trim();

            CODE_BAR = CODE_BAR.Replace("[", "");


            //1ero busco por codigo de barra
            Producto busqueda = General._LISTA_PRODUCTOS.Find(x => x.CODIGO_BARRA == CODE_BAR);


            //3ero si no lo encuentro lo busco por descripcion
            if (busqueda == null)
            {
                BuscarProductoSugerencia(CODE_BAR);

                //   PanelBusquedaMostrar();
                return;
            }

            // AgregaProductoGrilla2(string.Empty, 0, CANT, busqueda);

            AgregarProductoGrilla(busqueda);

            _FIRST_SEARCH = true;


        }

        private void AgregarProductoGrilla(Producto pro)
        {


            if (ExisteProducto(pro.ID_PRODUCTO))
            {
                SumaCantidadProducto(pro.ID_PRODUCTO);
            }
            else
            {
                double cantidad = 1;
                double subtotal = cantidad * pro.PRECIO_VENTA;

                dgPedidos.Rows.Add(pro.ID_PRODUCTO, pro.DESCRIPCION, String.Format("{0:N}", pro.PRECIO_VENTA), cantidad, String.Format("{0:N}", subtotal));
            }


            CalculaTotalPedido();

            txtInput.Text = "";
            txtInput.Focus();

        }


        private void BuscarProductoSugerencia(string Busqueda)
        {
            if (_FIRST_SEARCH) //-->PARA QUE NO CIERRE EL BUSCADOR SI HACE VARIAS BUSQUEDAS
                ToggleBuscador();

            Cursor.Current = Cursors.WaitCursor;
            dgBusqueda.SuspendLayout();
            dgBusqueda.VirtualMode = true;

            dgBusqueda.DataSource = General._LISTA_PRODUCTOS.FindAll(a => a.DESCRIPCION.Contains(Busqueda.ToUpper()) || a.CODIGO_PRODUCTO.Contains(Busqueda.ToUpper()));


            //VISIBLES
            dgBusqueda.Columns[0].Visible = false;
            dgBusqueda.Columns["CODIGO_BARRA"].Visible = false;
            dgBusqueda.Columns["FECHA_MODIFICACION"].Visible = false;

            //ANCHOS
            dgBusqueda.Columns["CODIGO_PRODUCTO"].Width = 100;
            dgBusqueda.Columns["DESCRIPCION"].Width = 450;
            dgBusqueda.Columns["PRECIO_VENTA"].Width = 100;
            dgBusqueda.Columns["PRECIO_VENTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //TEXTO CABECERA
            dgBusqueda.Columns["CODIGO_PRODUCTO"].HeaderText = "CÓDIGO";
            dgBusqueda.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";
            dgBusqueda.Columns["PRECIO_VENTA"].HeaderText = "PRECIO";

            dgBusqueda.Columns["STOCK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgBusqueda.MultiSelect = false;
            dgBusqueda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgBusqueda.AllowUserToAddRows = false;
            dgBusqueda.ReadOnly = true;
            dgBusqueda.ResumeLayout(true);

            _FIRST_SEARCH = false;
        }

        private void btnCerrarBuscador_Click(object sender, EventArgs e)
        {
            _FIRST_SEARCH = true;
            ToggleBuscador();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (PanelBusquedaSugerida.Visible && e.KeyCode == Keys.Down)
            {
                dgBusqueda.Focus();
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto pro = dgBusqueda.SelectedRows[0].DataBoundItem as Producto;
                AgregarProductoGrilla(pro);
                ToggleBuscador();
                _FIRST_SEARCH = true;

                e.Handled = true;
            }
        }

        private void CalculaTotalPedido()
        {
            //CALCULA EL TOTAL DEL PEDIDO CUANDO SE AGREGA UN PRODUCTO A LA GRILLA

            Int32 i;
            double Total = 0;
            double CantArt = 0;
            DataGridViewCell dgc;



            //Recorremos el DataGridView con un bucle for
            for (i = 0; i < dgPedidos.Rows.Count; i++)
            {
                dgc = dgPedidos.Rows[i].Cells[4];
                Total += Convert.ToDouble(dgc.Value);

                CantArt += Convert.ToDouble(dgPedidos.Rows[i].Cells[3].Value);

            }

            _TOTAL_PEDIDO = Total;
            lblTotal.Text = String.Format("$ {0:N}", Total);
            //txtCantidadArticulos.Text = CantArt.ToString();

        }

        private bool ExisteProducto(long ID_PRODUCTO)
        {
            //DETERMINA SI YA EXISTE O NO EL PRODUCTO EN LA GRILLA
            Int16 i;
            bool existe = false;

            for (i = 0; i < dgPedidos.Rows.Count; i++)
            {
                if (Convert.ToInt64(dgPedidos.Rows[i].Cells[0].Value) == ID_PRODUCTO)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        private void SumaCantidadProducto(long ID_PRODUCTO)
        {
            //LE COLOCA LA NUEVA CANTIDAD EL PRODUCTO EN LA GRILLA
            double CANTIDAD = DameCantidadProducto(ID_PRODUCTO);

            CANTIDAD++;

            for (int i = 0; i < dgPedidos.Rows.Count; i++)
            {
                if (Convert.ToInt64(dgPedidos.Rows[i].Cells[0].Value) == ID_PRODUCTO)
                {

                    Double precio = Convert.ToDouble(dgPedidos.Rows[i].Cells[2].Value);

                    Double SUB_TOTAL = CANTIDAD * precio;

                    dgPedidos.Rows[i].Cells[3].Value = CANTIDAD;
                    dgPedidos.Rows[i].Cells[4].Value = String.Format("{0:N}", SUB_TOTAL);

                    break;
                }
            }

        }

        private void RestaCantidadProducto(long ID_PRODUCTO)
        {
            //LE COLOCA LA NUEVA CANTIDAD EL PRODUCTO EN LA GRILLA
            double CANTIDAD = DameCantidadProducto(ID_PRODUCTO);

            CANTIDAD--;

            if (CANTIDAD == 0)
                return;

            for (int i = 0; i < dgPedidos.Rows.Count; i++)
            {
                if (Convert.ToInt64(dgPedidos.Rows[i].Cells[0].Value) == ID_PRODUCTO)
                {

                    Double precio = Convert.ToDouble(dgPedidos.Rows[i].Cells[2].Value);

                    Double SUB_TOTAL = CANTIDAD * precio;

                    dgPedidos.Rows[i].Cells[3].Value = CANTIDAD;
                    dgPedidos.Rows[i].Cells[4].Value = String.Format("{0:N}", SUB_TOTAL);

                    break;
                }
            }

        }

        private long DameCantidadProducto(long ID_PRODUCTO)
        {
            //RETORNA LA CANTIDAD QUE TIENE UN PRODUCTO EN LA GRILLA
            Int16 i;
            long cantidad = 0;

            for (i = 0; i < dgPedidos.Rows.Count; i++)
            {
                if (Convert.ToInt64(dgPedidos.Rows[i].Cells[0].Value) == ID_PRODUCTO)
                {
                    cantidad = Convert.ToInt64(dgPedidos.Rows[i].Cells[3].Value);
                    break;
                }
            }
            return cantidad;
        }


        private void SumarCantidadProducto()
        {
            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {
                SumaCantidadProducto(Convert.ToInt64(dgPedidos.CurrentRow.Cells[0].Value));
                CalculaTotalPedido();
            }
        }

        private void RestarCantidadProducto()
        {
            if (dgPedidos.RowCount >= 1 && dgPedidos.CurrentRow.Index != -1)
            {

                RestaCantidadProducto(Convert.ToInt64(dgPedidos.CurrentRow.Cells[0].Value));
                CalculaTotalPedido();
            }
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            RestarCantidadProducto();
        }

        private void btnGuardar_Click(object sender, EventArgs? e)
        {


            if (dgPedidos.Rows.Count == 0)
            {
                MessageBox.Show("Debe cargar al menos un producto a la venta", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInput.Focus();
                return;
            }

            //SI NO EXISTE CAJA ACTUAL SOLICITO APERTURA            
            if (General._ID_CAJA_ACTUAL == 0)
            {
                while (true)
                {
                    FrmCajaNuevo frmCaja = new FrmCajaNuevo();

                    //1=APERTURA DE CAJA
                    if (frmCaja.ShowDialog(1) == DialogResult.OK)
                    {
                        // Realizar acciones después de que el usuario haya presionado "OK"
                        break; // Salir del bucle si DialogResult.OK es verdadero
                    }
                }
            }

            FrmVentaMetodoPago frm = new FrmVentaMetodoPago();

            if (frm.ShowDialog(_TOTAL_PEDIDO) == DialogResult.OK)
            {

                if (Grabar(frm))
                {
                    MessageBox.Show("Pedido realizado con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();

                    if (General._CONNECTED == "1")
                    {
                        // InformarPedidosAlserver();
                    }

                }
            }


        }

        private void InformarPedidosAlserver()
        {
            Thread th1 = new Thread(new ThreadStart(Orquestador.SubirPedidos));
            th1.Start();
            th1.Join();
        }

        private void ClearForm()
        {
            dgPedidos.Rows.Clear();
            txtInput.Focus();
            CalculaTotalPedido();
            _TOTAL_PEDIDO = 0;
        }

        private bool Grabar(FrmVentaMetodoPago frm)
        {
            List<PEDIDO_DETALLE> LISTA_STOCK = new List<PEDIDO_DETALLE>();


            if (dgPedidos.Rows.Count == 0)
            {
                MessageBox.Show("Debe cargar al menos un producto a la venta", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInput.Focus();
                return false;
            }

            bool _RESULT = false;

            try
            {

                int ID_PEDIDO = 0;


                string Sql = @"INSERT INTO pedidos(FECHA,TOTAL_PEDIDO,DESCUENTO,TOTAL_FINAL,EFECTIVO,TRANSFERENCIA,DEBITO,QR,OBSERVACIONES)  
                                        VALUES(@FECHA,@TOTAL_PEDIDO,@DESCUENTO,@TOTAL_FINAL,@EFECTIVO,@TRANSFERENCIA,@DEBITO,@QR,@OBSERVACIONES)";


                OleDbConnection connection = new OleDbConnection(General.GetConnectionString());
                connection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand(Sql, connection);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FECHA", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"))));
                oleDbCommand.Parameters.Add(new OleDbParameter("@TOTAL_PEDIDO", _TOTAL_PEDIDO));
                oleDbCommand.Parameters.Add(new OleDbParameter("@DESCUENTO", frm._VALOR_DESCUENTO));
                oleDbCommand.Parameters.Add(new OleDbParameter("@TOTAL_FINAL", frm._VALOR_FINAL));
                oleDbCommand.Parameters.Add(new OleDbParameter("@EFECTIVO", frm._VALOR_EFECTIVO));
                oleDbCommand.Parameters.Add(new OleDbParameter("@TRANSFERENCIA", frm._VALOR_TRANSFERENCIA));
                oleDbCommand.Parameters.Add(new OleDbParameter("@DEBITO", frm._VALOR_DEBITO));
                oleDbCommand.Parameters.Add(new OleDbParameter("@QR", frm._VALOR_QR));
                oleDbCommand.Parameters.Add(new OleDbParameter("@OBSERVACIONES", frm._METEDO_OBSERVACION));
                if (oleDbCommand.ExecuteNonQuery() > 0)
                {

                    OleDbDataReader oleDbDataReader = new OleDbCommand("SELECT Max(ID_PEDIDO) AS [ID_PEDIDO] FROM PEDIDOS;", connection).ExecuteReader();

                    if (oleDbDataReader.Read())
                    {
                        _RESULT = true;
                        ID_PEDIDO = Convert.ToInt32(oleDbDataReader["ID_PEDIDO"]);

                        for (int index = 0; index < this.dgPedidos.Rows.Count; ++index)
                        {

                            int ID_PRODUCTO = Convert.ToInt32(dgPedidos.Rows[index].Cells["ID_PRODUCTO"].Value);
                            double CANTIDAD = Convert.ToDouble(dgPedidos.Rows[index].Cells["CANTIDAD"].Value);
                            double PRECIO = Convert.ToDouble(dgPedidos.Rows[index].Cells["PRECIO"].Value);
                            double SUBTOTAL = Convert.ToDouble(dgPedidos.Rows[index].Cells["SUB TOTAL"].Value);

                            Sql = @"INSERT INTO pedidos_detalle (ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO,SUBTOTAL) 
                                    VALUES (@ID_PEDIDO,@ID_PRODUCTO,@CANTIDAD,@PRECIO,@SUBTOTAL)";

                            OleDbCommand oleDbCommandDet = new OleDbCommand(Sql, connection);
                            oleDbCommandDet.CommandType = CommandType.Text;
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@ID_PRODUCTO", ID_PRODUCTO));
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@CANTIDAD", CANTIDAD));
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@PRECIO", PRECIO));
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@SUBTOTAL", SUBTOTAL));
                            if (oleDbCommandDet.ExecuteNonQuery() > 0)
                            {
                                LISTA_STOCK.Add(new PEDIDO_DETALLE()
                                {
                                    ID_PRODUCTO = ID_PRODUCTO,
                                    CANTIDAD = Convert.ToInt32(CANTIDAD)
                                });
                            }

                        }

                        //BAJA DE STOCK
                        foreach (PEDIDO_DETALLE producto in LISTA_STOCK)
                        {
                            Sql = "UPDATE productos SET stock = IIF( stock - @CANTIDAD < 0, 0,  stock - @CANTIDAD) WHERE id_producto = @ID_PRODUCTO";
                            OleDbCommand oleDbCommandDet = new OleDbCommand(Sql, connection);
                            oleDbCommandDet.CommandType = CommandType.Text;
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@CANTIDAD", producto.CANTIDAD));
                            oleDbCommandDet.Parameters.Add(new OleDbParameter("@ID_PRODUCTO", producto.ID_PRODUCTO));
                            oleDbCommandDet.ExecuteNonQuery();
                        }


                        //INGRESO MOVIMIENTO DE CAJA
                        switch (frm._VALOR_TIPO)
                        {
                            case 2:  //EFECTIVO                              
                            case 3:  //TRANSFERENCIA                              
                            case 4:  //DEBITO
                            case 5:  //QR

                                Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                                OleDbCommand oleDbCaja = new OleDbCommand(Sql, connection);
                                oleDbCaja.CommandType = CommandType.Text;
                                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", frm._VALOR_TIPO));
                                oleDbCaja.Parameters.Add(new OleDbParameter("@VALOR", frm._VALOR_FINAL));
                                oleDbCaja.Parameters.Add(new OleDbParameter("@OBSERVACIONES", frm._METEDO_OBSERVACION));
                                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                                oleDbCaja.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));

                                oleDbCaja.ExecuteNonQuery();
                                break;
                            case 6: //MIXTO

                                if (frm._VALOR_EFECTIVO > 0)
                                {
                                    Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                                    OleDbCommand oleDbEFECTIVO = new OleDbCommand(Sql, connection);
                                    oleDbEFECTIVO.CommandType = CommandType.Text;
                                    oleDbEFECTIVO.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", Convert.ToInt32(2)));
                                    oleDbEFECTIVO.Parameters.Add(new OleDbParameter("@VALOR", frm._VALOR_EFECTIVO));
                                    oleDbEFECTIVO.Parameters.Add(new OleDbParameter("@OBSERVACIONES", frm._METEDO_OBSERVACION));
                                    oleDbEFECTIVO.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                                    oleDbEFECTIVO.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                                    oleDbEFECTIVO.ExecuteNonQuery();
                                }

                                if (frm._VALOR_TRANSFERENCIA > 0)
                                {
                                    Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                                    OleDbCommand oleDbTRANSF = new OleDbCommand(Sql, connection);
                                    oleDbTRANSF.CommandType = CommandType.Text;
                                    oleDbTRANSF.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", Convert.ToInt32(3)));
                                    oleDbTRANSF.Parameters.Add(new OleDbParameter("@VALOR", frm._VALOR_TRANSFERENCIA));
                                    oleDbTRANSF.Parameters.Add(new OleDbParameter("@OBSERVACIONES", frm._METEDO_OBSERVACION));
                                    oleDbTRANSF.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                                    oleDbTRANSF.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                                    oleDbTRANSF.ExecuteNonQuery();
                                }

                                if (frm._VALOR_DEBITO > 0)
                                {
                                    Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                                    OleDbCommand oleDbDEBITO = new OleDbCommand(Sql, connection);
                                    oleDbDEBITO.CommandType = CommandType.Text;
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", Convert.ToInt32(4)));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@VALOR", frm._VALOR_DEBITO));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@OBSERVACIONES", frm._METEDO_OBSERVACION));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                                    oleDbDEBITO.ExecuteNonQuery();
                                }

                                if (frm._VALOR_QR > 0)
                                {
                                    Sql = @"INSERT INTO CAJA (ID_CAJA_TIPO,FECHA,HORA,VALOR,OBSERVACIONES,ID_PEDIDO,ID_CAJA_PARENT) 
                                          VALUES (@ID_CAJA_TIPO,Date(),TIME(),@VALOR,@OBSERVACIONES,@ID_PEDIDO,@ID_CAJA_PARENT)";

                                    OleDbCommand oleDbDEBITO = new OleDbCommand(Sql, connection);
                                    oleDbDEBITO.CommandType = CommandType.Text;
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_CAJA_TIPO", Convert.ToInt32(5)));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@VALOR", frm._VALOR_QR));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@OBSERVACIONES", frm._METEDO_OBSERVACION));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_PEDIDO", ID_PEDIDO));
                                    oleDbDEBITO.Parameters.Add(new OleDbParameter("@ID_CAJA_PARENT", General._ID_CAJA_ACTUAL));
                                    oleDbDEBITO.ExecuteNonQuery();
                                }
                                break;
                        }





                    }
                    oleDbDataReader.Close();
                    Imprimir(ID_PEDIDO);



                }

                oleDbCommand.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return _RESULT;
        }

        private void Imprimir(int id_pedido)
        {

            if (!File.Exists(General._COMERCIO_LOGO))
            {
                MessageBox.Show("No se puede imprimir ticket, Falta configurar el logo.");
                return;
            }

            Ticket.ID_PEDIDO = id_pedido;

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = General._PRINTER_TICKET;
                printDoc.PrintPage += new PrintPageEventHandler(Ticket.Crear);
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void FrmVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnGuardar_Click(btnGuardar, null);
            }

        }

        private void btnMovimientoCaja_Click(object sender, EventArgs e)
        {
            if (General._ID_CAJA_ACTUAL == 0)
            {
                MessageBox.Show("No existe una caja abierta, no se puede pueden agregar movimientos", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (new FrmCajaNuevo().ShowDialog(7) == DialogResult.OK)
            {
                MessageBox.Show("Movimiento generado con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmEsperar frm = new FrmEsperar();
            if (frm.ShowDialog(1) == DialogResult.OK)
            {
                MessageBox.Show("Lista de precios actualizada con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string directorio = Path.GetDirectoryName(General._SYS_UBICACION_DB);
                string filePath = directorio + "\\Flag.txt";

                if (File.Exists(filePath))                               
                    File.Delete(filePath);

                pnlActualizacion.Visible = false;
                txtInput.Focus();
            }

        }
    }
}
