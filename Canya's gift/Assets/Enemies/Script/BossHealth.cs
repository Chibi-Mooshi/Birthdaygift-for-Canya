using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{

    public ValueBarData healthData;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthData.maxValue = maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        healthData.currentValue = currentHP;
    }
}
