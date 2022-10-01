using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGamePlayer : MonoBehaviour
{
    public float speed = 7f;
    public float left;
    public float right;
    Rigidbody2D myBody;
    void Start()
    {
        left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        right = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        left -= transform.localScale.x / 2;
        right += transform.localScale.x / 2;
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myBody.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            myBody.velocity = Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            myBody.velocity = Vector3.right * speed * Time.deltaTime;

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
