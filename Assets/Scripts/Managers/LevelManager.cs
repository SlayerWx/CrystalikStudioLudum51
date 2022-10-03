using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levelList;

    GameObject actualLevel;

    [SerializeField] float timePerLevel = 10;

    [SerializeField] bool ableToChange;

    float levelChangeCounter;

    int newLevelId;

    private void Start()
    {
        actualLevel = Instantiate(levelList[Random.Range(0, levelList.Count)]);
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

        if (newLevelId != actualLevel.GetComponent<Level>().id)
        {
            Destroy(actualLevel.gameObject);

            actualLevel = Instantiate(levelList[newLevelId]);

            levelChangeCounter = timePerLevel;
        }
    }

    public void ChangeGameImmediately()
    {
        Destroy(actualLevel);

        if (actualLevel.GetComponent<Level>().id != levelList.Count)
        {
            actualLevel = Instantiate(levelList[actualLevel.GetComponent<Level>().id + 1]);
        }
        else
        {
            actualLevel = levelList[0];
        }

        levelChangeCounter = timePerLevel;
    }
}
