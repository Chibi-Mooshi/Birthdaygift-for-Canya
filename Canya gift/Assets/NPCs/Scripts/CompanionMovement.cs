using UnityEngine;

public class CompanionMovement : MonoBehaviour
{

    public Vector2 endPoint;

    public bool approachPlayer;

    private void Start()
    {
        approachPlayer = false;
    }

    private void Update()
    {
        if (approachPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, Time.deltaTime * 5f);
        }
   }

    public void ApproachPlayer()
    {
        approachPlayer = true;
    }
}
