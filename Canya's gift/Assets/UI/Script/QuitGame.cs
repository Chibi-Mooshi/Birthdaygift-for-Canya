using UnityEngine;

public class QuitGame : MonoBehaviour
{
   public void ExitGame()
    {
        Debug.Log("End game");
        Application.Quit();
    }
}
