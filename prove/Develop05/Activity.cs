using System;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting: {_name}");
        Console.WriteLine(_description);
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b-");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b\\");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b|");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i}...");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}
