namespace _02.Blobs.Entities.Behaviors
{
    public class AggressiveBehavior : Behavior
    {
        private static int AggressiveDamageMultiplier = 2;
        private static int AggressiveDamageDecrementer = 5;

        private int sourceInitialDamage;

        protected override void ApplyTriggerEffect(Blob source)
        {
            source.Damage *= AggressiveDamageMultiplier;
        }

        public override void Trigger(Blob source)
        {
            this.sourceInitialDamage = source.Damage;
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public override void ApplyPostTriggerEffect(Blob source)
        {
            source.Damage -= AggressiveDamageDecrementer;

            if (source.Damage <= this.sourceInitialDamage)
            {
                source.Damage = this.sourceInitialDamage;
            }
        }
    }
}