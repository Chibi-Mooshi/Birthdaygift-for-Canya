using UnityEngine;
using UnityEngine.Events;

public class BossMovement : MonoBehaviour
{

    public GameObject spellPrefabShower;

    public GameObject spellPrefabFollow;

    public int spellAmount = 5;

    public UnityEvent onCastSpellShower;


    private int currentSpellSummoned;

    //for timer
    [SerializeField]
    private float timerToCastSpells;
    private float elapsed;

    private void Start()
    {
        currentSpellSummoned = 0;
        castSpellShower();
    }

    public void Update()
    {

        elapsed += Time.deltaTime;
        if (elapsed >= timerToCastSpells)
        {
            elapsed = 0f;
            castSpellShower();
        }
       
    }

    public void castSpellShower()
    {

      

        Debug.Log(currentSpellSummoned);
        if (currentSpellSummoned < spellAmount)
        {
            for (int i = 0; i < 1; ++i)
            {
                GameObject spell;
                spell = Instantiate(spellPrefabShower, transform.position, Quaternion.identity);
                spell.transform.parent = transform;

                currentSpellSummoned++;
            } 
        } else if(currentSpellSummoned == 1)
        {
            onCastSpellShower.Invoke();
        } else if(currentSpellSummoned >= spellAmount)
        {
            currentSpellSummoned = 0;
            followSpell();
        }
    }

    public void followSpell()
    {
        Instantiate(spellPrefabFollow, transform.position, Quaternion.identity);
    }

 
}
