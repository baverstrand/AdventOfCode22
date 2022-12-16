using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Models
{
    public class D07Directory
    {
        public string Name { get; set; }
        public List<string>? Pathway { get; set; }
        public int ParentId { get; set; }
        public bool IsCurrent { get; set; }
        public List<D07File>? Files { get; set; }
        public double Value { get; set; }
    }
}
