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
        ListaPasaportes pasaportes;

        public MainWindow()
        {
            InitializeComponent();
            pasaportes = new ListaPasaportes();

            if(!File.Exists("partida.txt"))
            {
                cargarPartida.IsEnabled = false;
            }
        }

        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            pasaportes.Crear();

            PantallaJuego p = new PantallaJuego();
            p.Show();

            this.Close();
        }

        private void CargarPartida_Click(object sender, RoutedEventArgs e)
        {
            pasaportes.Cargar();

            PantallaJuego p = new PantallaJuego();
            p.Show();

            this.Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            pasaportes.Guardar();
            this.Close();
        }
        
        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
