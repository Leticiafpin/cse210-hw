using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {this.GetType().Name} for {duration} seconds.");
        Thread.Sleep(2000);
        PerformActivity();
        Console.WriteLine($"Good job! You completed the {this.GetType().Name} for {duration} seconds.");
        Thread.Sleep(2000);
    }

    protected abstract void PerformActivity();
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you relax by guiding you to breathe in and out slowly. Clear your mind and focus on your breathing.");
        for (int i = 0; i < duration / 4; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] prompts = {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something very difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different from other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you showed strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        for (int i = 0; i < duration / 10; i++)
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine(question);
            Thread.Sleep(5000);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private static readonly string[] prompts = {
        "Who are the people you appreciate?",
        "What are your personal strengths?",
        "Who are the people you helped this week?",
        "When did you feel the Holy Spirit this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(5000);
        Console.WriteLine("Start listing...");
        Thread.Sleep(duration * 1000);
        Console.WriteLine("Time's up! How many items did you list?");
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int activityChoice) && activityChoice >= 1 && activityChoice <= 3)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    MindfulnessActivity activity = activityChoice switch
                    {
                        1 => new BreathingActivity(duration),
                        2 => new ReflectionActivity(duration),
                        3 => new ListingActivity(duration),
                        _ => null
                    };

                    activity?.StartActivity();
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
