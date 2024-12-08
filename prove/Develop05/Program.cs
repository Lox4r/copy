using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Application!");
        Console.WriteLine("Please select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Listing Activity");
        Console.WriteLine("3. Reflection Activity");
        Console.Write("Enter your choice (1-3): ");

        string choice = Console.ReadLine();

        Activity selectedActivity;

        switch (choice)
        {
            case "1":
                selectedActivity = new BreathingActivity();
                break;
            case "2":
                selectedActivity = new ListingActivity();
                break;
            case "3":
                selectedActivity = new ReflectingActivity();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }

        selectedActivity.Run();

        Console.WriteLine("Thank you for using the Mindfulness Application. Goodbye!");
    }
}
