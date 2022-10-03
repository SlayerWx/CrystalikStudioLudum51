using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBatPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float force = 1.5f;
    [SerializeField] private float yBound = -8;

    [SerializeField] AudioSource jumpAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _rigidbody.position.y < yBound)
        {
            Flap();
        }
        if(transform.position.y < -5.55f)
        {
            if (PlayerManager.instance) PlayerManager.instance.TakeDamage();

        }

    }
    private void Flap()
    {
        jumpAudio.Play();
        _rigidbody.velocity = Vector2.zero;
        //_rigidbody.AddForce(Vector2.up * force * Time.deltaTime);
        _rigidbody.velocity = Vector2.up * force;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (PlayerManager.instance) PlayerManager.instance.TakeDamage();
        }
    }
}


