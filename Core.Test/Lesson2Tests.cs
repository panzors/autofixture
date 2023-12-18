using AutoFixture;
using AutoFixture.NUnit3;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test
{
    /// <summary>
    /// Using Fixtures to create auto generated properties
    /// </summary>
    public class Lesson2Tests
    {
        [Test]
        [AutoData]
        public void BasicFixtureTest(IFixture fixture)
        {
            var sample = fixture.Build<Sample1>()
                .With(x => x.Description, "Custom")
                .Create();
            Assert.That("Custom", Is.EqualTo(sample.Description));
            Assert.True(sample.Items.Count() > 0);
        }

        [Test]
        [AutoData]
        public void AutogDataAttribute(Sample1 injectedSample)
        {
            Assert.True(injectedSample.Items.Count() > 0);
        }

        /// <summary>
        /// Throws AutoFixture.ObjectCreationExceptionWithPath
        /// This throws an exception because it doesn't know how to navigate circular dependencies. Tests will fail
        /// </summary>
        /// <param name="brokenSample"></param>
        [Test]
        [AutoData]
        public void CircularDependencies_Break(Sample2 brokenSample) 
        {
            Assert.Fail();
        }

        [Test]
        [AutoData]
        public void AdditionalSupportedTypes(IEnumerable<Sample1> samples, List<Sample1> listSamples, Sample1[] arraySamples) 
        {
            CollectionAssert.IsNotEmpty(samples);
            CollectionAssert.IsNotEmpty(listSamples);
            CollectionAssert.IsNotEmpty(arraySamples);
        }

        //[Test] be sure not to add these to the header as well.
        //[TestCase] these will trigger additional tests
        [InlineAutoData("test")]
        public void InlineData(string thing, Sample1 sample)
        {
            Assert.IsNotNull(sample);
            Assert.That(thing, Is.EqualTo("test"));
        }
    }
}
