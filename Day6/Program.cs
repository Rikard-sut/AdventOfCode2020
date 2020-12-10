using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\admin\source\repos\AdventOfCode2020\Day6\Data6.txt";
            var data = filepath.GetData();
            var yesAnswerCountPerGroup = FindAmountOfYesAnswersPerGroup(data);
            var yesAnswerCountPerGroupPt2 = FindAmountOfYesAnswersPerGroupPt2(data);
            var answer = yesAnswerCountPerGroup.Sum();
            var answer2 = yesAnswerCountPerGroupPt2.Sum();
            Console.WriteLine(answer);
            Console.WriteLine(answer2);
            Console.ReadKey();
        }

        public static List<int> FindAmountOfYesAnswersPerGroup(List<object> answerstrings)
        {
            List<int> answers = new List<int>();
            int yescount = 0;
            var values = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (string answerstring in answerstrings)
            {
                if (!string.IsNullOrEmpty(answerstring))
                {
                    foreach (char letter in answerstring)
                    {
                        if (values.Any(x => x == letter))
                        {
                            yescount++;
                            values.RemoveAll(x => x == letter);
                        }
                    }
                }

                else
                {
                    answers.Add(yescount);
                    yescount = 0;
                    values = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                }
            }
            answers.Add(yescount);
            return answers;
        }

        public static List<int> FindAmountOfYesAnswersPerGroupPt2(List<object> answerstrings)
        {
            List<int> answers = new List<int>();
            int countOfppl = 0;
            string groupAnswer = "";

            int yescount;
            foreach (string anwerstring in answerstrings)
            {
                if (!string.IsNullOrEmpty(anwerstring))
                {
                    groupAnswer += anwerstring;
                    countOfppl++;
                }
                else
                {
                    yescount = YesCountOfEveryPersonInGrp(countOfppl, groupAnswer);
                    answers.Add(yescount);
                    countOfppl = 0;
                    groupAnswer = "";
                }
            }
            yescount = YesCountOfEveryPersonInGrp(countOfppl, groupAnswer);
            answers.Add(yescount);
            return answers;
        }

        public static int YesCountOfEveryPersonInGrp(int countOfppl, string group)
        {
            int yescount = 0;

            while (group.Length > 0 && countOfppl > 1)
            {
                int lettercount = 0;
                for (int j = 0; j < group.Length; j++)
                {
                    if (group[0] == group[j])
                    {
                        lettercount++;
                        if (lettercount == countOfppl)
                            yescount++;
                    }
                }
                group = group.Replace(group[0].ToString(), string.Empty);
            }
            if (countOfppl == 1)
            {
                yescount = group.Length;
            }
            return yescount;
        }
    }
}
