using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            // var day = "07Test";
            var day = "07Data";
            var data = Helpers.ReadLines(day);

            List<D07Directory> directories = new();

            // Read list
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
                    directories = HandleFile(directories, line);
                }
                else if (line.StartsWith("dir "))
                {
                    directories = HandleDir(directories, line);
                }
            }

            // Sum up sizes


            Console.ReadKey();
        }

        private static List<D07Directory> HandleDir(List<D07Directory> directories, string line)
        {
            var splitLines = line.Split(' ');
            var currentDirIndex = -1;
            var isInList = false;
            for (var i = 0; i < directories.Count; i++)
            {
                if (directories[i].Name == splitLines[1])
                {
                    isInList = true;
                }
                else if (directories[i].IsCurrent)
                {
                    currentDirIndex = i;
                }
            }
            if (!isInList)
            {
                var d = new D07Directory
                {
                    Name = splitLines[1],
                    Parent = directories[currentDirIndex].Name,
                    IsCurrent = false,
                };

                if (directories[currentDirIndex].ChildrenDirs != null &&
                !directories[currentDirIndex].ChildrenDirs.Contains(splitLines[1]))
                {
                    directories[currentDirIndex].ChildrenDirs.Add(splitLines[1]);
                }
                else if (directories[currentDirIndex].ChildrenDirs == null)
                {
                    List<string> l = new()
                    {
                        splitLines[1]
                    };
                    directories[currentDirIndex].ChildrenDirs = l;
                }
                directories.Add(d);
                
            }
            return directories;
        }

        private static List<D07Directory> HandleFile(List<D07Directory> directories, string line)
        {
            var splitLine = line.Split(' ');
            var fileSize = double.Parse(splitLine[0]);
            var fileName = splitLine[1];
            var currentDir = -1;
            
            for (var i = 0; i < directories.Count; i++)
            {
                if (directories[i].IsCurrent)
                {
                    currentDir = i;
                }
            }

            var f = new D07File
            {
                Name = fileName,
                Directory = directories[currentDir].Name,
                FileSize = fileSize
            };

            if (directories[currentDir].ChildrenFiles is not null &&
                !directories[currentDir].ChildrenFiles.Contains(f))
            {
                directories[currentDir].ChildrenFiles.Add(f);
                directories[currentDir].Value += f.FileSize;
            }
            else if (directories[currentDir].ChildrenFiles is null)
            {
                List<D07File> l = new() { f };
                directories[currentDir].ChildrenFiles = l;
                directories[currentDir].Value = f.FileSize;
            }

            return directories;
        }

        private static List<D07Directory> HandleCD(List<D07Directory> directories, string line)
        {
            var dir = line.Remove(0, 5);
            if (dir == "..")
            {
                // hittar parent name, sätter nuvarande till false   
                var parentName = "";
                foreach (var directory in directories)
                {
                    if (directory.IsCurrent)
                    {
                        directory.IsCurrent= false;
                        parentName= directory.Name;
                    }
                }
                // hittar parent i listan, sätter till true
                foreach (var directory in directories)
                {
                    if (directory.Name.Equals(parentName))
                    {
                        directory.IsCurrent= true;
                    }
                }
            }
            else if (directories.Count == 0)
            {
                var d = new D07Directory
                {
                    Name = dir,
                    IsCurrent = true,
                };
                directories.Add(d);
            }
            else // om dir pekar på en plats
            {
                foreach (var directory in directories)
                {
                    if (directory.Name == dir)
                    {
                        directory.IsCurrent = true;
                    }
                    else if (directory.IsCurrent)
                    {
                        directory.IsCurrent= false;
                    }
                }
            }
            return directories;
        }
    }
}
