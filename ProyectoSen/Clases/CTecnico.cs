using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSen.Clases
{
    internal class CTecnico
    {
        public void mostrarTecnico(DataGridView tablaTecnico)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "Select * from Tecnico";
                tablaTecnico.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaTecnico.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void guardarTecnico(TextBox nombres ,TextBox apellidos,TextBox Dni)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into Tecnico (Nombre,Apellido,Dni)"+"values ('"+ nombres.Text+ "','"+apellidos.Text+ "','" + Dni.Text + "');";
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
        public void SelecionTecnico(DataGridView tablaTecnico,TextBox id,TextBox nombres, TextBox apellidos, TextBox Dni)
        {
            try
            {
                id.Text = tablaTecnico.CurrentRow.Cells[0].Value.ToString();
                nombres.Text = tablaTecnico.CurrentRow.Cells[1].Value.ToString();
                apellidos.Text = tablaTecnico.CurrentRow.Cells[2].Value.ToString();
                Dni.Text = tablaTecnico.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se seleciona los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void modificarTecnico(TextBox Id,TextBox nombres, TextBox apellidos, TextBox Dni)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "update Tecnico set nombre='" + nombres.Text + "', apellido='" + apellidos.Text + "', Dni ='" + Dni.Text + "' where id = '" + Id.Text+"';";
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
        public void DeleteTecnico(TextBox Id)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "delete from Tecnico where id = '" + Id.Text + "';";
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
