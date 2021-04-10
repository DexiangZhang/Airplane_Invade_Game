using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject PlayerBullet;
    public float fireRate = 2.0f;
    private float nextFire = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fire the bullet in the delay of time
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(PlayerBullet, firePoint.position, firePoint.rotation);
    }
}
