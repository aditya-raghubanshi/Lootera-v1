﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{
    public float healAmount = 10;
    public float manaUse = 20;
    private PlayerHealth health;
    private PlayerMana mana;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        mana = FindObjectOfType<PlayerMana>();

    }

    public void heal()
    {
        if (mana.Getmana() < manaUse)
        {
            //Not Enough Mana
            return ;
        }
        health.Heal(healAmount);
        mana.Damage(manaUse);
    }
    
}
