using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn C#", "CodeAcademy", 600);
        Video video2 = new Video("Master Python", "PythonGuru", 3600);
        Video video3 = new Video("Understanding Abstraction", "TechWithTim", 900);

        // Add comments to each video
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "This helped a lot!"));
        video1.AddComment(new Comment("Charlie", "Nice explanation!"));

        video2.AddComment(new Comment("Dave", "Amazing content!"));
        video2.AddComment(new Comment("Eve", "Very helpful."));
        video2.AddComment(new Comment("Frank", "Clear and concise!"));

        video3.AddComment(new Comment("Grace", "Clear explanation."));
        video3.AddComment(new Comment("Hank", "Loved this video!"));
        video3.AddComment(new Comment("Ivy", "Excellent examples!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(); 
        }
    }
}
