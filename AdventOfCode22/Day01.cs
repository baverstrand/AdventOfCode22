using AdventOfCode22.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day01
    {
        public static void Run01()
        {
            //var day = "01Test";
            var day = "01Data";
            var data = Helpers.ReadLines(day);

            List<int> caloriesPerElf = new();

            var calories = 0;
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] != "")
                {
                    calories += int.Parse(data[i]);

                    if (i == data.Length -1)
                    {
                        caloriesPerElf.Add(calories);
                    }
                }
                else
                {
                    caloriesPerElf.Add(calories);
                    calories = 0;
                }
            }
            var maxValue = caloriesPerElf.Max(x => x);
            var orderedCalories = caloriesPerElf.OrderByDescending(x => x).ToList();
            var top3Sum = orderedCalories[0] + orderedCalories[1] + orderedCalories[2];
            Console.WriteLine(top3Sum);
        }
    }
}
