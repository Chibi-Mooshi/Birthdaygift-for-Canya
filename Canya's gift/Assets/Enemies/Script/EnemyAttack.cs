using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [Tooltip("How much should the enemy damage the player?")]public int damage;

   [Tooltip("How long should pass between enemy attacks?")] public float timer;
    private bool isReadyToAttack;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
    */

    private void Update()
    {
        Debug.Log("Is enemy ready to attack " + isReadyToAttack);

        if (!isReadyToAttack)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                isReadyToAttack = true;
            }

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (isReadyToAttack)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                isReadyToAttack = false;
            }

        }

      
       
    }
}