using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject[] spellPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CastSpell();
        }
    }

   public void CastSpell()
    {

       Instantiate(spellPrefab[0], transform.position, Quaternion.identity);

        
        Spell spell = spellObject.GetComponent<Spell>();

        spell.Launch(Vector2.left, 300);
        
    }


    /*

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.1f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();

        if (facingLeft == true)
        {
            projectile.Launch(Vector2.left, 300);
        }
        else if (facingLeft == false)
        {
            projectile.Launch(Vector2.right, 300);
        }
    */

    

}
