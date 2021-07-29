using UnityEngine;


[CreateAssetMenu(menuName = "Setting File")]
//this is a blueprint for the settingsfile
public class GameSettings : ScriptableObject
{
    public bool fullScreen;
    public int textureQuality;
    public int resolutionsIndex;
    public float musicVolume;
}
