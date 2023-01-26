using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

class Journal
{
    List<Entry> entries = new List<Entry>();
    List<string> prompts = new List<string>() { "Who was the most interesting person I interacted with today?",
                                                "What was the best part of my day?",
                                                "How did I see the hand of the Lord in my life today?",
                                                "What was the strongest emotion I felt today?",
                                                "If I had one thing I could do over today, what would it be?"};

    public void AddEntry()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        string prompt = prompts[index];

        Console.WriteLine("Prompt: " + prompt);
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString();

        Entry newEntry = new Entry(prompt, response, date);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine("Prompt: " + entry.Prompt);
                Console.WriteLine("Response: " + entry.Response);
                Console.WriteLine("Date: " + entry.Date);
                Console.WriteLine();
            }
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                file.WriteLine(entry.Prompt + "|" + entry.Response + "|" + entry.Date);
            }
        }
    }
    public void LoadJournal(string filename)
    {
        entries.Clear();
        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split("|");
                string prompt = parts[0];
                string response = parts[1];
                string date = parts[2];

                Entry newEntry = new Entry(prompt, response, date);
                entries.Add(newEntry);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load a journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            switch (choice)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.WriteLine("Enter filename to save as:");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournal(saveFilename);
                    break;
                case 4:
                    Console.WriteLine("Enter filename to load:");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournal(loadFilename);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}