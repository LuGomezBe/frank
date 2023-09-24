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
    public partial class Vista : Form
    {
        public Vista()
        {
            InitializeComponent();
            Clases.Estudiante objetoReporte = new Clases.Estudiante();
            objetoReporte.mostrarEstudiante(dgvPrincipal);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Estudiante objetoCliente = new Clases.Estudiante();
            objetoCliente.DeleteE(txtId);
            objetoCliente.mostrarEstudiante(dgvPrincipal);
            MessageBox.Show("Se elimino correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtId.Text = string.Empty;
            txtNombreS.Text = string.Empty;
            txtApellidosS.Text = string.Empty;
            txtTelefonoS.Text = string.Empty;
            txtDomicilioS.Text = string.Empty;
            txtGrado.Text = string.Empty;
            txtSeccion.Text = string.Empty;
            txtDniS.Text = string.Empty;
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            dgvPrincipal.ScrollBars = ScrollBars.Both;
        }

        private void dgvPrincipal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clases.Estudiante objetoReporte = new Clases.Estudiante();
            objetoReporte.SelecionE(dgvPrincipal,txtId,txtNombreS,txtApellidosS,txtTelefonoS,txtDomicilioS,txtGrado,txtSeccion,txtDniS);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Clases.Estudiante objetoCliente= new Clases.Estudiante();
            objetoCliente.modificarE(txtId,txtNombreS,txtApellidosS,txtTelefonoS,txtDomicilioS,txtGrado,txtSeccion,txtDniS);
            objetoCliente.mostrarEstudiante(dgvPrincipal);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainPage Mpage = new MainPage();
            Mpage.ShowDialog();
        }
    }
}
