using UnityEngine;

public class DebugEnding : MonoBehaviour
{
   public  CheckEndingScriptableObject ending;

    public void Update()
    {
       if ( Input.GetKeyDown(KeyCode.F))
        {
            ending.withWitch = true;
        }
    }
}
