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
        IEnumerable<Coche> coches;
        int totalCoches;

        IEnumerable<Cliente> clientes;

        public MainWindow()
        {
            InitializeComponent();
            marcaComboBox.ItemsSource= new String[] { "BMW", "Citroen", "Ford", "Nissan", "Opel", "Peugeot", "Renault", "Seat", "Toyota", "Volkswagen" };
            modeloComboBox.ItemsSource = new String[] { "208", "C3", "Clio", "Corsa", "Corolla", "Fiesta", "Golf", "Ibiza", "Qashqai", "Serie 3" };




            coches = Coche.ObtenerCochesEjemplo();
            coches = coches.OrderBy(coche => (coche.Marca))
                .ThenBy(coche => (coche.Modelo));
            totalCoches = coches.Count();
            CarChanged(null, null);


            clientes = Cliente.ObtenerClientesEjemplo();
            clientes = clientes.OrderBy(cliente => (cliente.Nombre));
            ClientChanged(null, null);

        }

        private void CarChanged(object sender, RoutedEventArgs e)
        {
            
            string marcaSeleccionada="", modeloSeleccionado="";
            var cochesFiltrados = coches;

            marcaSeleccionada = (marcaComboBox.SelectedItem)?.ToString();
            modeloSeleccionado = (modeloComboBox.SelectedItem)?.ToString();

            
            if (!string.IsNullOrEmpty(marcaSeleccionada))
            {
                cochesFiltrados = cochesFiltrados.Where(coche => coche.Marca.Equals(marcaSeleccionada));
            }

            if (!string.IsNullOrEmpty(modeloSeleccionado))
            {
                cochesFiltrados = cochesFiltrados.Where(coche => coche.Modelo.Equals(modeloSeleccionado));
            }

            if (!string.IsNullOrEmpty(Matricula.Text))
            {
                cochesFiltrados = cochesFiltrados.Where(coche => coche.Matricula.StartsWith(Matricula.Text, StringComparison.OrdinalIgnoreCase));
            }
            
            tablaCoches.ItemsSource = cochesFiltrados;
            Etiqueta.Content = "Mostrando " + cochesFiltrados.Count() + " de " + totalCoches+ " coches ";
            
        }

        private void Reset(object sender, RoutedEventArgs e)
        {

            marcaComboBox.SelectedValue="";
            modeloComboBox.SelectedValue = "";
            Matricula.Text = "";
            CarChanged(null, null);
        }

        private void ClientChanged(object sender, RoutedEventArgs e)
        {
            var clientesFiltrados = clientes;
            if (!String.IsNullOrEmpty(Buscador.Text)) 
            {
                clientesFiltrados = clientes.Where(cliente => cliente.Nombre.StartsWith(Buscador.Text, StringComparison.OrdinalIgnoreCase) || 
                cliente.NumeroCarnetConducir.StartsWith(Buscador.Text, StringComparison.OrdinalIgnoreCase) || 
                cliente.Telefono.StartsWith(Buscador.Text, StringComparison.OrdinalIgnoreCase));
            } 

            tablaClientes.ItemsSource = clientesFiltrados;
            Etiqueta2.Content = "Mostrando " + clientesFiltrados.Count() + " de " + clientes.Count() + " clientes ";

        }

        private void EliminarCliente(object sender, RoutedEventArgs e)
        {
            if (tablaClientes.SelectedItems != null)
            {
                var list = clientes.ToList();
                var elimClientes = tablaClientes.SelectedItems;
                foreach (var item in elimClientes)
                    list.Remove((Cliente)item);
                clientes = list;
            }
            ClientChanged(null, null);
        }

        private void Reservar(object sender, RoutedEventArgs e)
        {
            if (FechaInicio.SelectedDate.HasValue)
            {
                if (tablaCoches.SelectedItems.Count == 1)
                {
                    if (tablaClientes.SelectedItems.Count == 1)
                    { 
                        Warning.Content = "";

                        var fechaIni = (System.DateTime)FechaInicio.SelectedDate;

                        var coche = (Coche)tablaCoches.SelectedItem;
                        var cliente = (Cliente)tablaClientes.SelectedItem;
                        var list = coches.ToList();
                        int n = list.IndexOf(coche);

                        coche.Alquilar(fechaIni, cliente);
                        list[n] = coche;
                        coches = list;
                        CarChanged(null, null);

                    } else { Warning.Content = "Debes seleccionar 1 cliente";}
                } else {Warning.Content = "Debes seleccionar 1 vehículo";}
            } else { Warning.Content = "No has elegido fecha de inicio";}
        }

        private void Devolver(object sender, RoutedEventArgs e)
        {
            if (FechaFinal.SelectedDate.HasValue)
            {
                if (tablaCoches.SelectedItems.Count == 1)
                {
                    var fechaFinal = (System.DateTime)FechaFinal.SelectedDate;
                    var coche = (Coche)tablaCoches.SelectedItem;
                    var list = coches.ToList() ;
                    int n = list.IndexOf(coche);

                    if (coche.ClienteAlquilando != null)
                    {
                        coche.Devolver(fechaFinal);
                        list[n] = coche;
                        coches= list;
                        CarChanged(null, null);

                    } else { Warning.Content = "Seleccionar 1 vehículo que tenga un cliente alquilando"; }
                } else { Warning.Content = "Selecciona 1 vehículo"; }
            } else { Warning.Content = "No has seleccionado fecha de devolución"; }
        }

        private void Borrar(object sender, RoutedEventArgs e)
        {

        }

    }
}
