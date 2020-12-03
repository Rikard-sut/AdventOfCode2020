using System;
using System.Collections.Generic;
using System.IO;

namespace Extensions
{
    public static class Extensions
    {
        public static List<object> GetData(this string filepath)
        {
            List<object> dataList = new List<object>();
            using (StreamReader file = new StreamReader(filepath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    dataList.Add(line);
                }
            }
            return dataList;
        }

        public static int[] ParseToIntArray(this List<object> dataList)
        {
            List<int> numbers = new List<int>();

            foreach(var item in dataList)
            {
                numbers.Add(Int32.Parse(item.ToString()));
            }
            return numbers.ToArray();
        }

        public static IEnumerable<string> ParseToStringList(this List<object> dataList)
        {
            List<string> strings = new List<string>();

            foreach (var item in dataList)
            {
                strings.Add(item.ToString());
            }
            return strings.ToArray();
        }
    }
}
