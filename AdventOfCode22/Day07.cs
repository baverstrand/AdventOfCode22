using AdventOfCode22.Help;
using AdventOfCode22.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Rad 170


namespace AdventOfCode22
{
    public class Day07
    {
        public static void Run()
        {
            //var day = "07Test";
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
            var totalSumOfDisposables = 0.0;
            foreach (var dir in directories)
            {
                if (dir.Value <= 100000.0)
                {
                    totalSumOfDisposables += dir.Value;
                }
            }
            Console.WriteLine(totalSumOfDisposables);
        }

        private static List<D07Directory> HandleDir(List<D07Directory> directories, string line)
        {
            int currentDirIndex = FindCurrentDirectory(directories);
            var splitLines = line.Split(' ');
            var name = splitLines[1];
            var isInList = false;

            foreach (var dir in directories)
            {
                if (dir.Name == name && dir.ParentId == currentDirIndex)
                {
                    isInList = true;
                }
            }

            if (!isInList)
            {
                List<string> nPath = CreateNewPath(directories[currentDirIndex]);
                List<D07File> files = new();
                var d = new D07Directory
                {
                    Name = splitLines[1],
                    Pathway = nPath,
                    ParentId = currentDirIndex,
                    IsCurrent = false,
                    Files= files,
                    Value = 0
                };
                directories.Add(d);
            }
            return directories;
        }
        
        private static List<D07Directory> HandleFile(List<D07Directory> directories, string line)
        {
            // Hämta info
            var splitLine = line.Split(' ');
            var fileSize = double.Parse(splitLine[0]);
            var fileName = splitLine[1];
            var currentDir = FindCurrentDirectory(directories);
            
            var f = new D07File
            {
                Name = fileName,
                Directory = directories[currentDir].Name,
                FileSize = fileSize
            };

            // LÄgg till som child
            if (!directories[currentDir].Files.Contains(f))
            {
                directories[currentDir].Files.Add(f);
            }

            // Uppdatera value uppåt
            directories = UpdateValue(directories, f);

            return directories;
        }

        private static List<D07Directory> UpdateValue(List<D07Directory> directories, D07File f)
        {
            var currentDir = FindCurrentDirectory(directories);
            directories[currentDir].Value += f.FileSize;
            var parentId = directories[currentDir].ParentId;
            
            while (parentId >= 0)
            {
                directories[parentId].Value += f.FileSize;
                parentId = directories[parentId].ParentId;
            }

            return directories;
        }

        private static List<D07Directory> HandleCD(List<D07Directory> directories, string line)
        {
            var dir = line.Remove(0, 5);
            var currentIndex = FindCurrentDirectory(directories);
            if (dir == "..")
            {
                // hittar parent name, sätter nuvarande till false och nya till true   
                directories[currentIndex].IsCurrent = false;
                directories[directories[currentIndex].ParentId].IsCurrent = true;
            }
            else if (directories.Count == 0)
            {
                List<string> l = new();
                var d = new D07Directory
                {
                    Name = dir,
                    IsCurrent = true,
                    Pathway = l,
                    ParentId = -1
                };
                directories.Add(d);
            }
            else // om cd pekar på en plats
            {
                directories[currentIndex].IsCurrent = false;

                // hitta dir mha dess path + name
                foreach (var directory in directories)
                {
                    if (directory.Name == dir && directory.ParentId == currentIndex)
                    {
                        directory.IsCurrent = true;
                    }
                }
            }
            return directories;
        }
        
        private static int FindCurrentDirectory(List<D07Directory> directories)
        {
            for (var i = 0; i < directories.Count; i++)
            {
                if (directories[i].IsCurrent)
                {
                    return i;
                }
            }
            return -1;
        }

        private static List<string> CreateNewPath(D07Directory dir)
        {
            List<string> nPath = new();
            foreach (var n in dir.Pathway)
            {
                nPath.Add(n);
            }
            nPath.Add(dir.Name);
            return nPath;
        }
    }
}
