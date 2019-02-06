using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    private int maxHealth;
    public PlayerHealth(int health)
    {
        this.health = health;
        this.maxHealth = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if(health < 0)
        {
            health = 0;
        }
    }

    public void Heal(int HealAmount)
    {
        health += HealAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
