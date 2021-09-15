using UnityEngine;
using UnityEngine.Events;
public class SaveGameAtStartLevel : MonoBehaviour
{
    public UnityEvent onStartGame;

    // Start is called before the first frame update
    void Start()
    {
        onStartGame.Invoke();
    }

    
}
