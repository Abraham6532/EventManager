using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.Models
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public Rol(int idRol, string nombre)
        {
            IdRol = idRol;
            Nombre = nombre;
        }
        public Rol() { }
    }
}