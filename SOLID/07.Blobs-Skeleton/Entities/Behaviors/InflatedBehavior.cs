using System;

namespace _02.Blobs.Entities.Behaviors
{
    public class InflatedBehavior : Behavior
    {
        private const int InflatedHealthAddition = 50;
        private const int InflatedHealthDecrementer = 10;

        public override void ApplyPostTriggerEffect(Blob source)
        {
            source.Health -= InflatedHealthDecrementer;
        }

        public override void Trigger(Blob source)
        {
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        protected override void ApplyTriggerEffect(Blob source)
        {
            source.Health += InflatedHealthAddition;
        }
    }
}
