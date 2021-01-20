using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using gestion_pizzeria.Clases;
using gestion_pizzeria.Screens;

namespace gestion_pizzeria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class ingresar : Window
    {
        public ingresar()
        {
            InitializeComponent();
        }

        private void pass_box_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public int counter_close = 0;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ingrese su usuario y contraseña" + "\n" + "Si no cuenta con uno comuníquese con el proveedor de servicios.", "Ayuda", MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (counter_close == 0) {
                System.Windows.Application.Current.Shutdown();
            }
        }
        consultas consulta = new Clases.consultas();
        InsertData insertar = new InsertData();
        ClaseDatos datos = new ClaseDatos();
        private void ingresar_btn_Click(object sender, RoutedEventArgs e)
        {
            

            //Acá va todo el acceso del usuario, validando las credenciales.-
            
            //Clases.functions funciones = new Clases.functions();
          
            if (usuario_box.Text != "" && pass_box.Password != "")
            {
                consulta.password = pass_box.Password;
                consulta.usuario = usuario_box.Text;
                if (consulta.getUser())
                {
                    if (FirstAcces())
                    {
                        //Si es el primer acceso del usuario, registramos la dirección MAC.-
                        if (InsertMACAddress())
                        {
                            //Ingresar datos del primer acceso.- PENDIENTE
                            if (InsertUserAcces())
                            {
                                counter_close = 1;
                                this.Close();
                            }
                           
                            
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al tomar el primer ingreso" + "\n" + "Por favor, inténtelo de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        //Si no es el primer acceso del usuario, continua el flujo normal.-
                        string UserMACAdress = consulta.funciones.usuario.MAC;
                        ArrayList dir = getMacAddress();
                        if (UserMACAdress != dir[0].ToString())
                        {
                            MessageBox.Show("Este equipo no es el registrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            System.Windows.Application.Current.Shutdown();
                        }
                        else
                        {
                            if (InsertUserAcces())
                            {
                                counter_close = 1;
                                this.Close();
                            }
                            //Ingresamos datos del acceso.- PENDIENTE
                            
                        }
                    }
                    
                } else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
               
            } else
            {
                MessageBox.Show("¡Los campos no pueden estar vacíos!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        public Boolean FirstAcces()
        {
            Boolean estado = false;
            if (usuario_box.Text != "" && pass_box.Password != "")
            {
                consulta.usuario = usuario_box.Text;
                if (consulta.GetFirstAcces())
                {
                    estado = false;
                }
                else
                {
                    estado = true;
                }
            }
            return estado;
        }
        public Boolean InsertMACAddress()
        {
            Boolean estado = false;
            if (usuario_box.Text != "" && pass_box.Password != "")
            {
                datos.usuario = usuario_box.Text;
                ArrayList dir = getMacAddress();
                datos.UserMACAdress = dir[0].ToString();
                if (insertar.UpdateMACUser(datos))
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            return estado;
        }
        public Boolean InsertUserAcces()
        {
            Boolean estado = false;
            if (usuario_box.Text != "" && pass_box.Password != "")
            {
                datos.fecha = DateTime.Today.ToString("yyyy-MM-dd");
                datos.hora = DateTime.Now.ToString("HH:mm:ss");
                datos.usuario = usuario_box.Text;
                if (insertar.InsertUserAcces(datos))
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
            }
            return estado;
        }
        public static ArrayList getMacAddress()
        {
            // Contador para un ciclo
            int i = 0;
            // Colección de direcciones MAC
            ArrayList DireccionesMAC = new ArrayList();
            // Información de las tarjetas de red
            NetworkInterface[] interfaces = null;
            // Obtener todas las interfaces de red de la PC
            interfaces = NetworkInterface.GetAllNetworkInterfaces();
            // Validar la cantidad de tarjetas de red que tiene
            if (interfaces != null && interfaces.Length > 0)
            {
                // Recorrer todas las interfaces de red
                foreach (NetworkInterface adaptador in interfaces)
                {
                    // Obtener la dirección fisica
                    PhysicalAddress direccion = adaptador.GetPhysicalAddress();
                    // Obtener en modo de arreglo de bytes la dirección
                    byte[] bytes = direccion.GetAddressBytes();
                    // Variable que tendra la dirección visible
                    string mac_address = string.Empty;
                    // Recorrer todos los bytes de la direccion
                    for (i = 0; i < bytes.Length; i++)
                    {
                        // Pasar el byte a un formato legible para el usuario
                        mac_address += bytes[i].ToString("X2");
                        if (i != bytes.Length - 1)
                        {
                            // Agregar un separador, por formato
                            mac_address += ":";
                        }
                    }
                    // Agregar la direccion MAC a la lista
                    DireccionesMAC.Add(mac_address);
                }
            }
            // Valor de retorno, la lista de direcciones MAC
            return DireccionesMAC;
        }

        private void recuperar_lbl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea recuperar el acceso a su cuenta?","Recuperar Acceso",MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                recuperar_acceso frm = new recuperar_acceso();
                frm.ShowDialog();
            }
        }
    }
}
