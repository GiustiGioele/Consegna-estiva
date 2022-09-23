using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem2 : MonoBehaviour
{
    
    public TeamManager teamManager;

   

    public Transform[] playerBattleStation;
    public Transform[] enemyBattleStation;

    public Character playerBattle;
    public Character enemyBattle;

    public BattleSystemHP playerHP;
    public BattleSystemHP enemyHP;
 

  public BattleState state;

    private void Start()                            
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
       
    }

   IEnumerator SetupBattle ()
    {
        teamManager = FindObjectOfType<TeamManager>();

        for (int i = 0; i < playerBattleStation.Length; i++)
        {
            GameObject go = Instantiate(teamManager.player[i], playerBattleStation[i].position, Quaternion.identity);
           playerBattle = go.GetComponent<Character>();

            GameObject enemyGo = Instantiate(teamManager.enemy[i], enemyBattleStation[i].position, Quaternion.identity);
            enemyBattle = enemyGo.GetComponent<Character> ();
        }
        //playerHP.SetHp(playerBattle);
        //enemyHP.SetHp(enemyBattle);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyBattle.TakeDamage(playerBattle.damage);

       enemyHP.SetHP(enemyBattle.currentHP);          

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        IEnumerator EnemyTurn()
        {
            yield return new WaitForSeconds(1f);

          bool isDead =  playerBattle.TakeDamage(enemyBattle.damage);

            playerHP.SetHP(playerBattle.currentHP);

            yield return new WaitForSeconds(1f);

            if(isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state= BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }

        void EndBattle()
        {
            if (state == BattleState.WON)
            {

            }else if (state == BattleState.LOST)
            {

            }
        }

        void PlayerTurn()
        {

        }
        
    }

   public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
    }
}
