using UnityEngine;
using UnityEngine.Events;

public class MouseCursorMovement : MonoBehaviour
{

    public UnityEvent onStartGame;

    void Start()
    {

        onStartGame.Invoke();
    }

   
}
