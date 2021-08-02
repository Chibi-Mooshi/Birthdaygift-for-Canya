using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UI
{
    //[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public class PauseMenuHandler : MonoBehaviour
    {
        #region Private Fields

        private Canvas pauseMenuCanvas;
        //private CanvasGroup pauseMenuCanvasGroup;
        private float scaleOfTime = 1f;


        #endregion

        #region Public fields

       // [SerializeField] private GameObject PauseMenuUI;
        [SerializeField] private GameObject PauseMenuPanelObject;

        [Header("Pause menu buttons")] [SerializeField]
        private Button resumeGameButton = default;

        [SerializeField] private Button optionsButton = default;
        [SerializeField] private Button quitGameButton = default;

        [Header("Pause selection events")] [SerializeField]
        private UnityEvent onSelectResume = default;

        [SerializeField] private UnityEvent onSelectOptions = default;
        [SerializeField] private UnityEvent onSelectQuit = default;
        [SerializeField] private UnityEvent onGameIsPaused = default;

        [HideInInspector] public static bool gameIsPaused = false;

        #endregion

        #region Event Methods

        private void Start()
        {
           //pauseMenuCanvas = GetComponent<Canvas>();
           // pauseMenuCanvasGroup = GetComponent<CanvasGroup>();

            Resume();
            AddPauseMenuButtonListener();
            
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        #endregion

        #region public methods

        public void Resume()
        {

            gameIsPaused = false;

            PauseMenuPanelObject.SetActive(false);
            //pauseMenuCanvas.enabled = false;
            //pauseMenuCanvasGroup.blocksRaycasts = false;

            // PauseMenuUI.SetActive(false);

            Time.timeScale = scaleOfTime;
            AudioListener.pause = false;
        }

        public void Pause()
        {
           gameIsPaused = true;
           // pauseMenuCanvas.enabled = true;
            PauseMenuPanelObject.SetActive(true);
            //pauseMenuCanvasGroup.blocksRaycasts = true;

            //PauseMenuUI.SetActive(true);

            Time.timeScale = 0;
            AudioListener.pause = true;

            onGameIsPaused.Invoke();

            CallPauseMenuObjectSelection();
        }

        #endregion


        #region private methods

        private void AddPauseMenuButtonListener()
        {
            resumeGameButton.onClick.AddListener(InvokeResumeGame);
            optionsButton.onClick.AddListener(InvokeOptions);
            quitGameButton.onClick.AddListener(InvokeQuitGame);
        }

        private void InvokeResumeGame()
        {
            onSelectResume.Invoke();
        }

        private void InvokeOptions()
        {
            onSelectOptions.Invoke();
        }

        private void InvokeQuitGame()
        {
            onSelectQuit.Invoke();
        }

        private void CallPauseMenuObjectSelection()
        {
            //resumeGameButton.gameObject.SetPauseMenuSelectedObject();
        }

        #endregion


       /* public void Restart()
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } */

        public void Quit()
        {
            
            Application.Quit();
        }
    }
}