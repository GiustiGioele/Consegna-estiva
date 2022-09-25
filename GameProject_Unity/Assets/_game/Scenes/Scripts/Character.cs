using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string unitName;
    public float damage;
    public float maxHP;
    public float currentHP;
    public Attributes attribute;
     
    [SerializeField] Models models;

    private void Start()
    {
        damage = models.damage;
        maxHP = models.maxHp; 
        currentHP = models.currentHP;
        attribute = models.attribute;
        unitName = models.name;


    } 

    public void TakeDamage (float damage, Attributes attributedmg)   
    {
        if (attribute.weakness.Contains(attributedmg))
        {
           currentHP -= damage * 1.5f;
        }
         else if (attributedmg.weakness.Contains(attribute)) //la debolezza dell'attacco è il mio elemento mi fa la metà x0.5
         {
          currentHP -= damage * 0.5f;
         }
         else
         {
          currentHP -= damage;
         }

        if (currentHP <= 0)
        {
            Die();
        }
    }
       public void Die()
       {
        Destroy(gameObject);
       }
    
}
