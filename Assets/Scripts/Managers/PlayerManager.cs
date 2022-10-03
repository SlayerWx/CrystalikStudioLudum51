using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class PlayerManager : MonoBehaviour
{
    public UnityEvent onTakeDamage;

    public static PlayerManager instance;

    [SerializeField] TextMeshProUGUI lifePointsText;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int maxLifePoints;

    int lifePoints;

    [SerializeField] ScoreScriptable scoreScriptable;

    private void Awake()
    {
        scoreScriptable.score = 0;
    }

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

        lifePoints = maxLifePoints;
        lifePointsText.text = "HP: " + lifePoints.ToString();
        scoreText.text = "Score: " + scoreScriptable.score.ToString();
    }

    public void TakeDamage()
    {
        lifePoints--;
        lifePointsText.text = "HP: " + lifePoints.ToString();

        if (lifePoints <= 0)
        {
            SceneManager.LoadScene("EndGameScreen");
        }
        
        onTakeDamage?.Invoke();
    }

    public void AddScore()
    {
        scoreScriptable.score++;
        scoreText.text = "Score: " + scoreScriptable.score.ToString();
    }
}
