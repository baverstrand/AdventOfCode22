using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode22
{
    public class Day05
    {
        public static void Run()
        {
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

            var columnsCounter = 0;
            for (var i = 0; i < data[columnFinder].Length; i++)
            {
                if (char.IsDigit(data[columnFinder][i]))
                {
                    columnsCounter = int.Parse((data[columnFinder][i]).ToString());
                }
            }

            // Gör grid med packages
            List<List<char>> packageStack = new();
            for (var i = 0; i < columnFinder; i++)
            {
                List<char> packageRow= new();
                for (var j = 1; j < columnsCounter * 4; j += 4)
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
            
            // Gör moves
            for (var i = 0; i < moves.Count; i++)
            {
                packageStack = MakeMove(moves[i], packageStack);
            }

            // Kolla bokstäver i raden
            PrintGrid(packageStack);
        }
        #region part 2

        private static List<List<char>> MakeMove(Triple triple, List<List<char>> packageStack)
        {
            var toIndex = FindToIndex(triple, packageStack);
            var boxesToMove = GetBoxString(triple, packageStack);
            if (toIndex.Y - boxesToMove.Length < 0)
            {
                var rowsToAdd = 0 - (toIndex.Y - (boxesToMove.Length - 1));
                packageStack = AddRows(rowsToAdd, packageStack);
                toIndex = FindToIndex(triple, packageStack);
            }

            for (var i = 0; i < boxesToMove.Length; i++)
            {
                var fromIndex = FindFromIndex(triple, packageStack);
                toIndex = FindToIndex(triple, packageStack);
                packageStack[fromIndex.Y][fromIndex.X] = 'x';
                packageStack[toIndex.Y][toIndex.X] = boxesToMove[i];
            }

            return packageStack;
        }

        private static string GetBoxString(Triple triple, List<List<char>> packageStack)
        {
            var boxesToMove = "";
            var boxAmount = int.Parse(triple.First);
            var fromIndex = FindFromIndex(triple, packageStack);
            for (var i = fromIndex.Y; i < fromIndex.Y + boxAmount; i++)
            {
                boxesToMove = packageStack[i][fromIndex.X] + boxesToMove;
            }

            return boxesToMove;
        }
        #endregion

        #region part 1
        //private static List<List<char>> MakeMove(Triple triple, List<List<char>> packageStack)
        //{
        //    var toIndex = FindToIndex(triple, packageStack);

        //    var boxesToMove = int.Parse(triple.First);
        //    if (toIndex.Y - boxesToMove < 0)
        //    {
        //        var rowsToAdd = 0 - (toIndex.Y - (boxesToMove - 1));
        //        packageStack = AddRows(rowsToAdd, packageStack);
        //        toIndex = FindToIndex(triple, packageStack);
        //    }

        //    for (var i = 0; i < boxesToMove; i++)
        //    {
        //        var fromIndex = FindFromIndex(triple, packageStack);
        //        toIndex = FindToIndex(triple, packageStack);
        //        var letter = packageStack[fromIndex.Y][fromIndex.X];
        //        packageStack[fromIndex.Y][fromIndex.X] = 'x';
        //        packageStack[toIndex.Y][toIndex.X] = letter;
        //    }

        //    return packageStack;
        //}
        #endregion
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
            List<List<char>> nps = new();
            for (var i = 0; i < rowsToAdd; i++)
            {
                var row = new List<char>();
                for (var j = 0; j < packageStack[0].Count; j++)
                {
                    row.Add('x');
                }
                nps.Add(row);
            }

            foreach (var line in packageStack)
            {
                nps.Add(line);
            }
            return nps;
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
