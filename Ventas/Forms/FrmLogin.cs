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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SetColorTheme();
        }

        private void SetColorTheme()
        {

            btnAceptar.BackColor = ThemeColor.PrimaryColor;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnAceptar.FlatStyle = FlatStyle.Flat;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un usuario", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return;
            }


            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un usuario", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
                return;
            }


            if (Server.VerificaLogin(txtUsuario.Text.Trim(), txtPassword.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña invalidos", "App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
