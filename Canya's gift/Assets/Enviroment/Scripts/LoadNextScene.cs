using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    [Tooltip("What scene should load? Check build settings"),SerializeField] private int sceneToLoad;

    [SerializeField] private UnityEvent onCollisionWithSceneManager;

    
   

  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        onCollisionWithSceneManager.Invoke();
    } */

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
