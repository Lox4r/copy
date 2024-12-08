using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you apply this experience in the future?"
    };

    public ReflectingActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. Recognize your power and potential.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    private void DisplayQuestions(int duration)
    {
        int timeElapsed = 0;
        while (timeElapsed < duration)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
            timeElapsed += 5;
        }
    }

    public override void Run()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());

        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        ShowSpinner(3);

        DisplayQuestions(_duration);

        DisplayEndingMessage();
    }
}