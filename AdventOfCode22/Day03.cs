using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day03
    {
        public static void Run()
        {
            //var day = "03Test";
            var day = "03Data";
            var data = Helpers.ReadLines(day);

            List<Triple> triples = new();
            for (int i = 0; i < data.Length; i += 3)
            {
                var t = new Triple
                {
                    First = data[i],
                    Second = data[i + 1],
                    Third = data[i + 2]
                };
                triples.Add(t);
            }

            List<char> uniques = new();
            foreach (var triple in triples)
            {
                char c = FindUniqueChar(triple);
                uniques.Add(c);
            }

            var sum = 0.0;
            foreach (var unique in uniques)
            {
                sum += SetValue(unique);
            }


            #region part 1
            //List<char> doubles= new();
            //foreach (var line in data)
            //{
            //    var length = (line.Length / 2);
            //    var s1 = line.Substring(0, length);
            //    var s2 = line.Substring(length);
            //    foreach (var c in s1)
            //    {
            //        if (s2.Contains(c))
            //        {
            //            doubles.Add(c);
            //            break;
            //        }
            //    }
            //}

            //double sum = 0;
            //foreach (var c in doubles)
            //{
            //    sum += SetValue(c);
            //}
            #endregion

            Console.WriteLine(sum);
        }

        private static char FindUniqueChar(Triple triple)
        {
            List<char> chars = new();
            foreach (char c in triple.First)
            {
                if (triple.Second.Contains(c))
                {
                    if (!chars.Contains(c))
                    {
                        chars.Add(c);
                    }
                }
            }
            List<char> chars2 = new();
            foreach (char c in chars)
            {
                if (triple.Third.Contains(c))
                {
                    if(!chars2.Contains(c))
                    {
                        chars2.Add(c);
                    }
                }
            }
            return chars2[0];
        }

        private static double SetValue(char c)
        {
            double value = 0;
            if (char.IsUpper(c))
            {
                value = 26;
            } 

            switch (char.ToLower(c))
            {
                case 'a': 
                    value += 1;
                    break;
                case 'b':
                    value += 2; 
                    break;
                case 'c':
                    value += 3;
                    break;
                case 'd':
                    value += 4;
                    break;
                case 'e':
                    value += 5;
                    break;
                case 'f':
                    value += 6;
                    break;
                case 'g':
                    value += 7;
                    break;
                case 'h':
                    value += 8;
                    break;
                case 'i':
                    value += 9;
                    break;
                case 'j':
                    value += 10;
                    break;
                case 'k':
                    value += 11;
                    break;
                case 'l':
                    value += 12;
                    break;
                case 'm':
                    value += 13;
                    break;
                case 'n':
                    value += 14;
                    break;
                case 'o':
                    value += 15;
                    break;
                case 'p':
                    value += 16;
                    break;
                case 'q':
                    value += 17;
                    break;
                case 'r':
                    value += 18;
                    break;
                case 's':
                    value += 19;
                    break;
                case 't':
                    value += 20;
                    break;
                case 'u':
                    value += 21;
                    break;
                case 'v':
                    value += 22;
                    break;
                case 'w':
                    value += 23;
                    break;
                case 'x':
                    value += 24;
                    break;
                case 'y':
                    value += 25;
                    break;
                case 'z':
                    value += 26;
                    break;
            }
            return value;
        }
    }
}
