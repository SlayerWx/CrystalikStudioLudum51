using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGamePickUp : MonoBehaviour
{
    public float speed;
    public float endY;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < endY)
            gameObject.SetActive(false);

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Player")
         {
            gameObject.SetActive(false);
            if(PlayerManager.instance) PlayerManager.instance.AddScore();
             
         }
    }
}
