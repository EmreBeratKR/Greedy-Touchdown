namespace ScriptableEvents.Core
{
    public interface IEventRaiser
    {
        void RaiseEvent();
    }
    
    public interface IEventRaiser<in T>
    {
        void RaiseEvent(T data);
    }
}