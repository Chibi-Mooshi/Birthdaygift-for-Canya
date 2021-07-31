using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
   [Tooltip("How much health should the player have?")] public int maxHP;
    [HideInInspector] public int currentHP;

  [Tooltip("Insert data for health here")]  public ValueBarData healthData;

    [Tooltip("What effect should play when the player takes damage?")]public GameObject takeDamageEffect;

    [Tooltip("What should happen when player dies?")]public UnityEvent onPlayerDeath;

  

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
