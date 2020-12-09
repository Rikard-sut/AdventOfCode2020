using System;
using System.Collections.Generic;
using Extensions;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\admin\source\repos\AdventOfCode2020\Day5\Data5.txt";
            var data = filepath.GetData();
            var seatIds = FindSeatIds(data);
            int highestId = FindHighestId(seatIds);
            int mySeatId = FindEmptySeatId(seatIds);
            Console.WriteLine(highestId);
            Console.WriteLine(mySeatId);
            Console.ReadKey();
        }

        public static List<int> FindSeatIds(List<object> seatcodes)
        {
            List<int> seatIds = new List<int>();
            int[] rows;
            int[] seats;

            foreach (string seatCode in seatcodes)
            {
                rows = GetRows();
                seats = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
                foreach (char letter in seatCode)
                {

                    int possibleMaxRow;
                    int possibleMinRow;

                    if (letter == 'F' || letter == 'f')
                    {
                        possibleMinRow = rows[0];
                        possibleMaxRow = rows[rows.Length / 2 - 1];
                        rows = CopyValues(possibleMinRow, possibleMaxRow, rows);
                    }

                    if (letter == 'B' || letter == 'b')
                    {
                        possibleMinRow = rows[rows.Length / 2];
                        possibleMaxRow = rows[rows.Length - 1];
                        rows = CopyValues(possibleMinRow, possibleMaxRow, rows);
                    }

                    int possibleMaxSeat;
                    int possibleMinSeat;

                    if (letter == 'L' || letter == 'l')
                    {
                        possibleMinSeat = seats[0];
                        possibleMaxSeat = seats[seats.Length / 2 -1];
                        seats = CopyValues(possibleMinSeat, possibleMaxSeat, seats);
                    }

                    if (letter == 'R' || letter == 'r')
                    {
                        possibleMinSeat = seats[seats.Length / 2];
                        possibleMaxSeat = seats[seats.Length - 1];
                        seats = CopyValues(possibleMinSeat, possibleMaxSeat, seats);
                    }
                }

                int seatid = rows[0] * 8 + seats[0];
                seatIds.Add(seatid);
            }
            return seatIds;
        }

        public static int[] GetRows()
        {
            int[] rows = new int[128];
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = i;
            }
            return rows;
        }

        public static int[] CopyValues(int min, int max, int[] arrayToCopy)
        {
            var list = new List<int>();

            for (int i = 0; i < arrayToCopy.Length; i++)
            {
                if (arrayToCopy[i] >= min && arrayToCopy[i] <= max)
                {
                    list.Add(arrayToCopy[i]);
                }
            }

            return list.ToArray();
        }

        public static int FindHighestId(List<int> seatIds)
        {
            int highestid = 0;
            int currentId;
            foreach (int id in seatIds)
            {
                currentId = id;
                if (highestid < currentId)
                    highestid = currentId;
            }
            return highestid;
        }

        public static int FindEmptySeatId(List<int> seatIds)
        {
            seatIds.Sort();
            for (int i = 0; i < seatIds.Count; i++)
            {
                if (seatIds[i] + 1 != seatIds[i + 1])
                    return seatIds[i + 1] - 1;
            }
            return 0;
        }
    }
}
