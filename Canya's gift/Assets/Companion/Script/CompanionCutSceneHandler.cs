using UnityEngine;
using UnityEngine.Events;

public class CompanionCutSceneHandler : MonoBehaviour
{
    public ScoreScriptableObject enemyScore;

    [Tooltip("Add raise event here to spawn warrior")]
    public UnityEvent onSpawnWarrior;
    [Tooltip("Add raise event here to spawn druid")]
    public UnityEvent onSpawnDruid;


   public void CheckEnemyScore()
    {
        if (enemyScore.scoreAmount > 0)
        {
            onSpawnWarrior.Invoke();
        } else
        {
            onSpawnDruid.Invoke();
        }
    }


}
