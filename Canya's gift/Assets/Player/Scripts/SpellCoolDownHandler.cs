using UnityEngine;
using UnityEngine.UI;

public class SpellCoolDownHandler : MonoBehaviour
{
    [SerializeField] CoolDownDataHolder coolDownDataHolder;

  

    private Image coolDownBar;

    // Start is called before the first frame update
    void Start()
    {
        coolDownBar = GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
       


        coolDownBar.fillAmount = coolDownDataHolder.spellCoolDown; 

        if (coolDownDataHolder.spellCoolDown > 0)
        {
           
          

            coolDownDataHolder.spellCoolDown -= Time.deltaTime;
        } 
        
        if (coolDownDataHolder.spellCoolDown <= 0)
        {
          
            coolDownDataHolder.spellCoolDown = 0;
          
        }





        
    
      

        //coolDownBar.fillAmount -= 1 / coolDownDataHolder.spellCoolDown * Time.deltaTime;


          
    }

}
        


