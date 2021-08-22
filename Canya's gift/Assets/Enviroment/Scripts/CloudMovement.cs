using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float speed = 2;

    private float endPosx;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * speed));

        if (transform.position.x > endPosx)
        {
            Destroy(gameObject);
        }
    }

    public void StartFloating(float floatSpeed, float endPositionX)
    {
        speed = floatSpeed;
        endPosx = endPositionX;
    }
}
