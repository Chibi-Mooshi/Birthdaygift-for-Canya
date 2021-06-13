using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField] public int damage;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyHealth>())
        {
            Debug.Log("Has script");
        }
    }

}
