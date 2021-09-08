using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    public ScoreScriptableObject enemyScore;

    const string EnemyScoreKey = "EnemyScore";

    // Start is called before the first frame update
    void Start()
    {
       // LoadPrefs();   
    }

    public void OnApplicationQuit()
    {
        Saveprefs();
    }

    public void Saveprefs()
    {
        PlayerPrefs.SetInt(EnemyScoreKey, enemyScore.scoreAmount);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        var newEnemyScore = PlayerPrefs.GetInt(EnemyScoreKey, 0);
        enemyScore.scoreAmount = newEnemyScore;
    }
}
