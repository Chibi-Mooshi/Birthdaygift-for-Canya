using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
   public void ExitGame()
    {
        Debug.Log("End game");
        Application.Quit();
    }

    public void Restartlevel()
    {
        Debug.Log("Load scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
