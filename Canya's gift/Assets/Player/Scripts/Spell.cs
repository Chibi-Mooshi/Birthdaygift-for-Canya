using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{
    [Header("Spell data")]
    public float spellCoolDown;
    public int manaCost;

    public SpellType spellType;

    public enum SpellType
    {
        offensive,
        defensive
    };



    [Header("Offense spells")]
    public float speed = 20f;
    public float damage = 40;
    public float timeBeforeDestruction = 10f;
    [Space(10)]

    [Header("Defense spells")]
    public int healAmount;
    [Space(10)]

   [Header("Effects for spells")]
    public GameObject endEffect;
    public GameObject startEffect;

    [Space(10)]
    [Header("Sound for spell")]
    public AudioClip spellSound;

    [Header("Events")]
    public UnityEvent onCasting;
    public UnityEvent onHitPlayer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        onCasting.Invoke();

        Instantiate(startEffect, transform.position, Quaternion.identity);
       
    }

    public void Update()
    {
        //for destroying spells after a certain amount of time
        timeBeforeDestruction -= Time.deltaTime;
        if (timeBeforeDestruction <= 0 )
        {
            Instantiate(endEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, timeBeforeDestruction);
        }

       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spellType == SpellType.offensive)
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                 enemyHealth.TakeDamage(damage);
                Instantiate(endEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

           /* if (collision.gameObject.tag == "Ground")
            {
                Instantiate(endEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            } */

        } else {

            if (collision.CompareTag("Player"))
            {
                Debug.Log("PLAYER HEAL");
                // Heal(collision.gameObject);
                onHitPlayer.Invoke();
            
            }
        }
    }

    #region Public Fields

    public void OffenseSpellCasted()
    {
        rb.velocity = transform.right * speed;
    }



    public void Heal()
    {
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (playerHealth.currentHP < playerHealth.maxHP)
        {
            playerHealth.AddHealth(healAmount);
            Instantiate(endEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length + 0f);
        }
       /* if (player.gameObject.GetComponent<PlayerHealth>().currentHP < player.gameObject.GetComponent<PlayerHealth>().maxHP)
        {
            player.gameObject.GetComponent<PlayerHealth>().AddHealth(healAmount);
            Instantiate(endEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }*/
    }

    #endregion
}
