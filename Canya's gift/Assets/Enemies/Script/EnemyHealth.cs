using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("How much health should the enemy have?")] public int maxHP;
    [HideInInspector] public int currentHP;

   [Tooltip("What should happen when the enemy dies?")] public UnityEvent onDeath;

    [Tooltip("What should the enemy say when they die?")]public AudioClip EnemyDies;

    //for effect
    [Tooltip("What effect should spawn when the enemy dies?")]public GameObject deathEffect;

    private AudioSource audioSource;

    private void Start()
    {
        currentHP = maxHP;
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (currentHP <= 0)
        {
            onDeath.Invoke();

        }
    }



    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(EnemyDies);

        EnemyDeath();
    }

    public void EnemyDeath()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
