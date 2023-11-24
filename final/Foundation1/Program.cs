using System;

class Program
{
    static void Main(string[] args)
    {
        // Creat Video Object
        Video video1 = new Video("My Neighbor Totoro Trailer", "Hayao Miyazaki", 120);
        Video video2 = new Video("Pirates of the Caribbean Trailer", "Gore Verbinski", 180);
        Video video3 = new Video("Crouching Tiger, Hidden Dragon Trailer", "Ang Lee", 60);
        Video video4 = new Video("The Hunger Games Trailer", "Gary Ross", 150);

        video1.AddComment("Rachel Wagner","An emotionally true animated film full of whimsy and delight");
        video1.AddComment("Brian Eggert","Miyazaki's film is about imagination and family in their purest, most innocent forms.");
        video1.AddComment("Ard Vijn","On paper it may sound saccharine and lethally sentimental, but My Neighbour Totoro is nothing but wonderful and honest.");
        video2.AddComment("Micheal Compton","There's always too much going on, which is easily forgivable for a while. But as the minutes mount, the flaws are only accentuated.");
        video2.AddComment("Debbie Lynn Elias","Ahoy mateys! Shiver me timbers, I think we have a winner here!");
        video2.AddComment("Namrata Joshi","A wonderful entertainer, thrilling, engrossing and stylish.");
        video3.AddComment("Allison Rose","Crouching Tiger, Hidden Dragon was groundbreaking for its time... Lee did an incredible job bringing something new and fresh to action movies.");
        video3.AddComment("Howard Waldstein","It's a lush, striking homage to a genre that by the new millennium had already been dead except for the intermittent throwback-style film");
        video3.AddComment("Amy Bracken Sparks","Ang Lee's dreamlike film transcends its hybrid roots; it's unlike anything you've seen before.");
        video3.AddComment("Matt Conway","A masterful and emotionally sumptuous work that will continue to stand the test of time.");
        video4.AddComment("Sean Axmaker","I confess that for all my issues with the film (and there are many), I more impressed at how much it got right.");
        video4.AddComment("Brian Eggert","Whatever objections one might have about the execution, it’s a compelling story that’s been made into a serviceable film.");
        video4.AddComment("Julie and Brandy","[Rue's] presence gave the heart to the whole movie.");

        List<Video> videos = new List<Video>{video1, video2, video3, video4};
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} (seconds)");
            Console.WriteLine($"Number of Comments: {video.NumberComment()}");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }

    }
}