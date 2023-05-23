using System.Collections.Generic;
using UnityEngine;
using Frttpc.Interfaces;

namespace Frttpc.SOs
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Scriptable Objects /Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> eventListeners = new();

        public void Raise()
        {
            foreach (IGameEventListener listener in eventListeners)
            {
                listener.RaiseEvent();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnRegisterListener(IGameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }

    [System.Serializable]
    public class GameEventGeneric<T> : ScriptableObject
    {
        private readonly List<IGameEventListenerGeneric<T>> eventListeners = new();

        public void Raise(T param)
        {
            foreach (IGameEventListenerGeneric<T> listener in eventListeners)
            {
                listener.RaiseEvent(param);
            }
        }

        public void RegisterListener(IGameEventListenerGeneric<T> listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnRegisterListener(IGameEventListenerGeneric<T> listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}