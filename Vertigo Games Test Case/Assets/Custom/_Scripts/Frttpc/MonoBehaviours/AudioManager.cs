using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frttpc.Mono
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private AudioSource musicPlayer;
        [SerializeField] private AudioSource soundPlayer;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayAtPosition(AudioClip clip, Vector3 pos)
        {
            soundPlayer.PlayOneShot(clip);
        }

        public void Play()
        {
            musicPlayer.Play();
        }
    }
}
