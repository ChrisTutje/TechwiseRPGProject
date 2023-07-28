using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, VICTORY, DEFEAT, /*FLEE*/ } //list of phases

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

    public AudioSource battleTheme;
    public AudioSource victoryFanfare;
   
    

   
    void Start()
    {
        state = BattleState.START;
        battleTheme.Play();
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
       int damageToEnemy = playerUnit.attack - enemyUnit.defence;
       bool isDead = enemyUnit.TakeDamage(damageToEnemy);

       enemyHUD.SetHP(enemyUnit.currentHp);
       dialogueText.text = "POW! \n" + enemyUnit.unitName + " takes " + playerUnit.attack + " damage!" ;

        yield return new WaitForSeconds(2f);

        if(isDead) { 
            state = BattleState.VICTORY;
            EndBattle();
        } else{
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        playerHUD.SetStamina(playerUnit.currentStamina); //used to decrement the player's stamina each attack
    }

    IEnumerator EnemyTurn() {
        dialogueText.text = enemyUnit.unitName + " attacks " + playerUnit.unitName + "! \n" + playerUnit.unitName + " takes " + enemyUnit.attack + " damage!";
        

        yield return new WaitForSeconds(1f);
        int damageToPlayer =  enemyUnit.attack - playerUnit.defence;
        bool isDead = playerUnit.TakeDamage(damageToPlayer);

        playerHUD.SetHP(playerUnit.currentHp);

        yield return new WaitForSeconds(1f);

        if(isDead) {
            state = BattleState.DEFEAT;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

        enemyHUD.SetStamina(enemyUnit.currentStamina); //used to decrement the enemy's stamina per attack 
    }

    void EndBattle() {
        if(state == BattleState.VICTORY) {
            playerUnit.currentExp += enemyUnit.expDrop; //gain EXP 
            dialogueText.text = "Conglaturations! You are winner!!! \n You gained " + enemyUnit.expDrop + " experience points!";
            battleTheme.Stop();
            victoryFanfare.Play(); //switch to the victory fanfare
        } else if (state == BattleState.DEFEAT){
            battleTheme.Stop(); //switch to the game over music
            //gameoverTheme.stop(); //yet to be implemented 
            dialogueText.text = "Get gud, skrub.";
        }
    }

    public int roundCounter = 1;

    void PlayerTurn() { //function for the PlayerTurn phase
    dialogueText.text = "Round " + roundCounter +  ": \n How will " +  playerUnit.unitName + " respond?" ;
    roundCounter += 1; //used to increment the round counter
    }

    IEnumerator PlayerHeal() { //healing action
        int hpRecovery = 8; //how much action heals by
        playerUnit.Heal(hpRecovery);

        playerHUD.SetHP(playerUnit.currentHp);
        dialogueText.text = playerUnit.unitName + " regained " + hpRecovery  + " hit points.";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

       IEnumerator PlayerBlock() { //blocking action
        playerUnit.Block();

        dialogueText.text = playerUnit.unitName + " defends!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton(){
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());

    }

     public void OnHealButton(){
       if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerHeal());
    }

    public void OnBlockButton(){
       if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerBlock());
    }

  
}
