using System;

interface IUsuarioPrototype
{
    IUsuarioPrototype Clonar();
    void MostrarInfo();
}

class Usuario : IUsuarioPrototype
{
    public string Nombre 
    public string Email 
    public string Rol 

    public Usuario(string nombre, string email, string rol)
    {
        Nombre = nombre;
        Email = email;
        Rol = rol;
    }

    public virtual IUsuarioPrototype Clonar()
    {
        return (IUsuarioPrototype)this.MemberwiseClone();
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Usuario: {Nombre} | Email: {Email} | Rol: {Rol}");
    }
}

class Estudiante : Usuario
{
    public string Nivel 

    public Estudiante(string nombre, string email, string nivel)
        : base(nombre, email, "Estudiante")
    {
        Nivel = nivel;
    }

    public override IUsuarioPrototype Clonar()
    {
        return new Estudiante(Nombre, Email, Nivel);
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Estudiante: {Nombre} | Email: {Email} | Nivel: {Nivel}");
    }
}

class Profesor : Usuario
{
    public string Especialidad 

    public Profesor(string nombre, string email, string especialidad)
        : base(nombre, email, "Profesor")
    {
        Especialidad = especialidad;
    }

    public override IUsuarioPrototype Clonar()
    {
        return new Profesor(Nombre, Email, Especialidad);
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Profesor: {Nombre} | Email: {Email} | Especialidad: {Especialidad}");
    }
}

class Administrador : Usuario
{
    public string Permisos

    public Administrador(string nombre, string email, string permisos)
        : base(nombre, email, "Administrador")
    {
        Permisos = permisos;
    }

    public override IUsuarioPrototype Clonar()
    {
        return new Administrador(Nombre, Email, Permisos);
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Administrador: {Nombre} | Email: {Email} | Permisos: {Permisos}");
    }
}

class Program
{
    static void Main()
    {
        Usuario estudiante1 = new Estudiante("Juan Pérez", "juan@example.com", "Universitario");
        Usuario profesor1 = new Profesor("María Gómez", "maria@example.com", "Matemáticas");
        Usuario administrador1 = new Administrador("Carlos López", "carlos@example.com", "Gestión de usuarios");

        Usuario estudiante2 = (Usuario)estudiante1.Clonar();
        estudiante2.Nombre = "Ana Rodríguez"; 

        estudiante1.MostrarInfo();
        estudiante2.MostrarInfo();
        profesor1.MostrarInfo();
        administrador1.MostrarInfo();
    }
}
