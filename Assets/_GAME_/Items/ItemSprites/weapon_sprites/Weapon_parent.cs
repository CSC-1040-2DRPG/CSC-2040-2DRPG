using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_parent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public float offset;  // Added offset variable

    public Animator animator;

    //delay between attack 
    public float delay = 0.3f;

    //flag to block repeated attacks 
    private bool attackBlocked;

    private void Update()
    {
        // Have weapon follow mouse pointer direction
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;

        // calculate the direction of the mouse pointer 
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);


        // adjust the local scale to flip the weapon if needed
        Vector2 scale = transform.localScale;
        if (Mathf.Abs(rotation_z) > 90)
        {
            scale.y = 1; // flip weapon vertically 
        }
        else if (Mathf.Abs(rotation_z) < 90)
        {
            scale.y = 1; //ensure weapon is upright
        }
        transform.localScale = scale;

    }


    public void Attack()
    {
        if (attackBlocked)
        {
            //prevent attack if attack is blocked
            return;
        }
        else
        {
            //trigger animation 
            animator.SetTrigger("WeaponAttack");
            attackBlocked = true;
            StartCoroutine(DelayAttack() );
        }

    }

    private IEnumerator DelayAttack()
    {
        //wait for delay before allowing player to attack again
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

}

    



