using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for movement

    #region public variables
 
   [Header("Variables for movement")]
   [Tooltip("How fast should the player move?")] public float moveSpeed;

   [Tooltip("How high should the player jump?")]public float jumpHeight;

   [Tooltip("How fast should the player fall after their jump?")]public float drag = -0.1f;

   [Tooltip("What particles should spawn when the player hits the ground after jump")]public GameObject dustJumpEffect;
    [Tooltip("What particles should spawn when the player hits the ground after jump")] public GameObject purpleDustJumpEffect;

    [Tooltip("Add feetobject here")]public Transform feetPosition;

   [Tooltip("What particles should spawn when the player walks on ground")] public GameObject walkParticleEffect;
    [Tooltip("What particles should spawn when the player walks on ground")] public GameObject purpleWalkParticleEffect;

    [Tooltip("How much time should spawn between walk dust spawning and walk sound playing?")] public float delayAmountForWalkdDustEffect;

    [Space(10)]
    [Header("Audio")]
    [Space(10)]
    [Tooltip("What sound should play when player walks?")] public AudioClip walkSound;
    [Tooltip("What sound should play when player jumps?")] public AudioClip jumpSound;
    [Tooltip("What sound should play when player lands?")] public AudioClip landSound;

    #endregion

    #region Private Variables

    private float moveInput;
    private Rigidbody2D rb;
    private GroundCollision groundCollision;
    private bool canJump;

    private float timer = 0f;
    private bool spawnDust;
    private Animator animator;

    private AudioSource feetAudioSource;

    #endregion

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCollision = GetComponent<GroundCollision>();

        feetAudioSource = GetComponentInChildren<AudioSource>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (groundCollision.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            feetAudioSource.PlayOneShot(jumpSound);

                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

        if (groundCollision.isGrounded)
        {
            if (spawnDust == true)
            {
                if (groundCollision.orangeGround)
                {
                    Instantiate(dustJumpEffect, feetPosition.position, Quaternion.identity);
                } else
                {
                    Instantiate(purpleDustJumpEffect, feetPosition.position, Quaternion.identity);
                }

                

                spawnDust = false;

                feetAudioSource.PlayOneShot(landSound);
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



       

        //animator
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !facingLeft)
            reverseImage();
        else if (moveInput < 0 && facingLeft)
            reverseImage();


        //for spawning
        if (moveInput != 0)
        {
            if (timer <= 0)
            {
                if (groundCollision.isGrounded) { 

                    if (groundCollision.orangeGround)
                    {
                        Instantiate(walkParticleEffect, feetPosition.position, Quaternion.identity);
                    } else
                    {
                        Instantiate(purpleWalkParticleEffect, feetPosition.position, Quaternion.identity);
                    }
               
                timer = delayAmountForWalkdDustEffect;

                var randomVolume = Random.Range(0.1f, 0.9f);
                feetAudioSource.volume = randomVolume;
                feetAudioSource.PlayOneShot(walkSound);
                }

            } else {
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
