using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        // Create the first job instance
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Display the first job's company
        job1.DisplayJobInfo();

        // Create the second job instance
        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Senior Developer";
        job2._startYear = 2022;
        job2._endYear = 2024;

        // Display the second job's company
        job2.DisplayJobInfo();
    }

    
}