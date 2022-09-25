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

            GameObject enemyGo = Instantiate(teamManager.enemy[i], enemyBattleStation[i]);
            enemyGo.layer = LayerMask.NameToLayer("characterEnemy");
            //enemyBattle = enemyGo.GetComponent<Character>();
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
     
           Debug.Log("1");


            if (Input.GetKey(KeyCode.Mouse1))
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterPlayer);   //Raycast che controlla se il personaggio ha il suo layer
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
        if (state != BattleState.PLAYERTURN)
            StartCoroutine(PlayerAtk());
        Debug.Log("Attack");
            return;
    }

    IEnumerator PlayerAtk()
    {
        state = BattleState.PLAYERATK;
        bool isGoing = false;
        while (!isGoing)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                RaycastHit2D enemyHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, characterEnemy);

                if (characterSelected != null && enemyHit.collider != null)
                {
                    enemyHit.collider.GetComponent<Character>();
                    state = BattleState.PLAYERTURN;
                    isGoing = true;
                }
                var Character = enemyHit.collider.GetComponent<Character>();
                float normalizedcurrentHP = (float)Character.currentHP / Character.maxHP;
                //enemyHealtBarBackground.SetActive(true);
                //healthBarEnemy.fillAmount = normalizedcurrentHP;

            }
            yield return null;
        }

        state = BattleState.ENEMYTURN;
        EnemyTurn();
               
    }

    void EnemyTurn()
    {

      


    }
        
}
