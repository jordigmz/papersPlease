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

namespace PapersPlease
{
    public partial class PantallaJuego : Window
    {
        ListaPasaportes pasaportes;
        List<Pasaporte> listaPasaportes;
        MainWindow inicio;
        Random r;
        int aleatorio;

        public PantallaJuego()
        {
            InitializeComponent();
            inicio = new MainWindow();

            pasaportes = new ListaPasaportes();
            pasaportes.Crear();

            listaPasaportes = pasaportes.GetPasaportes();

            r = new Random();
        }

        //hacer función siguiente

        private void Aprobar_Click(object sender, RoutedEventArgs e)
        {
            pasaportes.Guardar(inicio.GetPartida());

            aleatorio = r.Next(0, listaPasaportes.Count);

            if (listaPasaportes.Count > 0)
            {
                personajeImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPersonajeImagen(), UriKind.Absolute));

                pasaporteImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPasaporteImagen(), UriKind.Absolute));

                visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));

                listaPasaportes.RemoveAt(aleatorio);
            }

            //tipo pasaporte
            tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r.Next(1, 7) + ".png", UriKind.Absolute));
        }

        private void Denegar_Click(object sender, RoutedEventArgs e)
        {
            pasaportes.Guardar(inicio.GetPartida());

            aleatorio = r.Next(0, listaPasaportes.Count);

            if (listaPasaportes.Count > 0)
            {
                personajeImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPersonajeImagen(), UriKind.Absolute));

                pasaporteImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetPasaporteImagen(), UriKind.Absolute));

                visadoImagen.Source = new BitmapImage(new Uri(listaPasaportes[aleatorio].GetVisadoImagen(), UriKind.Absolute));

                listaPasaportes.RemoveAt(aleatorio);
            }
            //tipo pasaporte
            tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r.Next(1, 7) + ".png", UriKind.Absolute));
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            //Guardar
        }
    }
}
