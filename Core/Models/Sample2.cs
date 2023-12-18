using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Sample2
    {

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Item> Items { get; set; } = Enumerable.Empty<Item>();

        public class Item
        {
            /// <summary>
            /// Circular dependencies are commonplace
            /// </summary>
            public Sample2 Sample { get; set; }
            public string Contents { get; set; } = string.Empty;

            public Item(Sample2 sample) 
            { 
                Sample = sample; 
            }
        }
    }
}
