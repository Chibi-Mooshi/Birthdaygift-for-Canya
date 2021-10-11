using UnityEngine;

public class CompanionHandler : MonoBehaviour
{

    public GameObject DruidSprite;
    public GameObject WarriorSprite;

    public ChoiceHolderScriptableObject choice;

    public GameObject player;

    public GameObject shieldSpellFromWarrior;
    public GameObject shieldSpellFromDruid;

    private Animator druidAnimator;
    private Animator warriorAnimator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        druidAnimator = DruidSprite.GetComponent<Animator>();
        warriorAnimator = WarriorSprite.GetComponent<Animator>();
    }


    void Start()
    {
       if (choice.hasDruid)
        {
            DruidSprite.SetActive(true);
        } else if (choice.hasWarrior)
        {
            WarriorSprite.SetActive(true);
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
        druidAnimator.SetTrigger("Protect");
       GameObject protectionSpell = Instantiate(shieldSpellFromDruid, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);

        protectionSpell.transform.parent = player.transform;
        druidAnimator.SetTrigger("Idle");
    }

    private void WarriorHandler()
    {
        warriorAnimator.SetTrigger("Protect");
        GameObject protectionSpell = Instantiate(shieldSpellFromWarrior, player.transform.position, Quaternion.identity);
        protectionSpell.transform.parent = player.transform;
        warriorAnimator.SetTrigger("Idle");
    }

   

}
