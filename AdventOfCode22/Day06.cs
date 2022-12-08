using AdventOfCode22.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day06
    {
        public static void Run() 
        {
            // var day = "06Test";
            var day = "06Data";
            var data = Helpers.ReadText(day);
            var firstKeyEnd = 0;

            for (var i = 13; i < data.Length; i++)
            {
                var key = data.Substring(i - 13, 14);
                string cleanKey = new String(key.Distinct().ToArray());
                if (cleanKey.Length == key.Length)
                {
                    firstKeyEnd = i + 1;
                    break;
                }
            }
            Console.WriteLine(firstKeyEnd);
        }
    }
}
