using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string winSceneName = "UI_WinScreen"; 
    [SerializeField] private string loseSceneName = "UI_EndScreen"; 
    [SerializeField] private string menuSceneName = "UI_MainMenu";
    [SerializeField] private string leaderboardSceneName = "UI_Leaderboard";
    public int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError("Game scene name is not set in GameManager!");
        }
    }

    public void OpenLoseScreen()
    {
        if (!string.IsNullOrEmpty(loseSceneName))
        {
            SceneManager.LoadScene(loseSceneName);
        }
        else
        {
            Debug.LogError("Game scene name is not set in GameManager!");
        }
    }

    public void OpenWinScreen()
    {
        if (!string.IsNullOrEmpty(winSceneName))
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            Debug.LogError("Game scene name is not set in GameManager!");
        }
    }

    public void OpenMenuScreen()
    {
        if (!string.IsNullOrEmpty(menuSceneName))
        {
            SceneManager.LoadScene(menuSceneName);
        }
        else
        {
            Debug.LogError("Game scene name is not set in GameManager!");
        }
    }

    public void OpenLeaderboardScreen()
    {
        if (!string.IsNullOrEmpty(leaderboardSceneName))
        {
            SceneManager.LoadScene(leaderboardSceneName);
        }
        else
        {
            Debug.LogError("Game scene name is not set in GameManager!");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode
#else
        Application.Quit(); // Quit the build
#endif
    }
}


