using UnityEngine;
using UnityEngine.Events;


public class MouseCursorHandler : MonoBehaviour
{

    private void Start()
    {
        CursorLocked();

    }


    public void CursorUnlocked()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void CursorLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
  
    }


}
