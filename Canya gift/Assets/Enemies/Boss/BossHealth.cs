using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider bossHealthBar;

    [Tooltip("How much health should the enemy have?")] public float maxHP;
    [HideInInspector] public float currentHP;

    [Tooltip("What should happen when the enemy dies?")] public UnityEvent onDeath;

    private void Start()
    {
        currentHP = maxHP;
        bossHealthBar.maxValue = maxHP;
    }

    private void Update()
    {
        bossHealthBar.value = currentHP;

    }


    public void TakeDamage(float damage)
    {
        if (currentHP <= 0)
        {
            onDeath.Invoke();
        }
        currentHP -= damage;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spell spell = collision.GetComponent<Spell>();
        if (spell != null)
        {

            TakeDamage(spell.damage);
        }
    }
}
