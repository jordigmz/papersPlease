using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace PapersPlease
{
    public partial class PantallaJuego : Window
    {
        ListaPasaportes p;
        List<Pasaporte> listaPasaportes;
        List<Pasaporte> listaPasaportesErroneos;
        MainWindow inicio;
        Jugador j;
        Random r;
        int aleatorio;
        int contPersonajes;

        public PantallaJuego()
        {
            InitializeComponent();
            inicio = new MainWindow();
            j = new Jugador();
            r = new Random();

            p = new ListaPasaportes();
            
            p.Crear();
            listaPasaportes = p.GetPasaportes();
            listaPasaportesErroneos = p.GetPasaportesErroneos();

            contPersonajes = 0;
        }
        public PantallaJuego(string fichero) 
        {
            InitializeComponent();
            inicio = new MainWindow();
            j = new Jugador();
            r = new Random();

            p = new ListaPasaportes();

            p.Crear();
            listaPasaportes = p.GetPasaportes();
            listaPasaportesErroneos = p.GetPasaportesErroneos();

            contPersonajes = 0;
        }

        public void SiguientePersonaje()
        {
            if (listaPasaportes.Count > 0)
            {
                aleatorio = r.Next(0, listaPasaportes.Count);

                personajeImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPersonajeImagen(), UriKind.Absolute));
                pasaporteImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPasaporteImagen(), UriKind.Absolute));
                visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                nombreCorrecto.Content = listaPasaportes[aleatorio].GetNombre();
                apellidoCorrecto.Content = listaPasaportes[aleatorio].GetApellido();
                dniCorrecto.Content = listaPasaportes[aleatorio].GetDni();
                fechaNCorrecto.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length-8);

                if (aleatorio%2==0)
                {
                    switch(r.Next(0, 4))
                    {
                        case 1:
                            nombreError.Content = listaPasaportesErroneos[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        case 2:
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportesErroneos[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        case 3:
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportesErroneos[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        default:
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportesErroneos[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                    }
                }
                else
                {
                    nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                    apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                    dniError.Content = listaPasaportes[aleatorio].GetDni();
                    fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                }
                
                tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r.Next(1, 7) + ".png", UriKind.Absolute));
            }
            else
            {
                MessageBox.Show("Has ganado!");
            }
        }

        private void Aprobar_Click(object sender, RoutedEventArgs e)
        {
            j.Amonestar(0 , listaPasaportes[aleatorio], listaPasaportes[aleatorio]);

            listaPasaportes.RemoveAt(aleatorio);

            SiguientePersonaje();

            contPersonajes++;
        }

        private void Denegar_Click(object sender, RoutedEventArgs e)
        {
            j.Amonestar(1, listaPasaportes[aleatorio], new Pasaporte("", "", "", "", "", "", DateTime.Now));

            listaPasaportes.RemoveAt(aleatorio);

            SiguientePersonaje();

            contPersonajes++;
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            p.Guardar(inicio.GetPartida());

            this.Close();
        }
    }
}
