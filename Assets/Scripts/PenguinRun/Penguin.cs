using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Penguin : MonoBehaviour
{

    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpSpeed;

    [Space, SerializeField] private float _distanceGround;

    [SerializeField] private bool _isGrounded;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Transform _groundCheck;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(0, _jumpSpeed);
        }

        if (transform.localPosition.y <= -8f)
        {
            if (PlayerManager.instance != null)
            {
                PlayerManager.instance.TakeDamage();
            }
        }
    }

    private void FixedUpdate()
    {
        float _speed;
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed, _rigidbody.velocity.y);
        _speed = _rigidbody.velocity.x;
        if (_speed > 0f)
            _spriteRenderer.flipX = false;
        else if(_speed < 0f)
            _spriteRenderer.flipX = true;

        if(_speed != _animator.GetFloat("speed")) _animator.SetFloat("speed", _rigidbody.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float collisionTopPosY = collision.transform.position.y + (collision.transform.localScale.y / 2f);
        float posYPlayer = _groundCheck.position.y;

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
