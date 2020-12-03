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

            var testdata = new PassWordMatch
            {
                ActualPassword = "baabaa",
                Letter = 'a',
                MinLength = 1,
                MaxLength = 5
            };
            var testlist = new List<PassWordMatch>() { testdata };

            var testresult = FindValidPassWordCoundPtTwo(testlist);

            var numberOfValidPasswordsPtTwo = FindValidPassWordCoundPtTwo(passwordsWithRules);

            Console.WriteLine(numberOfValidPasswords);
            Console.WriteLine(numberOfValidPasswordsPtTwo);
            Console.WriteLine(testresult);
            Console.ReadKey();
        }

        public static List<PassWordMatch> GetPasswordObjects(IEnumerable<string> dataList)
        {
            List<PassWordMatch> passwordsAndRules = new List<PassWordMatch>();
            foreach (string item in dataList)
            {
                var passwordMatch = new PassWordMatch();

                string[] ruleAndPw = item.Split(':');
                passwordMatch.ActualPassword = ruleAndPw[1];

                string passwordRules = ruleAndPw[0];

                string[] ruleAndLetter = passwordRules.Split(' ');
                passwordMatch.Letter = char.Parse(ruleAndLetter[1]);

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
            foreach (var password in passwords)
            {
                var countOfLetter = password.ActualPassword.Count(x => x == password.Letter);

                if (countOfLetter >= password.MinLength && countOfLetter <= password.MaxLength)
                    i++;
            }
            return i;
        }

        public static int FindValidPassWordCoundPtTwo(IEnumerable<PassWordMatch> passwords)
        {
            int i = 0;
            foreach (var password in passwords)
            {
                string trimmedPw = password.ActualPassword.Trim();
                char[] pwAsArray = trimmedPw.ToCharArray();

                var firstActualLetter = pwAsArray[password.MinLength - 1];
                var secondActualLetter = pwAsArray[password.MaxLength - 1];

                if ((firstActualLetter == password.Letter && secondActualLetter != password.Letter)
                    || (secondActualLetter == password.Letter && firstActualLetter != password.Letter))
                {
                    i++;
                }
            }
            return i;
        }
    }

    public class PassWordMatch
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char Letter { get; set; }
        public string ActualPassword { get; set; }
    }
}
