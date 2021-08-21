using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //203
    [SerializeField] private int ammoAmount = 5;
    [SerializeField] private AmmoType ammoType = AmmoType.Bullets;

    //203
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player did what the player do");
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
