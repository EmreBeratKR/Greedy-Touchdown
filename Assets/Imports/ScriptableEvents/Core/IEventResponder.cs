namespace ScriptableEvents.Core
{
    public interface IEventResponder
    {
        void Respond();
    }

    public interface IEventResponder<in T>
    {
        void Respond(T data);
    }
}