using System;
using System.Collections.Generic;

interface IReporte
{
    void Generar();
}

class ReporteSimple : IReporte
{
    private string _nombre;
    
    public ReporteSimple(string nombre)
    {
        _nombre = nombre;
    }

    public void Generar()
    {
        Console.WriteLine($"Generando reporte: {_nombre}");
    }
}

class ReporteCompuesto : IReporte
{
    private List<IReporte> _reportes = new List<IReporte>();

    public void AgregarReporte(IReporte reporte)
    {
        _reportes.Add(reporte);
    }

    public void Generar()
    {
        Console.WriteLine("Generando reporte compuesto:");
        foreach (var reporte in _reportes)
        {
            reporte.Generar();
        }
    }
}

class Program
{
    static void Main()
    {
        IReporte reporte1 = new ReporteSimple("Reporte de Ventas");
        IReporte reporte2 = new ReporteSimple("Reporte de Inventario");

        ReporteCompuesto reporteGeneral = new ReporteCompuesto();
        reporteGeneral.AgregarReporte(reporte1);
        reporteGeneral.AgregarReporte(reporte2);

        reporteGeneral.Generar();
    }
}
