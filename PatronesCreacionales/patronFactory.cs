using System;

abstract class Vehiculo
{
    public string Tipo 
    public double CapacidadCarga 

    public abstract void MostrarInfo();
}

class Camion : Vehiculo
{
    public Camion() { Tipo = "Camión"; CapacidadCarga = 5000; }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Vehículo: {Tipo} | Capacidad de carga: {CapacidadCarga} kg");
    }
}

class Motocicleta : Vehiculo
{
    public Motocicleta() { Tipo = "Motocicleta"; CapacidadCarga = 50; }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Vehículo: {Tipo} | Capacidad de carga: {CapacidadCarga} kg");
    }
}

class Dron : Vehiculo
{
    public Dron() { Tipo = "Dron"; CapacidadCarga = 10; }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Vehículo: {Tipo} | Capacidad de carga: {CapacidadCarga} kg");
    }
}

class FabricaVehiculos : IFabricaVehiculos
{
    public Vehiculo CrearVehiculo(string tipo)
    {
        return tipo switch
        {
            "Camion" => new Camion(),
            "Motocicleta" => new Motocicleta(),
            "Dron" => new Dron(),
            _ => throw new ArgumentException("Tipo de vehículo no válido")
        };
    }
}

class Program
{
    static void Main()
    {
        IFabricaVehiculos fabrica = new FabricaVehiculos();

        Vehiculo camion = fabrica.CrearVehiculo("Camion");
        Vehiculo moto = fabrica.CrearVehiculo("Motocicleta");
        Vehiculo dron = fabrica.CrearVehiculo("Dron");

        camion.MostrarInfo();
        moto.MostrarInfo();
        dron.MostrarInfo();
    }
}