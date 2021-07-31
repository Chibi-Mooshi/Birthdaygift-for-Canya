using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("How much health should the enemy have?")] public float maxHP;
    [HideInInspector] public float currentHP;

   [Tooltip("What should happen when the enemy dies?")] public UnityEvent onDeath;

    [Tooltip("What should the enemy say when they die?")]public AudioClip EnemyDiesSound;

    //for effect
    [Tooltip("What effect should spawn when the enemy dies?")]public GameObject deathEffect;

    private AudioSource audioSource;

    [Header("HealthBar")]
   public Image healthBar;
    public Canvas healthCanvas;

    private void Start()
    {
        currentHP = maxHP;
        audioSource = GetComponent<AudioSource>();


        

    }


   /* private void Update()
    {
        if (currentHP <= 0)
        {
            onDeath.Invoke();

        }

      
    } */



    // Update is called once per frame
    public void TakeDamage(float damage)
    {

       

        if (currentHP <= 0)
        {
            onDeath.Invoke();

        }


        currentHP -= damage;

        if (currentHP < maxHP)
        {
            healthCanvas.enabled = true;
        }

        healthBar.fillAmount = currentHP / maxHP;

    }


    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(EnemyDiesSound);

        EnemyDeath();
    }

    public void EnemyDeath()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
