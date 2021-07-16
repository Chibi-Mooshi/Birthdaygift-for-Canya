using UnityEngine;

public class DialogueTrigger : Interactable
{
    public Dialogue[] dialogue;

    //for more dialogue
    [HideInInspector] public int index;
    public bool NextDialogueOnInteract;

    public override void Interact()
    {
        if (NextDialogueOnInteract && !DialogueManager.Instance.inDialogue)
        {
            Debug.Log("We got called");
            DialogueManager.Instance.EnqueueDialogue(dialogue[index]);

            if (index < dialogue.Length - 1)
            {
                index++;
            }

            //new code to test
            if (DialogueManager.Instance.inDialogue && Input.GetKeyDown(KeyCode.Z))
            {
                DialogueManager.Instance.DequeueDialogue();
            }
        }
        else
        {
            DialogueManager.Instance.EnqueueDialogue(dialogue[index]);
        }
    }

} 