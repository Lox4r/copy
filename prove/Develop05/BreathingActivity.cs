using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());

        DisplayStartingMessage();

        int cycles = _duration / 6; // 3 seconds for "Breathe in" and 3 seconds for "Breathe out"
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }

        DisplayEndingMessage();
    }
}
