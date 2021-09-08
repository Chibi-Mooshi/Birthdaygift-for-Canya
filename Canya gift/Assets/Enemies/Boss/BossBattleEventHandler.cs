using UnityEngine;
using UnityEngine.Events;

public class BossBattleEventHandler : MonoBehaviour
{
    public bool playerCastSpell;

    [Header("Insert where whether Player is alone or not")]
    public ChoiceHolderScriptableObject choice;

    
    [Tooltip("How long should pass of Player not hurting boss?")]public float timeBeforeBossReacts;
    private float time;

    public UnityEvent onBossHasNotBeenHurtYet;

    public void Start()
    {
        playerCastSpell = false;
    }

    public void Update()
    {
        time += Time.deltaTime;

        if (time >= timeBeforeBossReacts && choice.isAlone && !playerCastSpell)
        {
            
            onBossHasNotBeenHurtYet.Invoke();
        }
    }

    public void PlayerCastSpell()
    {
        playerCastSpell = true;
    }

}
