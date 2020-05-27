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
        ListaPasaportes p;
        List<Pasaporte> mujeres;
        List<Pasaporte> hombres;
        MainWindow inicio;
        Random r;
        Random r2;
        int aleatorio;

        public PantallaJuego()
        {
            InitializeComponent();
            inicio = new MainWindow();
            p = new ListaPasaportes();
            mujeres = p.GetPasaportesMujeres();
            hombres = p.GetPasaportesHombres();

            r = new Random();
            r2 = new Random();
        }

        private void Aprobar_Click(object sender, RoutedEventArgs e)
        {
            p.Guardar(inicio.GetPartida());

            aleatorio = r.Next(0, mujeres.Count);

            if (mujeres.Count > 0)
            {
                personajeImagen.Source = new BitmapImage(new Uri(mujeres[aleatorio].GetPersonajeImagen(), UriKind.Absolute));

                pasaporteImagen.Source = new BitmapImage(new Uri(mujeres[aleatorio].GetPasaporteImagen(), UriKind.Absolute));

                visadoImagen.Source = new BitmapImage(new Uri(mujeres[aleatorio].GetVisadoImagen(), UriKind.Absolute));
            }
            else if (hombres.Count > 0)
            {
                personajeImagen.Source = new BitmapImage(new Uri(hombres[aleatorio].GetPersonajeImagen(), UriKind.Absolute));

                pasaporteImagen.Source = new BitmapImage(new Uri(hombres[aleatorio].GetPasaporteImagen(), UriKind.Absolute));

                visadoImagen.Source = new BitmapImage(new Uri(hombres[aleatorio].GetVisadoImagen(), UriKind.Absolute));
            }

            //tipo pasaporte
            tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r2.Next(1, 7) + ".png", UriKind.Absolute));
        }

        private void Denegar_Click(object sender, RoutedEventArgs e)
        {
            p.Guardar(inicio.GetPartida());

            aleatorio = r.Next(0, mujeres.Count);

            if (mujeres.Count > 0)
            {
                personajeImagen.Source = new BitmapImage(new Uri(mujeres[aleatorio].GetPersonajeImagen(), UriKind.Absolute));

                pasaporteImagen.Source = new BitmapImage(new Uri(mujeres[aleatorio].GetPasaporteImagen(), UriKind.Absolute));

                visadoImagen.Source = new BitmapImage(new Uri(mujeres[aleatorio].GetVisadoImagen(), UriKind.Absolute));
            }
            else if (hombres.Count > 0)
            {
                personajeImagen.Source = new BitmapImage(new Uri(hombres[aleatorio].GetPersonajeImagen(), UriKind.Absolute));

                pasaporteImagen.Source = new BitmapImage(new Uri(hombres[aleatorio].GetPasaporteImagen(), UriKind.Absolute));

                visadoImagen.Source = new BitmapImage(new Uri(hombres[aleatorio].GetVisadoImagen(), UriKind.Absolute));
            }

            //tipo pasaporte
            tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r2.Next(1, 7) + ".png", UriKind.Absolute));
        }
    }
}
