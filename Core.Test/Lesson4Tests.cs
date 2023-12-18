using Core.Service;
using Core.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test
{
    public class Lesson4Tests
    {
        [Test]
        [CustomMoqData("test", true)]
        public void WithFlagStateTrue_ReturnsNewRoute(PreconfiguredService service)
        {
            var result = service.DoThing();
            Assert.That(result, Is.EqualTo("New route"));
        }

        [Test]
        [CustomMoqData()]
        public void WithDefaultFlagState_ReturnsOldRoute(PreconfiguredService service)
        {
            var result = service.DoThing();
            Assert.That(result, Is.EqualTo("Old route"));
        }
    }
}
