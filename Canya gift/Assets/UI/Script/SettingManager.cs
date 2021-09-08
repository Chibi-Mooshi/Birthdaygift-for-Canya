using UnityEngine;
using UnityEngine.UI;

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

    public GameSettings gameSettings;

    private int resolutionValue;

    private void OnEnable()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        //onvalueChanged.Addlistener --> whenever vlaue is changed, a listenr will react immediately
        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        texttureQualityDropdown.onValueChanged.AddListener(delegate { onTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnAudioChange(); });

        //ApplyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolution = Screen.resolutions;

        foreach (Resolution resolution in resolution)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {

        Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolution[resolutionDropdown.value].width, resolution[resolutionDropdown.value].height, Screen.fullScreen);

        resolutionValue = resolutionDropdown.value;
    }

    public void onTextureQualityChange()
    {
        QualitySettings.masterTextureLimit =  texttureQualityDropdown.value; 
    }

    public void OnAudioChange()
    {
        audioSource.volume = musicVolumeSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        gameSettings.fullScreen = Screen.fullScreen;

        gameSettings.resolutionsIndex = resolutionValue;

        gameSettings.musicVolume = audioSource.volume;

        gameSettings.textureQuality = QualitySettings.masterTextureLimit;
    }

    public void LoadSettings()
    {
        musicVolumeSlider.value = gameSettings.musicVolume;
        texttureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionsIndex;
        fullScreenToggle.isOn = gameSettings.fullScreen;

        resolutionDropdown.RefreshShownValue();
    }
}
