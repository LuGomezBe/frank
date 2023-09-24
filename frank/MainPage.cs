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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool nombreAVacio = string.IsNullOrEmpty(txtNombreA.Text);
            bool nombreSVacio = string.IsNullOrEmpty(txtNombreS.Text);

            if (nombreAVacio && nombreSVacio)
            {
                MessageBox.Show("Ambos campos de nombre están vacíos. Ingrese datos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nombreAVacio)
            {
                Clases.Estudiante objetoEstudiante = new Clases.Estudiante();
                objetoEstudiante.guardarE(txtNombreS, txtApellidosS, txtTelefonoS, txtDomicilioS,cmbGrado, cmbSeccionS, txtDniS);
                
                MessageBox.Show("Se guardó correctamente el apoderado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nombreSVacio)
            {
                Clases.Apoderado objetoApoderado = new Clases.Apoderado();
                objetoApoderado.guardarApoderado(txtNombreA, txtApellidosA, txtTelefonoA, txtDomicilioA, txtDniA);
                MessageBox.Show("Se guardó correctamente el estudiante.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Clases.Apoderado objetoApoderado = new Clases.Apoderado();
                objetoApoderado.guardarApoderado(txtNombreA, txtApellidosA, txtTelefonoA, txtDomicilioA, txtDniA);
                Clases.Estudiante objetoEstudiante = new Clases.Estudiante();
                objetoEstudiante.guardarE(txtNombreS, txtApellidosS, txtTelefonoS, txtDomicilioS, cmbGrado, cmbSeccionS, txtDniS);

                MessageBox.Show("Se guardó correctamente ambos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Vista Mpage = new Vista();
            Mpage.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login Mpage = new Login();
            Mpage.ShowDialog();
        }
    }
}
