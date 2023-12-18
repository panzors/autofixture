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
        public void Test(IFixture fixture)
        {
            var sample = fixture.Build<Sample1>()
                .With(x => x.Description, "Custom")
                .Create();
            Assert.That("Custom", Is.EqualTo(sample.Description));
            Assert.True(sample.Items.Count() > 0);
        }

        [Test]
        [AutoData]
        public void Test(Sample1 injectedSample)
        {
            Assert.True(injectedSample.Items.Count() > 0);
        }

        /// <summary>
        /// Throws AutoFixture.ObjectCreationExceptionWithPath
        /// </summary>
        /// <param name="brokenSample"></param>
        [Test]
        [AutoData]
        public void CircularDependencies_Break(Sample2 brokenSample) 
        {
            // This throws an exception because it doesn't know how to navigate circular dependencies. Tests will fail
            Assert.Fail();
        }
    }
}
