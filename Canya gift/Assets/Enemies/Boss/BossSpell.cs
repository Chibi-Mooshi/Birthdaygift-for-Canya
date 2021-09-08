using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{

    public float timeBeforeDestruction = 10f;

    [Header("Effects for spells")]
    public GameObject endEffect;

    private Rigidbody2D rb;

    public float speed;

    public int damage = 40;

    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        direction = new Vector2(Random.Range(-10f, 10f), Random.Range(-1f, 10f));
        rb.velocity = direction * speed;
    }

    // Start is called before the first frame update
    public void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1f));

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


    }
}

        
