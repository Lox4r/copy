using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling bike = new Cycling("04 Nov 2022", 40, 15.0);
        Swimming swim = new Swimming("05 Nov 2022", 25, 20);

        // Add to a list and display summaries
        List<Activity> activities = new List<Activity> { run, bike, swim };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
