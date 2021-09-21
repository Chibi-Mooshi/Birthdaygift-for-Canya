using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;

    public UnityEvent ShowScore;

    private int currentScore;
    private int maxScore;

    private int allCatsInLevel;

    public ScoreScriptableObject scoreScriptableObject;
    private GameObject[] cats;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        currentScore = 0;

        cats = GameObject.FindGameObjectsWithTag("Cat");
        allCatsInLevel = cats.Length;

    }

    public void IncreaseScore()
    {

        currentScore++;

        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreScriptableObject.scoreAmount = currentScore;

        scoreText.text = "Cats found: " + currentScore + " out of " + allCatsInLevel;

        if (currentScore > 0)
        {
            ShowScore.Invoke();

        }
    }

    public void Update()
    {
        /*
        scoreScriptableObject.scoreAmount = currentScore;

        scoreText.text = "Cats found: " + currentScore;

        if (currentScore > 0 )
        {
            ShowScore.Invoke();

        }
        */
    }

}
