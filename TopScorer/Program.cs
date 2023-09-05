using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TopScorer
{
    class Program
    {
        static void Main(string[] args)
        {
            //getting csv file name as a string
            string csvFileName = @"TestData.csv";
            //splitting the csv file into a list of lines using the above file name
            List<string> fileLines = File.ReadAllLines(csvFileName).ToList();
            //Console.WriteLine(lines[1]);
            //create a list of type Scorers which will contain the scorers details
            List<Scorers> scorers = new List<Scorers>();
            int highestScore = 0;

            //skipping the first line in the file as those are headings and iterating through to add to the scorers list.
            //also here we determine the highest score in the file
            for (int i = 1; i < fileLines.Count; i++)
            {
                string[] details = fileLines[i].Split(",");
                if (int.Parse(details[2]) > highestScore)
                {
                    highestScore = int.Parse(details[2]);
                }

                scorers.Add(new Scorers(details[0], details[1], int.Parse(details[2])));
            }
            //sorting the list according to the first name and second name alphabetically
            List<Scorers> sortedList = scorers.OrderBy(x => x.FirstName).ThenBy(x => x.SecondName).ToList();
            //printing the scorers names and the highest score
            foreach (Scorers scorer in sortedList)
            {
                if (scorer.Score == highestScore)
                {
                    Console.WriteLine("{0} {1}", scorer.FirstName, scorer.SecondName);
                }
            }
            Console.WriteLine("Score: {0}", highestScore);
        }

        class Scorers
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public int Score { get; set; }

            public Scorers(string firstName, string secondName, int score)
            {
                FirstName = firstName;
                SecondName = secondName;
                Score = score;
            }
        }
    }
}