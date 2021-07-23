using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance; //if there is no dialogue on the character, then nothing happens. By playing instance, you reference the dialoguemanager
    private void Awake()
    {

        DialogueBox = GameObject.Find("DialogueBox");
        DialogueName = GameObject.Find("CharacterName").GetComponent<Text>();
        DialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        DialogueImage = GameObject.Find("DialogueImage").GetComponent<Image>();

        DialogueBox.SetActive(false);

        if (Instance != null)
        {

        }
        else
        {
            Instance = this;
        }
    }

    public GameObject DialogueBox;
    //private GameObject DialogueBox;

    public Text DialogueName;
    public Text DialogueText;
    public Image DialogueImage;
    //private Text DialogueName;
    //private Text DialogueText;

    public float delay = 0.01f;

    // for auto text
    private bool isCurrentlyTyping;
    private string completeText;
    
    public bool inDialogue;

    public UnityEvent onDialogueEnd;
    public UnityEvent onDialogueOpen;


    //for event
    public delegate void OnDialogueLineCallBack(int dialogueLine);
    public OnDialogueLineCallBack onDialogueLineCallBack;
    public int TotalLineCount;


    //for buffing text
    private bool Buffer;


    public Queue<Dialogue.Info> dialogueInfo = new Queue<Dialogue.Info>(); //First in first out

    private void Start()
    {
       

   
    }

    public void EnqueueDialogue(Dialogue db) //makes it take the dialogue information and place it in a qeueu
    {

        if (inDialogue) { return; }
        inDialogue = true;


        //for buffing
        Buffer = true;
        StartCoroutine(BufferTime());




        DialogueBox.SetActive(true);

        dialogueInfo.Clear();

        

        foreach (Dialogue.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        //for events
        TotalLineCount = dialogueInfo.Count;


        DequeueDialogue();
    }

    public void DequeueDialogue() // this is for displaying the dialogue
    {



        //if currently typing,

        if (isCurrentlyTyping == true)
        {
            //for buffing 
            if (Buffer == true) return;



            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }


        Dialogue.Info info = dialogueInfo.Dequeue();


        //for event
        if (onDialogueLineCallBack != null)
        {
            onDialogueLineCallBack.Invoke(TotalLineCount - dialogueInfo.Count);
        }

        //for auto type
        completeText = info.myText;

        DialogueName.text = info.myName;
        DialogueImage.sprite = info.myImage;
        DialogueText.text = info.myText;

        //for auto text
        DialogueText.text = "";

        StartCoroutine(TypeText(info));
    }

    //for typing the text
    IEnumerator TypeText(Dialogue.Info info)
    {
        //for auto text
        isCurrentlyTyping = true;
        foreach (char letter in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            DialogueText.text += letter;

            //for playing voice clip
            AudioManager.instance.PlayClip(info.myVoice);

            yield return null;
        }
        isCurrentlyTyping = false;
    }

    //for buffing text
    IEnumerator BufferTime()
    {
        yield return new WaitForSeconds(0.1f);
        Buffer = false;
    }


    private void CompleteText()
    {
        DialogueText.text = completeText;
    }

    public void EndDialogue()
    {
        DialogueBox.SetActive(false);

        onDialogueEnd.Invoke();

        inDialogue = false;

        onDialogueOpen.Invoke();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (inDialogue)
            {
                DequeueDialogue();
            }
        }
    }

    
}
