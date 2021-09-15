using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  
    [HideInInspector]
    public int enemyScoreAmount;
    [HideInInspector]
    public int catScoreAmount;

    [HideInInspector]
    public bool witchEnding;
    [HideInInspector]
    public bool catEnding;
    [HideInInspector]
    public bool warriorEnding;
    [HideInInspector]
    public bool druidEnding;

    //for settings
    [HideInInspector]
    public bool fullScreen;
    [HideInInspector]
    public int textureQuality;
    [HideInInspector]
    public int resolutionsIndex;
    [HideInInspector] public float musicVolume;

    //for scene
    [HideInInspector]
    public int sceneID;

}
