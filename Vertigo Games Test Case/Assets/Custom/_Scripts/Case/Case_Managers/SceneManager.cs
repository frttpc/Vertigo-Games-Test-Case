using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
