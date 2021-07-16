using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject[] spellPrefab;

    public Transform firePoint;

    private int spellIndex;

    [Header("For events")]
    public UnityEvent onKeyPress;
    public UnityEvent onNotEnoughMana;
    public UnityEvent onCoolDownOngoing;

    public int maxMana;
    private int currentMana;

    public ValueBarData manaData;

    private float timer = 0f;
    [Tooltip("How fast should the mana go up?")]public float delayAmount;
    [Tooltip("How much should the mana go up by?")]public int addedManaAmount;

    [Header("For cooldowns")]
    [SerializeField] private CoolDownDataHolder[] coolDownHolder;
   
    private void Start()
    {
        currentMana = maxMana;
        manaData.maxValue = maxMana;
    }

    private void Update()
    {
        manaData.currentValue = currentMana;

        timer += Time.deltaTime;
       
        if (currentMana < maxMana)
        {
            if (timer >= delayAmount)
            {
                timer = 0f;
                currentMana += addedManaAmount;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellIndex = 0;
            //CastSpell(spellIndex);
            onKeyPress.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spellIndex = 1;
           // CastSpell(spellIndex);
            onKeyPress.Invoke();

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spellIndex = 2;
           // CastSpell(spellIndex);
            onKeyPress.Invoke();

        }
    }

   public void CastSpell()
    {

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        Spell spell = spellPrefab[spellIndex].GetComponent<Spell>();

       if (spell.manaCost <= manaData.currentValue && coolDownHolder[spellIndex].spellCoolDown <= 0) // && spell.spellCoolDownData.coolDown <= 0)  //spellCoolDownData.coolDown <= 0)
        {

            if (spell.spellType == Spell.SpellType.offensive)
            {

                Debug.Log("Is casting spell");

                currentMana -= spell.manaCost;
                Instantiate(spellPrefab[spellIndex], firePoint.position, firePoint.rotation);

                //for cooldown
                coolDownHolder[spellIndex].spellCoolDown = spell.spellCoolDown;

            } else if (spell.spellType == Spell.SpellType.defensive && playerHealth.currentHP < playerHealth.maxHP)
            {
                Debug.Log("Is casting spell");

                currentMana -= spell.manaCost;
                Instantiate(spellPrefab[spellIndex], firePoint.position, firePoint.rotation);

                //for cooldown
                coolDownHolder[spellIndex].spellCoolDown = spell.spellCoolDown;
            }

        }
        else if (spell.manaCost > manaData.currentValue)
        {
            onNotEnoughMana.Invoke();
        } else if (spell.spellCoolDown > 0)
        {
            onCoolDownOngoing.Invoke();
        }

        Debug.Log(spellPrefab[spellIndex].GetComponent<Spell>().manaCost);
    }

}
