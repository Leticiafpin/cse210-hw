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
        Console.WriteLine($"Iniciando {this.GetType().Name} por {duration} segundos.");
        Thread.Sleep(2000);
        PerformActivity();
        Console.WriteLine($"Bom trabalho! Você completou a {this.GetType().Name} por {duration} segundos.");
        Thread.Sleep(2000);
    }

    protected abstract void PerformActivity();
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Esta atividade vai ajudá-lo a relaxar, guiando-o a respirar lenta e profundamente. Limpe sua mente e concentre-se na sua respiração.");
        for (int i = 0; i < duration / 4; i++)
        {
            Console.WriteLine("Inspire...");
            Thread.Sleep(2000);
            Console.WriteLine("Expire...");
            Thread.Sleep(2000);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] prompts = {
        "Pense em uma vez que você defendeu alguém.",
        "Pense em uma vez que você fez algo muito difícil.",
        "Pense em uma vez que você ajudou alguém em necessidade.",
        "Pense em uma vez que você fez algo verdadeiramente altruísta."
    };

    private static readonly string[] questions = {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou essa vez diferente de outras vezes em que você não foi tão bem-sucedido?",
        "Qual é a sua coisa favorita sobre essa experiência?",
        "O que você poderia aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo através dessa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Esta atividade vai ajudá-lo a refletir sobre momentos em sua vida em que você mostrou força e resiliência. Isso vai ajudá-lo a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.");
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
        "Quem são as pessoas que você aprecia?",
        "Quais são suas forças pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo este mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    public ListingActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Esta atividade vai ajudá-lo a refletir sobre as coisas boas em sua vida, fazendo você listar o máximo de coisas que puder em uma determinada área.");
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(5000);
        Console.WriteLine("Comece a listar...");
        Thread.Sleep(duration * 1000);
        Console.WriteLine("O tempo acabou! Quantos itens você listou?");
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Escolha uma atividade:");
            Console.WriteLine("1. Atividade de Respiração");
            Console.WriteLine("2. Atividade de Reflexão");
            Console.WriteLine("3. Atividade de Listagem");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int activityChoice) && activityChoice >= 1 && activityChoice <= 3)
            {
                Console.Write("Digite a duração da atividade em segundos: ");
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
                    Console.WriteLine("Duração inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
        }
    }
}
