using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float dmgAmount = 10f;
    private PlayerHealth health;
    public void DamageEvent()
    {
        health = FindObjectOfType<PlayerHealth>();
        health.Damage(dmgAmount);
    }
}
