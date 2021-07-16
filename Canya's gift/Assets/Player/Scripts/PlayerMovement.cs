using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for movement

    #region public variables
   [Header("Variables for movement")]
   [Tooltip("How fast should the player move?")] public float moveSpeed;

   [Tooltip("How high should the player jump?")]public float jumpHeight;

   [Tooltip("How fast should the player fall after their jump?")]public float drag = -0.1f;


    private bool spawnDust;
    public GameObject dustJumpEffect;

    public Transform feetPosition;


    public GameObject walkParticleEffect;
    private float timer = 0f;
    public float delayAmountForWalkdDustEffect;


    #endregion

    #region Private Variables

    private float moveInput;
    private Rigidbody2D rb;
    private GroundCollision groundCollision;
    private bool canJump;

    #endregion

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCollision = GetComponent<GroundCollision>();

        
    }

    private void Update()
    {

        if (groundCollision.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }


        if (groundCollision.isGrounded)
        {
            if (spawnDust == true)
            {
                Instantiate(dustJumpEffect, feetPosition.position, Quaternion.identity);
                spawnDust = false;
            }
          
        } else
        {
            spawnDust = true;
        }


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0 && !facingLeft)
            reverseImage();
        else if (moveInput < 0 && facingLeft)
            reverseImage();


        //for spawning
        if (moveInput != 0)
        {
            if (timer <= 0)
            {
                Instantiate(walkParticleEffect, feetPosition.position, Quaternion.identity);
                timer = delayAmountForWalkdDustEffect;
            } else
            {
                timer -= Time.deltaTime;
            }
        }



        //for jumping
        Vector3 force = drag * rb.velocity.normalized * rb.velocity.sqrMagnitude;
        rb.AddForce(force);
    }

    void reverseImage()
    {
        facingLeft = !facingLeft;

        transform.Rotate(0f, 180f, 0f);
        /*
        Vector2 theScale = rb.transform.localScale;
        theScale.x *= -1;
        rb.transform.localScale = theScale;
        */
    }

}
