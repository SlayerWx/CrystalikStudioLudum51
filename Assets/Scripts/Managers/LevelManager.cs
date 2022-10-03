using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public List<Level> levelList;

    Level actualLevel;

    [SerializeField] float timePerLevel = 10;

    [SerializeField] bool ableToChange;

    float levelChangeCounter;

    int newLevelId;

    private void Start()
    {
        actualLevel = levelList[Random.Range(0, levelList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        levelChangeCounter -= Time.deltaTime;

        if (ableToChange)
        {
            if (levelChangeCounter <= 0)
            {
                ChangeGame();
            }
        }
    }

    public void ChangeGame()
    {
        newLevelId = Random.Range(0, levelList.Count);

        if (newLevelId != actualLevel.id)
        {
            actualLevel.gameObject.SetActive(false);

            actualLevel = levelList[newLevelId];

            actualLevel.gameObject.SetActive(true);

            levelChangeCounter = timePerLevel;
        }
    }

    public void ChangeGameImmediately()
    {
        actualLevel.gameObject.SetActive(false);

        if (actualLevel.id != levelList.Count)
        {
            actualLevel = levelList[actualLevel.id + 1];
        }
        else
        {
            actualLevel = levelList[0];
        }

        actualLevel.gameObject.SetActive(true);

        levelChangeCounter = timePerLevel;
    }
}
