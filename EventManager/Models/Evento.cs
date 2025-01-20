using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Evento(int idEvento, string titulo, string descripcion, string lugar, DateTime fecha, int usuarioId)
        {
            IdEvento = idEvento;
            Titulo = titulo;
            Descripcion = descripcion;
            Lugar = lugar;
            Fecha = fecha;
            UsuarioId = usuarioId;
        }
        public Evento()
        {
        }
    }
}