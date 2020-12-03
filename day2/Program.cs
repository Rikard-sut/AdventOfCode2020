using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"C:\Users\admin\source\repos\AdventOfCode2020\day2\Data2.txt";
            var data = filePath.GetData();
            var parsedData = data.ParseToStringList();

            var passwordsWithRules = GetPasswordObjects(parsedData);

            var numberOfValidPasswords = FindValidPasswordCount(passwordsWithRules);

            Console.WriteLine(numberOfValidPasswords);
            Console.ReadKey();
        }

        public static List<PassWordMatch> GetPasswordObjects(IEnumerable<string> dataList)
        {
            List<PassWordMatch> passwordsAndRules = new List<PassWordMatch>();
            foreach(string item in dataList)
            {
                var passwordMatch = new PassWordMatch();

                string[] ruleAndPw = item.Split(':');
                passwordMatch.ActualPassword = ruleAndPw[1];

                string passwordRules = ruleAndPw[0];

                string[] ruleAndLetter = passwordRules.Split(' ');
                passwordMatch.Letter = ruleAndLetter[1];

                string rules = ruleAndLetter[0];

                string[] maxAndMinLength = rules.Split('-');
                passwordMatch.MinLength = Int32.Parse(maxAndMinLength[0]);
                passwordMatch.MaxLength = Int32.Parse(maxAndMinLength[1]);

                passwordsAndRules.Add(passwordMatch);
            }
            return passwordsAndRules;
        }

        public static int FindValidPasswordCount(IEnumerable<PassWordMatch> passwords)
        {
            int i = 0;
            foreach(var password in passwords)
            {
                var countOfLetter = password.ActualPassword.Count(x => x == char.Parse(password.Letter));

                if (countOfLetter >= password.MinLength && countOfLetter <= password.MaxLength)
                    i++;
            }
            return i;
        }
    }
    public class PassWordMatch
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string Letter { get; set; }
        public string ActualPassword { get; set; }
    }
}
