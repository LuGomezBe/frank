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
    internal class Apoderado
    {
        public void mostrarApoderado(DataGridView tablaDatos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "Select * from apoderado";
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


        public void guardarApoderado(TextBox nombres, TextBox apellidos, TextBox telefono, TextBox domicilio,  TextBox Dni)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into apoderado (Nombre,Apellidos,Telefono,domicilio,dni)" + "values ('" + nombres.Text + "','" + apellidos.Text + "','" + telefono.Text + "','" + domicilio.Text + "','" + Dni.Text + "');";
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
    }
}
