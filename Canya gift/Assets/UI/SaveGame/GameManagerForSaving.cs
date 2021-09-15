using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManagerForSaving : MonoBehaviour
{
    public PlayerStats saveObject;

    public ScoreScriptableObject enemyScore;
    public ScoreScriptableObject catScore;

    public CheckEndingScriptableObject endings;


    public GameSettings settings;

    public int sceneID;

    public UnityEvent onSaveFileCreated;

    public void SavePlayer() //make an event lead to this
    {
;



        saveObject.enemyScoreAmount = enemyScore.scoreAmount;
        saveObject.catScoreAmount = catScore.scoreAmount;

        saveObject.witchEnding = endings.withWitch;
        saveObject.catEnding = endings.withSelf;
        saveObject.warriorEnding = endings.withWarrior;
        saveObject.druidEnding = endings.withDruid;

        saveObject.fullScreen = settings.fullScreen;
        saveObject.textureQuality = settings.textureQuality;
        saveObject.resolutionsIndex = settings.resolutionsIndex;
        saveObject.musicVolume = settings.musicVolume;


        saveObject.sceneID = SceneManager.GetActiveScene().buildIndex;


        SaveSystem.SavePlayer(saveObject);

        



    }


    public void LoadPlayer() // make an event lead to this
    {
        PlayerData data = SaveSystem.LoadPlayer();


        enemyScore.scoreAmount = data.newenemyScoreAmount;
        catScore.scoreAmount = data.newcatScoreAmount;

        endings.withDruid = data.newdruidEnding;
        endings.withWarrior = data.newwarriorEnding;
        endings.withSelf = data.newcatEnding;
        endings.withWitch = data.newwitchEnding;

        settings.fullScreen = data.newfullScreen;
        settings.textureQuality = data.newtextureQuality;
        settings.resolutionsIndex = data.newresolutionsIndex;
        settings.musicVolume = data.newmusicVolume;

        SceneManager.LoadScene(data.newsceneID);


}


    public void UnlockContinueGame()
    {
        string path = Application.persistentDataPath + "/gamesave.save";
        if (File.Exists(path))
        {
            onSaveFileCreated.Invoke();
        }

    }

    public void ResetSaveFile()
    {
        string path = Application.persistentDataPath + "/gamesave.save";
        if (File.Exists(path))
        {
            PlayerData data = SaveSystem.LoadPlayer();


            data.newenemyScoreAmount = 0;
            data.newcatScoreAmount = 0;

        }
    }

}
