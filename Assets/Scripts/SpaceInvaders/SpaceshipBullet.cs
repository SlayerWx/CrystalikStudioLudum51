using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBullet : MonoBehaviour
{
    [SerializeField] float speed = 10;

    float maxLifetime = 3;
    float lifetime;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        lifetime = maxLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);

        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
