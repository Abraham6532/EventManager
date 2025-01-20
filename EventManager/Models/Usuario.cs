using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int IdRol { get; set; }
        public Usuario(int idUsuario, string nombre, string correo, int idRol)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Correo = correo;
            IdRol = idRol;
        }
        public Usuario()
        {
        }
    }
}