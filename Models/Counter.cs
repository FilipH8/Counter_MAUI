using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektv2.Models
{
    public class Counter
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public Counter()
        {
            Name = "";
            Count = 0;
        }
        public Counter(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}
