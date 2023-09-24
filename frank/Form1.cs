using frank.Clases;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frank
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Ingrese su usuario";
                txtUsuario.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese su usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "Ingrese su contraseña";
                txtContra.ForeColor = Color.LightSteelBlue;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "Ingrese su contraseña")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void ckbMuestra_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMuestra.Checked == true)
            {
                txtContra.UseSystemPasswordChar = false;
            }
            else
            {
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario, contraseña;
            usuario = txtUsuario.Text;
            contraseña = txtContra.Text;
            CConexion objetoConexion = new CConexion();

            string query = "SELECT Usuario, Contraseña FROM login WHERE Usuario = @usuario AND Contraseña = @contraseña";
            MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
            mySqlCommand.Parameters.AddWithValue("@usuario", usuario);
            mySqlCommand.Parameters.AddWithValue("@contraseña", contraseña);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                
                    this.Hide();
                    MessageBox.Show("Bienvenido " + usuario, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainPage Mpage = new MainPage();
                    Mpage.ShowDialog();


            }
            else
            {
                MessageBox.Show("No existe ese usuario " + usuario);
            }
            objetoConexion.cerrarConexion();
        }

        private void lblReg_Click(object sender, EventArgs e)
        {
            
        }
    }
}
