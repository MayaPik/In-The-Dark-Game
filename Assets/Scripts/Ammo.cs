using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
   [SerializeField] AmmoSlot[] AmmoSlots;

   [System.Serializable]
   private class AmmoSlot 
   {
     public AmmoType ammoType;
     public int ammoAmount;
   }

   public int ReturnAmmoAmount(AmmoType ammoType) {
    return GetAmmoSlot(ammoType).ammoAmount;
   }
   public void DecreaseAmmo(AmmoType ammoType) {
    GetAmmoSlot(ammoType).ammoAmount--;
   }
public void IncreaseAmmo(AmmoType ammoType, int ammoAmount) {
    GetAmmoSlot(ammoType).ammoAmount+= ammoAmount;
   }

   private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
    foreach (AmmoSlot slot in AmmoSlots)
    {
        if (slot.ammoType == ammoType) {
            return slot;
        }
    }
       return null;
   }
}
