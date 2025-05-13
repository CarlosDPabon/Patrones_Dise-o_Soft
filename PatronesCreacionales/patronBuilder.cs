using System;
using System.Collections.Generic;

class Menu
{
    public string Nombre 
    public List<Categoria> Categorias = new List<Categoria>();

    public void Mostrar()
    {
        Console.WriteLine($"Menú: {Nombre}");
        foreach (var categoria in Categorias)
        {
            categoria.MostrarPlatos();
        }
    }
}

class Categoria
{
    public string Nombre 
    public List<Plato> Platos = new List<Plato>();

    public void MostrarPlatos()
    {
        Console.WriteLine($"\nCategoría: {Nombre}");
        foreach (var plato in Platos)
        {
            Console.WriteLine($"- {plato.Nombre}: ${plato.Precio}");
        }
    }
}

class Plato
{
    public string Nombre 
    public double Precio 
}

interface IMenuBuilder
{
    IMenuBuilder AsignarNombre(string nombre);
    IMenuBuilder AgregarCategoria(string nombre);
    IMenuBuilder AgregarPlato(string categoria, string nombre, double precio);
    Menu Construir();
}

class MenuBuilder : IMenuBuilder
{
    private Menu _menu = new Menu();

    public IMenuBuilder AsignarNombre(string nombre)
    {
        _menu.Nombre = nombre;
        return this;
    }

    public IMenuBuilder AgregarCategoria(string nombre)
    {
        _menu.Categorias.Add(new Categoria { Nombre = nombre });
        return this;
    }

    public IMenuBuilder AgregarPlato(string categoria, string nombre, double precio)
    {
        var cat = _menu.Categorias.Find(c => c.Nombre == categoria);
        if (cat != null)
        {
            cat.Platos.Add(new Plato { Nombre = nombre, Precio = precio });
        }
        return this;
    }

    public Menu Construir()
    {
        return _menu;
    }
}

class MenuDirector
{
    public Menu ConstruirMenuItaliano(IMenuBuilder builder)
    {
        return builder.SetNombre("Menú Italiano")
                      .AgregarCategoria("Entradas")
                      .AgregarPlato("Entradas", "Pasta", 5.99)
                      .AgregarCategoria("Platos Fuertes")
                      .AgregarPlato("Platos Fuertes", "Lasagna", 12.50)
                      .Construir();
    }
}

class Program
{
    static void Main()
    {
        IMenuBuilder builder = new MenuBuilder();
        MenuDirector director = new MenuDirector();

        // Prueba con menú italiano
        Menu menuItaliano = director.ConstruirMenuItaliano(builder);
        menuItaliano.Mostrar();
    }
}
