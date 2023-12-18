using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Sample1
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Item> Items { get; set; } = Enumerable.Empty<Item>();

        public record Item(int Id);
    }
}
