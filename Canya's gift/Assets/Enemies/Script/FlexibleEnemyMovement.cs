using UnityEngine;

public class FlexibleEnemyMovement : MonoBehaviour
{
    [Tooltip("How fast should enemy move?")]   public float speed;

   [Tooltip("Add coordinates for the enemy to move between here")] public Vector3[] positions;

    [Tooltip("Player will appear here during in play")] public Transform target;

    [Tooltip("How close does the player need to get for the enemy to attack?")]public float chaseRadius;
    private float sightRange;
    private int index;
    private bool playerInSightRange;
  
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        sightRange = chaseRadius;

        if (Vector2.Distance(transform.position, target.position) < chaseRadius)
        {
            Debug.Log("sight range");
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
        Debug.Log("Player in sight");

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
