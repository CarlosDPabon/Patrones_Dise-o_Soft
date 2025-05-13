using System;

interface IVentana
{
    void Mostrar();
}

class VentanaBase : IVentana
{
    public void Mostrar()
    {
        Console.WriteLine("Mostrando ventana básica");
    }
}

abstract class VentanaDecorator : IVentana
{
    protected IVentana _ventana;

    public VentanaDecorator(IVentana ventana)
    {
        _ventana = ventana;
    }

    public virtual void Mostrar()
    {
        _ventana.Mostrar();
    }
}

class VentanaConBorde : VentanaDecorator
{
    public VentanaConBorde(IVentana ventana) : base(ventana) { }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.WriteLine("Agregando borde a la ventana");
    }
}

class VentanaConBarraDesplazamiento : VentanaDecorator
{
    public VentanaConBarraDesplazamiento(IVentana ventana) : base(ventana) { }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.WriteLine("Agregando barra de desplazamiento a la ventana");
    }
}

class Program
{
    static void Main()
    {
        IVentana ventana = new VentanaBase();
        IVentana ventanaDecorada = new VentanaConBorde(new VentanaConBarraDesplazamiento(ventana));

        ventanaDecorada.Mostrar();
    }
}
