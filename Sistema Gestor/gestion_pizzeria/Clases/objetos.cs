using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;

namespace gestion_pizzeria.Clases
{
 
    public  class Usuario
    {
        public  string usuario { get; set; }
        public string password { get; set; }
        public string MAC { get; set; }
        public string cod_recuperacion { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string local { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string cuota_establecida { get; set; }
        public string estado { get; set; }
    }

    public class UserAcces
    {
        public string fecha { get; set; }
        public string hora { get; set; }
    }

    public class CodeUser
    {
        public string code { get; set; }
    }
}
