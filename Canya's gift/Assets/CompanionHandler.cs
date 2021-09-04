using UnityEngine;

public class CompanionHandler : MonoBehaviour
{

    public Sprite DruidSprite;
    public Sprite WarriorSprite;

    public ChoiceHolderScriptableObject choice;

    private SpriteRenderer spriteRender;

    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
       if (choice.hasDruid)
        {
            spriteRender.sprite = DruidSprite;
        } else if (choice.hasWarrior)
        {
            spriteRender.sprite = WarriorSprite;
        } else
        {
            gameObject.SetActive(false);
        }
    }


    public void ProtectPlayer()
    {
        if (choice.hasDruid)
        {
            DruidHandler();
        }
        else if (choice.hasWarrior)
        {
            WarriorHandler();
        }
    }


    public void DruidHandler()
    {

    }

    public void WarriorHandler()
    {

    }

   

}
