using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoint = 100f;
    bool isDead = false;
    ZombieNum zKill;
    private void Start()
    {
        zKill = FindObjectOfType<ZombieNum>();
    }

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoint -= damage;
        if(hitPoint<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        zKill.ZombieKill();
    }
}
