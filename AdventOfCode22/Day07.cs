using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            // Fill list
            foreach (var line in data)
            {
                if (line.StartsWith("$ cd"))
                {
                    directories = HandleCD(directories, line);
                }
                else if (line.StartsWith("$ ls"))
                {
                    continue;
                }
                else if (char.IsDigit(line[0])) 
                {
                    // create file
                    // set current as parent
                    // add file to current directory
                    // split on ' '
                    // set filesize to split[0] double parse
                }
                else if (char.IsLetter(line[0]))
                {
                    // create directory
                    // set current as parent
                    // add this to children
                }
            }
            
        }

        private static List<D07Directory> HandleCD(List<D07Directory> directories, string line)
        {
            var dir = line.Remove(0, 5);
            if (dir == "..")
            {
                // hitta current dir
                // sätt current till false
                // kolla parent
                // sätt parent till current
            }
            else 
            {
                // kolla om dir finns i listan
                // om ja, sätt current till false
                // sätt dir till true, 
                // om nej, skapa dir
                // sätt current som parent
                // sätt dir till true
            }
            return directories;
        }
    }
}
