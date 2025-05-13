using System;
using System.Collections.Generic;

abstract class DocumentoBase
{
    public string Nombre 
    public abstract void ExportarPDF();
}

class DocumentoXLSX : DocumentoBase
{
    public override void ExportarPDF() => Console.WriteLine("Exportando XLSX a PDF...");
}

class DocumentoDOCX : DocumentoBase
{
    public override void ExportarPDF() => Console.WriteLine("Exportando DOCX a PDF...");
}

class DocumentoXML : DocumentoBase
{
    public override void ExportarPDF() => Console.WriteLine("Exportando XML a PDF...");
}

class FabricaDocumentos
{
    public DocumentoBase CrearDocumento(string tipo)
    {
        return tipo switch
        {
            "XLSX" => new DocumentoXLSX(),
            "DOCX" => new DocumentoDOCX(),
            "XML" => new DocumentoXML(),
            _ => throw new ArgumentException("Tipo de documento no válido")
        };
    }
}

class DocumentoBuilder
{
    private DocumentoBase _documento;

    public DocumentoBuilder(DocumentoBase documento)
    {
        _documento = documento;
    }

    public DocumentoBuilder AgregarTitulo(string titulo)
    {
        Console.WriteLine($"Agregando título: {titulo}");
        return this;
    }

    public DocumentoBuilder AgregarTabla(List<List<string>> tabla)
    {
        Console.WriteLine("Agregando tabla...");
        return this;
    }

    public DocumentoBuilder AgregarEstilo(string estilo)
    {
        Console.WriteLine($"Aplicando estilo: {estilo}");
        return this;
    }

    public DocumentoBase Construir()
    {
        return _documento;
    }
}

class Program
{
    static void Main()
    {
        FabricaDocumentos fabrica = new FabricaDocumentos();

        // Prueba con documento XLSX
        DocumentoBase documento = fabrica.CrearDocumento("XLSX");


        DocumentoBuilder builder = new DocumentoBuilder(documento);
        builder.AgregarTitulo("Informe de Ventas")
               .AgregarTabla(new List<List<string>> { new List<string> { "Producto", "Cantidad", "Precio" } })
               .AgregarEstilo("Negrita")
               .Construir();

        documento.ExportarPDF();
    }
}
