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
    public int damage = 40;
    public int pushBackForce = 1;
    [Space(10)]

    [Header("Defense spells")]
    public int healAmount;
    [Space(10)]

   [Header("Effects for spells")]
    public GameObject endEffect;
    public GameObject startEffect;


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


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spellType == SpellType.offensive)
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
               

                //force backwards
                var enemyPositon = enemyHealth.GetComponent<GameObject>();
                Vector2 pushDirection = transform.InverseTransformDirection(enemyPositon.transform.position - this.transform.position);
                enemyPositon.transform.Translate(pushDirection * pushBackForce * Time.deltaTime);
              
                 enemyHealth.TakeDamage(damage);
                Instantiate(endEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Ground")
            {
                Instantiate(endEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

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
            Destroy(gameObject);
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
