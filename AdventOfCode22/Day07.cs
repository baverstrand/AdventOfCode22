using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day07
    {
        public static void Run()
        {
            var day = "07Test";
            // var day = "07Data";
            var data = Helpers.ReadLines(day);

            List<D07Directory> directories = new();
            List<D07File> files = new();
            D07Directory currentDirectory = new ();

            // Fill list
            foreach (var line in data)
            {
                if (line.StartsWith("$ cd"))
                {
                    directories = HandleCD(currentDirectory, line);
                }
                else if (line.StartsWith("$ ls"))
                {
                    continue;
                }
                else if (char.IsDigit(line[0])) 
                {
                    // create file
                    // add file to current directory
                    // split on ' '
                }
                else if (char.IsLetter(line[0]))
                {
                    // create directory
                    // add to vurrent directory
                }
            }
            
        }

        private static List<D07Directory> HandleCD(D07Directory currentDirectory, string line)
        {
            throw new NotImplementedException();
        }
    }
}
