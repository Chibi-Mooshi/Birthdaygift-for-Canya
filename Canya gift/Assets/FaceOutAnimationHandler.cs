using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FaceOutAnimationHandler : MonoBehaviour
{
    public UnityEvent onAfterFadeOut;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        animator.enabled = true;
        StartCoroutine(LoadFadeOut());
     
        
    }

    IEnumerator LoadFadeOut()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length + 0f);
        onAfterFadeOut.Invoke();
    }
}
