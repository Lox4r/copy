using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures();
        Scripture scripture = GetRandomScripture(scriptures);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Memorization complete.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hides 3 random words
        }
    }

    static List<Scripture> LoadScriptures()
    {
        List<Scripture> scriptures = new List<Scripture>();
        string filePath = "scriptures.txt";

        if (File.Exists(filePath))
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Reference reference = ParseReference(parts[0]);
                    scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
        else
        {
            Console.WriteLine("Scriptures file not found. Using default scripture.");
            scriptures.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding."
            ));
        }

        return scriptures;
    }

    static Reference ParseReference(string reference)
    {
        string[] parts = reference.Split(' ');
        string book = parts[0];
        string[] verses = parts[1].Split(':');
        int chapter = int.Parse(verses[0]);
        string[] verseRange = verses[1].Split('-');

        int verseStart = int.Parse(verseRange[0]);
        int? verseEnd = verseRange.Length > 1 ? int.Parse(verseRange[1]) : (int?)null;

        return new Reference(book, chapter, verseStart, verseEnd);
    }

    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        return scriptures[random.Next(scriptures.Count)];
    }
}
