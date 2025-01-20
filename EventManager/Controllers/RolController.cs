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
    public class RolController : ApiController
    {
        DataBaseManager db = new DataBaseManager();

        // GET: api/Rol
        public IEnumerable<Rol> GetRoles()
        {
            return db.QueryGetRoles();
        }

        // GET: api/Rol/1
        public Rol GetRol(int id)
        {
            try
            {
                var myList = db.QueryGetRoles();
                // Verificar que la lista no sea nula ni esté vacía
                if (myList == null || myList.Count == 0)
                {
                    Console.WriteLine("La lista de roles está vacía o no se pudo obtener.");
                    return null;
                }
                foreach (var item in myList)
                {
                    if (item.IdRol.Equals(id))
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
                Console.WriteLine($"Ocurrió un error al buscar el dato: {ex.Message}");
                return null;
            }
        }
    }
}
