using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string unitName;
    public float damage;
    public int maxHP;
    public float currentHP;
    [SerializeField] Models models;

    private void Start()
    {
        damage = models.damage;

    }

    public bool TakeDamage (float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}
