using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Ventas.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;


namespace Ventas
{
    public partial class FrmMain : Form
    {

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private Button currentButton;
        //private Random random;
        //private int tempIndex;
        private Form activeForm;
        private System.Timers.Timer _TIMER;

        

        public FrmMain()
        {
            InitializeComponent();

            //if (General._CONNECTED == "1")
            //{
            //    InicializaTimer();
            //}

        }

        /*
        private void InicializaTimer()
        {
            _TIMER = new System.Timers.Timer();
            _TIMER.Interval = 100000;
            _TIMER.Elapsed += TIMER_Tick;
            _TIMER.Start();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            _TIMER.Stop();
            Thread th1 = new Thread(new ThreadStart(Orquestador.BajarProductos));
            th1.Start();
            th1.Join();

            if (th1.ThreadState == System.Threading.ThreadState.Stopped)
            {


                if (ConfigurationManager.AppSettings["REFRESH_PRODUCTOS"].ToString() == "1")
                {
                    General.GuardarConfiguracion("REFRESH_PRODUCTOS", "0");
                    General.CargarDatosDeProductos();
                }
            }

            _TIMER.Start();
        }*/

        private Color SelectThemeColor()
        {

            //PARA HACERLO RANDOM
            //int n = ThemeColor.ColorList.Count();
            //int index = random.Next(n);

            //while (tempIndex == index)
            //{
            //    index = random.Next(ThemeColor.ColorList.Count);
            //}
            //tempIndex = index;            
            //string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(General._SYS_THEME);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();

            childForm.Show();
            lblTitle.Text = childForm.Text;
            panelTitleBar.Visible = true;
        }


        private void OpenChildForm(FrmVenta childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();

            panelTitleBar.Visible = false;

            //childForm.OnChildTextChanged += new EventHandler(child_OnChildTextChanged);

            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void OpenChildForm(FrmEventos childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();

            panelTitleBar.Visible = false;

            //childForm.OnChildTextChanged += new EventHandler(child_OnChildTextChanged);

            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void OpenChildForm(FrmVentaConsultas childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();

            panelTitleBar.Visible = false;

            //childForm.OnChildTextChanged += new EventHandler(child_OnChildTextChanged);

            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void OpenChildForm(FrmCaja childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();

            panelTitleBar.Visible = false;

            childForm.Show();
            lblTitle.Text = childForm.Text;

        }

        private void OpenChildForm(FrmProductos childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();

            panelTitleBar.Visible = false;

            childForm.Show();
            lblTitle.Text = childForm.Text;

        }

        void child_OnChildTextChanged(object sender, EventArgs e)
        {
            lblTitle.Text = (string)sender;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {

                CultureInfo forceDotCulture = (CultureInfo)Application.CurrentCulture.Clone();
                forceDotCulture.NumberFormat.NumberDecimalSeparator = ".";
                forceDotCulture.NumberFormat.NumberGroupSeparator = ",";
                forceDotCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                Application.CurrentCulture = forceDotCulture;


                //EVITAR QUE CORRA 2 VECES
                Process currentProcess = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName("Ventas");                
                if (processes.Length > 1)
                {
                    foreach (Process process in processes)
                    {
                        if (process.Id != currentProcess.Id)
                        {
                            // Maximizar la ventana del proceso existente
                            ShowWindow(process.MainWindowHandle, SW_SHOWMAXIMIZED);
                            // Enfocar la ventana del proceso existente
                            SetForegroundWindow(process.MainWindowHandle);
                            // Cerrar la instancia actual
                            Environment.Exit(0);
                            return;
                        }
                    }
                }


                Version version = Assembly.GetEntryAssembly().GetName().Version;



                this.Text = string.Format("Punto de Venta v{0}.{1}", version.Major, version.Minor);
                

                //CARGA DATOS DEL SISTEMA

                General.CargarConfiguracion();



                panelTitleBar.BackColor = ThemeColor.PrimaryColor;

                if (!File.Exists(General._SYS_UBICACION_DB))
                {
                    MessageBox.Show("Ubicación de base de datos no encontrada", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }


                General.CargarDatosDeProductos();

                SetPrimerSetup();

                //if (!InicializaUbicacionBD())
                //    Environment.Exit(0);

                //if (!pidePIN())
                //    Environment.Exit(0);

                //VerificaMenu();


                //configuracion.Aplicacion.CargarConfiguracionPrincipal();

                //toolStripStatusLabel.Text = "Conectado a " + cls.General._SYS_UBICACION_DB;

                Local.EliminaLogAntiguo();

                btnNuevo_Click(btnNuevo, null);


                General._ID_CAJA_ACTUAL = Caja.ExisteCajaDelDia();

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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetPrimerSetup()
        {
            lblNombreEmpresa.Text = General._COMERCIO_NOMBRE;
            toolLabelBD.Text = General._SYS_UBICACION_DB;
            toolLabelSucursal.Text = "| Sucursal: " + General._SUCURSAL;
            toolLabelPuesto.Text = "| Puesto: " + General._PUESTO;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FrmVenta(), sender);
        }

        private void btnConsultaPedidos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FrmVentaConsultas(), sender);
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCaja(), sender);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FrmProductos(), sender);
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FrmEventos(), sender);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FrmConfiguracion(), sender);
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}