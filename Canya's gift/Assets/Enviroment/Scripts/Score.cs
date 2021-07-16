using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;

    private int currentScore;
    private int maxScore;


    private void Start()
    {
        scoreText = GetComponent<Text>();

        currentScore = 0;
        
    }

    public void IncreaseScore()
    {

        currentScore++;
    }

    public void Update()
    {
        
    }

}
