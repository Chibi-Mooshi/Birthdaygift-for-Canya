using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndingCutSceneHandler : MonoBehaviour
{
    private Image endingImage;

    public CheckEndingScriptableObject ending;
    [Space(10)]
    [Header("Add different images below")]
    public Sprite endingWithDruid;
    public Sprite endingWithWarrior;
    public Sprite endingWithWitch;
    public Sprite endingWithSelf;

    [Space(10)]
    [Header("Dialogue for the endings")]
    public Dialogue[] dialogueWithWarrior;
    public Dialogue[] dialogueWithDruid;
    public Dialogue[] dialogueWithSelf;
    public Dialogue[] dialogueWithWitch;

    private DialogueTrigger dialogueTrigger;


    [Space(10)]
    [Header("Unityevent for the endings")]
    public UnityEvent endingDialogue;
  

    private void Awake()
    {
        endingImage = GetComponent<Image>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Start()
    {
        if (ending.withDruid) //druid
        {
            endingImage.sprite = endingWithDruid;
            dialogueTrigger.dialogue = dialogueWithDruid;
            endingDialogue.Invoke();

        } else if (ending.withWarrior) //warrior
        {
            endingImage.sprite = endingWithWarrior;
            dialogueTrigger.dialogue = dialogueWithWarrior;
            endingDialogue.Invoke();

        } else if (ending.withSelf) //self
        {
            endingImage.sprite = endingWithSelf;
            dialogueTrigger.dialogue = dialogueWithSelf;
            endingDialogue.Invoke();

        } else if (ending.withWitch) //witch
        {
            endingImage.sprite = endingWithWitch;
            dialogueTrigger.dialogue = dialogueWithWitch;
            endingDialogue.Invoke();
        }
    }

   
}
