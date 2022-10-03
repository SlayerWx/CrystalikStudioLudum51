using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private static bool firstMainMenu = false;
    public float timer = 4f;
    private void OnEnable()
    {
        if (!firstMainMenu) StartCoroutine(ShowComic());
        firstMainMenu = true;
    }
    IEnumerator ShowComic()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
