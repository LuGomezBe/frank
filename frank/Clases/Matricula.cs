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
    internal class Matricula
    {
        public void mostrarDatos(DataGridView tablaDatos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "Select * from ";
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
        public void guardarDatos(TextBox nombres, TextBox apellidos, TextBox Dni, TextBox telefono, TextBox cargo)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into Tecnico (Nombre_Tecnico,Apellido_Tecnico,Dni_Tecnico,Telefono_Tecnico,Cargo)" + "values ('" + nombres.Text + "','" + apellidos.Text + "','" + Dni.Text + "','" + telefono.Text + "','" + cargo.Text + "');";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se guardo los datos de la base de datos, error " + ex.ToString());
            }
        }
    }
}
