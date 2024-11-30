using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos and add comments
        Video video1 = new Video("Learn C#", "CodeAcademy", 600);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "This helped a lot!");
        
        Video video2 = new Video("Master Python", "PythonGuru", 3600);
        video2.AddComment("Dave", "Amazing content!");
        video2.AddComment("Eve", "Very helpful.");

        Video video3 = new Video("Understanding Abstraction", "TechWithTim", 900);
        video3.AddComment("Grace", "Clear explanation.");
        video3.AddComment("Hank", "Loved this video!");

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Video details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<string> Comments { get; } = new List<string>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(string name, string text)
    {
        Comments.Add($"{name}: {text}");
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}
