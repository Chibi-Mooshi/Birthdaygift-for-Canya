using UnityEngine;
using UnityEngine.Events;
public class CollisionWithCat : MonoBehaviour
{
    public UnityEvent onCollisionWithPlayer;

    [Tooltip("Player will appear here during in play")] public Transform target;

    public GameObject triggerObject;

    [Range(0, 5)]
    public float catRadius;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            onCollisionWithPlayer.Invoke();
        }
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist < catRadius)
        {
            triggerObject.SetActive(true);
        } else
        {
            triggerObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, catRadius);
    }


    public void DestroyObject()
    {
        Destroy(gameObject);    
    }
}
