using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Sample3
    {
        public int WholeNumbers { get; set; }
        public string DescriptionTypes { get; set; }

        public enum DescriptionType
        {
            None,
            Basic,
            Complex,
        }
    }
}
