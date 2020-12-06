using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Extensions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\admin\source\repos\AdventOfCode2020\Day4\Day4.txt";
            var data = filePath.GetData();
            var passportList = GetPassPorts(data);
            var answer1 = FindCountOfValidPassports(passportList);
            var answer2 = FindCountOfValidPassportWithValidValues(passportList);
            Console.WriteLine(answer1);
            Console.WriteLine(answer2);
            Console.ReadKey();
        }

        public static List<PassPort> GetPassPorts(List<object> data)
        {
            List<PassPort> passportList = new List<PassPort>();
            var passport = new PassPort();
            foreach (string line in data)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    foreach (var pair in (string[])line.Split(' '))
                    {
                        string[] keyAndValue = pair.Split(':');
                        passport.KeyValuePairs.Add(keyAndValue[0], keyAndValue[1]);
                    }
                }
                else
                {
                    passportList.Add(passport);
                    passport = new PassPort();
                }
            }
            passportList.Add(passport); //To add the last passport coming in from data since there is no newline after the last.
            return passportList;
        }

        public static int FindCountOfValidPassportWithValidValues(List<PassPort> passports)
        {
            int validPassportCount = 0;
            foreach (var passport in passports)
            {
                if (passport.KeyValuePairs.ContainsKey("byr") && passport.KeyValuePairs.ContainsKey("iyr") &&
                    passport.KeyValuePairs.ContainsKey("eyr") && passport.KeyValuePairs.ContainsKey("hgt") &&
                    passport.KeyValuePairs.ContainsKey("hcl") && passport.KeyValuePairs.ContainsKey("ecl") &&
                    passport.KeyValuePairs.ContainsKey("pid"))
                {
                    var success = ValidateValues(passport.KeyValuePairs);
                    if (success)
                        validPassportCount++;
                }
            }
            return validPassportCount;
        }

        public static bool ValidateValues(Dictionary<string, string> keyValuePairs)
        {
            keyValuePairs.TryGetValue("byr", out string byr);
            bool byrValidation = false;
            if (byr.Length == 4 && int.Parse(byr) >= 1920 && int.Parse(byr) <= 2002)
                byrValidation = true;

            keyValuePairs.TryGetValue("iyr", out string iyr);
            bool iyrValidation = false;
            if (iyr.Length == 4 && int.Parse(iyr) >= 2010 && int.Parse(iyr) <= 2020)
                iyrValidation = true;

            keyValuePairs.TryGetValue("eyr", out string eyr);
            bool eyrValidation = false;
            if (eyr.Length == 4 && int.Parse(eyr) >= 2020 && int.Parse(eyr) <= 2030)
                eyrValidation = true;

            keyValuePairs.TryGetValue("hgt", out string hgt);
            bool hgtValidation = false;
            if (hgt.EndsWith("cm"))
            {
                hgt = hgt.Remove(hgt.Length - 2);
                if (int.Parse(hgt) >= 150 && int.Parse(hgt) <= 193)
                    hgtValidation = true;
            }

            if (hgt.EndsWith("in"))
            {
                hgt = hgt.Remove(hgt.Length - 2);
                if (int.Parse(hgt) >= 59 && int.Parse(hgt) <= 76)
                    hgtValidation = true;
            }

            keyValuePairs.TryGetValue("hcl", out string hcl);
            bool hclValidation = false;
            if (Regex.IsMatch(hcl, @"^\#[0-9a-f]{6}$"))
            {
                hclValidation = true;
            }

            keyValuePairs.TryGetValue("ecl", out string ecl);
            bool eclValidation = false;
            if (ecl == "amb" || ecl == "blu" || ecl == "brn" || ecl == "gry" || ecl == "grn" || ecl == "hzl" || ecl == "oth")
                eclValidation = true;

            keyValuePairs.TryGetValue("pid", out string pid);
            bool pidValidation = false;
            if (Regex.IsMatch(pid, @"^\d{9}$"))
                pidValidation = true;

            return byrValidation && iyrValidation && eyrValidation && hgtValidation && hclValidation && eclValidation && pidValidation;
        }

        public static int FindCountOfValidPassports(List<PassPort> passports)
        {
            // byr(Birth Year)
            //iyr(Issue Year)
            //eyr(Expiration Year)
            //hgt(Height)
            //hcl(Hair Color)
            //ecl(Eye Color)
            //pid(Passport ID) NOT REQUIRED

            int validPassportCount = 0;
            foreach (var passport in passports)
            {
                if (passport.KeyValuePairs.ContainsKey("byr") && passport.KeyValuePairs.ContainsKey("iyr") &&
                    passport.KeyValuePairs.ContainsKey("eyr") && passport.KeyValuePairs.ContainsKey("hgt") &&
                    passport.KeyValuePairs.ContainsKey("hcl") && passport.KeyValuePairs.ContainsKey("ecl") &&
                    passport.KeyValuePairs.ContainsKey("pid"))
                {
                    validPassportCount++;
                }
            }
            return validPassportCount;
        }
    }

    public class PassPort
    {
        public Dictionary<string, string> KeyValuePairs { get; set; }
        public PassPort()
        {
            KeyValuePairs = new Dictionary<string, string>();
        }
    }
}
