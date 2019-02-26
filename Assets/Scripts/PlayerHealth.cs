using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    private float maxHealth;
    private Image healthbar;

    void Start()
    {
        healthbar = GetComponent<Image>();
        health = 100f;
        maxHealth = 100f;
        
    }
    public PlayerHealth(float health = 100f)
    {
        this.health = health;
        this.maxHealth = health;
    }

    public float GetHealth()
    {
        return health;
    }

    public void Damage(float damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
        {
            health = 0;
        }
        healthbar.fillAmount = health / maxHealth;
    }

    public void Heal(float HealAmount)
    {
        health += HealAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthbar.fillAmount = health / maxHealth;
    }
}
