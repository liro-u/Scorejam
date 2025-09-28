using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [System.Serializable]
    public class ScoreChangedEvent : UnityEvent<float> { }

    [SerializeField] private int score = 0;
    [SerializeField] private ScoreChangedEvent onScoreChanged;

    public int Score => score;
    public ScoreChangedEvent OnScoreChanged => onScoreChanged;

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
}
