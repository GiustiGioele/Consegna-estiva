using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Models[] Models;
    public Transform Spot;

    private List<GameObject> characters;
    private int currentCharacter;
     void Start()
    {
        characters = new List<GameObject>(); 

        foreach (var Models in Models)
        {
            GameObject go = Instantiate(Models.Character, Spot.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(Spot);
            characters.Add(go);
        }
        ShowCharacterFromList();
    }
    
    void ShowCharacterFromList()
    {
        characters[currentCharacter].SetActive(true);
    }

    public void OnClickNext()
    {
        characters[currentCharacter].SetActive(false);
        if (currentCharacter < characters.Count - 1)
            currentCharacter = currentCharacter + 1;
        else 
            currentCharacter = 0;
        ShowCharacterFromList();
    }
    public void OnClickPrev()
    {
        characters[currentCharacter].SetActive(false);
        if (currentCharacter == 0)
            currentCharacter = characters.Count - 1;
        else
            currentCharacter = currentCharacter - 1;
        ShowCharacterFromList();
    }
}
