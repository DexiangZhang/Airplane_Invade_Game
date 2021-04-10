using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public Rigidbody2D myRigid;

    public float speed = 40.0f;
    public int attackDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (myRigid == null)
        {
            myRigid = GetComponent<Rigidbody2D>();
        }
        // change the size of bullet prelab when it spawns
        myRigid.transform.localScale = new Vector3(1f, 1f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
        myRigid.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
   
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;

            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if(player != null)
            {
                PersistentData.Instance.DecreaseScore(1);
                player.currentHealth();
                player.Damaged(attackDamage);
            }

            Destroy(gameObject);

        }


    }

    // when the bullet is out of the game screen, delete that 
    void OnBecameInvisible() 
    {
         Destroy(gameObject);
    }

}


