using UnityEngine;
using UnityEngine.Events;

public class CheckEndingHandler : MonoBehaviour
{
    public CheckEndingScriptableObject ending;
    public CheckEndingScriptableObject endingHolder;

    public ChoiceHolderScriptableObject choice;

    public Dialogue[] dialogueWithWarrior;
    public Dialogue[] dialogueWithDruid;
    public Dialogue[] dialogueWithSelf;

    private DialogueTrigger dialogueTrigger;

    public UnityEvent withWarriorEnding;
    public UnityEvent withDruidEnding;
    public UnityEvent withSelfEnding;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void CheckEnding() {
   
       if (choice.hasDruid)
        {
            ending.withDruid = true;
            dialogueTrigger.dialogue = dialogueWithDruid;
            endingHolder.withDruid = true;
            withDruidEnding.Invoke();
        } else if (choice.hasWarrior)
        {
            ending.withWarrior = true;
            dialogueTrigger.dialogue = dialogueWithWarrior;
            endingHolder.withWarrior = true;
            withWarriorEnding.Invoke();
        } else if (choice.isAlone)
        {
            ending.withSelf = true;
            dialogueTrigger.dialogue = dialogueWithSelf;
            endingHolder.withSelf = true;
            withSelfEnding.Invoke();

        }
    
    }


    public void EndingWithWitch()
    {
        ending.withWitch = true;
        endingHolder.withWitch = true;
    }

}