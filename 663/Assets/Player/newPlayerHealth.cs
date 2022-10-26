using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class newPlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // We're dead
            //Play Death animation
            Animation.SetBool("IsDead", true);
            // Show GameOver Screen
        }
    }


    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
