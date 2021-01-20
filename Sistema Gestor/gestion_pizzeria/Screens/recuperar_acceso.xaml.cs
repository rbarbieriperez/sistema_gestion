using gestion_pizzeria.Clases;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MailKit.Net;
using MailKit;
using MailKit.Search;
namespace gestion_pizzeria.Screens
{
    /// <summary>
    /// Lógica de interacción para recuperar_acceso.xaml
    /// </summary>
    public partial class recuperar_acceso : Window
    {
        public recuperar_acceso()
        {
            InitializeComponent();
        }
        consultas consulta = new consultas();
        InsertData insertar = new InsertData();
        ClaseDatos datos = new ClaseDatos();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cod_box.IsEnabled = false;
            validar_btn.IsEnabled = false;
        }

        private void enviar_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(dato_box.Text, "[0-9]{9}"))
            {
                consulta.option = "celular";
                consulta.value = dato_box.Text;
                //Trabajamos con celular.-
                if (consulta.GetUserCode())
                {

                    if (SendMail())
                    {
                        //Enviamos el correo con el usuario.-
                        MessageBox.Show("¡El código ha sido envíado correctamente!" + "\n" + "Por favor, verifique su casilla de correo.", "Correo envíado de forma exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        cod_box.IsEnabled = true;
                        enviar_btn.IsEnabled = true;

                    }

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado con el dato de búsqueda: celular", "Error al encontrar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else if (Regex.IsMatch(dato_box.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
            {
                consulta.option = "correo";
                consulta.value = dato_box.Text;
                //Trabajamos con correo electrónico.-
                if (consulta.GetUserCode())
                {
                    if (SendMail())
                    {
                        MessageBox.Show("¡El código ha sido envíado correctamente!" + "\n" + "Por favor, verifique su casilla de correo.", "Correo envíado de forma exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        cod_box.IsEnabled = true;
                        enviar_btn.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado con el dato de búsqueda: correo electrónico", "Error al encontrar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (Regex.IsMatch(dato_box.Text, "[0-9]{8}"))
            {
                //Trabajamos con telefono.-
                consulta.option = "telefono";
                consulta.value = dato_box.Text;
                if (consulta.GetUserCode())
                {
                    if (SendMail())
                    {
                        MessageBox.Show("¡El código ha sido envíado correctamente!" + "\n" + "Por favor, verifique su casilla de correo.","Correo envíado de forma exitosa",MessageBoxButton.OK,MessageBoxImage.Information);
                        cod_box.IsEnabled = true;
                        enviar_btn.IsEnabled = true;
                    }
                } else
                {
                    MessageBox.Show("Usuario no encontrado con el dato de búsqueda: teléfono", "Error al encontrar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El dato de búsqueda no coincide","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            } 
        }
        private Boolean SendMail()
        {
            Boolean estado = false;
            datos.usuario = consulta.funciones.usuario.usuario;
            datos.correo = consulta.funciones.usuario.correo;
            if (insertar.SendCode(datos))
            {
                //Mostramos el correo electrónico en el Label.-
                correo_lbl.Content = "El código a sido envíado a: "+ consulta.funciones.usuario.correo;
                estado = true;
            }
            return estado;
        }
    }
}
