using UnityEngine;

public class CompanionChoiceHandler : MonoBehaviour
{
   public ChoiceHolderScriptableObject choice;

    public void onChoosingWarrior()
    {
        choice.hasWarrior = true;
    }

    public void onChoosingDruid()
    {
        choice.hasDruid = true;
    }


    public void isAlone()
    {
        choice.isAlone = true;
    }





}
