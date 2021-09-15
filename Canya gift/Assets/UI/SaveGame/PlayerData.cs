
[System.Serializable]
public class PlayerData
{
    public int newlevel;
    public int newhealth;

    public int newenemyScoreAmount;
    public int newcatScoreAmount;

    public bool newwitchEnding;
    public bool newcatEnding;
    public bool newwarriorEnding;
    public bool newdruidEnding;

    //for settings
    public bool newfullScreen;
    public int newtextureQuality;
    public int newresolutionsIndex;
    public float newmusicVolume;


    //for scene
    public int newsceneID;

    public PlayerData (PlayerStats player)
    {


        newenemyScoreAmount = player.enemyScoreAmount;


       newcatScoreAmount = player.catScoreAmount;

        newwitchEnding = player.witchEnding;
        newcatEnding = player.catEnding;
        newwarriorEnding = player.warriorEnding;
        newdruidEnding = player.druidEnding;

        //for settings
        newfullScreen = player.fullScreen;
         newtextureQuality = player.textureQuality;
        newresolutionsIndex = player.resolutionsIndex;
        newmusicVolume = player.musicVolume;


        newsceneID = player.sceneID;

    }
}
