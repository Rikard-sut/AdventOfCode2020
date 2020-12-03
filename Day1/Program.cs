using System;
using Extensions;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"C:\Users\admin\source\repos\AdventOfCode2020\Day1\Data.txt";
            var data = filePath.GetData();
            var parsedData = data.ParseToIntArray();

            var answer1 = GetAnswer1(parsedData);
            var answer2 = GetAnswer2(parsedData);

            Console.WriteLine(answer1);
            Console.WriteLine(answer2);
            Console.ReadKey();
        }

        public static int GetAnswer1(int[] numbers)
        {
            int answer = 0;

            foreach (int number1 in numbers)
            {
                foreach (int number2 in numbers)
                {
                    int sum = number1 + number2;

                    if (sum == 2020)
                      answer = number1 * number2;
                }
            }
            return answer;
        }

        public static int GetAnswer2(int[] numbers)
        {
            int answer = 0;

            foreach (int number1 in numbers)
            {
                foreach (int number2 in numbers)
                {
                    foreach(int number3 in numbers)
                    {
                        int sum = number1 + number2 + number3;

                        if (sum == 2020)
                            answer = number1 * number2 * number3;
                    }
                }
            }
            return answer;
        }
    }
}
