using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' recorded! You earned {Points} points.");
    }

    public override string DisplayGoal()
    {
        return $"[ ∞ ] {Name} - {Description} ({Points} points per event)";
    }
}
