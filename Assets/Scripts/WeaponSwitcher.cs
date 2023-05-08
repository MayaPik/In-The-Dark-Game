using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
                int weaponLength;

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
          weaponLength = transform.childCount;
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
        if(Input.GetKeyDown(KeyCode.RightShift)) {
            current++;
            if (current == weaponLength) {
                current = 0;
        } 
        }
    }
}
