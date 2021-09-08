using UnityEngine;
using UnityEngine.Events;

public class LeaveOutOfScreenNPC : MonoBehaviour
{
    public GameObject endPoint;
    public float speed;

    public UnityEvent onReachedEndPoint;


    public bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.transform.position, speed);
            Destroy(endPoint, 1f);
            Destroy(gameObject, 1f);
        }
    }

    public void LeaveOutOfScreen()
    {
        isMoving = true;
    }

  

}
