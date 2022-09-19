using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem2 : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    BattleSystem playerBattle;
    BattleSystem enemyBattle;

    public BattleSystemHP playerHP;
    public BattleSystemHP enemyHP;
 

  public BattleState state;

    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

   void SetupBattle ()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerBattle = playerGo.GetComponent<BattleSystem>();

       GameObject enemyGo =  Instantiate(enemyPrefab, enemyBattleStation);
        enemyBattle = enemyGo.GetComponent<BattleSystem>();

        playerHP.SetHp(playerBattle);
        enemyHP.SetHp(enemyBattle);
    }
}
