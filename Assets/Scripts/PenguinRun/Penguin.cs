using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{

    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpSpeed;
 
    [Space,SerializeField] private float _distanceGround;

    [SerializeField] private bool _isGrounded;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(0, _jumpSpeed);
        }

        if(transform.position.y <= -8f)
        {
            PlayerManager.instance.TakeDamage();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed, _rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        float collisionTopPosY = collision.transform.position.y + (collision.transform.localScale.y / 2f);
        float posYPlayer = transform.position.y - (transform.localScale.y / 4f);

        _isGrounded = (posYPlayer >= collisionTopPosY);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
    
    public void ResetPenguin()
    {
        transform.position = _spawnPosition.position;
        _isGrounded = true;
        _rigidbody.velocity = Vector3.zero;
    }
}
