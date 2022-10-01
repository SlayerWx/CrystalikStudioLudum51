using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SlidersBehaviours : MonoBehaviour  //Interactua con la UI
    {
        ILoaderSaver loaderSaver;

        [SerializeField] Slider musicSlider;
        [SerializeField] Slider sfxSlider;

        private void Awake()
        {
            loaderSaver = new AudioSaveLoad();
        }

        void Start()
        {
            float musicVolume;
            float sfxVolume;

            loaderSaver.GetVolume(out musicVolume, out sfxVolume);

            musicSlider.value = musicVolume;
            sfxSlider.value = sfxVolume;
        }

        public void SetSlidersValue()
        {
            loaderSaver.SetVolume(musicSlider.value, sfxSlider.value);
        }

        private void OnApplicationQuit()
        {
            SetSlidersValue();
        }
    }
}


