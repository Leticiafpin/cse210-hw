using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsCompleted = true;
        Console.WriteLine($"Meta '{Name}' completada! Você ganhou {Points} pontos.");
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Points},{IsCompleted}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Meta '{Name}' registrada! Você ganhou {Points} pontos.");
    }

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Points}";
    }
}

class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
            Console.WriteLine($"Meta '{Name}' completada! Você ganhou {Points + BonusPoints} pontos.");
        }
        else
        {
            Console.WriteLine($"Meta '{Name}' registrada! Você ganhou {Points} pontos.");
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : $"[{CurrentCount}/{TargetCount}]";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Points},{CurrentCount},{TargetCount},{BonusPoints},{IsCompleted}";
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop06 World!");

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Criar nova meta");
            Console.WriteLine("2. Registrar evento");
            Console.WriteLine("3. Mostrar metas");
            Console.WriteLine("4. Mostrar pontuação total");
            Console.WriteLine("5. Salvar metas");
            Console.WriteLine("6. Carregar metas");
            Console.WriteLine("7. Sair");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowTotalPoints();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Escolha o tipo de meta:");
        Console.WriteLine("1. Meta Simples");
        Console.WriteLine("2. Meta Eterna");
        Console.WriteLine("3. Meta de Checklist");
        string choice = Console.ReadLine();

        Console.Write("Digite o nome da meta: ");
        string name = Console.ReadLine();
        Console.Write("Digite os pontos da meta: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Digite o número de vezes que a meta deve ser completada: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Digite os pontos bônus para completar a meta: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Tipo de meta inválido. Tente novamente.");
                break;
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("Escolha a meta para registrar um evento:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} - {goals[i].GetStatus()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            goals[choice].RecordEvent();
            totalPoints += goals[choice].Points;
        }
        else
        {
            Console.WriteLine("Meta inválida. Tente novamente.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("Metas:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - {goal.GetStatus()}");
        }
    }

    static void ShowTotalPoints()
    {
        Console.WriteLine($"Pontuação total: {totalPoints}");
    }

    static void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(totalPoints);
            foreach (var goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Metas salvas com sucesso.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            totalPoints = int.Parse(lines[0]);
            goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(details[0], int.Parse(details[1])) { IsCompleted = bool.Parse(details[2]) });
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(details[0], int.Parse(details[1])));
                        break;
                    case "ChecklistGoal":
                        goals.Add(new ChecklistGoal(details[0], int.Parse(details[1]), int.Parse(details[3]), int.Parse(details[4]))
                        {
                            CurrentCount = int.Parse(details[2]),
                            IsCompleted = bool.Parse(details[5])
                        });
                        break;
                }
            }
            Console.WriteLine("Metas carregadas com sucesso.");
        }
        else
        {
            Console.WriteLine("Nenhum arquivo de metas encontrado.");
        }
    }
}
