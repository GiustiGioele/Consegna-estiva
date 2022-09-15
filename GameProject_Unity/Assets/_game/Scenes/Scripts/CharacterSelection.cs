using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Models[] Models;
    public Transform Spot;
    public Transform[] characterPanel = new Transform[5];
    public int currentPanel = 0;
    public GameObject spriteIcon;
    public int currentCharacter;
    public GameObject play;

    private List<GameObject> characters;
    
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

    private void Update()
    {
        RemoveSelection();
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

    public void OnClickSelect()
    {
        if (characterPanel != null)
        {
          spriteIcon = Instantiate(characters[currentCharacter], characterPanel[currentPanel].position, Quaternion.identity);
            currentPanel++;
        }

        if (currentPanel == 5)
        {
            play.SetActive(true);
        }


    }
    public void RemoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
            

            Debug.Log("Remove");
            Destroy(spriteIcon);
            currentPanel = currentPanel - 1;
            
            if (currentPanel < 0)
            {
                currentPanel = 0;
            }
           


        }

    }
}
