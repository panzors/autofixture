using Core.Options;

namespace Core.Service
{

    public class HelloWorldService
    {
        private readonly IServiceOne _one;
        private readonly Connection _connection;

        public HelloWorldService(IServiceOne one, Connection connection)
        {
            _one = one;
            _connection = connection;
        }

        public string ExerciseOne()
        {
            return _one.DoThing();
        }
    }
}
