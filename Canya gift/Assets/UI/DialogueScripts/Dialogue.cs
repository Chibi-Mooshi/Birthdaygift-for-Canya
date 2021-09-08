using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string myName;
        [TextArea(4, 8)]
        public string myText;
        public AudioClip myVoice;

        public UnityEvent dialogueEvent;

    }
    [Header("Insert text below")]
    public Info[] dialogueInfo;

}
