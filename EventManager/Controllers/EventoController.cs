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
    public class EventoController : ApiController
    {
        DataBaseManager db = new DataBaseManager();
        Dictionary<int, Evento> eventos = new Dictionary<int, Evento>();

        // GET: api/Evento
        public IEnumerable<Evento> GetEventos()
        {
            return db.QueryGetEventos();
        }

        // GET: api/Evento/{id}
        public Evento GetEvento(int id)
        {
            try
            {
                var myList = db.QueryGetEventos();
                // Verificar que la lista no sea nula ni esté vacía
                if (myList == null || myList.Count == 0)
                {
                    Console.WriteLine("La lista de Eventos está vacía o no se pudo obtener.");
                    return null;
                }
                foreach (var item in myList)
                {
                    if (item.IdEvento.Equals(id))
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
        //POST: api/Evento
        public bool PostEvento([FromBody] Evento evento)
        {
            return db.QueryPostEvento(evento);
        }

        //UPDATE: api/Evento/{id}
        public bool PutEvento(int id, [FromBody] Evento evento)
        {
            return db.QueryUpdateEvento(evento, id);
        }

        //DELETE: api/Evento
        public bool DeleteEvento(int id)
        {
            return db.QueryDeleteEvento(id);
        }
    }
}
