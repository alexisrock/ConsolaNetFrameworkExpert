using Dominio.Service;
using NLog;
using NLog.Config;
using Servicio.Core;

namespace consolaFramework
{
    public class Program
    {
     
        private static Logger logger = LogManager.GetCurrentClassLogger();

       

        public static  void Main(string[] args)
        {

            string nlogConfigPath = @"C:\Users\Lenovo\source\repos\ConsolaFramework\consolaFramework\NLog.config";
            LogManager.Configuration = new XmlLoggingConfiguration(nlogConfigPath);

            var usuario = new UsuarioIn()
            {
                Nombre = "Clara ",
                Apellido = "Villalba",
                Edad = 359,
                Correo = "cvialllalba@gmmail.com",
                Hobbies = "Estudiar-HacerEjercicio-leer"
            };


            var usuarioDos = new UsuarioIn()
            {
                Nombre = "sergio andres ",
                Apellido = "ortiz",
                Edad = 23,
                Correo = "sortiz@gmmail.com",
                Hobbies = "Dormir-Bailar-cantar"
            };

            logger.Info("Usuario  " + usuario);
            logger.Info("Usuario  " + usuarioDos);
            //Core.AddInsertarUsuario(usuario);
            //Core.AddInsertarUsuario(usuarioDos);

            var list = Core.GetUsuarioCreados();
            list.ForEach(x =>
            {
                logger.Info("Usuario a Nombre" + x.Nombre);
                logger.Info("Usuario a Apellido" + x.Apellido);
                logger.Info("Usuario a Edad" + x.Edad);
                logger.Info("Usuario a Correo" + x.Correo);
                logger.Info("Usuario a Hobbies" + x.Hobbies);
                logger.Info("Usuario a Activo" + x.Activo);
                logger.Info("Usuario a FechaInsercion" + x.FechaInsercion);
                logger.Info("\n");



            });


            var listEdad = Core.GetUsuarioPorEdad(35);
            logger.Info("lista usuarios por edad");
            listEdad.ForEach(x =>
            {
                logger.Info("Usuario a Nombre" + x.Nombre);
                logger.Info("Usuario a Apellido" + x.Apellido);
                logger.Info("Usuario a Edad" + x.Edad);
                logger.Info("Usuario a Correo" + x.Correo);
                logger.Info("Usuario a Hobbies" + x.Hobbies);
                logger.Info("Usuario a Activo" + x.Activo);
                logger.Info("Usuario a FechaInsercion" + x.FechaInsercion);
                logger.Info("\n");
            });
        }
    }
}
