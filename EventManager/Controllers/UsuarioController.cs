using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EventManager.Database;
using EventManager.Models;

namespace EventManager.Controllers
{
    public class UsuarioController : ApiController
    {
        DataBaseManager db = new DataBaseManager();

        // GET: api/Usuario
        public IEnumerable<Usuario> GetUsuarios()
        {
            return db.QueryGetUsuarios();
        }

        // GET: api/Usuario/1
        public Usuario GetUsuario(int id)
        {
            try
            {
                var myList = db.QueryGetUsuarios();
                // Verificar que la lista no sea nula ni esté vacía
                if (myList == null || myList.Count == 0)
                {
                    Console.WriteLine("La lista de usuarios está vacía o no se pudo obtener.");
                    return null;
                }
                foreach (var item in myList)
                {
                    if (item.IdUsuario.Equals(id))
                    {

                        return item;
                    }
                }
                // Devolver el usuario correspondiente
                return null;
            }
            catch (Exception ex)
            {
                // Manejar excepciones inesperadas
                Console.WriteLine($"Ocurrió un error al buscar el usuario: {ex.Message}");
                return null;
            }
        }

        //POST: api/Usuario
        public bool PostUsuario([FromBody] Usuario usuario)
        {
            return db.QueryPostUsuario(usuario);
        }

        public bool DeleteUsuario(int id)
        {
            return db.QueryDeleteEvento(id);
        }
    }
}
