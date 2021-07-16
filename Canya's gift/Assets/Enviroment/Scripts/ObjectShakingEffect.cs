using System.Collections;
using UnityEngine;

public class ObjectShakingEffect : MonoBehaviour
{
    public float shakeTime = 0.1f;
    public float shakeRange;

    public void ShakeMe()
    {
        StartCoroutine(ShakeNow());
    }

    IEnumerator ShakeNow()
    {

        float elapsed = 0.0f;
        Quaternion originalRotation = gameObject.transform.rotation;

        while (elapsed < shakeTime)
        {
            elapsed += Time.deltaTime;
            float z = Random.value * shakeRange - (shakeRange / 2);
            this.transform.eulerAngles = new Vector3(originalRotation.x, originalRotation.y, originalRotation.z + z);
            yield return null;
        }

        gameObject.transform.rotation = originalRotation;
    }
}
