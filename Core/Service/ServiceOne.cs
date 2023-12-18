using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IServiceOne
    {
        string DoThing();
    }

    public class ServiceOne
    {
        public string DoThing() 
        {
            var theThing = "Service One did the thing";
            Console.WriteLine(theThing);
            return theThing;
        }
    }
}
