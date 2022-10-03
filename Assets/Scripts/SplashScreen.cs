using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private static bool firstMainMenu = true;
    public float timer = 4f;
    private void Start()
    {
        if (firstMainMenu) StartCoroutine(ShowComic());
        else
            gameObject.SetActive(false);

    }
    IEnumerator ShowComic()
    {
        firstMainMenu = false;
        gameObject.SetActive(true);
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
