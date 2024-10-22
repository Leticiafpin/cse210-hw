using System;
using System.Collections.Generic;

namespace YouTubeTraker
{

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments = new List<Comment>();

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video { Title = "Learning C#", Author = "John Doe", Length = 600 };
        Video video2 = new Video { Title = "Cooking Pasta", Author = "Jane Smith", Length = 300 };
        Video video3 = new Video { Title = "Travel Vlog", Author = "Alice Johnson", Length = 1200 };

        // Add comments to video1
        video1.AddComment(new Comment { Name = "User1", Text = "Great tutorial!" });
        video1.AddComment(new Comment { Name = "User2", Text = "Very helpful, thanks!" });
        video1.AddComment(new Comment { Name = "User3", Text = "I learned a lot." });

        // Add comments to video2
        video2.AddComment(new Comment { Name = "User4", Text = "Yummy recipe!" });
        video2.AddComment(new Comment { Name = "User5", Text = "Can't wait to try this." });

        // Add comments to video3
        video3.AddComment(new Comment { Name = "User6", Text = "Amazing places!" });
        video3.AddComment(new Comment { Name = "User7", Text = "Beautiful scenery." });
        video3.AddComment(new Comment { Name = "User8", Text = "Great vlog!" });

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
}