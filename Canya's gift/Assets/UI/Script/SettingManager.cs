using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour
{

    public static SettingManager instance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }



    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown texttureQualityDropdown;
    public Slider musicVolumeSlider;

    public Button ApplyButton;

    public Resolution[] resolution;

    private AudioSource audioSource;

    private GameSettings gameSettings;

    private void OnEnable()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        gameSettings = new GameSettings();

        //onvalueChanged.Addlistener --> whenever vlaue is changed, a listenr will react immediately
        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        texttureQualityDropdown.onValueChanged.AddListener(delegate { onTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnAudioChange(); });

        ApplyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolution = Screen.resolutions;

        foreach (Resolution resolution in resolution)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
        {
            LoadSettings();
        }

       // LoadSettings();

    }

    public void OnFullscreenToggle()
    {

       gameSettings.fullScreen = Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolution[resolutionDropdown.value].width, resolution[resolutionDropdown.value].height, Screen.fullScreen);

        gameSettings.resolutionsIndex = resolutionDropdown.value;
    }

    public void onTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = texttureQualityDropdown.value;
        
    }

    public void OnAudioChange()
    {
        audioSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gameSettings",jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gameSettings"));
       
        musicVolumeSlider.value = gameSettings.musicVolume;
        texttureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionsIndex;
        fullScreenToggle.isOn = gameSettings.fullScreen;

        resolutionDropdown.RefreshShownValue();
    }


}
