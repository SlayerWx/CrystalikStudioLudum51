using UnityEngine;

namespace Game
{
    public class InGamePause : MonoBehaviour
    {
        [SerializeField] GameObject inGamePause;
        [SerializeField] GameObject optionsMenu;
        [SerializeField] GameObject gamePanel;

        bool inPause = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!inPause)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
            inGamePause.SetActive(true);
            gamePanel.SetActive(false);
            inPause = true;
        }

        public void Resume()
        {
            Time.timeScale = 1;
            inGamePause.SetActive(false);
            optionsMenu.SetActive(false);
            gamePanel.SetActive(true);
            inPause = false;
        }
    }
}

