using _02.Blobs.Interfaces;

namespace _02.Blobs.Entities.Behaviors
{
    public abstract class Behavior : IBehavior
    {
        protected Behavior()
        {
            this.IsTriggered = false;
        }

        public bool IsTriggered { get; set; }

        public abstract void Trigger(Blob source);

        protected abstract void ApplyTriggerEffect(Blob source);

        public abstract void ApplyPostTriggerEffect(Blob source);
    }
}