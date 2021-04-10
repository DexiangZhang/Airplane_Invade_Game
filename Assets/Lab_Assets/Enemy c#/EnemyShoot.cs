using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

	
	public float startFire = 2.0f;
	public float repeatRate = 1.5f;

	public Transform firePoint;
    public GameObject EnemyBullet;

    public Animator animator;

     

    // Start is called before the first frame update
    void Start()
    {

        

        InvokeRepeating("LaunchProjectile", startFire, repeatRate);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectile()
    {

       EnemyHealth enemyHealth = GetComponent<EnemyHealth>();

        if (enemyHealth.maxHealth > enemyHealth.currHealth)
        {
            animator.SetInteger("status", 2);
            animator.SetBool("isAtt", true);


        }
        else if (enemyHealth.maxHealth == enemyHealth.currHealth)
        {
            animator.SetInteger("status", 1);
            animator.SetBool("isAtt", true);
        }

        Instantiate(EnemyBullet, firePoint.position, firePoint.rotation);
     
    }
}
