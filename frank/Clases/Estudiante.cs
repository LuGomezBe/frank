using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frank.Clases
{
    internal class Estudiante
    {
        public void mostrarEstudiante(DataGridView tablaDatos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "Select * from estudiante";
                tablaDatos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaDatos.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error " + ex.ToString());
            }
        }


        public void guardarE(TextBox nombres, TextBox apellidos, TextBox telefono, TextBox domicilio,ComboBox grado, ComboBox seccion, TextBox Dni)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into estudiante (Nombre,Apellidos,Telefono,domicilio,grado,seccion,dni)" + "values ('" + nombres.Text + "','" + apellidos.Text + "','" + telefono.Text + "','" + domicilio.Text + "','" + grado.Text + "','" + seccion.Text + "','" + Dni.Text + "');";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardo los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void SelecionE(DataGridView tablaTecnico, TextBox id, TextBox nombres, TextBox apellidos, TextBox telefono,TextBox domicilio,TextBox grado, TextBox seccion, TextBox Dni)
        {
            try
            {
                id.Text = tablaTecnico.CurrentRow.Cells[0].Value.ToString();
                nombres.Text = tablaTecnico.CurrentRow.Cells[1].Value.ToString();
                apellidos.Text = tablaTecnico.CurrentRow.Cells[2].Value.ToString();
                telefono.Text = tablaTecnico.CurrentRow.Cells[3].Value.ToString();
                domicilio.Text = tablaTecnico.CurrentRow.Cells[4].Value.ToString();
                grado.Text = tablaTecnico.CurrentRow.Cells[5].Value.ToString();
                seccion.Text = tablaTecnico.CurrentRow.Cells[6].Value.ToString();
                Dni.Text = tablaTecnico.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se seleciona los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void modificarE(TextBox Id, TextBox nombres, TextBox apellidos, TextBox telefono, TextBox domicilio, TextBox grado, TextBox seccion, TextBox Dni)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "update estudiante set Nombre='" + nombres.Text + "', Apellidos ='" + apellidos.Text + "', Telefono ='" + telefono.Text + "', domicilio ='" + domicilio.Text + "', grado='" + grado.Text + "', seccion='" + seccion.Text + "', dni ='" + Dni.Text + "' where Id_estudiante = '" + Id.Text + "';";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se modifico los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void DeleteE(TextBox Id)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "delete from estudiante where id_estudiante= '" + Id.Text + "';";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se elimino los datos de la base de datos, error " + ex.ToString());
            }
        }
    }
}
