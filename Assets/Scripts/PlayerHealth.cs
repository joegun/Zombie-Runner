using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // 6
    [SerializeField] private float hitPoints = 100f;

    // 6 challenge: create a public method which reduces hitpoints by the amount of damage
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            //Destroy(gameObject);
            Debug.Log("Player dead");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
