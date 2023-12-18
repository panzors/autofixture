namespace Core.Service
{
    public interface IPreconfiguredService
    {
        string DoThing();
    }

    public class PreconfiguredService : IPreconfiguredService
    {
        private readonly IFeatureFlagService _featureFlagService;

        public PreconfiguredService(IFeatureFlagService featureFlagService) 
        {
            _featureFlagService = featureFlagService;
        }

        public string DoThing()
        {
            if (_featureFlagService.IsEnabled("test"))
            {
                return "New route";
            }
            return "Old route";
        }
    }
}
