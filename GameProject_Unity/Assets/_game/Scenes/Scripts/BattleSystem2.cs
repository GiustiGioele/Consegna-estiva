using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, PLAYERATK, ENEMYTURN, ENEMYATK, WON, LOST }
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
   
    public BattleState state;

    private void Start()                            
    {
        state = BattleState.START;
        SetupBattle();
       
    }

    private void Update()
    {
        if (state == BattleState.PLAYERTURN)
            PlayerTurn();
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

    //IEnumerator PlayerAttack()
    //{
    //     enemyBattle.TakeDamage(playerBattle.damage, playerBattle.attribute);

    //   enemyHP.SetHP(enemyBattle.currentHP);          

    //    yield return new WaitForSeconds(1f);

    //    if (enemyBattle.currentHP <= 0)
    //    {
    //        state = BattleState.WON;
    //        EndBattle();
    //    }else
    //    {
    //        state = BattleState.ENEMYTURN;
    //        StartCoroutine(EnemyTurn());
    //    }

    //    IEnumerator EnemyTurn()
    //    {
    //        yield return new WaitForSeconds(1f);

    //        playerBattle.TakeDamage(enemyBattle.damage, enemyBattle.attribute);

    //        playerHP.SetHP(playerBattle.currentHP);

    //        yield return new WaitForSeconds(1f);

    //        if(playerBattle.currentHP <= 0)
    //        {
    //            state = BattleState.LOST;
    //            EndBattle();
    //        }
    //        else
    //        {
    //            state= BattleState.PLAYERTURN;
    //            PlayerTurn();
    //        }
    //    }

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
           //Debug.Log("1");
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterPlayer);   //Raycast che controlla se il personaggio ha il suo layer
                Debug.Log(hit.collider);

            if (hit.collider != null)
                {
                    var Character = hit.collider.GetComponent<Character>();
                    float normalizedcurrentHP = (float)Character.currentHP / Character.maxHP;
                    Debug.Log(Character.name);
                    //healthBarBackground.SetActive(true);
                    //healthBarPplayer.fillAmount = normalizedHealth
                    //charcterSelected = Character;
                    //buttonPanel.SetActive(true);


                }

           

            }
        
    }
    public void OnAttackButton()
    {
        Debug.Log("Attack");
        StartCoroutine(PlayerAtk());
        state = BattleState.PLAYERATK;
       
            
    }

    IEnumerator PlayerAtk()
    {
        state = BattleState.PLAYERATK;
        bool isGoing = false;
        while (!isGoing)
        {
            

            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit2D enemyHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterEnemy);
                //Debug.Log(enemyHit.collider);

                if (characterSelected != null && enemyHit.collider != null)
                {                  
                    enemyHit.collider.GetComponent<Character>().TakeDamage(characterSelected.damage,characterSelected.attribute);
                    Debug.Log("colpito");
                    state = BattleState.PLAYERTURN;
                    isGoing = true;
                   
                   
                }
                var Character = enemyHit.collider.GetComponent<Character>();
                //float normalizedcurrentHP = (float)Character.currentHP / Character.maxHP;
                //enemyHealtBarBackground.SetActive(true);
                //healthBarEnemy.fillAmount = normalizedcurrentHP;

            }
            yield return null;
        }

           if (enemyBattle.currentHP >= 0)
           {
            state = BattleState.ENEMYTURN;
            Debug.Log("enemyturn");
            EnemyTurn();
           }
            
        //else
        //    {
        //        state = BattleState.ENEMYTURN;
        //        EnemyTurn();
        //    }
        
        //state = BattleState.ENEMYTURN;
        
        //EnemyTurn();

      

    }

   public void EnemyTurn()
    {

      int enemyRandomIndex = Random.Range(0,enemies.Count);
      var enemy = enemies[enemyRandomIndex].GetComponent<Character>();
      Debug.Log("nemico : " + enemies[enemyRandomIndex].name);
     
      int playerRandomIndex = Random.Range(0, players.Count);
      var player = players[playerRandomIndex].GetComponent<Character>();
      Debug.Log("player : " + players[playerRandomIndex].name);
     


    }
        
}
