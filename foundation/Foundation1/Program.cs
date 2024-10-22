using System;
using System.Collections.Generic;

namespace YouTubeTraker
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } // Length in seconds
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {Length} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create videos
            var video1 = new Video("Introduction to C#", "John Doe", 300);
            var video2 = new Video("Advanced C# Techniques", "Jane Smith", 600);
            var video3 = new Video("C# Design Patterns", "Emily Johnson", 450);

            // Add comments to videos
            video1.AddComment(new Comment("Alice", "Great video!"));
            video1.AddComment(new Comment("Bob", "Very informative."));
            video1.AddComment(new Comment("Charlie", "Thanks for sharing."));

            video2.AddComment(new Comment("Dave", "Excellent content."));
            video2.AddComment(new Comment("Eve", "Learned a lot."));
            video2.AddComment(new Comment("Frank", "Well explained."));

            video3.AddComment(new Comment("Grace", "Helpful tutorial."));
            video3.AddComment(new Comment("Heidi", "Loved the examples."));
            video3.AddComment(new Comment("Ivan", "Clear and concise."));

            // Store videos in a list
            var videos = new List<Video> { video1, video2, video3 };

            // Display video information
            foreach (var video in videos)
            {
                video.DisplayVideoInfo();
                Console.WriteLine();
            }
        }
    }
}
