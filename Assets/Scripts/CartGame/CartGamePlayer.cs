using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGamePlayer : MonoBehaviour
{
    public float speed = 7f;
    public float left;
    public float right;
    void Start()
    {
        left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        right = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        left -= transform.localScale.x / 2;
        Debug.Log(left);
        right += transform.localScale.x / 2;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        if(transform.position.x > right )
        {
            transform.position = new Vector3(left,transform.position.y,transform.position.z);
        }
        if (transform.position.x < left)
        {
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.gameObject.name);
    }
}
