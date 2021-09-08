using UnityEngine;
using UnityEngine.Events;

public class BossMovement : MonoBehaviour
{

    public GameObject spellPrefabShower;

    public GameObject spellPrefabFollow;

    public GameObject playerTooCloseToWitchParticleSpawn;

    public int spellAmount = 5;

    public int damage = 5;

    public UnityEvent onCastSpellShower;
    public UnityEvent onCastSpellFollow;

    private int currentSpellSummoned;

    private BossHealth bossHealth;
    private Animator animator;

    //for timer
    [SerializeField]
    private float timerToCastSpells;
    [SerializeField] private float timerToCastSpellsAtHalfHealth;
    private float elapsed;

    private void Awake()
    {
        bossHealth = GetComponent<BossHealth>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentSpellSummoned = 0;
        castSpellShower();

    }

    public void Update()
    {

        elapsed += Time.deltaTime;

        if (bossHealth.currentHP < bossHealth.maxHP / 2)
        {
            if (elapsed >= timerToCastSpellsAtHalfHealth)
            {
                elapsed = 0f;
                castSpellShower();
            }
        }
        else
        {

            if (elapsed >= timerToCastSpells)
            {
                elapsed = 0f;
                castSpellShower();
            }
        }
       
    }

    public void castSpellShower()
    {
       
      
        if (currentSpellSummoned < spellAmount)
        {
            for (int i = 0; i < 1; ++i)
            {
                animator.SetTrigger("Attack");
                GameObject spell;
                spell = Instantiate(spellPrefabShower, transform.position, Quaternion.identity);
                spell.transform.parent = transform;
                animator.SetTrigger("Idle");

                currentSpellSummoned++;
            } 
        } else if(currentSpellSummoned == 1)
        {
            onCastSpellShower.Invoke();
        } else if(currentSpellSummoned >= spellAmount)
        {
            currentSpellSummoned = 0;
            followSpell();
            onCastSpellFollow.Invoke();
        }
    }

    public void followSpell()
    {
        animator.SetTrigger("Attack");
        Instantiate(spellPrefabFollow, transform.position, Quaternion.identity);
        animator.SetTrigger("Idle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Instantiate(playerTooCloseToWitchParticleSpawn, transform.position, Quaternion.identity);

        }


    }


}
