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
            //var day = "08Data";
            var day = "08Test";
            var data = Helpers.ReadLines(day);

            // create forest
            // X = value, Y = isVisible
            List<List<Point>> forest = new();
            //FIXA EN FAKKING PROPP TILL PÅ ÅPOINT ELLER NÅT
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

            var topScore = 0;
            for (var y= 0; y < forest.Count; y++)
            {
                for (var x = 0;  x < forest[y].Count; x++)
                {
                    var product = 1;
                    // pluttificera
                    // kolla upp 
                    product *= LookUpwards(y, x, forest);
                    // kolla höger
                    product *= LookRight(y, x, forest);
                    // kolla ner
                    product *= LookDownwards(y, x, forest);
                    // kolla vänster  
                    product *= LookLeft(y, x, forest);

                    if (product > topScore)
                    {
                        topScore = product;
                    }
                }
            }

            Console.WriteLine("top score :" + topScore);

            #region part 1
            /*
            // kolla synlighet
            // vänster till höger
            for (var y = 0; y < forest.Count; y++)
            {
                var top = forest[y][0].X;
                for (var x = 0; x < forest[y].Count; x++)
                {
                    if (forest[y][x].Y == 1)
                    {
                        if (forest[y][x].X > top)
                        {
                            top = forest[y][x].X;
                        }
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }
            }
            //PrintForest(forest);

            // höger till vänster
            for (var y = 0; y < forest.Count; y++)
            { 
                var top = forest[y][forest[y].Count - 1].X;
                for (var x = forest[y].Count - 1; x >= 0; x--)
                {
                    if (forest[y][x].Y == 1)
                    {
                        if (forest[y][x].X > top)
                        {
                            top = forest[y][x].X;
                        }
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }
            }
            //PrintForest(forest);

            // uppifrån och ned
            for (var x = 0; x < forest[0].Count; x++)
            {
                var top = forest[0][x].X;
                for (var y = 0; y < forest.Count; y++)
                {
                    if (forest[y][x].Y == 1)
                    {
                        if (forest[y][x].X > top)
                        {
                            top = forest[y][x].X;
                        }
                    }
                    else if (forest[y][x].X > top)
                    {
                        top = forest[y][x].X;
                        forest[y][x].Y = 1;
                    }
                }
            }
            //PrintForest(forest);

            // nerifrån och upp
            for (var x = 0; x < forest[0].Count; x++)
            {
                var top = forest[forest.Count - 1][x].X;
                for (var y = forest.Count -1; y >= 0; y--)
                {
                    if (forest[y][x].Y == 1)
                    {
                        if (forest[y][x].X > top)
                        {
                            top = forest[y][x].X;
                        }
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
                    Console.Write(tree.Y);
                    if (tree.Y == 1)
                    {
                        treecounter++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(treecounter);
            */
            #endregion
        }

        private static int LookLeft(int y, int x, List<List<Point>> forest)
        {
            if (x == 0)
            {
                return 1;
            }
            var count = 0;
            var height = forest[y][x].X;
            for (var X = x; X > 0; X--)
            {
                if (forest[y][X - 1].X >= height)
                {
                    count++;
                    return count;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        private static int LookDownwards(int y, int x, List<List<Point>> forest)
        {
            if (y == forest.Count - 1)
            {
                return 1;
            }
            var count = 0;
            var height = forest[y][x].X;
            for (var Y = y; Y < forest.Count - 1; Y++ )
            {
                if (forest[Y + 1][x].X >= height)
                {
                    count++;
                    return count;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        private static int LookRight(int y, int x, List<List<Point>> forest)
        {
            if (x == forest[y].Count - 1)
            {
                return 1;
            }
            var count = 0;
            var treeHeight = forest[y][x].X;
            var previousTree = 0; 
            for (var X = x; X < forest[y].Count - 1; X++)
            {
                if (forest[y][X + 1].X >= treeHeight)
                {
                    count++;
                    return count;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        private static int LookUpwards(int y, int x, List<List<Point>> forest)
        {
            if (y == 0)
            {
                return 1;
            }
            var count = 0;
            var height = forest[y][x].X;
            for (var Y = y; Y > 0; Y--)
            {
                if (forest[Y - 1][x].X >= height)
                {
                    count++;
                    return count;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        private static void PrintForest(List<List<Point>> forest)
        {
            foreach (var line in forest)
            {
                foreach (var tree in line)
                {
                    Console.Write(tree.Y);
                }
                Console.WriteLine();
            }

            foreach (var line in forest)
            {
                foreach (var tree in line)
                {
                    Console.Write(tree.X);
                }
                Console.WriteLine();
            }
        }
    }
}
