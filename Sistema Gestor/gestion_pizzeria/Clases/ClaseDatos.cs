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
    class ClaseDatos
    {
        private string _responseString;
        private string _UserMACAdress;
        private string _usuario;
        private string _fecha;
        private string _hora;
        private string _correo;
        public string responseString
        {
            get
            {
                return _responseString;
            } set
            {
                _responseString = value;
            }
        }
        public string UserMACAdress
        {
            get
            {
                return _UserMACAdress;
            }
            set
            {
                _UserMACAdress = value;
            }
        }
        public string usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }
        public string fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }
        public string hora
        {
            get
            {
                return _hora;
            }
            set
            {
                _hora = value;
            }
        }
        public string correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;
            }
        }
    }
    
}
