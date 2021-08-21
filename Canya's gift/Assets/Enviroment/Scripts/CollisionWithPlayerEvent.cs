using UnityEngine;
using UnityEngine.Events;

public class CollisionWithPlayerEvent : MonoBehaviour
{
    public UnityEvent onCollisionWithPlayer;

    [SerializeField] private UnityEvent ifNotAllCatsAreCollected;

    [SerializeField] private UnityEvent ifAllCatsAreCollected;

    [SerializeField] private ScoreScriptableObject score;

    private int scoreForLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            if (score.scoreAmount >= scoreForLevel)
            {
                ifAllCatsAreCollected.Invoke();
            } else
            {
                Debug.Log("Not all cats have been collected");
                ifNotAllCatsAreCollected.Invoke();
            }
        }
    }


    public void Update()
    {
        GameObject[] cats = GameObject.FindGameObjectsWithTag("Cat");
        scoreForLevel = cats.Length;
    }


}
