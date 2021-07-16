using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP;
    [HideInInspector] public int currentHP;


    public UnityEvent onPlayerDeath;

    public ValueBarData healthData;

    public GameObject takeDamageEffect;

    private void Start()
    {
        currentHP = maxHP;
        healthData.maxValue = maxHP;

    }


    private void Update()
    {
        healthData.currentValue = currentHP;
       

        if (currentHP <= 0)
        {

            Debug.Log("At 0 health");
            onPlayerDeath.Invoke();
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        Instantiate(takeDamageEffect, transform.position, Quaternion.identity);

    }


    public void AddHealth(int healAmount)
    {
        currentHP += healAmount;
    }


}
