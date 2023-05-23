using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Frttpc.Mono
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float magnitude;
        [SerializeField] private float duration;

        private Transform camTransform;

        public static CameraShake Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            camTransform = transform;
        }

        public void Shake()
        {
            transform.DOShakePosition(duration, magnitude);
            transform.DOShakeRotation(duration, magnitude);

            transform.Translate(camTransform.position);
        }
    }
}
