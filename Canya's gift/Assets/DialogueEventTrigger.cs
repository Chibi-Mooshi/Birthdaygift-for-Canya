using UnityEngine;


[RequireComponent(typeof(DialogueTrigger))]
public class DialogueEventTrigger : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    private int dialogueTriggerIndex;

    // private bool hasAddedEvent;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();

    }

    private void Update()
    {
        
    }


    public void PlayEvent()
    {
      var dialogueLength =  dialogueTrigger.dialogue;

       
       
    }


}
