using UnityEngine;

[CreateAssetMenu (menuName = "CoolDowns/New Cool Down Data")]
public class CoolDownDataHolder : ScriptableObject
{
    public float spellCoolDown;

    private void OnEnable()
    {
        spellCoolDown = 0;
    }
}
