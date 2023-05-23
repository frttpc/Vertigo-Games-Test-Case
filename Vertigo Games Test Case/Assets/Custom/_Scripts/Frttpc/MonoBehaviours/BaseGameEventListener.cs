using Frttpc.Interfaces;
using Frttpc.SOs;
using UnityEngine;

namespace Frttpc.Mono
{
    public abstract class BaseGameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent GameEvent;

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnRegisterListener(this);
        }

        public abstract void RaiseEvent();
    }

    public abstract class BaseGameEventListenerGeneric<T, TGameEventGeneric> : MonoBehaviour, IGameEventListenerGeneric<T>
        where TGameEventGeneric : GameEventGeneric<T>
    {
        [SerializeField] private TGameEventGeneric GameEventGeneric;

        private void OnEnable()
        {
            GameEventGeneric.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEventGeneric.UnRegisterListener(this);
        }

        public abstract void RaiseEvent(T param);
    }
}
