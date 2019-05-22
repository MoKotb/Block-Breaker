using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.5f,5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestoryed = 50;
    [SerializeField] bool isAutoPlayEnabled;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void SetScore()
    {
        currentScore += pointsPerBlockDestoryed;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
