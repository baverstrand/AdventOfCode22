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
                    if (y == 0 || y == data.Length - 1)
                    {
                        tree.Y = 1;
                    }
                    else if (x == 0 || x == data[y].Length - 1)
                    {
                        tree.Y = 1;
                    }
                    trees.Add(tree);
                }
                forest.Add(trees);
            }
            
            // kolla synlighet
            for (var y = 0; y < forest.Count; y++)
            {
                // vänster till höger
                var top = forest[y][0].X;
                for (var x = 0; x < forest[y].Count; x++)
                {
                    if (forest[y][x].Y == 1)
                    {
                        continue;
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }
                // höger till vänster
                top = forest[y][forest[y].Count - 1].X;
                for (var x = forest[y].Count - 1; x >= 0; x--)
                {
                    if (forest[y][x].Y == 1)
                    {
                        continue;
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }
            }

            for (var x = 0; x < forest[0].Count; x++)
            {
                // uppifrån och ned
                var top = forest[0][x].X;
                for (var y = 0; y < forest.Count; y++)
                {
                    if (forest[y][x].Y == 1)
                    {
                        continue;
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }

                // nerifrån och upp
                top = forest[forest[0].Count - 1][x].X;
                for (var y = forest.Count -1; y >= 0; y--)
                {
                    if (forest[y][x].Y == 1)
                    {
                        continue;
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }
            }

            // count visibles
            var treecounter = 0.0;
            foreach (var line in forest)
            {
                foreach (var tree in line)
                {
                    if (tree.Y == 1)
                    {
                        treecounter++;
                    }
                }
            }
            Console.WriteLine(treecounter);
        }
    }
}
