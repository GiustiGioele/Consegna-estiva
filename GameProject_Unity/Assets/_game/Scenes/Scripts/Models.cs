using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Models", menuName = "Models")]
public class Models : ScriptableObject
{
    public string Name;
    public float HP;
    public float MP;
    public GameObject spriteElement;
    public enum abilities { Slot1, Slot2, Slot3, Slot4 };
    public GameObject Character;
}
