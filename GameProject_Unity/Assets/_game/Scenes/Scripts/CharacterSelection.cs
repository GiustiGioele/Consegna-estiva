using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelection : MonoBehaviour
{
    public Models[] Models;
    public Transform Spot;
    public Transform spotElement;
    public Transform[] characterPanel = new Transform[5];
    public int currentPanel = 0;
    public GameObject spriteIcon;
    public GameObject spriteElement;
    public int currentCharacter;
    public GameObject play;
    public List<GameObject> player;
    public List<GameObject> enemy;
    public GameObject playerPrefab;
    public List<GameObject> characters;
    public List<GameObject> playerPrefabs;
    
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
            player.Add(playerPrefabs[currentCharacter]);
        }

        if (currentPanel == 5)
        {
            play.SetActive(true);
            
        }

    }

    public void PlayButton()
    {
        if (currentPanel == 5)
        {
            play.SetActive(true);
            TeamManager.Instance.SaveTeam(player);
            SceneManager.LoadScene(1);
        }
    }
    public void RemoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Debug.Log("Remove");
            Destroy(spriteIcon);
            currentPanel = currentPanel - 1;
            
            if (currentPanel < 0)
            {
                currentPanel = 0;
            }
           


        }

    }
}
