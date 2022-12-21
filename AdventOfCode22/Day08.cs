using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day08
    {
        public static void Run()
        {
           // var day = "08Data";
            var day = "08Test";
            var data = Helpers.ReadLines(day);

            // create forest
            // X = value, Y = isVisible
            List<List<Point>> forest = new();
            for (var y = 0; y < data.Length; y++)
            {
                List<Point> trees = new();
                for (var x = 0; x < data[y].Length; x++)
                {
                    var tree = new Point
                    {
                        X = int.Parse(data[y][x].ToString()),
                        Y = 0
                    };
                    trees.Add(tree);
                }
                forest.Add(trees);
            }

            for (var y = 0; y < forest.Count; y++)
            {
                var top = forest[y][0].X;
                // om y är noll eller sista alla X= 1, nästa rad
                // om x är noll eller sista X = 1
            }
        }
    }
}
