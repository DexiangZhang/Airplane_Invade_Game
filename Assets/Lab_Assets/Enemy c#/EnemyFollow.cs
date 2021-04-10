using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float Speed = 3.0f;

    private Rigidbody2D myRigidBody;
    private Vector2 movement;

    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = this.GetComponent<Rigidbody2D>();

        target = GameObject.FindWithTag("Player").transform;

        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            myRigidBody.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }

    private void FixedUpdate()
    {
      moveCharacter(movement);
  
    }

    void moveCharacter (Vector2 direction)
    {
       myRigidBody.MovePosition((Vector2)transform.position + (direction * Speed * Time.deltaTime));

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
