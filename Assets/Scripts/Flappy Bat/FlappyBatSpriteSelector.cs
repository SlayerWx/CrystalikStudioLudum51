using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlappyBatSpriteSelector : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer myRenderer;
    public GameObject[] colliderObject;
    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        myRenderer.sprite = sprites[index];
        colliderObject[index].SetActive(true);
    }
}
