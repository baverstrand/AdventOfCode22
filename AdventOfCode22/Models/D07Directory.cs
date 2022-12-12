﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Models
{
    public class D07Directory
    {
        public string Name { get; set; }
        public string? Parent { get; set; }
        public List<string>? ChildrenDirs { get; set; }
        public List<string>? ChildrenFiles { get; set; }
    }
}
