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

namespace PapersPlease
{
    public partial class MainWindow : Window
    {
        string partida;
        ListaPasaportes pasaportes;

        public MainWindow()
        {
            InitializeComponent();
            pasaportes = new ListaPasaportes();

            //comprobar si exiten GetFiles() y hacer adds

            if (partidas.Items.Count == 0)
            {
                partidas.Visibility = Visibility.Hidden;
                cargarPartida.IsEnabled = false;
            }
        }

        public string GetPartida()
        {
            return partida;
        }
        public void SetPartida(string partida)
        {
            this.partida = partida;
        }

        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                partida = Interaction.InputBox("Por favor, registre la partida.", "Nombre", "", -1, -1);

            } while (partida == "");

            PantallaJuego p = new PantallaJuego();
            p.Show();

            this.Close();
        }

        private void CargarPartida_Click(object sender, RoutedEventArgs e)
        {
            pasaportes.Cargar(partidas.SelectedItem.ToString());

            PantallaJuego p = new PantallaJuego();
            p.Show();

            this.Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Main_Navigated(object sender, NavigationEventArgs e) { }

        private void ComboBox_Partidas(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
