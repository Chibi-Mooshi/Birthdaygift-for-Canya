using UnityEngine.Events;
using UnityEngine;

public class EventTester : MonoBehaviour
{

    public UnityEvent testEvent;

   

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Pressing Y");
            testEvent.Invoke();
        }   
    }
}
