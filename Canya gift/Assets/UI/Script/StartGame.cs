using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
public class StartGame : MonoBehaviour
{


    [Header("Pause menu buttons")]
    [SerializeField] private Button startGameButton = default;
  //  [SerializeField] private Button optionsButton = default;
    [SerializeField] private Button quitGameButton = default;

    [Header("Pause selection events")]
    [SerializeField]
    private UnityEvent onSelectStart = default;

    //[SerializeField] private UnityEvent onSelectOptions = default;
    [SerializeField] private UnityEvent onSelectQuit = default;

    [HideInInspector] public static bool gameIsPaused = false;

    #region Event Methods

    private void Start()
    {
        AddPauseMenuButtonListener();
    }

    #endregion

    #region private methods

    private void AddPauseMenuButtonListener()
    {
        startGameButton.onClick.AddListener(InvokeStartGame);
       // optionsButton.onClick.AddListener(InvokeOptions);
        quitGameButton.onClick.AddListener(InvokeQuitGame);
    }

    private void InvokeStartGame()
    {
        onSelectStart.Invoke();
    }

    /*
    private void InvokeOptions()
    {
        onSelectOptions.Invoke();
    } */

    private void InvokeQuitGame()
    {
        onSelectQuit.Invoke();
    }

    private void CallPauseMenuObjectSelection()
    {
        //resumeGameButton.gameObject.SetPauseMenuSelectedObject();
    }

    #endregion

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {

        Application.Quit();
    }

}


