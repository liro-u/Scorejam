using UnityEngine;

public class CallGameManager : MonoBehaviour
{
    // Call to start the game
    public void StartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
    }

    // Call to quit the game
    public void QuitGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.QuitGame();
        }
    }

    public void OpenMenu()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OpenMenuScreen();
        }
    }

    public void ShowLoseScreen()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OpenLoseScreen();
        }
    }

    public void ShowWinScreen()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OpenWinScreen();
        }
    }
}
