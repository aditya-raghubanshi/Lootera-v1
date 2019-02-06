using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    // Start is called before the first frame update
    private int mana;
    private int maxMana;
    public PlayerMana(int mana)
    {
        this.mana = mana;
        this.maxMana = mana;
    }

    public int Getmana()
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
    }

    public void Heal(int recoverAmount)
    {
        mana += recoverAmount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }
}
