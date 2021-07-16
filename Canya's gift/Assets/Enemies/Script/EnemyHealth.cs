using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP;
    [HideInInspector] public int currentHP;

    public UnityEvent onDeath;

    public AudioClip EnemyDies;

    //for effect
    public GameObject effect;

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
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
