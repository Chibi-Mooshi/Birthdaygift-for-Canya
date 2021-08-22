using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{

    [Tooltip("How fast should the mana go up?")] public float delayAmount;
    [Tooltip("How much should the mana go up by?")] public int addedManaAmount;

    [Tooltip("Insert spells here"),SerializeField]private GameObject[] spellPrefab;

    [Tooltip("Add firepoint object here")]public Transform firePoint;
    [Tooltip("Add feetposition here")] public Transform feetPosition;

    [Tooltip("What should be the max amount of mana the player has?")]public int maxMana;


    [Tooltip("Insert the manabar data here")]public ValueBarData manaData;

    [Header("For cooldowns")]
    [Tooltip("Insert data for cooldowns here"),SerializeField] private CoolDownDataHolder[] coolDownHolder;

    [Header("For events")]
   [Tooltip("What should happen when the player presses the button to fire?")] public UnityEvent onKeyPress;
    [Tooltip("What should happen when there's not enough mana?")]public UnityEvent onNotEnoughMana;
   [Tooltip("What should happen is a spell is currently in cooldown?")] public UnityEvent onCoolDownOngoing;

  
    private int currentMana;
    private int spellIndex;
    private Animator animator;

    private float timer = 0f;

    private AudioSource audioSource;
   
    private void Start()
    {
        currentMana = maxMana;
        manaData.maxValue = maxMana;

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
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

    void HandleAttackAnimation()
    {
       
        
            animator.SetTrigger("Attack");
        
    }

   public void CastSpell()
    {
       

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        Spell spell = spellPrefab[spellIndex].GetComponent<Spell>();

       if (spell.manaCost <= manaData.currentValue && coolDownHolder[spellIndex].spellCoolDown <= 0) // && spell.spellCoolDownData.coolDown <= 0)  //spellCoolDownData.coolDown <= 0)
        {
           

            if (spell.spellType == Spell.SpellType.offensive)
            {
                //animation
                HandleAttackAnimation();

                //play audio
                audioSource.PlayOneShot(spell.spellSound);



                currentMana -= spell.manaCost;
                Instantiate(spellPrefab[spellIndex], firePoint.position, firePoint.rotation);

                //for cooldown
                coolDownHolder[spellIndex].spellCoolDown = spell.spellCoolDown;

         

            } else if (spell.spellType == Spell.SpellType.defensive && playerHealth.currentHP < playerHealth.maxHP)
            {
                Debug.Log("Is casting spell");

                //play audio
                audioSource.PlayOneShot(spell.spellSound);

                currentMana -= spell.manaCost;
                Instantiate(spellPrefab[spellIndex], feetPosition.position, feetPosition.rotation);
                spellPrefab[spellIndex].transform.SetParent(gameObject.transform);

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


    }

}
