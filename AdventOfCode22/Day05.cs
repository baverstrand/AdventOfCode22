using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode22
{
    public class Day05
    {
        public static void Run()
        {
            //TODO rad 13 i .txt får out of range-problem
            // 13 rows men shit nånting
            /*
             * Läs in alla rader
             * Först kolumner i forloop tills contains 1
             * sen hitta move
             * gör till triples
             * körkörkör
             */
            //var day = "05Test";
            var day = "05Data";
            var data = Helpers.ReadLines(day);

            var columnFinder = 0;
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i].Contains('1'))
                {
                    columnFinder = i;
                    break;
                }
            }

            // Gör grid med packages
            List<List<char>> packageStack = new();
            for (var i = 0; i < columnFinder; i++)
            {
                List<char> packageRow= new();
                for (var j = 1; j < data[0].Length; j += 4)
                {
                    if (char.IsWhiteSpace(data[i][j]))
                    {
                        packageRow.Add('x');
                    }
                    else
                    {
                        packageRow.Add(data[i][j]);
                    }
                }
                packageStack.Add(packageRow);
            }

            // Gör triples med moves
            List<Triple> moves = new();
            for (var i = columnFinder; i < data.Length; i++)
            {
                if (string.IsNullOrEmpty(data[i]) || char.IsWhiteSpace(data[i][0]))
                {
                    continue;
                }
                else
                {
                    var line = data[i].Split(' ');
                    var m = new Triple
                    {
                        First = line[1],
                        Second = line[3],
                        Third = line[5]
                    };
                    moves.Add(m);
                }
            }

            /*
             * Hitta från-index (faktisk -1), point
             * Hitta till-index (faktisk -1)
             * Kolla om rader räcker till (till-index - antal > 0?)
             * (Prepend rad(er))
             */

            for (var i = 0; i < moves.Count; i++)
            {
                packageStack = MakeMove(moves[i], packageStack);
            }
            Console.WriteLine("");
        }

        private static List<List<char>> MakeMove(Triple triple, List<List<char>> packageStack)
        {
            var toIndex = FindToIndex(triple, packageStack);

            var boxesToMove = int.Parse(triple.First);
            if (toIndex.Y - boxesToMove < 0)
            {
                var rowsToAdd = 0 - (toIndex.Y - (boxesToMove - 1));
                packageStack = AddRows(rowsToAdd, packageStack);
                toIndex = FindToIndex(triple, packageStack);
            }
            var fromIndex = FindFromIndex(triple, packageStack);

            for (var i = 0; i < boxesToMove; i++)
            {
                var letter = packageStack[fromIndex.Y][fromIndex.X];
                packageStack[fromIndex.Y][fromIndex.X] = 'x';
                packageStack[toIndex.Y][toIndex.X] = letter;
                fromIndex.Y++;
                toIndex.Y--;
            }
            PrintGrid(packageStack);

            return packageStack;
        }

        private static void PrintGrid(List<List<char>> packageStack)
        {
            foreach (var row in packageStack)
            {
                Console.WriteLine();
                foreach (var c in row)
                {
                    Console.Write(c.ToString() + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static List<List<char>> AddRows(int rowsToAdd, List<List<char>> packageStack)
        {
            var row = new List<char>();
            for (var i = 0; i < packageStack[0].Count; i++)
            {
                row.Add('x');
            }
            for (var i = 0; i < rowsToAdd; i++)
            {
                packageStack = packageStack.Prepend(row).ToList();
            }
            return packageStack;
        }

        private static Point FindFromIndex(Triple triple, List<List<char>> packageStack)
        {
            var column = int.Parse(triple.Second) - 1;
            for (var i = 0; i < packageStack.Count; i++)
            {
                if (packageStack[i][column] != 'x')
                {
                    return new Point
                    {
                        X = column,
                        Y = i
                    };
                }
            }
            return default;
        }

        private static Point FindToIndex(Triple triple, List<List<char>> packageStack)
        {
            var column = int.Parse(triple.Third) - 1;
            for (var i = 0; i < packageStack.Count; i++)
            {
                if (packageStack[i][column] != 'x')
                {
                    return new Point
                    {
                        X = column,
                        Y = i - 1
                    };
                }
                if (i == packageStack.Count - 1 && packageStack[i][column] == 'x')
                {
                    return new Point
                    { 
                        X = column, 
                        Y = i 
                    };
                }
            }
            return default;
        }
    }
}
