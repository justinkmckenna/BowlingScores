using System;
using System.Collections.Generic;
using System.Linq;

//Practice 1: 

//Create a new .NET Core Console Application called BowlingScores.  Store it in your c:\dev directory.

//The application asks for a set of bowler names and their score (0-300).  

//The names must be unique. 

//They can enter any number of bowlers and scores.  

//If they enter a non-unique name, it tells them to pick another name. 

//If they enter a blank name, it computes the following: 

//Display the name of the bowler with the high score 
//Display the name of the bowler with the low score 
//Display the average score of all bowlers. 

//Extra Credit Steps: 

//Change the background color of the console window to blue with white text. 

//Allow for ties in the score summary. 

namespace BowlingScores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            var bowlers = new Dictionary<string, int>();

            while (true)
            {
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }
                else if (bowlers.ContainsKey(name))
                {
                    Console.WriteLine("Name must be unique.");
                    continue;
                }
                Console.WriteLine("Enter score: ");
                int score;
                try
                {
                    score = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Score must be a number.");
                    continue;
                }
                bowlers.Add(name, score);
            }

            var high = bowlers.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var low = bowlers.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
            var avg = bowlers.Sum(x => x.Value) / bowlers.Count;
            Console.WriteLine($"Highest Score: {high}");
            Console.WriteLine($"Lowest Score: {low}");
            Console.WriteLine($"Average: {avg}");
        }
    }
}
