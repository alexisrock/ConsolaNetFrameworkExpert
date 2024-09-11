using DataAccess.Conexion;
using Dominio.DataAccess;
using Dominio.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core
{
    public static class Core
    {






        public static void AddInsertarUsuario(UsuarioIn usuarioIn)
        {
            try
            {
                var usuario = MapperUuserioDB(usuarioIn);
                Conexion.InsertUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        private static Usuario MapperUuserioDB(UsuarioIn usuarioIn)
        {
            return new Usuario()
            {
                Nombre = usuarioIn.Nombre,
                Apellido = usuarioIn.Apellido,
                Correo = usuarioIn.Correo,
                Edad = usuarioIn.Edad,
                Hobbies = usuarioIn.Hobbies
            };

        }


        public static List<UsuarioDBIn> GetUsuarioCreados()
        {
            var listUsuarioIn = new List<UsuarioDBIn>();
            ;
            try
            {

                var lista =  Conexion.GetUsuariosCreados();
                lista.ForEach(x =>
                {
                    var usuarioDBIn = MapperUsuarioDBIn(x);
                    listUsuarioIn.Add(usuarioDBIn);

                });


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listUsuarioIn;
        }

        private static UsuarioDBIn MapperUsuarioDBIn(UsuarioDB usuarioDB)
        {
            return new UsuarioDBIn()
            {
                id = usuarioDB.id,
                Nombre = usuarioDB.Nombre,
                Apellido = usuarioDB.Apellido,
                Edad = usuarioDB.Edad,
                Correo = usuarioDB.Correo,
                Hobbies = usuarioDB.Hobbies,
                Activo = usuarioDB.Activo,
                FechaInsercion = usuarioDB.FechaInsercion,
                FechaActualizacion = usuarioDB.FechaActualizacion,


            };
        }


        public static List<UsuarioDBIn> GetUsuarioPorEdad(int edad)
        {
            var listUsuarioIn = new List<UsuarioDBIn>();
            try
            {
                var lista = Conexion.GetUsuariosPorEdad(edad);

                lista.ForEach(x =>
                {
                    var usuarioDBIn = MapperUsuarioDBIn(x);
                    listUsuarioIn.Add(usuarioDBIn);

                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listUsuarioIn;
        }
    }
}
