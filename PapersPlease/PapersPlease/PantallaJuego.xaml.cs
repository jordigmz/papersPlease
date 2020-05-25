using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        Random r;

        public PantallaJuego()
        {
            InitializeComponent();
        }

        private void Aprobar_Click(object sender, RoutedEventArgs e)
        {
            this.r = new Random();
            //personaje
            personajeImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\"+@"m\p14.png", UriKind.Absolute));

            //pasaporte
            pasaporteImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\" + @"m\d14.png", UriKind.Absolute));

            //visado
            visadoImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\" + @"m\d14.png", UriKind.Absolute));

            //tipo pasaporte
            tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r.Next(1, 7) + ".png", UriKind.Absolute));
        }

        private void Denegar_Click(object sender, RoutedEventArgs e)
        {
            this.r = new Random();
            //personaje
            personajeImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\" + @"m\p14.png", UriKind.Absolute));

            //pasaporte
            pasaporteImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\" + @"m\d14.png", UriKind.Absolute));

            //visado
            visadoImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\" + @"m\d14.png", UriKind.Absolute));

            //tipo pasaporte
            tipoPasImagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\imagenes\assets\papers\pt" + r.Next(1, 7) + ".png", UriKind.Absolute));
        }
    }
}
