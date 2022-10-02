using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBatObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 250;
    [SerializeField] private float xBound = 6;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }

}


