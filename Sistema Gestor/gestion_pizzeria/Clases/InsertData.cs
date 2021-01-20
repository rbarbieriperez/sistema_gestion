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
using MySql.Data.MySqlClient.Memcached;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace gestion_pizzeria.Clases
{
    class InsertData
    {

        private Boolean estado = false;
        private string url = "http://localhost/gestor/";
        public Boolean UpdateMACUser(ClaseDatos datos)
        {
            try
            {
                
                var client = new WebClient();
                var method = "POST"; // If your endpoint expects a GET then do it.
                var parameters = new NameValueCollection();

                parameters.Add("MAC", datos.UserMACAdress);
                parameters.Add("usuario", datos.usuario);
                /* Always returns a byte[] array data as a response. */
                var response_data = client.UploadValues(url + "consulta_usuario.php", method, parameters);
                // Parse the returned data (if any) if needed.
                string responseString = UnicodeEncoding.UTF8.GetString(response_data);
                if (responseString == "1")
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return estado;
        }
        public Boolean InsertUserAcces(ClaseDatos datos)
        {
            try
            {
                var client = new WebClient();
                var method = "POST"; // If your endpoint expects a GET then do it.
                var parameters = new NameValueCollection();

                parameters.Add("usuario", datos.usuario);
                parameters.Add("fecha", datos.fecha);
                parameters.Add("hora", datos.hora);
                /* Always returns a byte[] array data as a response. */
                var response_data = client.UploadValues(url + "consulta_usuario.php", method, parameters);
                // Parse the returned data (if any) if needed.
                string responseString = UnicodeEncoding.UTF8.GetString(response_data);
                if (responseString == "1")
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return estado;
        }

        public Boolean SendCode(ClaseDatos datos)
        {
            try
            {
                var client = new WebClient();
                var method = "POST"; // If your endpoint expects a GET then do it.
                var parameters = new NameValueCollection();

                parameters.Add("usuario", datos.usuario);
                parameters.Add("correo", datos.correo);
                /* Always returns a byte[] array data as a response. */
                var response_data = client.UploadValues(url + "consulta_usuario.php", method, parameters);
                // Parse the returned data (if any) if needed.
                string responseString = UnicodeEncoding.UTF8.GetString(response_data);
                if (responseString == "1")
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return estado;
        }
    }
}
