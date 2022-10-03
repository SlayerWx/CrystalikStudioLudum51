using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreScriptable scoreScriptable;

    private void Awake()
    {
        scoreText.text = "Score: " + scoreScriptable.score.ToString();
    }
        
    // Start is called before the first frame update
    void Start()
    {
        scoreScriptable.score = 0;
    }
}
