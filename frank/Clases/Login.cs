﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frank.Clases
{
    internal class Login
    {
        public void MostrarDatoEnLabel(Label label)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                // Establecer la conexión con la base de datos
                MySqlConnection conexion = objetoConexion.establecerConexion();

                // Crear un comando SQL para obtener el dato deseado
                string consulta = "SELECT Nombre FROM login WHERE ID = 1";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                // Ejecutar el comando y obtener el resultado
                object resultado = comando.ExecuteScalar();

                // Verificar si el resultado no es nulo
                if (resultado != null)
                {
                    // Asignar el resultado al texto del Label
                    label.Text = resultado.ToString();
                }

                // Cerrar la conexión
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el dato: " + ex.ToString());
            }
        }
        public void guardarCuenta(TextBox usuario, TextBox contraseña)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into Login (Usuario,Contraseña)" + "values ('" + usuario.Text + "','" + contraseña.Text + "');";
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
