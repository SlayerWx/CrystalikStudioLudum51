using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levelList;

    GameObject actualLevel;

    GameObject ruidoAnimation;

    [SerializeField] float timePerLevel = 10;

    [SerializeField] bool ableToChange;

    float levelChangeCounter;

    int newLevelId;

    private void Awake()
    {
        ruidoAnimation = transform.Find("Ruido_02").gameObject;
    }

    private void Start()
    {
        StartCoroutine(AnimNoiseCoroutine());
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
        StartCoroutine(AnimNoiseCoroutine());
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
        StartCoroutine(AnimNoiseCoroutine());
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

    IEnumerator AnimNoiseCoroutine()
    {
        ruidoAnimation.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ruidoAnimation.SetActive(false);
    }
}
