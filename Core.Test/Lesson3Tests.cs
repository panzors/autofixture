using AutoFixture.NUnit3;
using Core.Models;
using Core.Service;
using Core.Test.Fixtures;
using Moq;

namespace Core.Test
{
    /// <summary>
    /// Using custom builder patterns
    /// </summary>
    public class Lesson3Tests
    {
        [Test]
        [CustomMoqData]
        public void Test(Sample2 sample, Sample2.Item item)
        {
            // Check the patterns registered in CustomMoqDataAttribute
            Assert.That(sample.Items.Count(), Is.EqualTo(0));

            // This will now work because when Sample2 is generated it's emptied out.
            Assert.That(item.Sample.Items.Count(), Is.EqualTo(0));
        }

        [Test]
        [CustomMoqData]
        public void WithDefaultInjectedServices(HelloWorldService service)
        {
            var result = service.ExerciseOne();

            // All dependencies are Moqed and return null
            Assert.IsNull(result);
        }

        [Test]
        [CustomMoqData]
        public void IncorrectUsage_WithoutFrozenAttribute(HelloWorldService service, Mock<IServiceOne> mockedService)
        {
            mockedService.Setup(x => x.DoThing()).Returns("It works");

            var result = service.ExerciseOne();

            // You might think this uses a shared instance but it does not.
            Assert.IsNull(result);
        }

        [Test]
        [CustomMoqData]
        public void IncorrectUsage_WithInjectedFrozen_IncorrectOrdering_DoesNotWork(
            HelloWorldService service,
            [Frozen] Mock<IServiceOne> mockedService) // Creation order is important
        {
            mockedService.Setup(x => x.DoThing()).Returns("It works");

            var result = service.ExerciseOne();
            
            Assert.IsNull(result);
        }

        [Test]
        [CustomMoqData]
        public void CorrectUsage_WithOrderedFrozenInjectedServices_UsesSharedMockInstance(
            [Frozen] Mock<IServiceOne> mockedService,
            HelloWorldService service)
        {
            mockedService.Setup(x => x.DoThing()).Returns("It works");

            var result = service.ExerciseOne();

            Assert.That(result, Is.EqualTo("It works"));
        }

    }
}
