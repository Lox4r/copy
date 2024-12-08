using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped recently?",
        "What are some of your favorite memories?",
        "Who are your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you focus on the positive by listing as many things as you can in response to a prompt.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser(int duration)
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
                responses.Add(response);
        }

        return responses;
    }

    public override void Run()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());

        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        ShowCountdown(3);

        List<string> responses = GetListFromUser(_duration);

        Console.WriteLine($"You listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}
