using System;
using System.IO;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using System.Media;

namespace PapersPlease
{
    public partial class MainWindow : Window
    {
        DirectoryInfo dir;
        FileInfo[] infoFicheros;
        string partida;
        string ultimaPartida;
        DateTime mayor;
        SoundPlayer reproductor;

        public MainWindow()
        {
            InitializeComponent();

            reproductor = new SoundPlayer(Directory.GetCurrentDirectory() + @"\imagenes\assets\sonidos\inicio.mp3");
            reproductor.Load();
            reproductor.Play();

            dir = new DirectoryInfo(Environment.CurrentDirectory);
            infoFicheros = dir.GetFiles();

            mayor = Convert.ToDateTime("01/01/1111 0:00:00");
            ultimaPartida = "";

            foreach (FileInfo infoUnFich in infoFicheros)
            {
                if (infoUnFich.Name.Contains(".txt") && !infoUnFich.Name.Contains("Correctos") && !infoUnFich.Name.Contains("Erroneos"))
                {
                    partidas.Items.Add(infoUnFich.Name.Substring(0, infoUnFich.Name.Length - 4));

                    if(infoUnFich.CreationTime > mayor)
                    {
                        mayor = infoUnFich.CreationTime;
                        ultimaPartida = infoUnFich.Name;
                    }
                }
            }

            if (partidas.Items.Count == 0)
            {
                partidas.Visibility = Visibility.Hidden;
                cargarPartida.IsEnabled = false;
            }
            else
            {
                partidas.SelectedItem = ultimaPartida.Substring(0, ultimaPartida.Length - 4);
            }
        }

        public string GetPartida()
        {
            return partida;
        }
        public void SetPartida(string nPartida)
        {
            partida = nPartida;
        }

        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            PantallaJuego p = new PantallaJuego();

            p.Show();

            this.Close();
        }

        private void CargarPartida_Click(object sender, RoutedEventArgs e)
        {
            SetPartida(partidas.SelectedItem.ToString());

            PantallaJuego p = new PantallaJuego(GetPartida() + ".txt");

            File.Delete(GetPartida() + ".txt");
            File.Delete(GetPartida() + "Correctos.txt");
            File.Delete(GetPartida() + "Erroneos.txt");

            p.Show();

            this.Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Main_Navigated(object sender, NavigationEventArgs e) { }

        private void ComboBox_Partidas(object sender, SelectionChangedEventArgs e) { }
    }
}
