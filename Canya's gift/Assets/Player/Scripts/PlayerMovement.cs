using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for movement

    #region public variables
   [Header("Variables for movement")]
   [Tooltip("How fast should the player move?")] public float moveSpeed;

   [Tooltip("How high should the player jump?")]public float jumpHeight;

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
    }

    void reverseImage()
    {
        facingLeft = !facingLeft;
        Vector2 theScale = rb.transform.localScale;
        theScale.x *= -1;
        rb.transform.localScale = theScale;

    }

}
