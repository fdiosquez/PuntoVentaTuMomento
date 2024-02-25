using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Forms
{
    public partial class FrmFechaDesdeHasta : Form
    {

        DateTime m_fechaDesde;
        DateTime m_fechaHasta;
        string m_fechaTexto;

        public DateTime _fechaDesde
        {
            get { return m_fechaDesde; }
            set { m_fechaDesde = value; }
        }

        public DateTime _fechaHasta
        {
            get { return m_fechaHasta; }
            set { m_fechaHasta = value; }
        }

        public string _fechaTexto
        {
            get { return m_fechaTexto; }
            set { m_fechaTexto = value; }
        }

        public FrmFechaDesdeHasta()
        {
            InitializeComponent();
        }

        private void FrmFechaDesdeHasta_Load(object sender, EventArgs e)
        {
            SetColorTheme();
        }

        private void SetColorTheme()
        {
            btnAceptar.BackColor = ThemeColor.PrimaryColor;
            btnAceptar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ForeColor = Color.White;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var dt1 = dateTimePickerFD.Value.Date;
            var dt2 = dateTimePickerFH.Value.Date;

            int result = DateTime.Compare(dt1, dt2);
           
            if (result > 0)
            {
                MessageBox.Show("La fecha Desde no puede ser mayor a la fecha Hasta", "App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerFD.Focus();
                return;
            }

            this._fechaDesde = dt1;
            this._fechaHasta = dt2;
            this._fechaTexto = "Fecha Desde " + dt1.ToString("dd/MM/yyyy") + " hasta " + dt2.ToString("dd/MM/yyyy");
            this.DialogResult = DialogResult.OK;
        }
    }
}
