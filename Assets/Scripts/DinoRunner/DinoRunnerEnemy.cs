using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoRunnerEnemy : MonoBehaviour
{
    public float speed = 3f;
    public float timer;
    public float maxTimer;
    void Start()
    {
        
    }

    void Update()
    {
        if (timer < maxTimer)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            timer += Time.deltaTime;
        }
    }
}
