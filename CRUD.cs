using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    //CRUD son 4 palabras en ingles create, consultar, update  y delete
    class CRUD
    {
        public void insertar() {
            //LAB2\SQLEXPRESS
            try
            {

                string conexion = @"data source = DESKTOP-BPIPVCL; initial catalog = curso_adonet;
                           persist security info = true; Integrated Security = SSPI;";

                string query = "insert into productos values(1,'sd',2,12)";

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                SqlCommand cm = new SqlCommand(query, con);
                cm.CommandText = query;

                SqlDataReader dr = cm.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                dr.Close();

                Console.WriteLine("Registro insertado");

                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Insertar: " + ex.Message);
            }
            }

        public void consultar()
        {
            try
            {

                string conexion = @"data source = DESKTOP-BPIPVCL; initial catalog = curso_adonet;
                           persist security info = true; Integrated Security = SSPI;";

                string query = "select * from productos";

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                SqlCommand cm = new SqlCommand(query, con);
                //ejecuta el comando text almacenado
                cm.CommandText = query;

                
                SqlDataReader dr = cm.ExecuteReader();

                //cargar la informacion del dr
                DataTable dt = new DataTable();
                dt.Load(dr);

                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Console.WriteLine("Matricula: " + dt.Rows[i]["folio"]);
                        Console.WriteLine("Nomre: " + dt.Rows[i]["producto"]);
                        Console.WriteLine("APP: " + dt.Rows[i]["cantidad"]);
                        Console.WriteLine("APM: " + dt.Rows[i]["precio"]);
                        //Console.WriteLine("EDAD: " + dt.Rows[i]["EDAD"]);
                        Console.WriteLine("-------------");
                    }
                }
                else {
                    Console.WriteLine("No existe registros");
                }

                
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Actualizar: " + ex.Message);
            }
        }

        public void actualizar()
        {
            //LAB2\SQLEXPRESS
            try
            {

                string conexion = @"data source = DESKTOP-BPIPVCL; initial catalog = curso_adonet;
                           persist security info = true; Integrated Security = SSPI;";

                string query = "update productos set producto = 'Prueba' where folio = 5";

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                SqlCommand cm = new SqlCommand(query, con);
                //ejecuta el comando text almacenado
                cm.CommandText = query;


                SqlDataReader dr = cm.ExecuteReader();

                //cargar la informacion del dr
                DataTable dt = new DataTable();
                dt.Load(dr);

                dr.Close();


                Console.WriteLine("Registro actualizado");

                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Actualizar: " + ex.Message);
            }
        }

        public void Eliminar()
        {
            //LAB2\SQLEXPRESS
            try
            {

                string conexion = @"data source = DESKTOP-BPIPVCL; initial catalog = curso_adonet;
                           persist security info = true; Integrated Security = SSPI;";

                string query = "delete from productos where folio = 1";

                SqlConnection con = new SqlConnection(conexion);
                con.Open();

                SqlCommand cm = new SqlCommand(query, con);
                //ejecuta el comando text almacenado
                cm.CommandText = query;


                SqlDataReader dr = cm.ExecuteReader();

                //cargar la informacion del dr
                DataTable dt = new DataTable();
                dt.Load(dr);

                dr.Close();


                Console.WriteLine("Registro eliminado");

                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de Eliminar: " + ex.Message);
            }
        }
    }
}
