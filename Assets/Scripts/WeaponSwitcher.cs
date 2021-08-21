using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    //197
    [SerializeField] private int _currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        //197
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //198
        int previousWeapon = _currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != _currentWeapon)
        {
            SetWeaponActive();
        }
    }

    //198
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // press 1 down from keyboard
        {
            _currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // press 2 down from keyboard
        {
            _currentWeapon = 1;
        }
    }

    //198
    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_currentWeapon >= transform.childCount - 1)
            {
                _currentWeapon = 0;
            }
            else
            {
                _currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_currentWeapon <= 0)
            {
                _currentWeapon = transform.childCount - 1;
            }
            else
            {
                _currentWeapon--;
            }
        }
    }
}
