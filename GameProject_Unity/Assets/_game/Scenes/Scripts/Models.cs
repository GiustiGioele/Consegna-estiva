using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Models", menuName = "Models")]
public class Models : ScriptableObject
{
    public string Name;
    public string Type;
    public float HP;
    public float MP;
    public enum abilities { Slot1, Slot2, Slot3, Slot4 };
    public GameObject Character;
}
