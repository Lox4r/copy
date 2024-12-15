using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        IsCompleted = true;
        Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
    }

    public override string DisplayGoal()
    {
        return $"[ {(IsCompleted ? "X" : " ")} ] {Name} - {Description} ({Points} points)";
    }
}
