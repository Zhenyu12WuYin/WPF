using System;
using System.Collections.Generic;
using System.ComponentModel.Design;


class Cliente
{

    public string Nombre { get; set; }
    public string NumeroCarnetConducir { get; set; }
    public string Telefono { get; set; }

    public static List<Cliente> ObtenerClientesEjemplo()
    {
        List<Cliente> clientes = new List<Cliente>();

        string[] nombres = { "Ana", "Carlos", "Laura", "Pedro", "Elena", "David", "María", "José", "Isabel", "Javier" };
        string[] apellidos = { "López", "Martínez", "García", "Sánchez", "Pérez", "Rodríguez", "Fernández", "Moreno", "Gómez", "González" };

        Random random = new Random();

        for (int i = 0; i < 300; i++)
        {
            string nombre = nombres[random.Next(nombres.Length)];
            string apellido1 = apellidos[random.Next(apellidos.Length)];
            string apellido2 = apellidos[random.Next(apellidos.Length)];

            Cliente cliente = new Cliente
            {
                Nombre = $"{nombre} {apellido1} {apellido2}",
                NumeroCarnetConducir = GenerarNumeroCarnet(),
                Telefono = GenerarNumeroTelefono()
            };

            clientes.Add(cliente);
        }

        return clientes;
    }

    static string GenerarNumeroTelefono()
    {
        Random random = new Random();
        string numero = "6";

        for (int i = 0; i < 8; i++)
        {
            numero += random.Next(10);
        }

        return numero;
    }

    static string GenerarNumeroCarnet()
    {
        Random random = new Random();
        string numeros = "0123456789";
        string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        string numeroCarnet = "";

        for (int i = 0; i < 8; i++)
        {
            numeroCarnet += numeros[random.Next(numeros.Length)];
        }

        numeroCarnet += letras[random.Next(letras.Length)];

        return numeroCarnet;
    }

    public override string ToString()
    {
        return this.Nombre + $" ({this.NumeroCarnetConducir})";
    }
}