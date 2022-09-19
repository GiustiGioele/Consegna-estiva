using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage (int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}