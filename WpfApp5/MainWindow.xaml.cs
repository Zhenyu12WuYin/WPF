using System;
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
using WpfApp5;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            marcaComboBox.ItemsSource = new String[] { "Renault", "Seat", "Volkswagen", "Ford", "Peugeot", "Opel", "Toyota", "Citroen", "Nissan", "BMW" };
            modeloComboBox.ItemsSource = new String[] { "Clio", "Ibiza", "Golf", "Fiesta", "208", "Corsa", "Corolla", "C3", "Qashqai", "Serie 3" };



            // Asignar la lista enumerable como ItemsSource
            coches.ItemsSource = Coche.ObtenerCochesEjemplo();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            marcaComboBox.SelectedValue="";
            modeloComboBox.SelectedValue = "";
            matricula.Text = "";
        }
    }
}
