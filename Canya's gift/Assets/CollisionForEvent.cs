using UnityEngine;
using UnityEngine.Events;

public class CollisionForEvent : MonoBehaviour
{

    public UnityEvent onCollisionWithPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            onCollisionWithPlayer.Invoke(); 
        }
    }

    

}
