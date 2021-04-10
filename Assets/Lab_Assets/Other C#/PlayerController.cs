using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;

    public Rigidbody2D myRigid;
    public float speed = 25.0f;

    public bool isFacingRight = true;

    public new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if(myRigid == null)
        {
            myRigid = GetComponent<Rigidbody2D>();
        }

          if (audio == null)
          {
              audio = GetComponent<AudioSource>();
          }

     

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    // called mutiple times per frame
    void FixedUpdate()
    {
        myRigid.velocity = new Vector2(horizontalMove * speed, myRigid.velocity.y);
        myRigid.velocity = new Vector2(myRigid.velocity.x, verticalMove * speed);

        if(horizontalMove < 0 && isFacingRight || horizontalMove > 0 && !isFacingRight)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        Vector3 direction = new Vector3(0, 180, 0);
        transform.Rotate(direction);
        isFacingRight = !isFacingRight;
    }

    // when got hit by enemy bullet 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audio.Play();
        }
    }
}
