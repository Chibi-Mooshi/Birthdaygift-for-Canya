using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;

    public UnityEvent ShowScore;

    private int currentScore;
    private int maxScore;

    public ScoreScriptableObject scoreScriptableObject;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        currentScore = 0;
        
    }

    public void IncreaseScore()
    {

        currentScore++;

        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreScriptableObject.scoreAmount = currentScore;

        scoreText.text = "Cats found: " + currentScore;

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
