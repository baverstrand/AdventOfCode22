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
                    directories = HandleFile(directories, line);
                    
                }
                else if (line.StartsWith("dir "))
                {
                    // create directory
                    // set current as parent
                    // add this to children
                }
            }
            
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

            if (directories[currentDir].ChildrenFiles != null && 
                !directories[currentDir].ChildrenFiles.Contains(fileName))
            {
                directories[currentDir].ChildrenFiles.Add(fileName);
            }
            else if (directories[currentDir].ChildrenFiles == null)
            {
                List<string> l = new()
                { 
                    fileName
                };
                directories[currentDir].ChildrenFiles = l;
            }
         
            throw new NotImplementedException();
        }

        private static List<D07Directory> HandleCD(List<D07Directory> directories, string line)
        {
            var dir = line.Remove(0, 5);
            if (dir == "..")
            {
                var parentName = "";
                foreach (var directory in directories)
                {
                    if (directory.IsCurrent)
                    {
                        directory.IsCurrent= false;
                        parentName= directory.Name;
                    }
                }
                foreach (var directory in directories)
                {
                    if (directory.Name.Equals(parentName))
                    {
                        directory.IsCurrent= true;
                    }
                }
            }
            else 
            {
                int dirIndex = -1;
                int parentIndex = -1;
                for (var i = 0; i < directories.Count; i++)
                {
                    if (directories[i].Name == dir)
                    {
                        dirIndex = i;
                    }
                    if (directories[i].IsCurrent)
                    {
                        directories[i].IsCurrent= false;
                        parentIndex = i;
                    }
                }

                if (dirIndex < 0)
                {
                    var d = new D07Directory
                    {
                        Name = dir,
                        IsCurrent = true,
                        Parent = directories[parentIndex].Name
                    };

                    if (directories[parentIndex].ChildrenDirs != null && 
                        !directories[parentIndex].ChildrenDirs.Contains(dir))
                    {
                        directories[parentIndex].ChildrenDirs.Add(dir);
                    }
                    else if (directories[parentIndex].ChildrenDirs == null)
                    {
                        List<string> l = new()
                        {
                            dir
                        };
                        directories[parentIndex].ChildrenDirs = l;
                    }
                    directories.Add(d);
                }
                else
                {
                    directories[parentIndex].IsCurrent = false;
                    directories[dirIndex].IsCurrent = true;
                }
            }
            return directories;
        }
    }
}
