using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Ventas.Forms
{
    public partial class FrmEsperar : Form
    {
        /*
            tipo = 0 descarga productos desde el server
            tipo = 1 carga los productos en memoria
         */

        int _TIPO = 0; // 
        private System.Timers.Timer _TIMER;

        public FrmEsperar()
        {
            InitializeComponent();
        }

        private void FrmEsperar_Load(object sender, EventArgs e)
        {


            //button1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 50;
            progressBar1.BackColor = ThemeColor.PrimaryColor;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();            

        }
    

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_TIPO == 0)
            {
                Orquestador.BajarProductos();
            }

            if (_TIPO == 1)
            {
                General.CargarDatosDeProductos();                
            }

            if (_TIPO == 2)
            {
                Orquestador.TraerProductosPrimeraVez();
                
            }

            if (_TIPO == 3)
            {
                General.CargarDatosDeProductos();
            }

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Minimum;

            this.DialogResult = DialogResult.OK;
        }

        public DialogResult ShowDialog(int tipo)
        {
            _TIPO = tipo;
            return ShowDialog();
        }

    }
}
