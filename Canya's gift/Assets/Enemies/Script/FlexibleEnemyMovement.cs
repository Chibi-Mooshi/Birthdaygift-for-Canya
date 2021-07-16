using UnityEngine;

public class FlexibleEnemyMovement : MonoBehaviour
{
    public float speed;

    public Vector3[] positions;
    private int index;

    private bool playerInSightRange;
    public float chaseRadius;
    private float sightRange;

    public Transform target;

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
        Debug.Log("Plyer not in sight");

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
