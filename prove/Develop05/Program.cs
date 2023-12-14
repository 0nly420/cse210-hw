using System;
using System.Collections.Generic;

// Clase base para representar un objetivo
public abstract class Objetivo
{
    private string descripcion;
    private bool completado;

    public Objetivo(string descripcion)
    {
        this.descripcion = descripcion;
        this.completado = false;
    }

    public string Descripcion
    {
        get { return descripcion; }
    }

    public bool Completado
    {
        get { return completado; }
    }

    // Método abstracto para registrar el progreso del objetivo
    public abstract void RegistrarProgreso();

    // Método para marcar el objetivo como completado
    protected void MarcarComoCompletado()
    {
        completado = true;
    }
}

// Clase para representar un objetivo simple
public class ObjetivoSimple : Objetivo
{
    private int valor;

    public ObjetivoSimple(string descripcion, int valor) : base(descripcion)
    {
        this.valor = valor;
    }

    public int Valor
    {
        get { return valor; }
    }

    public override void RegistrarProgreso()
    {
        MarcarComoCompletado();
        Console.WriteLine($"¡Objetivo simple completado! Ganaste {valor} puntos.");
    }
}

// Clase para representar un objetivo eterno
public class ObjetivoEterno : Objetivo
{
    private int valor;

    public ObjetivoEterno(string descripcion, int valor) : base(descripcion)
    {
        this.valor = valor;
    }

    public override void RegistrarProgreso()
    {
        Console.WriteLine($"Has progresado en tu objetivo eterno. Ganaste {valor} puntos.");
    }
}

// Clase para representar un objetivo de lista de verificación
public class ObjetivoListaVerificacion : Objetivo
{
    private int vecesCompletado;
    private int vecesObjetivo;

    private int valorPorCompletar;
    private int bono;

    public ObjetivoListaVerificacion(string descripcion, int vecesObjetivo, int valorPorCompletar, int bono) : base(descripcion)
    {
        this.vecesCompletado = 0;
        this.vecesObjetivo = vecesObjetivo;
        this.valorPorCompletar = valorPorCompletar;
        this.bono = bono;
    }

    public override void RegistrarProgreso()
    {
        vecesCompletado++;

        if (vecesCompletado < vecesObjetivo)
        {
            Console.WriteLine($"Has completado {vecesCompletado}/{vecesObjetivo} veces el objetivo de lista de verificación. Ganaste {valorPorCompletar} puntos.");
        }
        else
        {
            MarcarComoCompletado();
            Console.WriteLine($"¡Objetivo de lista de verificación completado! Ganaste un bono de {bono} puntos.");
        }
    }
}

// Clase principal que gestiona los objetivos del usuario
public class EternalQuest
{
    private List<Objetivo> objetivos;
    private int puntaje;

    public EternalQuest()
    {
        objetivos = new List<Objetivo>();
        puntaje = 0;
    }

    public int Puntaje
    {
        get { return puntaje; }
    }

    // Método para agregar un nuevo objetivo
    public void AgregarObjetivo(Objetivo objetivo)
    {
        objetivos.Add(objetivo);
    }

    // Método para registrar el progreso de un objetivo
    public void RegistrarProgreso(Objetivo objetivo)
    {
        if (!objetivo.Completado)
        {
            objetivo.RegistrarProgreso();
            puntaje += objetivo.Completado ? 0 : CalcularPuntosPorProgreso(objetivo);
        }
        else
        {
            Console.WriteLine("Este objetivo ya ha sido completado.");
        }
    }

    // Método para calcular los puntos ganados por progreso
    private int CalcularPuntosPorProgreso(Objetivo objetivo)
    {
        // Lógica para calcular puntos basados en el tipo de objetivo, podrías personalizar esto
        // según tus necesidades específicas de gamificación.
        return 50; // Puntos arbitrarios por progreso
    }

    // Método para mostrar la lista de objetivos
    public void MostrarListaObjetivos()
    {
        foreach (var objetivo in objetivos)
        {
            string estado = objetivo.Completado ? "[X]" : "[ ]";
            string progreso = objetivo is ObjetivoListaVerificacion
                ? $"Completed {((ObjetivoListaVerificacion)objetivo).VecesCompletado}/{((ObjetivoListaVerificacion)objetivo).VecesObjetivo} times"
                : "";

            Console.WriteLine($"{estado} {objetivo.Descripcion} {progreso}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Ejemplo de uso
        EternalQuest eternalQuest = new EternalQuest();

        ObjetivoSimple objetivoCorrerMaraton = new ObjetivoSimple("Correr una maratón", 1000);
        ObjetivoEterno objetivoLeerEscrituras = new ObjetivoEterno("Leer las Escrituras", 100);
        ObjetivoListaVerificacion objetivoAsistirTemplo = new ObjetivoListaVerificacion("Asistir al templo", 10, 50, 500);

        eternalQuest.AgregarObjetivo(objetivoCorrerMaraton);
        eternalQuest.AgregarObjetivo(objetivoLeerEscrituras);
        eternalQuest.AgregarObjetivo(objetivoAsistirTemplo);

        eternalQuest.RegistrarProgreso(objetivoCorrerMaraton);
        eternalQuest.RegistrarProgreso(objetivoLeerEscrituras);
        eternalQuest.RegistrarProgreso(objetivoAsistirTemplo);

        eternalQuest.MostrarListaObjetivos();
        Console.WriteLine($"Puntaje total: {eternalQuest.Puntaje}");
    }
}
