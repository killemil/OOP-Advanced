using _02.Blobs.Entities;

namespace _02.Blobs.Interfaces
{
    public interface IBehavior
    {
        bool IsTriggered { get; }

        void Trigger(Blob source);

        void ApplyPostTriggerEffect(Blob source);
    }
}