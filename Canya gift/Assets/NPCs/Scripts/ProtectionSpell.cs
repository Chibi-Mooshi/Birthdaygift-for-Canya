using UnityEngine;

public class ProtectionSpell : MonoBehaviour
{

    public float timerUntilDestroy = 5f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timerUntilDestroy);
    }
}
