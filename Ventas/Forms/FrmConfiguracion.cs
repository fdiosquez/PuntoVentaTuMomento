using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Forms
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            cboColores.DataSource = ThemeColor.ColorList;
            cboColores.SelectedText = General._SYS_THEME;
            btnMuestra.BackColor = ColorTranslator.FromHtml(General._SYS_THEME);
        }

        private void cboColores_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Color color = ColorTranslator.FromHtml(cboColores.Text);

            btnMuestra.BackColor = color;
        }

        private void cboColores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            General.GuardarConfiguracion("THEME", cboColores.Text);
            MessageBox.Show("Configuración realizada con exito!", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Orquestador.SubirPedidos();






        }

        private void button5_Click(object sender, EventArgs e)
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            string actual_version = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Revision);

            string nueva_version = Server.VerificaNuevasVersiones();


            if (nueva_version == actual_version)
            {
                MessageBox.Show("Ya posee la última version disponible, se procedera a la actualización");
            }
            else
            {
                MessageBox.Show("Existe una nueva versión de esta App, se procedera a la actualización, presione aceptar para continuar");

                if (CreoBackup(actual_version))
                {
                    string CurrentPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                    string Actualizador = string.Format("{0}\\UPDATE\\VentasUpdate.exe", CurrentPath);


                    if (File.Exists(Actualizador))
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = Actualizador;
                        p.StartInfo.Arguments = string.Format("{0} {1} ", nueva_version, CurrentPath);
                        p.Start();

                        Environment.Exit(0);

                    }
                    else
                    {
                        MessageBox.Show("Falta la aplicación de Actualización");
                    }

                }

            }

        }

        private bool CreoBackup(string actual_version)
        {

            try
            {
                //calcula el path actual
                string CurrentPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                //creo path de Backup segun la vieja version
                string version_PATH_OLD = CurrentPath + "\\BKP_" + actual_version.Replace(".", "_");

                bool exists = System.IO.Directory.Exists(version_PATH_OLD);

                //si no existe diretorio lo creo
                if (!exists)
                    System.IO.Directory.CreateDirectory(version_PATH_OLD);

                //si no existe diretorio creo temporal
                if (!System.IO.Directory.Exists(CurrentPath + "\\TMP"))
                    System.IO.Directory.CreateDirectory(CurrentPath + "\\TMP");


                string destinationDirectory = version_PATH_OLD;

                if (File.Exists(destinationDirectory + "\\Ventas.exe"))
                {
                    File.Delete(destinationDirectory + "\\Ventas.exe");
                }

                if (File.Exists(destinationDirectory + "\\Ventas.dll"))
                {
                    File.Delete(destinationDirectory + "\\Ventas.dll");
                }

                File.Copy(CurrentPath + "\\Ventas.exe", destinationDirectory + "\\Ventas.exe");

                File.Copy(CurrentPath + "\\Ventas.dll", destinationDirectory + "\\Ventas.dll");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
