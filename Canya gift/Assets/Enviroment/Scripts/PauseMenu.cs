using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
        private Canvas pauseMenuCanvas;
        private float scaleOfTime = 1f;

        [SerializeField] private GameObject PauseMenuPanelObject;

        [Header("Pause selection events")]
        [SerializeField]
        private UnityEvent onSelectResume = default;
        [SerializeField] private UnityEvent onGameIsPaused = default;

        
        [HideInInspector] public static bool gameIsPaused = false;


        private void Awake()
        {
            Resume();
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

        public void Resume()
        {
            gameIsPaused = false;



           
            Time.timeScale = scaleOfTime;
            AudioListener.pause = false;

            onSelectResume.Invoke();
            PauseMenuPanelObject.SetActive(false);
        }

        public void Pause()
        {
            gameIsPaused = true;



        PauseMenuPanelObject.SetActive(true);
         
            Time.timeScale = 0;
            AudioListener.pause = true;

            onGameIsPaused.Invoke();
        }

        public void Restartlevel()
        {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

        public void Quit()
        {

        Application.Quit();
        }
    
}
