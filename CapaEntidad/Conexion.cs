using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

using System.Windows.Forms;

namespace SISTEMA_DE_CITAS_MEDICAS
{
    class Conexion
    {
        SqlConnection cn;
        SqlDataReader dr;
        SqlCommand cmd;
        public Conexion()
        {

            try
            {
                cn = new SqlConnection("Data Source=DESKTOP-KFDKCFE\\SQLEXPRESS;Initial Catalog=ExamenFinal;Integrated Security=True");
                cn.Open();
                MessageBox.Show("Conectado");


            }
            catch (Exception ex)
            {

                MessageBox.Show("No Conectado" + ex.ToString());
            }
        }
            public string Guardar(string nombre, int id, int telefono, String email)
        {
            string cerrar = "Se guardo";
            try
            {

                cn = new SqlConnection("Data Source=DESKTOP-KFDKCFE\\SQLEXPRESS;Initial Catalog=ProyectoParcial;Integrated Security=True");
                cn.Open();
                cmd = new SqlCommand($"Insert into Contacto(nombre,id,telefono,email) values('{nombre}',{id },{telefono},'{email}'", cn);
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cerrar = "No se conecto" + ex.ToString();
            }

            return cerrar;

        }
    
        
        public int personaRegistrada(int id)
        {
            int contador = 0;
           
            try
            {

                SqlCommand cmd = new SqlCommand("select * from Contacto where id=" + id + "", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;

                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo "+ex.ToString());
            }

            return contador;
        }
       
    }
}