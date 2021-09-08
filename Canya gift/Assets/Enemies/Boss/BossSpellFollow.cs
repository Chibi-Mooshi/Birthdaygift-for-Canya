using UnityEngine;

public class BossSpellFollow : MonoBehaviour
{
    public float timeBeforeDestruction = 10f;

    [Header("Effects for spells")]
    public GameObject endEffect;

    private Rigidbody2D rb;

    public float speed;

    public int damage = 40;

    public GameObject playerObject;

    private Vector3 aim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerObject = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void Start()
    {

    aim = (playerObject.transform.position - transform.position).normalized;
        
    }

    public void Update()
    {
        rb.AddForce(aim * speed);

        transform.Rotate(new Vector3(0, 0, 1f));

      //  transform.position = Vector3.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);

        //for destroying spells after a certain amount of time
        timeBeforeDestruction -= Time.deltaTime;
        if (timeBeforeDestruction <= 0)
        {
            Instantiate(endEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, timeBeforeDestruction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Instantiate(endEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        ProtectionSpell protectionSpell = collision.GetComponent<ProtectionSpell>();
        if (protectionSpell != null)
        {
            Destroy(gameObject);
        }
    }
}
