using Core.Models;
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

        [Test]
        [CustomMoqData]
        public void DoNotRelyOnRegisteredTypes(Sample3 sample)
        {
            var result = Enum.Parse<Sample3.DescriptionType>(sample.DescriptionTypes);
            
            Assert.That(result, Is.EqualTo(Sample3.DescriptionType.Complex));

            // Relying on something that doesn't exsit in the setup flow makes it more complicated to build tests
            // If you do choose to update the registered patterns, this will fail, but for reasons that might not
            // be easy to figure out (if it's more than a simple set)
        }

        [Test]
        [CustomMoqData]
        public void DoNotRelyOnRegisteredTypes_InsteadSetThem(Sample3 sample)
        {
            sample.DescriptionTypes = Sample3.DescriptionType.Complex.ToString();

            var result = Enum.Parse<Sample3.DescriptionType>(sample.DescriptionTypes);

            Assert.That(result, Is.EqualTo(Sample3.DescriptionType.Complex));

            // When you read this test, you immediately see that it's overriding the `sample` data
            // Be intentional about your data
        }

    }
}
