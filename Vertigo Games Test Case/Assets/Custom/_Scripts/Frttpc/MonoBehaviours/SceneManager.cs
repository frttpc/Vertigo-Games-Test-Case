using UnityEngine;

namespace Frttpc.Mono
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance;

        private void Awake()
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }

        public void OpenGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }

        public void OpenMainMenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

        public void CloseGame()
        {
            Application.Quit();
        }
    }
}