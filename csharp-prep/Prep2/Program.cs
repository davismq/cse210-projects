using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What was your score out of 100 for this class?");
        string score = Console.ReadLine();

        int numberScore = int.Parse(score);

        if (numberScore >= 90)
        {
            Console.WriteLine("You got an A in the class.");
        }
        else if (numberScore >= 80)
        {
            Console.WriteLine("You got a B in the class.");
        }
        else if (numberScore >= 70)
        {
            Console.WriteLine("You got a C in the class.");
        }
        else if (numberScore >= 60)
        {
            Console.WriteLine("You got a D in the class.");
        }
        else
        {
            Console.WriteLine("You got an F in the class.");
        }
    }
}