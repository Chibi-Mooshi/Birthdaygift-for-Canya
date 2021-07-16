using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*    PlayerHealthSystem playerHealth = other.GetComponent<PlayerHealthSystem>();
            if (playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.ChangeHealth(30);
                Debug.Log("Your health is now" + playerHealth.currentHealth);
                Destroy(gameObject);
            }
        */

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Heal trigger");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player Heal collision");
        }


    }


}
