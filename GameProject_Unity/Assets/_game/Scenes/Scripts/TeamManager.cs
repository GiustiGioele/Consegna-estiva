using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
  public static TeamManager Instance;

    public List<GameObject> player;
    public List<GameObject> enemy;
    //public GameObject playerPrefab;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

     
    }
    public void SaveTeam(List<GameObject> player, List<GameObject> enemy)
    {
        this.player = new List<GameObject>(player);
        this.enemy = new List<GameObject>(enemy);

    }
}
