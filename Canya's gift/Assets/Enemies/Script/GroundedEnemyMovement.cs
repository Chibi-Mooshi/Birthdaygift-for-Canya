using UnityEngine;

public class GroundedEnemyMovement : MonoBehaviour
{
   [Tooltip("How fast should enemy move?")] public float speed;

   [Tooltip("How long should pass before enemy changes direction?")] public float changeTime;

   [Tooltip("Player will appear here in playmode")] public Transform target;

   [Tooltip("How far should the enemy see?")] public float sightDistance;

    float timer;
    int directionSide = 1;
    public LayerMask playerLayer;
    private Vector2 direction;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        timer = changeTime;
    }

    private void Update()
    {
        transform.Translate(new Vector2(directionSide, 0) * speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            directionSide = -directionSide;
            timer = changeTime;
        }
    }

    public void FixedUpdate()
    {
            //Length of the ray
            float laserLength = sightDistance;

            //Get the first object hit by the ray
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(directionSide, 0), laserLength, playerLayer);

            //If the collider of the object hit is not NUll
            if (hit.collider != null)
            {
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.name);
            }

            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(transform.position, new Vector2(directionSide, 0) * laserLength, Color.red);
    }

    public void ChasePlayer()
    {
        Debug.Log("Player in sight");

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }
}
