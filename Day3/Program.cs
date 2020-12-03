using System;
using System.IO;
using Extensions;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extensions.Extensions.WriteData(@"C:\Users\admin\source\repos\AdventOfCode2020\Day3\Data3.txt", @"C:\Users\admin\source\repos\AdventOfCode2020\Day3\FinalData3.txt");
            Console.WriteLine(FindCountOfTrees(3));

            int route1 = FindCountOfTrees(1);
            int route2 = FindCountOfTrees(3);
            int route3 = FindCountOfTrees(5);
            int route4 = FindCountOfTrees(7);
            int route5 = FindCountOfTrees(1, 2);

            decimal sum = (decimal)route1 * (decimal)route2 * (decimal)route3 * (decimal)route4 * (decimal)route5;

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        public static int FindCountOfTrees(int amountOfStepsRight, int down = 1)
        {
            int startingPosition = 0;
            int treeCounter = 0;
            int lineCounter = 0;

            using (StreamReader reader = new StreamReader(@"C:\Users\admin\source\repos\AdventOfCode2020\Day3\FinalData3.txt"))
            {
                string line;
                if (down == 1)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineCounter++;

                        char position = line[startingPosition];
                        if (position == '#')
                            treeCounter++;

                        startingPosition += amountOfStepsRight;
                    }
                }

                if (down == 2)
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineCounter % 2 == 0)
                        {
                            char position = line[startingPosition];
                            position = line[startingPosition];
                            if (position == '#')
                                treeCounter++;

                            startingPosition += amountOfStepsRight;
                        }

                        lineCounter++;
                    }
                }
            }
            return treeCounter;
        }
    }
}
