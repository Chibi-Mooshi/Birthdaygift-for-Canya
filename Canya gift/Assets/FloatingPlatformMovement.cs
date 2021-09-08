using UnityEngine;

public class FloatingPlatformMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;

    public float maxChangeTime;
    public float minChangeTime;
    private float changeTime;

    private float timer;

    private float speed;

    [SerializeField, Range(-1,1)]int directionSide;


    private void Start()
    {
        changeTime = Random.Range(minChangeTime, maxChangeTime);
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        transform.Translate(new Vector2(0, directionSide) * speed * Time.deltaTime);

        changeTime = Random.Range(minChangeTime, maxChangeTime);

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            directionSide = -directionSide;
            timer = changeTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.gameObject.transform.SetParent(transform);
        }
    } 
}
