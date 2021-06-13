using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP;
    private int currentHP;

    public UnityEvent onDeath;

    private void Start()
    {
        currentHP = maxHP;
    }


    private void Update()
    {
        if (currentHP <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

    }
}
