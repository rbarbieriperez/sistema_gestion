using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace gestion_pizzeria.Clases
{
    class functions
    {
        //private ClaseDatos datos = new ClaseDatos();
        //ClaseDatos datos = new ClaseDatos();
        public Usuario usuario = new Usuario();
        public UserAcces accesos = new UserAcces();
        public void SaveUserData(ClaseDatos datos )
        {
            
            JArray jsonArray = JArray.Parse(datos.responseString);
            dynamic usuarioIntermedioObject = JObject.Parse(jsonArray[0].ToString());

            /* Usuario usuario = new Usuario();
              {
                  usuario = usuarioIntermedioObject["usuario"].ToString(),
                  password = usuarioIntermedioObject["password"].ToString(),
                  MAC = usuarioIntermedioObject["MAC"].ToString(),
                  cod_recuperacion = usuarioIntermedioObject["cod_recuperacion"].ToString(),
                  nombre = usuarioIntermedioObject["nombre"].ToString(),
                  apellidos = usuarioIntermedioObject["apellidos"].ToString(),
                  local = usuarioIntermedioObject["local"].ToString(),
                  correo = usuarioIntermedioObject["correo"].ToString(),
                  direccion = usuarioIntermedioObject["direccion"].ToString(),
                  pais = usuarioIntermedioObject["pais"].ToString(),
                  telefono = usuarioIntermedioObject["telefono"].ToString(),
                  celular = usuarioIntermedioObject["celular"].ToString(),
                  cuota_establecida = usuarioIntermedioObject["cuota_establecida"].ToString(),
                  estado = usuarioIntermedioObject["estado"].ToString()
              }; */
            usuario.usuario = usuarioIntermedioObject["usuario"].ToString();
            usuario.password = usuarioIntermedioObject["password"].ToString();
            usuario.MAC = usuarioIntermedioObject["MAC"].ToString();
            usuario.cod_recuperacion = usuarioIntermedioObject["cod_recuperacion"].ToString();
            usuario.nombre = usuarioIntermedioObject["nombre"].ToString();
            usuario.apellidos = usuarioIntermedioObject["apellidos"].ToString();
            usuario.local = usuarioIntermedioObject["local"].ToString();
            usuario.correo = usuarioIntermedioObject["correo"].ToString();
            usuario.direccion = usuarioIntermedioObject["direccion"].ToString();
            usuario.pais = usuarioIntermedioObject["pais"].ToString();
            usuario.telefono = usuarioIntermedioObject["telefono"].ToString();
            usuario.celular = usuarioIntermedioObject["celular"].ToString();
            usuario.cuota_establecida = usuarioIntermedioObject["cuota_establecida"].ToString();
            usuario.estado = usuarioIntermedioObject["estado"].ToString();



        } 
        public void SaveUserAccess(ClaseDatos datos)
        {
            JArray jsonArray = JArray.Parse(datos.responseString);
            dynamic AccessObject = JObject.Parse(jsonArray[0].ToString());
            accesos.fecha = AccessObject["fecha"].ToString();
            accesos.hora = AccessObject["hora"].ToString();

        }
        public void SaveUserCode(ClaseDatos datos)
        {
            JArray jsonArray = JArray.Parse(datos.responseString);
            dynamic CodeObject = JObject.Parse(jsonArray[0].ToString());
            usuario.usuario = CodeObject["usuario"].ToString();
            usuario.correo = CodeObject["correo"].ToString();

        }
    }
}
