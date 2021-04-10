using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public Slider healthBar;
    public Text healthText;
    public int currHealth;

    public Animator animator;

    public string LevelName;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currHealth;
        
    }

    public void Damaged (int damage)
    {
        currHealth -= damage;
        healthText.text = "Enemy: " + currHealth.ToString() + " / " + maxHealth.ToString();

        if (currHealth ==0)
        {
            Die();
        }

    }

    void Die()
    {
       // isDeath = true;
        animator.SetTrigger("death");
        animator.SetInteger("status", 0);

        // make the enemy stop moving when it becomes explorsion.
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
       
        //execute the destroy function after 0.8 second 
        Invoke("DelayDestroy", 0.8f);

        PersistentData.Instance.IncreaseScore(5);

        Invoke("LoadScene", 0.8f);


    }

    void DelayDestroy()
    {
        Destroy(gameObject);
    }

    void LoadScene()
    {

        SceneManager.LoadScene(LevelName);
        player.transform.position = new Vector3(-72f, -0.2f, -6);
    }

  


}
