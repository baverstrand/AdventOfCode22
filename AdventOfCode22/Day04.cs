using AdventOfCode22.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day04
    {
        public static void Run()
        {
            //var day = "04Test";
            var day = "04Data";
            var data = Helpers.ReadLines(day);

            var counter = 0;
            foreach (var line in data)
            {
                counter += CountDoubleWork(line);
            }
            Console.WriteLine(counter);
        }
        
        private static int CountDoubleWork(string line)
        {
            var lines = line.Split(',');
            var line1 = NumbersInPair(lines[0]);
            var line2 = NumbersInPair(lines[1]);

            var isInLine = IsInLine(line1, line2);
            if (!isInLine)
            {
                isInLine = IsInLine(line2, line1);
            }

            if (isInLine) return 1;
            return 0;
        }

        private static bool IsInLine(List<int> line1, List<int> line2)
        {
            foreach (var n in line1)
            {
                if (line2.Contains(n))
                {
                    return true;
                }
            }
            return false;
        }

        private static List<int> NumbersInPair(string line)
        {
            var numbers = line.Split("-");
            var n1 = int.Parse(numbers[0]);
            var n2 = int.Parse(numbers[1]);
            List<int> numbersInLine = new();
            for (var i = n1; i <= n2; i++)
            {
                numbersInLine.Add(i);
            }
            return numbersInLine;
        }
    }
}
