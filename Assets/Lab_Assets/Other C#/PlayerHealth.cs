using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public  Slider healthBar;
    public  Text healthText;
    public int currHealth;


    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        PersistentData.Instance.SetHealth(maxHealth);
    
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {
            Destroy(this.gameObject);
        }

       
    }

    public void currentHealth()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = PersistentData.Instance.GetHealth();

    }

    public void Damaged (int damage)
    {
        
            currHealth = PersistentData.Instance.GetHealth();
            currHealth -= damage;
            PersistentData.Instance.SetHealth(currHealth);
            healthText.text = "Player: " + PersistentData.Instance.GetHealth().ToString() + " / " + maxHealth.ToString();

            if (PersistentData.Instance.GetHealth() <= 0)
            {

                Die();
            }

        
    }

    void Die()
    {
        animator.SetTrigger("death");

        Invoke("ReloadScene", 0.4f);

       
    }

    void ReloadScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // respawn at default point 
        transform.position = new Vector3(-72f, -0.2f, -6);
        animator.SetTrigger("reborn");
        // set health to full when reborn
        healthBar.maxValue = maxHealth;
        PersistentData.Instance.SetHealth(maxHealth);
        healthBar.value = PersistentData.Instance.GetHealth();
        healthText.text = "Player: " + PersistentData.Instance.GetHealth().ToString() + " / " + maxHealth.ToString();
    }

 
}
