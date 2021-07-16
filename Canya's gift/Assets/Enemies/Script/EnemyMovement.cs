using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;

  //  public Vector3[] positions;

    private int index;

    public bool isEnemyHasLineOfSight;
    public float sightDistance;
    
    public Transform target;

    //States
    private float sightRange;
    public bool playerInSightRange;
    public float chaseRadius;

    public LayerMask playerLayer;
    private Vector2 direction;

    public float changeTime;
    float timer;
    int directionSide = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        timer = changeTime;
    }

    private void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            directionSide = -directionSide;
            timer = changeTime;
        }

        transform.Translate(new Vector2(directionSide,0) * speed * Time.deltaTime);

        sightRange = chaseRadius;

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);


        if (!isEnemyHasLineOfSight)
        {

            if (Vector2.Distance(transform.position, target.position) < chaseRadius)
            {
                Debug.Log("sight range");
                playerInSightRange = true;
            }
            else
            {
                playerInSightRange = false;
            }

        }
        

            

                /*
                Vector2 right = transform.TransformDirection(Vector2.one) * sightDistance;
                Debug.DrawRay(transform.position, right, Color.green);

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.right, out hit, sightDistance))
                {
                    print(hit.collider.name);

                } */
            


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


    public void FixedUpdate()
    {

        if (isEnemyHasLineOfSight)
        {

            //Length of the ray
            float laserLength = sightDistance;

            //Get the first object hit by the ray
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(directionSide,0), laserLength, playerLayer);

            //If the collider of the object hit is not NUll
            if (hit.collider != null)
            {
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.name);
            }


            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(transform.position, new Vector2(directionSide, 0) * laserLength, Color.red);


        }
    }



    public void Patrolling()
    {
        Debug.Log("Plyer not in sight");

     /*   transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

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
        } */

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
