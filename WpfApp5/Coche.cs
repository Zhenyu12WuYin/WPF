using System;
using System.Collections.Generic;
using System.Windows;

class Coche
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Matricula { get; set; }
    public double PrecioPorDia { get; set; }
    public DateTime FechaAlquiler { get; set; }
    public Cliente ClienteAlquilando { get; set; }

    public void Alquilar(DateTime fechaAlquiler, Cliente cliente)
    {
        if (ClienteAlquilando==null)
        {
            FechaAlquiler = fechaAlquiler;
            ClienteAlquilando = cliente;
            MostrarMensaje($"Coche {Marca} {Modelo} alquilado a {cliente.Nombre} el {fechaAlquiler.ToShortDateString()}");
        }
        else
        {
            MostrarMensaje($"Lo siento, el coche {Marca} {Modelo} no está disponible en este momento.");
        }
    }

    public void Devolver(DateTime fechaDevolucion)
    {
        if (ClienteAlquilando != null)
        {
            double diasAlquilados = (fechaDevolucion - FechaAlquiler).TotalDays;
            double costeTotal = diasAlquilados * PrecioPorDia;

            MostrarMensaje($"Coche {Marca} {Modelo} devuelto por {ClienteAlquilando.Nombre} el {fechaDevolucion.ToShortDateString()}.\nDebe pagar {costeTotal:C}");

            FechaAlquiler = DateTime.MinValue;
            ClienteAlquilando = null;
        }
        else
        {
            MostrarMensaje($"El coche {Marca} {Modelo} ya está disponible, no se puede devolver.");
        }
    }

    private static void MostrarMensaje(string mensaje)
    {
        MessageBox.Show(mensaje, "Alquiler de Coche", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public static List<Coche> ObtenerCochesEjemplo()
    {
        List<Coche> coches = new List<Coche>();

        string[] marcas = { "Renault", "Seat", "Volkswagen", "Ford", "Peugeot", "Opel", "Toyota", "Citroen", "Nissan", "BMW" };
        string[] modelos = { "Clio", "Ibiza", "Golf", "Fiesta", "208", "Corsa", "Corolla", "C3", "Qashqai", "Serie 3" };

        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            Coche coche = new Coche
            {
                Marca = marcas[random.Next(marcas.Length)],
                Modelo = modelos[random.Next(modelos.Length)],
                Matricula = GenerarMatricula(),
                PrecioPorDia = random.Next(50, 150) // Precio aleatorio entre 50 y 150 euros

            };

            coches.Add(coche);
        }

        return coches;
    }

    static string GenerarMatricula()
    {
        Random random = new Random();
        string consonantesPermitidas = "BCDFGHJKLMNPRSTVWXYZ";
        string numeros = "0123456789";

        string matricula = "";

        for (int i = 0; i < 4; i++)
        {
            matricula += numeros[random.Next(numeros.Length)];
        }

        for (int i = 0; i < 3; i++)
        {
            matricula += consonantesPermitidas[random.Next(consonantesPermitidas.Length)];
        }

        return matricula;
    }
}