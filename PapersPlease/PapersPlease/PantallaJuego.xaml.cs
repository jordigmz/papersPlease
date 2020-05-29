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
        string personajeTemp;
        string pasaporteTemp;
        string visadoTemp;

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

            personajeTemp = "";
            pasaporteTemp = "";
            visadoTemp = "";

            SiguientePersonaje();

            contPersonajes = 1;
        }
        public PantallaJuego(string ficheroPartida) 
        {
            InitializeComponent();
            inicio = new MainWindow();
            j = new Jugador();
            r = new Random();

            p = new ListaPasaportes();

            p.Cargar(ficheroPartida);

            listaPasaportes = p.GetPasaportes();
            listaPasaportesErroneos = p.GetPasaportesErroneos();

            personajeTemp = "";
            pasaporteTemp = "";
            visadoTemp = "";

            SiguientePersonaje();

            contPersonajes = 1;
        }

        public void SiguientePersonaje()
        {
            if(j.GetPerdido())
            {
                this.Close();
            }

            news.Content = "Día " + j.GetContadorDias() + " (" + j.GetAhorros() + "$)";

            if (contPersonajes == 4)
            {
                contPersonajes = 0;
                j.SetContadorDias(j.GetContadorDias()+1);
                j.SetAhorros(j.GetAhorros()+5);
                MessageBox.Show("Buen trabajo. (+5$)");
            }

            if (listaPasaportes.Count > 0)
            {
                aleatorio = r.Next(0, listaPasaportes.Count);

                personajeImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPersonajeImagen(), UriKind.Absolute));
                pasaporteImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPasaporteImagen(), UriKind.Absolute));
                
                nombreCorrecto.Content = listaPasaportes[aleatorio].GetNombre();
                apellidoCorrecto.Content = listaPasaportes[aleatorio].GetApellido();
                dniCorrecto.Content = listaPasaportes[aleatorio].GetDni();
                fechaNCorrecto.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length-8);

                if (aleatorio%2==0)
                {
                    switch(r.Next(0, 5))
                    {
                        case 1:
                            visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                            nombreError.Content = listaPasaportesErroneos[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        case 2:
                            visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportesErroneos[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        case 3:
                            visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportesErroneos[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        case 4:
                            visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportesErroneos[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                        default:
                            visadoImagen.Source = new BitmapImage(new Uri(listaPasaportesErroneos[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                            nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                            apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                            dniError.Content = listaPasaportes[aleatorio].GetDni();
                            fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                            break;
                    }
                }
                else
                {
                    visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));
                    nombreError.Content = listaPasaportes[aleatorio].GetNombre();
                    apellidoError.Content = listaPasaportes[aleatorio].GetApellido();
                    dniError.Content = listaPasaportes[aleatorio].GetDni();
                    fechaNError.Content = listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Substring(0, listaPasaportes[aleatorio].GetFechaNacimiento().ToString().Length - 8);
                }
                
                tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r.Next(1, 7) + ".png", UriKind.Absolute));
            }
            else
            {
                MessageBox.Show("Enhorabuena, has ganado!");
                this.Close();
            }
        }

        public void Decidir(int decision)
        {
            personajeTemp = personajeImagen.Source.ToString().Substring(8);
            pasaporteTemp = pasaporteImagen.Source.ToString().Substring(8);
            visadoTemp = visadoImagen.Source.ToString().Substring(8);

            j.Amonestar(decision, listaPasaportes[aleatorio], new Pasaporte(personajeTemp.Replace("/", @"\"), pasaporteTemp.Replace("/", @"\"), visadoTemp.Replace("/", @"\"), nombreError.Content.ToString(), apellidoError.Content.ToString(), dniError.Content.ToString(), Convert.ToDateTime(fechaNError.Content.ToString())));

            SiguientePersonaje();

            listaPasaportes.RemoveAt(aleatorio);
            listaPasaportesErroneos.RemoveAt(aleatorio);

            contPersonajes++;
        }

        private void Aprobar_Click(object sender, RoutedEventArgs e)
        {
            Decidir(0);
        }

        private void Denegar_Click(object sender, RoutedEventArgs e)
        {
            Decidir(1);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            if (inicio.GetPartida() == null)
            {
                do
                {
                    inicio.SetPartida(Interaction.InputBox("Por favor, registre la partida.", "Nombre", "", -1, -1));

                } while (inicio.GetPartida() == null);
            }

            p.Guardar(inicio.GetPartida(), listaPasaportes, listaPasaportesErroneos);

            this.Close();
        }
    }
}
