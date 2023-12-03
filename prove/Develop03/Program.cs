using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Text { get; }
    public bool Hidden { get; set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string reference)
    {
        // Implementa la lógica para parsear la referencia aquí
        string[] parts = reference.Split(':');

        if (parts.Length != 2)
        {
            throw new ArgumentException("La referencia debe tener el formato 'Libro Capítulo:Versículo' o 'Libro Capítulo:Versículo-Versículo'");
        }

        Book = parts[0];

        string[] chapterVerseParts = parts[1].Split('-');
        Chapter = int.Parse(chapterVerseParts[0]);

        if (chapterVerseParts.Length == 1)
        {
            StartVerse = EndVerse = int.Parse(chapterVerseParts[0]);
        }
        else if (chapterVerseParts.Length == 2)
        {
            StartVerse = int.Parse(chapterVerseParts[0]);
            EndVerse = int.Parse(chapterVerseParts[1]);
        }
        else
        {
            throw new ArgumentException("La referencia debe tener el formato 'Libro Capítulo:Versículo' o 'Libro Capítulo:Versículo-Versículo'");
        }
    }
}

class Scripture
{
    private List<Word> words;
    public Reference Reference { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{Reference.Book} {Reference.Chapter}:{Reference.StartVerse}-{Reference.EndVerse}");
        Console.WriteLine(string.Join(" ", words.Select(w => w.Hidden ? "___" : w.Text)));
    }

    public void HideRandomWord()
    {
        var random = new Random();
        var visibleWords = words.Where(w => !w.Hidden).ToList();

        if (visibleWords.Count > 0)
        {
            var randomWord = visibleWords[random.Next(visibleWords.Count)];
            randomWord.Hidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.Hidden);
    }
}

class Program
{
    static void Main()
    {
        var scripture = new Scripture(new Reference("Juan 3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();

            Console.WriteLine("Presiona Enter para ocultar una palabra o escribe 'salir' para terminar:");
            var input = Console.ReadLine();

            if (input.ToLower() == "salir")
                break;

            scripture.HideRandomWord();
        }

        Console.WriteLine("Todas las palabras han sido ocultadas. Programa finalizado.");
    }
}

