using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public float damageAmount = 20;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;

            enemy.GetComponentInChildren<Enemy_health>().TakeDamage(damageAmount);
        }
        else
        {
            GameObject Spawner = collision.gameObject;
            Spawner.GetComponentInChildren<Spawner_health>().TakeDamage(damageAmount);

        }

    }
}

    



