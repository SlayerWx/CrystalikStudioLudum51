using UnityEngine;
using UnityEngine.Audio;

namespace Game
{
    public class AudioSettings : MonoBehaviour  //Interactua con los audioMixers
    {
        public AudioMixer audioMixer;
        public AudioMixer SFXMixer;

        private const string volumeKey = "Volume";

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat(volumeKey, Mathf.Log10(volume) * 20);
        }

        public void SetSFXVolume(float volume)
        {
            SFXMixer.SetFloat(volumeKey, Mathf.Log10(volume) * 20);
        }
    }
}


