using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace AdventOfCode22
{
    public class Day02
    {
        public static void Run()
        {
            //var day = "02Test";
            var day = "02Data";
            var data = Helpers.ReadLines(day);
            List<Pair> rounds = new();
            foreach (var line in data)
            {
                var sLine = line.Split(' ');
                var r = new Pair
                {
                    First = sLine[0],
                    Second = sLine[1]
                };
                rounds.Add(r);
            }

            var score = 0;

            foreach (var round in rounds)
            {
                score += PlayRound(round);
            }

           Console.WriteLine(score);
        }

        private static int PlayRound(Pair round)
        {
            if (round.First.Equals("A"))
            {
                if (round.Second.Equals("X"))
                {
                    return 0 + 3;
                }
                else if (round.Second.Equals("Y"))
                {
                    return 3 + 1;
                }
                else
                {
                    return 6 + 2;
                }
            }
            else if (round.First.Equals("B")) 
            {
                if (round.Second.Equals("X"))
                {
                    return 0 + 1;
                }
                else if (round.Second.Equals("Y"))
                {
                    return 3 + 2;
                }
                else
                {
                    return 6 + 3;
                }
            }
            else
            {
                if (round.Second.Equals("X"))
                {
                    return 0 + 2;
                }
                else if (round.Second.Equals("Y"))
                {
                    return 3 + 3;
                }
                else
                {
                    return 6 + 1;
                }
            }
        }
    }
}
