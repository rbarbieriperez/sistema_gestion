using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using MySqlX.XDevAPI;
using System.Web;

namespace gestion_pizzeria.Clases
{
    class consultas
    {
        private Boolean estado = false;
        private string url = "http://localhost/gestor/";
        public string usuario, password,value,option,correo;
        public functions funciones = new functions();
        private ClaseDatos datos = new ClaseDatos();
        //  private Byte[] buffer = new byte[16 * 1024];
        public Boolean getUser()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "consulta_usuario.php?usuario=" + usuario + "&password=" + password + "");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resultado = response.GetResponseStream();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0)
                {
                    using (resultado)
                    {
                        StreamReader reader = new StreamReader(resultado, Encoding.UTF8);
                        string responseString = reader.ReadToEnd();
                        datos.responseString = responseString;
                        funciones.SaveUserData(datos);
                    }

                    estado = true;

                }
                else
                {
                    estado = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return estado;

        }
        public Boolean GetFirstAcces()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "consulta_usuario.php?usuario=" + usuario + "");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resultado = response.GetResponseStream();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0)
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return estado;
        }

        public Boolean GetUserCode()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "consulta_usuario.php?option=" + option + "&value="+ value +"");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resultado = response.GetResponseStream();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0)
                {
                    using (resultado)
                    {
                        StreamReader reader = new StreamReader(resultado, Encoding.UTF8);
                        string responseString = reader.ReadToEnd();
                        datos.responseString = responseString;
                        funciones.SaveUserCode(datos);
                    }
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return estado;
        }

    }
}
