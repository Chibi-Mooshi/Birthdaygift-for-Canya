using UnityEngine;

public class FlexibleEnemyMovement : MonoBehaviour
{
    [Tooltip("How fast should enemy move?")]   public float speed;

   [Tooltip("Add coordinates for the enemy to move between here")] public Vector3[] positions;

    [Tooltip("Player will appear here during in play")] public Transform target;

    [Tooltip("How close does the player need to get for the enemy to attack?")]public float chaseRadius;




    private int index;
    private bool playerInSightRange;
    private Vector2 direction;

    private Animator animator;
  
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction = target.position - transform.position;

        if (Vector2.Distance(transform.position, target.position) < chaseRadius)
        {

            playerInSightRange = true;
        }
        else
        {
            playerInSightRange = false;
        }

        //for states

        if (!playerInSightRange)
        {
            Patrolling();
        }
        else if (playerInSightRange)
        {
            ChasePlayer();

        }
        else
        {
            Debug.Log("Error");
        }
    }


    public void Patrolling()
    {
           transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        animator.SetBool("isAttacking", false);

        if (transform.position == positions[index])
           {
               if (index == positions.Length - 1)
               {
                   index = 0;
               }
               else
               {
                   index++;
               }
           } 
    }

    public void ChasePlayer()
    {
        var spriteRender = GetComponent<SpriteRenderer>();

        if (direction.x > 0f)
        {
            spriteRender.flipX = true;
        } else
        {
            spriteRender.flipX = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

        animator.SetBool("isAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
