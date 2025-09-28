using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [System.Serializable]
    public class ScoreChangedEvent : UnityEvent<float> { }

    [SerializeField] private int score = 0;
    [SerializeField] private int roomCompleted = 0;
    [SerializeField] private ScoreChangedEvent onScoreChanged;
    [SerializeField] private UnityEvent<float> onRoomCompletedChanged;
    [SerializeField] private int roomToWin = 10;

    public int Score => score;
    public int RoomCompleted => roomCompleted;
    public ScoreChangedEvent OnScoreChanged => onScoreChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        GameManager.Instance.score = score;
        onScoreChanged?.Invoke(score);
    }

    public void ResetScore()
    {
        score = 0;
        GameManager.Instance.score = score;
        onScoreChanged?.Invoke(score);
    }

    public void AddRoomCompleted()
    {
        roomCompleted += 1;
        onRoomCompletedChanged.Invoke(roomCompleted);
        if (roomToWin <= roomCompleted)
        {
            StartCoroutine(WinCoroutine());
        }
    }

    private IEnumerator WinCoroutine()
    {
        Player.Instance.GetComponent<PlayerAnimatorSetter>().SetIsWining(true);
        Player.Instance.GetComponent<PlayerInput>().enabled = false;

        yield return new WaitForSeconds(2);

        GameManager.Instance.OpenWinScreen();
    }
}
