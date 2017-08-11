namespace _02.Blobs.Entities.Attacks.Factory
{
    using _02.Blobs.Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AttackFactory
    {
        private const string BehaviorNameSuffix = "Attack";

        public IAttack CreateAttack(string behaviorTypeStr)
        {
            string behaviorComplateName = behaviorTypeStr + BehaviorNameSuffix;
            Type behaviorType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(b => b.Name == behaviorComplateName);

            return (IAttack)Activator.CreateInstance(behaviorType);
        }
    }
}
