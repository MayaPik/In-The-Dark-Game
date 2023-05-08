using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] int baseHealth = 100;

   bool isDead = false;

   public bool IsDead() {
    return isDead;
   }

    public void downLife(int damage) {
        BroadcastMessage("OnDamageTaken");
        baseHealth = baseHealth - damage;
        Debug.Log("ennemylife is" + baseHealth); 
        if (baseHealth <= 0) {
         Die();
        }
    }

    private void Die() {
        if (isDead) return;
        isDead = true;
        Destroy(gameObject);
    }
}
