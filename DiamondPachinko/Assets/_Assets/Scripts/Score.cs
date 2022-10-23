using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI finalScoreText;
    public GameObject gameOverPanel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void GameOverScreen()
    {
        finalScoreText.text = "Final Score: " + score.ToString();
        gameOverPanel.SetActive(true);
        
    }
}
