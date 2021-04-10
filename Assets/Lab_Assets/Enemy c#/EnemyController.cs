using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;

    public Rigidbody2D myRigid;
    public float speed = 30.0f;
    public bool isFacingRight = true;

    Vector3 pos;
    Vector3 cameraBorder;

    BoxCollider2D enemyBody;

    public new AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        if (myRigid == null)
            myRigid = GetComponent<Rigidbody2D>();

        if(enemyBody == null)
            enemyBody = GetComponent<BoxCollider2D>();

        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

        cameraBorder = Camera.main.ScreenToWorldPoint(transform.position);

        // to get accurate border when enemy is going to hit the screen border;
        cameraBorder.x = Mathf.Abs(cameraBorder.x) - (enemyBody.size.x / 2);

      
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void FixedUpdate()
    {

       if(isFacingRight)
           myRigid.velocity = new Vector2(horizontalMove * speed * -1, myRigid.velocity.y);
       else
           myRigid.velocity = new Vector2(horizontalMove * speed, myRigid.velocity.y);

       pos = transform.position;

       // value is add or substract is to make it more accurate before first body part of image is hit border (might change based on images provided)
      if(pos.x <  (cameraBorder.x * -1)+5 && isFacingRight  || pos.x > cameraBorder.x -10 && !isFacingRight)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // hit by player bullet 
        if (collision.gameObject.tag == "Fire")
        {
            audio.Play();
        }
    }


}
