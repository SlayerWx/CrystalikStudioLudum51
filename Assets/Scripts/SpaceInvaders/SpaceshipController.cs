using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float timePerShoot;
    float timePerShootCounter;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPosition;

    Rigidbody2D rb;

    private float objectWidth;
    private float objectHeight;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (transform.position.x > screenBounds.x - objectWidth)
        {
            inputX = -1;
        }
        else if (transform.position.x < -screenBounds.x + objectWidth)
        {
            inputX = 1;
        }

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && timePerShootCounter < 0)
        {
            SpawnBullet();
        }

        timePerShootCounter -= Time.deltaTime;
    }

    void SpawnBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
        timePerShootCounter = timePerShoot;
    }
}
