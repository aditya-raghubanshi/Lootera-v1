using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemController : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth health;
    PlayerMana mana;
    public int maxHealth = 1000;
    public int maxMana = 1000;
    private GameObject healthBar;
    private GameObject manaBar;
    void Start()
    {
        health = new PlayerHealth(maxHealth);
        mana = new PlayerMana(maxMana);
        healthBar = GameObject.Find("Healthbar");
        manaBar = GameObject.Find("Manabar");

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
