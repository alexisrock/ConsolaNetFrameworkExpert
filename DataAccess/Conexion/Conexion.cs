using System;
using System.Data.SqlClient;
using System.Data;
using Dominio.DataAccess;
using System.Windows.Input;
using Dominio.Service;
using System.Collections.Generic;

namespace DataAccess.Conexion
{
    public static class Conexion
    {

        private static string connectionString = "Data Source=DESKTOP-58J73J1\\SQLEXPRESS;Initial Catalog=ExpertPruebaDB; User Id=usrManejorh; Password=usrManejorh; TrustServerCertificate=True";


        public static SqlConnection Conectar()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;

        }



        public static void InsertUsuario(Usuario usuario)
        {
            string storedProcedureName = "dbo.Sp_InsertarUsuario";
            var conexion = Conectar();
            using (conexion)
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@Edad", usuario.Edad);
                        command.Parameters.AddWithValue("@Correo", usuario.Correo);
                        command.Parameters.AddWithValue("@Hobbies", usuario.Hobbies);
                        conexion.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }


        public static List<UsuarioDB> GetUsuariosPorEdad(int edad)
        {
            string storedProcedureName = "dbo.Sp_ListadoEdadUsuario";
            List<UsuarioDB> list = new List<UsuarioDB>();
            var conexion = Conectar();
            using (conexion)
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conexion.Open();
                        command.Parameters.AddWithValue("@Edad", edad);

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {

                            while (dataReader.Read())
                            {
                                UsuarioDB usuarioDBIn = new UsuarioDB()
                                {
                                    id = dataReader.GetInt32(0),
                                    Nombre = dataReader.GetString(1),
                                    Apellido = dataReader.GetString(2),
                                    Edad = dataReader.GetInt32(3),
                                    Correo = dataReader.GetString(4),
                                    Hobbies = dataReader.GetString(5),
                                    Activo = dataReader.GetBoolean(6),
                                    FechaInsercion = dataReader.GetDateTime(7),
                                
                                };

                                list.Add(usuarioDBIn);

                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }

                    return list;
                }

            }
        }





        public static List<UsuarioDB> GetUsuariosCreados()
        {
            string storedProcedureName = "dbo.Sp_ListarUsuariosCreados";
            List<UsuarioDB> list = new List<UsuarioDB>();
            var conexion = Conectar();

            using (conexion)
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {

                            while (dataReader.Read())
                            {
                                UsuarioDB usuarioDBIn = new UsuarioDB()
                                {
                                    id = dataReader.GetInt32(0),
                                    Nombre = dataReader.GetString(1),
                                    Apellido = dataReader.GetString(2),
                                    Edad = dataReader.GetInt32(3),
                                    Correo = dataReader.GetString(4),
                                    Hobbies = dataReader.GetString(5),
                                    Activo = dataReader.GetBoolean(6),
                                    FechaInsercion = dataReader.GetDateTime(7),
                                   
                                };

                                list.Add(usuarioDBIn);

                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }

                    return list;
                }

            }

        }
    }


}


