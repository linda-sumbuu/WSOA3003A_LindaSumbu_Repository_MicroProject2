using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystemScript : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHUDScript playerHUD;
    public BattleHUDScript enemyHUD;

    public EnemyFancy enemy;

   // public CameraFancyStuff cameraB;

    public Text dialogue;

    UnitScript playerUnit;
    UnitScript enemyUnit;
    public BattleState state;
    void Start()
    {

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
       GameObject playerGameObject = Instantiate(playerObject, playerBattleStation);
       playerUnit = playerGameObject.GetComponent<UnitScript>();
       GameObject enemyGameObject = Instantiate(enemyObject, enemyBattleStation);
       enemyUnit = enemyGameObject.GetComponent<UnitScript>();

        dialogue.text = "Oh no! You bumped into an angry " + enemyUnit.unitName + "! Time to fight!";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;

        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogue.text = "Pick a move!:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        
        dialogue.text = "Successful Attack >:D";
        StartCoroutine(enemy.Shake(.15f, .4f));
        yield return new WaitForSeconds(2f);

        

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

               
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogue.text = "HP Boost!<3";

         yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;

        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);

        dialogue.text = enemyUnit.unitName + " attacks!";
        StartCoroutine(enemy.Shake(.15f, .4f));
        yield return new WaitForSeconds(1f);

       
        //cameraB.shouldShake = true;
        
        

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }

        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();

        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogue.text = "You have defeated the enemy!:D";
        }
        else if(state == BattleState.LOST)
        {
            dialogue.text = "You have been defeated :(";
        }
        
    }
}
