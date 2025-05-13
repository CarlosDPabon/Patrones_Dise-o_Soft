
using System;
using System.Collections.Generic;

interface IEstadoPedido
{
    void SiguienteEstado(Pedido pedido);
    void MostrarEstado();
}

abstract class PreparacionPedido
{
    public void Preparar()
    {
        ObtenerIngredientes();
        Cocinar();
        Servir();
    }

    protected abstract void ObtenerIngredientes();
    protected abstract void Cocinar();
    protected virtual void Servir()
    {
        Console.WriteLine("Sirviendo el pedido.");
    }
}

interface IMediador
{
    void EnviarMensaje(string mensaje, IParticipante participante);
}

interface IParticipante
{
    void RecibirMensaje(string mensaje);
}

class Pedido
{
    public IEstadoPedido Estado { get; set; }

    public Pedido()
    {
        Estado = new EstadoPendiente();
    }

    public void SiguienteEstado()
    {
        Estado.SiguienteEstado(this);
    }

    public void MostrarEstado()
    {
        Estado.MostrarEstado();
    }
}

class EstadoPendiente : IEstadoPedido
{
    public void SiguienteEstado(Pedido pedido)
    {
        pedido.Estado = new EstadoPreparando();
    }

    public void MostrarEstado()
    {
        Console.WriteLine("El pedido está pendiente.");
    }
}

class EstadoPreparando : IEstadoPedido
{
    public void SiguienteEstado(Pedido pedido)
    {
        pedido.Estado = new EstadoListo();
    }

    public void MostrarEstado()
    {
        Console.WriteLine("El pedido está en preparación.");
    }
}

class EstadoListo : IEstadoPedido
{
    public void SiguienteEstado(Pedido pedido)
    {
        pedido.Estado = new EstadoEntregado();
    }

    public void MostrarEstado()
    {
        Console.WriteLine("El pedido está listo para entregar.");
    }
}

class EstadoEntregado : IEstadoPedido
{
    public void SiguienteEstado(Pedido pedido)
    {
        Console.WriteLine("El pedido ya ha sido entregado.");
    }

    public void MostrarEstado()
    {
        Console.WriteLine("El pedido ha sido entregado.");
    }
}

class PreparacionPizza : PreparacionPedido
{
    protected override void ObtenerIngredientes()
    {
        Console.WriteLine("Obteniendo masa, salsa y queso.");
    }

    protected override void Cocinar()
    {
        Console.WriteLine("Horneando la pizza.");
    }
}

class PreparacionHamburguesa : PreparacionPedido
{
    protected override void ObtenerIngredientes()
    {
        Console.WriteLine("Obteniendo pan, carne y vegetales.");
    }

    protected override void Cocinar()
    {
        Console.WriteLine("Cocinando la carne y armando la hamburguesa.");
    }
}

class MediadorRestaurante : IMediador
{
    private List<IParticipante> participantes = new List<IParticipante>();

    public void RegistrarParticipante(IParticipante participante)
    {
        participantes.Add(participante);
    }

    public void EnviarMensaje(string mensaje, IParticipante remitente)
    {
        foreach (var participante in participantes)
        {
            if (participante != remitente)
            {
                participante.RecibirMensaje(mensaje);
            }
        }
    }
}

class Mesero : IParticipante
{
    private IMediador mediador;

    public Mesero(IMediador mediador)
    {
        this.mediador = mediador;
    }

    public void TomarOrden(string orden)
    {
        Console.WriteLine($"Mesero toma orden: {orden}");
        mediador.EnviarMensaje($"Nueva orden: {orden}", this);
    }

    public void RecibirMensaje(string mensaje)
    {
        Console.WriteLine($"Mesero recibe mensaje: {mensaje}");
    }
}

class Cocina : IParticipante
{
    private IMediador mediador;

    public Cocina(IMediador mediador)
    {
        this.mediador = mediador;
    }

    public void RecibirMensaje(string mensaje)
    {
        Console.WriteLine($"Cocina recibe mensaje: {mensaje}");
    }

    public void PrepararPedido(string pedido)
    {
        Console.WriteLine($"Cocina preparando: {pedido}");
        mediador.EnviarMensaje($"Pedido {pedido} listo", this);
    }
}

class Cliente : IParticipante
{
    public void RecibirMensaje(string mensaje)
    {
        Console.WriteLine($"Cliente recibe mensaje: {mensaje}");
    }
}

class Program
{
    static void Main()
    {
        Pedido pedido = new Pedido();
        pedido.MostrarEstado();
        pedido.SiguienteEstado();
        pedido.MostrarEstado();
        pedido.SiguienteEstado();
        pedido.MostrarEstado();
        pedido.SiguienteEstado();
        pedido.MostrarEstado();

        Console.WriteLine("\nPreparación de pedidos:");
        PreparacionPedido pizza = new PreparacionPizza();
        pizza.Preparar();

        PreparacionPedido hamburguesa = new PreparacionHamburguesa();
        hamburguesa.Preparar();

        Console.WriteLine("\nSistema de comunicación:");
        MediadorRestaurante mediador = new MediadorRestaurante();
        Mesero mesero = new Mesero(mediador);
        Cocina cocina = new Cocina(mediador);
        Cliente cliente = new Cliente();

        mediador.RegistrarParticipante(mesero);
        mediador.RegistrarParticipante(cocina);
        mediador.RegistrarParticipante(cliente);

        mesero.TomarOrden("Pizza");
        cocina.PrepararPedido("Pizza");
    }
}
