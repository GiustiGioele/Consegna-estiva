using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, PLAYERATK, ENEMYATK, WON, LOST }
public class BattleSystem2 : MonoBehaviour
{
    
    public TeamManager teamManager;

    public Transform[] playerBattleStation;
    public Transform[] enemyBattleStation;
    public List<GameObject> enemies;
    public List<GameObject> players;

    public Character playerBattle;
    public Character enemyBattle;

    public BattleSystemHP playerHP;
    public BattleSystemHP enemyHP;

    [SerializeField] LayerMask characterPlayer;
    [SerializeField] LayerMask characterEnemy;
    [SerializeField] Character characterSelected;

    public Attributes attribute;
    public GameObject HealthBarBack;
    public GameObject HealthBar;
    public BattleState state;
    bool isGoing = false;

    private void Start()                            
    {
        state = BattleState.START;
        SetupBattle();
       
    }

    private void Update()
    {
        if (state == BattleState.PLAYERTURN)
            PlayerTurn();
         if (state == BattleState.ENEMYATK)
            EnemyTurn();

      
    }


    public void SetupBattle()
   {
        teamManager = FindObjectOfType<TeamManager>();

        for (int i = 0; i < playerBattleStation.Length; i++)
        {
            GameObject go = Instantiate(teamManager.player[i], playerBattleStation[i]);
            playerBattle = go.GetComponent<Character>();
            players.Add(go);


            GameObject enemyGo = Instantiate(teamManager.enemy[i], enemyBattleStation[i]);
            enemyGo.layer = LayerMask.NameToLayer("characterEnemy");
            enemyBattle = enemyGo.GetComponent<Character>();
            enemies.Add(enemyGo);
        }
        //playerHP.SetHp(playerBattle);
        //enemyHP.SetHp(enemyBattle);

       

        state = BattleState.PLAYERTURN;
        
        
   }

    
        void EndBattle()
        {
            if (state == BattleState.WON)
            {
             
            }else if (state == BattleState.LOST)
            {

            }
        }




   public void  PlayerTurn()
   {
           
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterPlayer);   //Raycast che controlla se il personaggio ha il suo layer
                Debug.Log(hit.collider);

                 if (hit.collider != null)
                 {
                    var Character = hit.collider.GetComponent<Character>();
                    float normalizedcurrentHP = (float)Character.currentHP / Character.maxHP;
                    Debug.Log(Character.name);
                    HealthBarBack.SetActive(true);
                    HealthBar.fillAmount = normalizedcurrentHP;
                    //charcterSelected = Character;
                    //buttonPanel.SetActive(true);


                 }

           

            }
        
   }
    public void OnAttackButton()
    {
        Debug.Log("Attack");
        StartCoroutine(PlayerAtk());
        if (isGoing == true)
        {
            StopCoroutine(PlayerAtk());
        }
        
        
       
            
    }

    public IEnumerator PlayerAtk()
    {
        state = BattleState.PLAYERATK;
       
        while (!isGoing)
        {
            

            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit2D enemyHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterEnemy);
                Debug.Log(enemyHit.collider);

                if (characterSelected != null && enemyHit.collider != null)
                {
                   
                    enemyHit.collider.GetComponent<Character>().TakeDamage(characterSelected.damage, characterSelected.specialDamage, characterSelected.attribute);
                   
                    
                    var Character = enemyHit.collider.GetComponent<Character>();
                    float normalizedcurrentHP = (float)Character.currentHP / Character.maxHP;
                    state = BattleState.ENEMYATK;


                }
                isGoing = true;


                HealtBarBack.SetActive(true);
                HealthBar.fillAmount = normalizedcurrentHP;

            }

            yield return new WaitForSeconds(3f);
        }
        state = BattleState.ENEMYATK;
        Debug.Log("enemyTurn");
            StartCoroutine(EnemyTurn());
            StopCoroutine(EnemyTurn());
           
            
       

      

    }

   public IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);

      int enemyRandomIndex = Random.Range(0,enemies.Count);
      var enemy = enemies[enemyRandomIndex].GetComponent<Character>();
      Debug.Log("nemico : " + enemies[enemyRandomIndex].name);
      characterSelected = enemy;
     
      int playerRandomIndex = Random.Range(0, players.Count);
      var player = players[playerRandomIndex].GetComponent<Character>();
      Debug.Log("player : " + players[playerRandomIndex].name);
     
     player.TakeDamage(characterSelected.damage, characterSelected.specialDamage, characterSelected.attribute);
     float normalizedHealth = (float)player.currentHP / player.maxHP;


     state = BattleState.PLAYERTURN;

    }
        
}
