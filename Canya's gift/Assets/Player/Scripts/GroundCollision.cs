using UnityEngine;

public class GroundCollision : MonoBehaviour
{

    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool orangeGround;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.GetComponent<CheckTerrainHandler>())
        {
            orangeGround = true;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }


        if (collision.gameObject.GetComponent<CheckTerrainHandler>())
        {
            orangeGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }


        if (collision.gameObject.GetComponent<CheckTerrainHandler>())
        {
            orangeGround = false;
        }
    }
}
