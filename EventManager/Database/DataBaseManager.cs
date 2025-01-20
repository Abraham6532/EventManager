using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using EventManager.Models;
using MySql.Data.MySqlClient;

namespace EventManager.Database
{
    public class DataBaseManager
    {
        //USUARIO
        //GET
        public List<Usuario> QueryGetUsuarios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            Dictionary<int, Usuario> usuarios = new Dictionary<int, Usuario>();
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();

                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = "SELECT * FROM Usuarios";

                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Usuario usuario = new Usuario(myReader.GetInt32("idUsuario"), myReader.GetString("nombre"), myReader.GetString("correo"), myReader.GetInt32("idRol"));
                            usuarios.Add(usuario.IdUsuario, usuario);
                        }
                        return new List<Usuario>(usuarios.Values);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return null;
            }
        }
        // POST
        public bool QueryPostUsuario(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();
                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = @"INSERT INTO Usuarios (nombre,correo,idRol) VALUES (@nombre, @correo, @idRol)";
                    myCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    myCommand.Parameters.AddWithValue("@correo", usuario.Correo);
                    myCommand.Parameters.AddWithValue("@idRol", usuario.IdRol);
                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return false;
            }
        }


        //ROLES
        //GET
        public List<Rol> QueryGetRoles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            Dictionary<int, Rol> roles = new Dictionary<int, Rol>();
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();

                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = "SELECT * FROM Roles";

                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Rol rol = new Rol(myReader.GetInt32("idRol"), myReader.GetString("nombre"));
                            roles.Add(rol.IdRol, rol);
                        }
                        return new List<Rol>(roles.Values);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return null;
            }
        }

        //EVENTOS
        //GET
        public List<Evento> QueryGetEventos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            Dictionary<int, Evento> eventos = new Dictionary<int, Evento>();
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();

                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = "SELECT * FROM Eventos";

                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Evento evento = new Evento(myReader.GetInt32("idEvento"), myReader.GetString("titulo"), myReader.GetString("descripcion"), myReader.GetString("lugar"), myReader.GetDateTime("fecha"), myReader.GetInt32("UsuarioId"));
                            eventos.Add(evento.IdEvento, evento);
                        }
                        return new List<Evento>(eventos.Values);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return null;
            }
        }

        // POST
        public bool QueryPostEvento(Evento evento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();
                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = @"INSERT INTO Eventos (titulo, descripcion, lugar, fecha, UsuarioId) VALUES (@titulo, @descripcion, @lugar,@fecha, @UsuarioId)";
                    myCommand.Parameters.AddWithValue("@titulo", evento.Titulo);
                    myCommand.Parameters.AddWithValue("@descripcion", evento.Descripcion);
                    myCommand.Parameters.AddWithValue("@lugar", evento.Lugar);
                    myCommand.Parameters.AddWithValue("@fecha", evento.Fecha);
                    myCommand.Parameters.AddWithValue("@UsuarioId", evento.UsuarioId);
                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return false;
            }
        }

        // UPDATE
        public bool QueryUpdateEvento(Evento evento, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();
                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = @"UPDATE Eventos SET titulo = @titulo, descripcion = @descripcion, lugar = @lugar, fecha=@fecha, UsuarioId = @UsuarioId WHERE idEvento = @id";
                    myCommand.Parameters.AddWithValue("@titulo", evento.Titulo);
                    myCommand.Parameters.AddWithValue("@descripcion", evento.Descripcion);
                    myCommand.Parameters.AddWithValue("@lugar", evento.Lugar);
                    myCommand.Parameters.AddWithValue("@fecha", evento.Fecha);
                    myCommand.Parameters.AddWithValue("@UsuarioId", evento.UsuarioId);
                    myCommand.Parameters.AddWithValue("@id", id);
                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return false;
            }
        }

        // DELETE
        public bool QueryDeleteEvento(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection myConnection = new MySqlConnection(connectionString))
                {
                    // Abre la conexión
                    myConnection.Open();
                    // Crear un comando SQL con parámetros
                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = @"DELETE FROM Eventos WHERE idEvento = @id";
                    myCommand.Parameters.AddWithValue("@id", id);
                    // Ejecutar el comando y leer los resultados
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return false;
            }
        }


    }
}