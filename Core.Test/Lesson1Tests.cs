using Core.Options;
using Core.Service;
using Moq;

namespace Core.Test
{

    /// <summary>
    /// Your standard pattern with Mocking framework
    /// </summary>
    public class Lesson1Tests
    {
        [Test]
        public void A_Familiar_Pattern()
        {
            // Setup your mocks
            var oneMock = new Mock<IServiceOne>();
            var connection = new Mock<Connection>();
            oneMock.Setup(x => x.DoThing()).Returns("a simple result");

            // Initalise the class under load
            var helloWorld = new HelloWorldService(oneMock.Object, connection.Object);
            
            // Action
            var result = helloWorld.ExerciseOne();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [TestCase("Input")]
        public void Test_WithParameters(string input)
        {
            // Setup your mocks
            var oneMock = new Mock<IServiceOne>();
            var connection = new Mock<Connection>();

            // Set with input parameter
            oneMock.Setup(x => x.DoThing()).Returns(input);

            // Initalise the class under load
            var helloWorld = new HelloWorldService(oneMock.Object, connection.Object);

            // Action
            var result = helloWorld.ExerciseOne();

            // Assert
            Assert.That(input, Is.EqualTo("Input"));
        }
    }

    /// <summary>
    /// Slight altenrative to above with a setup step.
    /// </summary>
    public class Lesson1VariationTests 
    {
        private Mock<IServiceOne> _oneMock;
        private HelloWorldService _helloWorld;

        [SetUp] 
        public void SetUp() 
        {
            _oneMock = new ();
            var connection = new Connection();

            _oneMock.Setup(x => x.DoThing()).Returns("Hello world");

            _helloWorld = new HelloWorldService(_oneMock.Object, connection);
        }

        [Test]
        public void Test()
        {
            // Action
            var result = _helloWorld.ExerciseOne();

            // Assert
            Assert.That(result, Is.EqualTo("Hello world"));
        }
    }
}
