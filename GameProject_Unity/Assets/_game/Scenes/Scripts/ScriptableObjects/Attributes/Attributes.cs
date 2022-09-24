using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttribute", menuName = "Attributes")]

public class Attributes : ScriptableObject
{
    public string attributeName;
    public List <Attributes> weakness;

}
