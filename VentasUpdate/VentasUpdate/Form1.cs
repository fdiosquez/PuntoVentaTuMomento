using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VentasUpdate
{
    public partial class Form1 : Form
    {
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();

        
        public String _VERSION_NUEVA = "";
        public String _PATH_DESCARGA = "";

        public String CurrentPath = "";
        public String CurrentPathTmp = "";
        public String NombreExe = "Ventas.exe";


        Aplicacion VersionActual = new Aplicacion();
        Aplicacion VersionNueva = new Aplicacion();

        List<FilesDowload> ArchivosDescargar = new List<FilesDowload>();

        public Form1(string VersionNueva,string path_trabajo)
        {
            InitializeComponent();
            _PATH_DESCARGA = path_trabajo;
            CurrentPath = _PATH_DESCARGA;

            _VERSION_NUEVA = VersionNueva;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000; // 2 segundos
            timer1.Tick += new EventHandler(timer1_Tick);

            // Enable timer.  
            timer1.Enabled = true;
        }

        private void timer1_Tick(object Sender, EventArgs e)
        {

            try
            {


                // Enable timer.  
                timer1.Enabled = false;                

                Process currentProcess = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName("Ventas");
                if (processes.Length > 1)
                {                    
                    processes[0].Kill();
                }


                DescargoArchivos();


                ////calcula el path actual
                //CurrentPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                //VersionActual = VersionActualExe();
                //VersionNueva = VerificaNuevasVersiones();

                //if (VersionActual.Version != VersionNueva.Version)
                //{
                //    MessageBox.Show("Existe una nueva versión de esta App, se procedera a la actualización");

                //    //creo una copia de seguridad de la version actual
                //    if (!CreoBackup())
                //    {
                //        MessageBox.Show("No se pudo crear la copia de seguridad");
                //        EjecutarYsalir();
                //        return;
                //    }

                //descargo archivos en segundo plano
                //DescargoArchivos();

                //}
                //else
                //{

                //    EjecutarYsalir();

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void EjecutarYsalir()
        {
            
            System.Diagnostics.Process.Start(_PATH_DESCARGA + "\\" + NombreExe);

            Environment.Exit(0);

        }


        private bool CreoBackup()
        {

            try
            {

                //creo carpeta de Backup segun la vieja version
                string version_PATH_OLD = CurrentPath + "\\BKP_" + VersionActual.Version.Replace(".", "_");

                bool exists = System.IO.Directory.Exists(version_PATH_OLD);

                //si no existe diretorio lo creo
                if (!exists)
                    System.IO.Directory.CreateDirectory(version_PATH_OLD);


                string destinationDirectory = version_PATH_OLD;

                if (File.Exists(destinationDirectory + "\\" + Path.GetFileName(VersionActual.Path)))
                {
                    File.Delete(destinationDirectory + "\\" + Path.GetFileName(VersionActual.Path));
                }

                File.Copy(VersionActual.Path, destinationDirectory + "\\" + Path.GetFileName(VersionActual.Path));


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private Aplicacion VersionActualExe()
        {
            Aplicacion app = new Aplicacion();

            app.Path = CurrentPath + "\\" + NombreExe;
            //app.Version = AssemblyName.GetAssemblyName(app.Path).Version.ToString();
            app.Version = "";
            return app;
        }
        private Aplicacion VerificaNuevasVersiones()
        {
            Aplicacion app = new Aplicacion();

            MySqlDataReader reader = null;

            string sql = "select * from actualizacion order by id_actualizacion desc limit 1";

            using (MySqlConnection Cnn = new MySqlConnection(ConnectString()))
            {
                try
                {


                    Cnn.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Cnn);
                    reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            app.Version = Convert.ToString(reader["version"]);
                            app.Path = CurrentPath + "\\" + Convert.ToString(reader["archivo"]);
                        }
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al buscar ultima version " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    if (Cnn.State == ConnectionState.Open)
                        Cnn.Close();
                }
            }

            return app;
        }

        public void DownloadFile(string urlAddress, string location)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                //Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                Uri URL = new Uri(urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar1.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {


                foreach (FilesDowload row in ArchivosDescargar)
                {
                    var url = new Uri(row.url);
                    string FileName = System.IO.Path.GetFileName(url.LocalPath);

                    string sourceFile = CurrentPathTmp + "\\" + FileName;
                    string destinationFile = CurrentPath + "\\" + FileName;


                    System.IO.File.Copy(sourceFile, destinationFile, true);
                }


                MessageBox.Show("Actualización realizada con Exito!");

                
                System.Diagnostics.Process.Start(CurrentPathTmp + "\\" + NombreExe);


                Environment.Exit(0);

            }
        }

        private void DescargoArchivos()
        {
            //List<FilesDowload> Files = new List<FilesDowload>();


            //ME TRAIGO LOS ARCHIVOS A DESCARGAR
            ArchivosDescargar = GetFilesForDowload();

            if (ArchivosDescargar.Count == 0)
            {
                MessageBox.Show("No pude descargar los archivos actualizados");
                EjecutarYsalir();
                return;
            }


            //DESCARGO UNO X UNO
            CurrentPathTmp = CurrentPath + "\\TMP"; //-->carpeta temporal de descarga


            if (!System.IO.Directory.Exists(CurrentPathTmp))
                System.IO.Directory.CreateDirectory(CurrentPathTmp);



            foreach (FilesDowload row in ArchivosDescargar)
            {
                var url = new Uri(row.url);
                string FileName = System.IO.Path.GetFileName(url.LocalPath);

                DownloadFile(row.url, CurrentPathTmp + "\\" + FileName);
            }
        }

        private List<FilesDowload> GetFilesForDowload()
        {
            List<FilesDowload> Files = new List<FilesDowload>();
            

            using (MySqlConnection Cnn = new MySqlConnection(ConnectString()))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    MySqlDataReader Dr;
                    MySqlCommand Cmd;
                    Cnn.Open();

                    string Sql = "SELECT url FROM actualizacion_detalle where id_actualizacion in(select id_actualizacion from actualizacion where version='" + _VERSION_NUEVA + "')";

                    Cmd = new MySqlCommand(Sql, Cnn);
                    Dr = Cmd.ExecuteReader();


                    while (Dr.Read())
                    {
                        Files.Add(new FilesDowload() { url = Convert.ToString(Dr["url"]) });
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    if (Cnn.State == ConnectionState.Open)
                        Cnn.Close();
                }
            }

            return Files;
        }

        public string ConnectString()
        {

            string str1 = "www.io-server.com";
            string str2 = "rabgxsdc_tumomento";
            string str3 = "rabgxsdc_usrtumomento";
            string str4 = "Fernando2023!";
            return "Database=" + str2 + "; Data Source=" + str1 + "; User Id= " + str3 + "; Password=" + str4 + ";Port=3306;";

        }
    }
}