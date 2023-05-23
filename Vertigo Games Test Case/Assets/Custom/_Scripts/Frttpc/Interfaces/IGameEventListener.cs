namespace Frttpc.Interfaces
{
    public interface IGameEventListener
    {
        public void RaiseEvent();
    }

    public interface IGameEventListenerGeneric<T>
    {
        public void RaiseEvent(T param);
    }
}