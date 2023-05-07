using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] float baseHealth = 100f;
   
    public void SetPlayerLife(float damage) {
        baseHealth = baseHealth - damage;        
        if (baseHealth <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }


}
