using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // 10
    [SerializeField] private Transform target;
    [SerializeField] private float damage = 40f;

    // 13
    //private PlayerHealth playerHealthTarget;

    void Start()
    {
        // 13
        //playerHealthTarget = FindObjectOfType<PlayerHealth>();
    }

    // just to test that we can use this with the broadcast message
    //public void OnDamageTaken()
    //{
    //    Debug.Log(name + " I also take a damage");
    //}

    public void AttackHitEvent()
    {
        // 11
        if (target == null) return;
        Debug.Log("Attack Attack");

        // 12
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
