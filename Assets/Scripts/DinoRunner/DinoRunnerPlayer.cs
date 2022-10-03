using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DinoRunnerPlayer : MonoBehaviour
{
    public bool jump;
    public float jumpForce = 7f;
    public float downForce = 5f;
    Rigidbody2D myBody;
    public bool crouching = false;
    public GameObject standing;
    public GameObject crouch;
    public AudioSource jumpAudio;
    public AudioSource bendAudio;
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        crouching = false;
        jump = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jump == false && !crouching)
        {
            myBody.velocity = new Vector2(0, jumpForce);
            jump = true;
            jumpAudio.Play();
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if (!crouching)
            {
                standing.SetActive(false);
                crouch.SetActive(true);
                if(!jumpAudio.isPlaying)bendAudio.Play();
            }
            crouching = true;

            if (jump)
            {
                myBody.AddForce(Vector2.down * downForce * Time.deltaTime);
            }
        }
        else if(crouch.activeSelf == true && crouching)
        {
            crouching = false;
            crouch.SetActive(false);
            standing.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (PlayerManager.instance) PlayerManager.instance.TakeDamage();
        }
    }
}
