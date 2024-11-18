using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public string FormatEntry()
    {
        return $"{Date}~|~{Prompt}~|~{Response}";
    }

    public static Entry Parse(string entryData)
    {
        string[] parts = entryData.Split("~|~");
        return new Entry(parts[0], parts[1], parts[2]);
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToShortDateString();
        _entries.Add(new Entry(date, prompt, response));
    }

    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, _entries.Select(e => e.FormatEntry()));
    }

    public void LoadFromFile(string filename)
    {
        _entries = File.ReadAllLines(filename)
                       .Select(Entry.Parse)
                       .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "5") break;

            switch (choice)
            {
                case "1":
                    string prompt = prompts[new Random().Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    string loadFilename = Console.ReadLine();
                    try
                    {
                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine("Journal loaded.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error loading file.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
