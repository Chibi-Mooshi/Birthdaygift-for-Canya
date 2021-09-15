using UnityEngine;
using UnityEngine.Events;

public class CollisionWithPlayerEvent : MonoBehaviour
{
    public UnityEvent onCollisionWithPlayer;

    [SerializeField] private UnityEvent ifNotAllCatsAreCollected;

    [SerializeField] private UnityEvent ifAllCatsAreCollected;

    [SerializeField] private ScoreScriptableObject score;

    private int scoreForLevel;

    public int currentLevelCatScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            if (currentLevelCatScore >= scoreForLevel)
            {
                ifAllCatsAreCollected.Invoke();
                Time.timeScale = 0;
            } else
            {
                Debug.Log("Not all cats have been collected");
                ifNotAllCatsAreCollected.Invoke();
            }
        }
    }


    public void Start()
    {
     currentLevelCatScore = 0;

         GameObject[] cats = GameObject.FindGameObjectsWithTag("Cat");
        scoreForLevel = cats.Length;

    }

    public void RaiseAmount()
    {
        currentLevelCatScore++;
    }

}
