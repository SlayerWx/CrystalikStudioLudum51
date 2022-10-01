using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void ChangeGame()
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

    
}
