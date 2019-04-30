using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.5f,5f)] [SerializeField]
    float gameSpeed = 1f;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    int currentScore = 0;
    [SerializeField]
    int pointsPerBlockDestoryed = 50;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestoryed;
        scoreText.text = currentScore.ToString();
    }
}
