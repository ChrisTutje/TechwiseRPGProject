using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, VICTORY, DEFEAT } //list of phases

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

   
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() { //co-routine for the START phase
       GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
       playerUnit = playerGO.GetComponent<Unit>();

       GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
       enemyUnit = enemyGO.GetComponent<Unit>();

      dialogueText.text = "A hostile " + enemyUnit.unitName + " challenges you!";

      playerHUD.setHUD(playerUnit);
      enemyHUD.setHUD(enemyUnit);

      yield return new WaitForSeconds(2f); // the setUp phase waits for 2 seconds 

      state = BattleState.PLAYERTURN;
      PlayerTurn();
    }

    IEnumerator PlayerAttack() { //Logic for the fight action
       bool isDead = enemyUnit.TakeDamage(playerUnit.attack);

       enemyHUD.SetHP(enemyUnit.currentHp);
       dialogueText.text = "POW! " + enemyUnit.unitName + " takes " + playerUnit.attack + " damage!" ;

        yield return new WaitForSeconds(2f);

        if(isDead) {
            state = BattleState.VICTORY;
            EndBattle();
        } else{
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn() {
        dialogueText.text = enemyUnit.unitName + " attacks " + playerUnit.unitName + "! \n" + playerUnit.unitName + " takes " + enemyUnit.attack + " damage!";
        

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.attack);

        playerHUD.SetHP(playerUnit.currentHp);

        yield return new WaitForSeconds(1f);

        if(isDead) {
            state = BattleState.DEFEAT;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle() {
        if(state == BattleState.VICTORY) {
            dialogueText.text = "Conglaturations! You are winner!!!";
        } else if (state == BattleState.DEFEAT){
            dialogueText.text = "Get gud, skrub.";
        }
    }

    void PlayerTurn() { //function for the PlayerTurn phase
    dialogueText.text = "How will " +  playerUnit.unitName + " respond?" ;
    }

    public void OnAttackButton(){
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());

    }

  
}
