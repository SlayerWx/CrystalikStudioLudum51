using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipsEnemy : MonoBehaviour
{
    [SerializeField] float speed;

    float maxLifetime = 3;
    float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = maxLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceshipBullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ScoreManager.instance.AddScore();
        }
    }
}
