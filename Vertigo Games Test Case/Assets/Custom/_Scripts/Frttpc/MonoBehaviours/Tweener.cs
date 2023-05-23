using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Frttpc.Mono
{
    public class Tweener : MonoBehaviour
    {
        [SerializeField] private Waypoint[] waypoints;

        [SerializeField] private bool tweenOnStart;
        [SerializeField] private bool loop;

        private void Start()
        {
            if (tweenOnStart)
                Tween();
        }

        public void Tween()
        {
            Sequence sequence =  DOTween.Sequence();

            foreach (Waypoint waypoint in waypoints)
            {
                sequence.Append(transform.DOLocalMove(waypoint.target, waypoint.duration).SetRecyclable(true).SetEase(waypoint.ease).SetDelay(waypoint.delay));
            }

            sequence.OnComplete(() => { if(loop) Tween(); });
        }

        [System.Serializable]
        public struct Waypoint
        {
            public Vector3 target;
            public float duration;
            public Ease ease;
            public float delay;
        }
    }
}