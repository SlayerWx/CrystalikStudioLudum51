using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] TextMeshProUGUI lifePointsText;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int lifePoints;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void TakeDamage()
    {
        lifePoints--;
        lifePointsText.text = "HP: " + lifePoints.ToString();

        if (lifePoints <= 0)
        {
            SceneManager.LoadScene("EndGameScreen");
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
