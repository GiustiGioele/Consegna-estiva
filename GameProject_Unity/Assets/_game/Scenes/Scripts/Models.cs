using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Models", menuName = "Models")]
public class Models : ScriptableObject
{
    public string Name;
    public float maxHp;
    public float damage;
    public float specialDamage;
    public float currentHP;
    
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    
    public GameObject Character;

    public Attributes attribute;
}
