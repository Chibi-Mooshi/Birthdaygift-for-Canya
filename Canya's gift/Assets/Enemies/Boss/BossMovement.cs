using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public GameObject spellPrefab;
  

    public void castSpellShower()
    {
        for (int i = 0; i < 5; ++i)
        {
            Instantiate(spellPrefab, new Vector3(0, i * 5, 0), Quaternion.identity);
        }
    }

 
}
