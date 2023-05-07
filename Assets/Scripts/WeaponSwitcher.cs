using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int current = 0;
    void Start()
    {
        SetWeaponActive();
    }

    void Update() {
        int previous = current;

        ProcessKeyInput();
        if (previous != current) {
            SetWeaponActive();
        }

    }
    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == current) {
                weapon.gameObject.SetActive(true);
            } else {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    void ProcessKeyInput() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            current = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            current = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            current = 2;
        }
    }
}
