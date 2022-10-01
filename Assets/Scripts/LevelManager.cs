using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int score;

    public List<Level> levelList;

    Level actualLevel;

    float timePerLevel = 10;

    float levelChangeCounter;

    int newLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levelChangeCounter -= Time.deltaTime;

        if (levelChangeCounter <= 0)
        {
            ChangeGame();
        }
    }

    void ChangeGame()
    {
        newLevel = Random.Range(0, levelList.Count);

        if (newLevel != actualLevel.id)
        {
            actualLevel.gameObject.SetActive(false);

            actualLevel = levelList[Random.Range(0, levelList.Count)];

            actualLevel.gameObject.SetActive(true);

            levelChangeCounter = timePerLevel;
        }
    }

    public void AddScore()
    {
        score++;
    }
}
