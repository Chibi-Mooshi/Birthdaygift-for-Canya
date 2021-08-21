using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

  

    [SerializeField] private UnityEvent onCollisionWithSceneManager;

    
   

  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        onCollisionWithSceneManager.Invoke();
    } */

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
