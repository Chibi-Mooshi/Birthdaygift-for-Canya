using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndingImageForMainMenuHolder : MonoBehaviour
{
    public CheckEndingScriptableObject endingImage;

    [Space(10)]
    [Header("Druid")]
    public Image druidImageHolder;
    public Sprite druidEndingImage;
    public UnityEvent onDruidEndingUnlock;

    [Space(10)]
    [Header("Warrior")]
    public Image warriorImageHolder;
    public Sprite warriorEndingImage;
    public UnityEvent onWarriorEndingUnlock;

    [Space(10)]
    [Header("Witch")]
    public Image witchImageHolder;
    public Sprite witchEndingImage;
    public UnityEvent onWitchEndingUnlock;

    [Space(10)]
    [Header("Self")]
    public Image selfImageHolder;
    public Sprite selfEndingImage;
    public UnityEvent onSelfEndingUnlock;

    private void Start()
    {
        if (endingImage.withDruid) //druid
        {
            druidImageHolder.sprite = druidEndingImage;
            druidImageHolder.preserveAspect = true;
            onDruidEndingUnlock.Invoke();
        }

        if (endingImage.withWarrior) //warrior
        {
            druidImageHolder.sprite = warriorEndingImage;
            druidImageHolder.preserveAspect = true;
            onWarriorEndingUnlock.Invoke();
        }

        if (endingImage.withSelf) //self
        {
            druidImageHolder.sprite = selfEndingImage;
            druidImageHolder.preserveAspect = true;
            onSelfEndingUnlock.Invoke();
        }

        if (endingImage.withWitch) //witch
        {
            druidImageHolder.sprite = witchEndingImage;
            druidImageHolder.preserveAspect = true;
            onWitchEndingUnlock.Invoke();
        }
    }

}
