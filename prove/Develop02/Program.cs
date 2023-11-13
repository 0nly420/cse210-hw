using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class JournalManager
{
    private List<JournalEntry> entries;

    public JournalManager()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response, string date)
    {
        JournalEntry entry = new JournalEntry(prompt, response, date);
        entries.Add(entry);
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}.\n");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries before loading new ones
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split(',');
                    if (parts.Length == 3)
                    {
                        AddEntry(parts[1], parts[2], parts[0]);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {filename}.\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please make sure the file exists.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}\n");
        }
    }
}

class Program
{
    static void Main()
    {
        JournalManager journalManager = new JournalManager();
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    int randomIndex = random.Next(prompts.Length);
                    string prompt = prompts[randomIndex];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journalManager.AddEntry(prompt, response, date);
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:\n");
                    journalManager.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFilename = Console.ReadLine();
                    journalManager.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFilename = Console.ReadLine();
                    journalManager.LoadFromFile(loadFilename);
                    break;

                case "5":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option (1-5).\n");
                    break;
            }
        }
    }

    static string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
}
