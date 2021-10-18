using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.canvasRenderer.SetAlpha(1.0f);
        fadeout();
    }

   void fadeout()
    {
        image.CrossFadeAlpha(0, 5, false);
        Invoke("HideFadePanel", 5);

    }

    public void HideFadePanel()
    {
        image.enabled = false;
    }

    
}
