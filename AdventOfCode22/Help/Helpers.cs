using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Help
{
    public class Helpers
    {
        public static string[] ReadLines(string day)
        {
            //var path = $@"C:\Users\sofie\source\repos\AdventOfCode22\AdventOfCode22\Input\{day}.txt";
            var path = $@"C:\Users\sofie.baverstrand\source\repos\AdventOfCode22\AdventOfCode22\Input\{day}.txt";
            var result = File.ReadAllLines(path);
            return result;
        }

        public static string ReadText(string day)
        {
            //var path = $@"C:\Users\sofie\source\repos\AdventOfCode22\AdventOfCode22\Input\{day}.txt";
            var path = $@"C:\Users\sofie.baverstrand\source\repos\AdventOfCode22\AdventOfCode22\Input\{day}.txt";
            var result = File.ReadAllText(path);
            return result;
        }
    }
}
