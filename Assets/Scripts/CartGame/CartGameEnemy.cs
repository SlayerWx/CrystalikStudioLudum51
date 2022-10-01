using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGameEnemy : MonoBehaviour
{
    public float speed;
    public float endY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < endY)
            transform.gameObject.SetActive(false);
    }
}
