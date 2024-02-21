using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5;

internal class List<T>
{

    private List<T> lista;

    public List()
    {
        this.lista = new List<T>();
    }

    public void Insert(int posicion, T objeto)
    {
        try
        {
            lista.Insert(posicion, objeto);
            Console.WriteLine($"El objeto {objeto} ha sido insertado de la posicion {posicion}");
        }
        catch
        {
            Console.WriteLine("Posición no válida");
        }
    }

    public void Remove(int posicion)
    {
        try
        {
            T obj = lista.At(posicion);
            lista.Remove(posicion);
            Console.WriteLine($"El objeto {obj} ha sido eliminado de la posicion {posicion}");
        }
        catch
        {
            Console.WriteLine("No hay lista para eliminar");
        }
    }

    public T At(int posicion)
    {
        try
        {
            return lista.At(posicion);
        }
        catch
        {
            Console.WriteLine("No se ha podido obtener el objeto de esa posicion");
            return default(T);
        }
    }

    public Boolean Empty()
    {
        return lista.Empty();
    }

    public void Principio(T objeto)
    {
        lista.Insert(0, objeto);
    }

    public void Add(T objeto)
    {
        lista.Add(objeto);
    }

    public int Count() { return lista.Count(); }
}
