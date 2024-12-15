using System;

public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _currentCount = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {_bonusPoints + Points} points.");
        }
        else
        {
            Console.WriteLine($"Progress for '{Name}': {_currentCount}/{_targetCount}. You earned {Points} points.");
        }
    }

    public override string DisplayGoal()
    {
        return $"[ {(IsCompleted ? "X" : " ")} ] {Name} - {Description} ({Points} points, Bonus: {_bonusPoints}) - Progress: {_currentCount}/{_targetCount}";
    }
}
