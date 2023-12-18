using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFeatureFlagService
    {
        bool IsEnabled(string flagName);

    }

    public class FeatureFlagService : IFeatureFlagService
    {
        public bool IsEnabled(string flagName)
        {
            // This is stubbed for testing purposes
            // You can choose what to do here later.
            return false;
        }
    }
}
