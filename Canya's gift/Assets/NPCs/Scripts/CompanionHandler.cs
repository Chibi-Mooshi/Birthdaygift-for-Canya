using UnityEngine;

public class CompanionHandler : MonoBehaviour
{

    public Sprite DruidSprite;
    public Sprite WarriorSprite;

    public ChoiceHolderScriptableObject choice;

    private SpriteRenderer spriteRender;

    public GameObject player;

    public GameObject shieldSpellFromWarrior;
    public GameObject shieldSpellFromDruid;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        spriteRender = GetComponent<SpriteRenderer>();
    }


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


    private void DruidHandler()
    {
       GameObject protectionSpell = Instantiate(shieldSpellFromDruid, player.transform.position, Quaternion.identity);

        protectionSpell.transform.parent = player.transform;
    }

    private void WarriorHandler()
    {
       GameObject protectionSpell = Instantiate(shieldSpellFromWarrior, player.transform.position, Quaternion.identity);
        protectionSpell.transform.parent = player.transform;
    }

   

}
