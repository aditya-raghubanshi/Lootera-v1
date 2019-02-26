using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    // Start is called before the first frame update
    private float mana;
    private float maxMana;
    Image manaBar;

    void Start()
    {
        manaBar = GetComponent<Image>();
        mana = 100f;
        maxMana = 100f;
    }
    public PlayerMana(float mana = 100f)
    {
        this.mana = mana;
        this.maxMana = mana;
    }

    public float Getmana()
    {
        return mana;
    }

    public void Damage(int spentAmount)
    {
        mana -= spentAmount;
        if (mana < 0)
        {
            mana = 0;
        }
        manaBar.fillAmount = mana / maxMana;
    }

    public void Heal(int recoverAmount)
    {
        mana += recoverAmount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        manaBar.fillAmount = mana / maxMana;
    }
}
