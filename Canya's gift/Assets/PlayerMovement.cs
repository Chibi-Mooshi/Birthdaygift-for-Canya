using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for movement
    public float moveSpeed;
    private float moveInput;
    private Rigidbody2D rb;

    //variables for jumping
    public float jumpHeight;
    private bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    //variables for double jump
   // private int extraJumps;
    //public int extraJumpsValue;


    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
       // extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }





    // Update is called once per frame
    void FixedUpdate()
    {

        //for jumping
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space)) //&& extraJumps > 0)
        {
           
            rb.velocity = Vector2.up * jumpHeight;
           // extraJumps = -1;
        }
        else if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) //&& extraJumps == 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
        }


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
