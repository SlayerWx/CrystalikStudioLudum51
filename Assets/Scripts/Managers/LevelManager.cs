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
    int idLevel = - 99;
    bool timerOn;
    private void Awake()
    {
        ruidoAnimation = transform.Find("Ruido_02").gameObject;
    }

    private void Start()
    {
        timerOn = false;
        StartCoroutine(AnimNoiseCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

        if (ableToChange)
        {
            if (levelChangeCounter <= 0)
            {
                ChangeGame();
            }
            if(timerOn) levelChangeCounter -= Time.smoothDeltaTime;
        }
    }
    public void ChangeGame()
    {
        if(timerOn) StartCoroutine(AnimNoiseCoroutine());

    }
    void ChangeGameNow()
    {
        NewLevelSelector(idLevel);
        if (newLevelId != idLevel)
        {
            actualLevel = Instantiate(levelList[newLevelId]);
            idLevel = newLevelId;
        }

    }

    IEnumerator AnimNoiseCoroutine()
    {
        timerOn = false;
        if (actualLevel) Destroy(actualLevel);
        ruidoAnimation.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ruidoAnimation.SetActive(false);

        ChangeGameNow();
        levelChangeCounter = timePerLevel;
        timerOn = true;
    }

    int NewLevelSelector(int lastLevelId)
    {
        int aux = 0;
        do
        {
            newLevelId = Random.Range(0, levelList.Count);
            aux++;
            if(aux>9)
            {
                lastLevelId = -99;
                newLevelId = 0;
            }
        } while (newLevelId == lastLevelId);
        return lastLevelId;
    }
}
