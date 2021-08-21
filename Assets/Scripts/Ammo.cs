using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    //[SerializeField] private int _ammoAmmunt = 10;
    [SerializeField] private AmmoSlot[] ammoSlots; //199

    //199
    [Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    // Start is called before the first frame update
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        // return _ammoAmount; // 10
        return GetAmmoSlot(ammoType).ammoAmount; // 200
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        // _ammoAmount--; // 10
        GetAmmoSlot(ammoType).ammoAmount--; // 200
    }

    //203
    public void IncreaseAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount; // 200
    }

    // 200
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
