using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SplashScreen : MonoBehaviour
{
    private static bool firstMainMenu = true;
    public float timer = 4f;
    public RawImage img;
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
        float aux = img.color.a;
        while (img.color.a > 0)
        {
            yield return null;
            img.color = new Vector4(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime * 0.5f));
        }

        img.color = new Vector4(img.color.r, img.color.g, img.color.b, aux);
        gameObject.SetActive(false);
    }
}
