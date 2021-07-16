using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DialogueTrigger))]
public class DialogueEvent : Interactable
{
    [Header("Target Info")]
    public int dialogueIndex;
    public int dialogueLine;

    public bool hasAddedEvent;

    public UnityEvent unityEvent;

    private DialogueTrigger dialogueTrigger;

    // private bool hasAddedEvent;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        InteractRange = dialogueTrigger.InteractRange;
    }

    public override void Interact()
    {
        if (hasAddedEvent = false || DialogueManager.Instance.inDialogue) return;

        if (dialogueTrigger.index == dialogueIndex)
        {
            DialogueManager.Instance.onDialogueLineCallBack += PlayEvent;
            hasAddedEvent = true;
        }
        //play event
        base.Interact();
    }

    public void PlayEvent(int line)
    {
        if (line == dialogueLine)
        {
            unityEvent.Invoke();
            DialogueManager.Instance.onDialogueLineCallBack -= PlayEvent;
        }
    }
}



