using UnityEngine;

namespace Game
{
    public class AudioSaveLoad : ILoaderSaver //Interactua con PlayerPrefs
    {
        const string musicKey = "musicVolume";
        const string sfxKey = "sxfVolume";

        public void GetVolume(out float musicVolume, out float sfxVolume)
        {
            if (PlayerPrefs.HasKey(musicKey))
            {
                musicVolume = PlayerPrefs.GetFloat(musicKey);
                sfxVolume = PlayerPrefs.GetFloat(sfxKey);
            }
            else
            {
                musicVolume = .5f;
                sfxVolume = .5f;
            }
        }

        public void SetVolume(float musicVolume, float sfxVolume)
        {
            PlayerPrefs.SetFloat(musicKey, musicVolume);
            PlayerPrefs.SetFloat(sfxKey, sfxVolume);
        }
    }
}


