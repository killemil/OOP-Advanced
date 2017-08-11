using _02.Blobs.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _02.Blobs.Entities.Behaviors.Factory
{
    public class BehaviorFactory
    {
        private const string BehaviorNameSuffix = "Behavior";

        public IBehavior CreateBehavior(string behaviorTypeStr)
        {
            string behaviorCompleteName = behaviorTypeStr + BehaviorNameSuffix;
            Type behaviorType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(b => b.Name == behaviorCompleteName);

            return (IBehavior)Activator.CreateInstance(behaviorType);
        }
    }
}
