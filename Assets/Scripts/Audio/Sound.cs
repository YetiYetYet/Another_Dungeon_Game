using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip audioClip;
        public AudioMixerGroup audioMixerGroup;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(0.1f, 3f)] public float pitch = 1f;
        public bool loop;
        [HideInInspector] public AudioSource source;
    }
}