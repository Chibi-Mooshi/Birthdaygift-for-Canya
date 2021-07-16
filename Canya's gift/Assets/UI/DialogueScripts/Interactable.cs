using UnityEngine;

public class Interactable : MonoBehaviour
{

    //his is a singular script which you can have other script derive from. it allows scripts to use this to interact with other objects
    public float InteractRange;

    public GameObject DialoguePoint;

    public GameObject player;

    private void Awake()
    {
        // player = GameObject.FindObjectOfType<PlayerBehavior>().gameObject;
       // player = GameObject.Find("PlayerManager").GetComponent<SwitchingCharacterHandler>().currentPlayer;
    }

    private void Update()
    {
        player = GameObject.Find("Player");

        DialoguePoint.SetActive(false);

        if (Vector2.Distance(gameObject.transform.position, player.transform.position) < InteractRange)
        {
            
            DialoguePoint.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Interact();
            }
        }

       

        
    }

    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InteractRange);
    }


}

