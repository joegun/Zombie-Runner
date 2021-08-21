using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // 6
    [SerializeField] private float hitPoints = 100f;

    // 6 challenge: create a public method which reduces hitpoints by the amount of damage
    public void TakeDamage(float damage)
    {
        //GetComponent<EnemyAI>().OnDamageTaken();
        BroadcastMessage("OnDamageTaken"); // to trigger the enemy to come over after got hit, which to use broadcast message

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
