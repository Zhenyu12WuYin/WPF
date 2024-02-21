using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp5
{
    public class Coche2
    {
        public Coche2(string marca, string modelo, string matricula, double precioPorDia, string clienteAlquilado)
        {
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            PrecioPorDia = precioPorDia;
            ClienteAlquilado = clienteAlquilado;
        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public double PrecioPorDia { get; set; }
        public string ClienteAlquilado { get; set; }

        
    }
}