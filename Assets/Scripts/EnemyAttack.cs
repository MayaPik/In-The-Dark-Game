using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
   [SerializeField] float damage = 25f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (!target) return;
        target.GetComponent<PlayerHealth>().SetPlayerLife(damage);
        target.GetComponent<DispayDamage>().ShowDamage();
    }
}
