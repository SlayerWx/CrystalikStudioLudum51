using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGamePickUp : MonoBehaviour
{
    public float speed;
    public float end;
    public Vector3 axis;
    // Update is called once per frame
    void Update()
    {
        transform.position += axis * speed * Time.deltaTime;
        if (transform.position.y < end && axis.y != 0)
            gameObject.SetActive(false);
        if (transform.position.x < end && axis.x != 0)
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
