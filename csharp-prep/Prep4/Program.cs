using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int sumOfList = 0;
        int addedNumber = 1;
        int greatestNumber = 0;

        while (addedNumber != 0)
        {
            Console.Write("Enter number: ");
            addedNumber = int.Parse(Console.ReadLine());

            if (addedNumber != 0)
            {
                numbers.Add(addedNumber);
            }
            
            sumOfList += addedNumber;
        }
        Console.WriteLine($"The sum is {sumOfList}");
        
        float listAverage = ((float)sumOfList) / numbers.Count;
        Console.WriteLine($"The average is: {listAverage}");

        foreach (int number in numbers)
        {
            if (number > greatestNumber)
            {
                greatestNumber = number;
            }
        }
        Console.WriteLine($"The largest number is: {greatestNumber}");
    }
}