using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem2 : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform[] playerBattleStation;
    public Transform[] enemyBattleStation;

    BattleSystem playerBattle;
    BattleSystem enemyBattle;

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
        for (int i = 0; i < playerBattleStation.Length; i++)
        {
            GameObject playerGo = Instantiate(playerPrefab, playerBattleStation[i]);
            playerBattle = playerGo.GetComponent<BattleSystem>();

            GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation[i]);
            enemyBattle = enemyGo.GetComponent<BattleSystem>();
        }
        playerHP.SetHp(playerBattle);
        enemyHP.SetHp(enemyBattle);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyBattle.TakeDamage(playerBattle.damage);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            //End the battle
        }else
        {
            //Enemy turn 23.01
        }

        
    }

   public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
    }
}
